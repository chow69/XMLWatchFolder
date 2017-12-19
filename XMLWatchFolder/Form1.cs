using System;
using System.IO;
using System.Collections.Generic;
using System.Xml;
using System.Windows.Forms;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace XMLWatchFolder
{
    public partial class frmXmlWatch : Form
    {
        public delegate void UpdateXMLtoTextbox(string message);

        public const string cSuccess = "success";
        public const string cError = "error";
        public const string cLog = "log";
        public const string cOutput = "output";
        public const string cJobXSD = "job.xsd";

        private bool blnIsWatching;
        private string strExePath;
        private string strWatchFolder;

        public frmXmlWatch()
        {
            InitializeComponent();
            tipWatch.SetToolTip(btnFolder, "Select Folder");
            tipPDF.SetToolTip(btnPDFFolder, "Select Output");
            btnStartStop.Text = "&Start";
            blnIsWatching = false;
            strExePath = Application.StartupPath;
        }

        private void btnFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = fldDialogWatch.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtWatchFolder.Text = fldDialogWatch.SelectedPath;
            }

            else if (result == DialogResult.Cancel)
            {
                return;
            }

        }

        private void btnStartStop_Click(object sender, EventArgs e)
        {
            string path = txtWatchFolder.Text.Trim();
            string message = "";
            string caption = "Error";
            MessageBoxButtons buttons = MessageBoxButtons.OK;

            if (blnIsWatching)
            {
                blnIsWatching = false;
                fswWatch.EnableRaisingEvents = false;
                fswWatch.Dispose();
                btnStartStop.Text = "&Start";
                updateLog("Watched stop!");
                lblStatus.Text = "Watch folder is STOP. Click [Start] to watch folder...";
            }
            else
            {

                if (path == "")
                {
                    message = "Please select a watch folder.";
                    MessageBox.Show(message, caption, buttons);
                }
                else
                {
                    if (Directory.Exists(path))
                    {
                        // initialise
                        blnIsWatching = true;
                        btnStartStop.Text = "&Stop";
                        txtNotification.Text = "XML Watcher started...";
                        lblStatus.Text = "Watch has STARTED! :)";

                        //watch
                        strWatchFolder = path;
                        fswWatch = new System.IO.FileSystemWatcher();
                        fswWatch.Path = path + "\\";
                        // Only watch xml files
                        fswWatch.Filter = "*.xml";
                        fswWatch.IncludeSubdirectories = false;

                        // Add event handlers.
                        fswWatch.Created += new FileSystemEventHandler(watcher_FileCreated);
                        fswWatch.EnableRaisingEvents = true;
                    }
                    else
                    {
                        message = String.Format("{0} is not a valid file or directory.", path);
                        MessageBox.Show(message, caption, buttons);
                    }
                }
            }
        }

        // Define the event handlers.
        private void watcher_FileCreated(object source, FileSystemEventArgs e)
        {
            // Specify what is done when a file is created
            string file = e.FullPath;
            txtNotification.BeginInvoke(new UpdateXMLtoTextbox(StartProcessXML), new object[] { file });
        }

        void StartProcessXML(string xmlfile)
        {
            //update notification textbox
            string filename = Path.GetFileName(xmlfile);
            DateTime currentDate = DateTime.Now;
            updateLog(filename + " -- " + currentDate.ToLocalTime());

            string message = "";
            string caption = "Error";
            MessageBoxButtons buttons = MessageBoxButtons.OK;

            bool blnXmlIsValid = false;

            string OutputPath = txtOutPDFFolder.Text.Trim();
            if (OutputPath == "")
            {
                OutputPath = strWatchFolder + "\\" + cOutput + "\\";
            }
            else
            {
                OutputPath += "\\";
                if (!Directory.Exists(OutputPath))
                {
                    OutputPath = strWatchFolder + "\\" + cOutput + "\\";
                }
            }
            
            //validate xml
            try
            {
                XmlReaderSettings settings = new XmlReaderSettings();
                settings.Schemas.Add(null, cJobXSD);
                settings.ValidationType = ValidationType.Schema;

                using (XmlReader reader = XmlReader.Create(xmlfile, settings))
                {
                    XmlDocument document = new XmlDocument();
                    document.Load(reader);

                    PDFJob job = new PDFJob();
                    XmlNode jobNode = document.SelectSingleNode("job");

                    job.id = jobNode.Attributes["id"].Value;
                    job.orderid = jobNode["orderid"].InnerText;
                    job.sku = jobNode["sku"].InnerText;

                    XmlNode pagesize = jobNode["pagesize"];
                    job.pgunit = pagesize["unit"].InnerText;
                    job.fpgwidth = float.Parse(pagesize["width"].InnerText);
                    job.fpgheight = float.Parse(pagesize["height"].InnerText);
                    job.fpgbleed = float.Parse(pagesize["bleed"].InnerText);

                    XmlNode pages = jobNode["pages"];
                    job.imgfld = pages.Attributes["imgfld"].Value;
                    //check if image folder exist
                    if (!Directory.Exists(job.imgfld))
                    {
                        updateLog(job.imgfld + " folder does not exist!");
                        blnXmlIsValid = false;
                        goto outer;
                    }

                    List<string> pgimg = new List<string>();
                    foreach (XmlNode page in pages.ChildNodes)
                    {
                        string strImg = page.Attributes["img"].Value;
                        string strJpeg = job.imgfld + "\\" + strImg;
                        // check file exist
                        if (!File.Exists(strJpeg))
                        {
                            updateLog(strJpeg + " image file does not exist!");
                            blnXmlIsValid = false;
                            goto outer;
                        }
                        pgimg.Add(strJpeg);
                    }
                    job.pgimg = new List<string>(pgimg);

                    createPDF(job, OutputPath);
                }

                // everything is ok
                blnXmlIsValid = true;
            }
            catch (Exception ex)
            {
                message = ex.Message;
                MessageBox.Show(message, caption, buttons);
                blnXmlIsValid = false;
            }

            outer:
            // once done, move to success directory
            string donePath = "";
            if (blnXmlIsValid)
            {
                donePath = strWatchFolder + "\\" + cSuccess + "\\";
                updateLog("OK: " + filename);
            }
            else
            {
                donePath = strWatchFolder + "\\" + cError + "\\";
                updateLog("ERROR: " + filename);
            }
            //check first
            if (!Directory.Exists(donePath))
            {
                Directory.CreateDirectory(donePath);
            }

            string sourceFile = xmlfile;
            string destinationFile = donePath + filename;
            try
            {
                // To move a file or folder to a new location
                File.Move(sourceFile, destinationFile);
            }
            catch (Exception e)
            {
                if (e is IOException)
                {
                    File.Copy(sourceFile, destinationFile, true);
                    File.Delete(sourceFile);
                }
                else
                {
                    // do nothing 
                }
            }

        }

        private void createPDF(PDFJob job, string outFld)
        {
            if (!Directory.Exists(outFld))
            {
                Directory.CreateDirectory(outFld);
            }
            DateTime currentDate = DateTime.Now;
            string strNow = currentDate.ToString("yyyyMMddHHmmssffff", System.Globalization.CultureInfo.GetCultureInfo("en-US"));
            string strPDFFilename = strNow + "_" + job.orderid + "_" + job.id + "_" + job.sku + ".pdf";
            string strOutputPDF = outFld + strPDFFilename;

            FileStream fs = new FileStream(strOutputPDF, FileMode.Create);
            switch (job.pgunit)
            {
                case "mm":
                    job.fpgwidth = Utilities.MillimetersToPoints(job.fpgwidth);
                    job.fpgheight = Utilities.MillimetersToPoints(job.fpgheight);
                    job.fpgbleed = Utilities.MillimetersToPoints(job.fpgbleed);
                    break;
                case "in":
                    job.fpgwidth = job.fpgwidth * 72;
                    job.fpgheight = job.fpgheight * 72;
                    job.fpgbleed = job.fpgbleed * 72;
                    break;
                default:
                    break;
            }

            // pgsz is mediabox
            Rectangle pgsz = new Rectangle(job.fpgwidth + (2 * job.fpgbleed), job.fpgheight + (2 * job.fpgbleed));
            // trbx = trimbox i.e. actual pagesize
            Rectangle trbx = new Rectangle(job.fpgbleed, job.fpgbleed, job.fpgwidth + job.fpgbleed, job.fpgheight + job.fpgbleed);
            // blbx = bleedbox i.e. setting to be the mediabox 
            Rectangle blbx = new Rectangle(0, 0, job.fpgwidth + (2 * job.fpgbleed), job.fpgheight + (2 * job.fpgbleed));

            Document doc = new Document(pgsz);
            PdfWriter writer = PdfWriter.GetInstance(doc, fs);
            writer.SetBoxSize("bleed", blbx);
            writer.SetBoxSize("trim", trbx);
            // Open the document to enable you to write to the document
            doc.Open();
            foreach (string strImg in job.pgimg)
            {
                Image imgPage = Image.GetInstance(strImg);
                imgPage.Alignment = Element.ALIGN_CENTER;
                imgPage.ScaleToFit(job.fpgwidth + (2 * job.fpgbleed), job.fpgheight + (2 * job.fpgbleed));
                imgPage.SetAbsolutePosition(0, 0);
                doc.Add(imgPage);

                doc.NewPage();
            }

            // Close the document
            doc.Close();
            // Close the writer instance
            writer.Close();
            // Always close open filehandles explicity
            fs.Close();
        }

        class PDFJob
        {
            public string id;
            public string orderid;
            public string sku;
            public string imgfld;
            public string pgunit;
            public float fpgwidth;
            public float fpgheight;
            public float fpgbleed;
            public List<string> pgimg;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            if (blnIsWatching)
            {
                blnIsWatching = false;
                fswWatch.EnableRaisingEvents = false;
                fswWatch.Dispose();
            }
            Application.Exit();
        }

        private void btnSaveLog_Click(object sender, EventArgs e)
        {
            string logPath = strExePath + "\\" + cLog + "\\";

            //check first
            if (!Directory.Exists(logPath))
            {
                Directory.CreateDirectory(logPath);
            }

            DateTime currentDate = DateTime.Now;
            string destinationFile = logPath + "log" + currentDate.ToString("yyyyMMddHHmmssffff", System.Globalization.CultureInfo.GetCultureInfo("en-US")) + ".txt";
            TextWriter txt = new StreamWriter(destinationFile);
            txt.Write(txtNotification.Text);
            txt.Close();

            string message = "Log is saved to " + destinationFile;
            string caption = "Info";
            MessageBoxButtons buttons = MessageBoxButtons.OK;
            MessageBox.Show(message, caption, buttons);

        }

        private void btnPDFFolder_Click(object sender, EventArgs e)
        {
            DialogResult result = fldDialogPDF.ShowDialog();

            if (result == DialogResult.OK)
            {
                txtOutPDFFolder.Text = fldDialogPDF.SelectedPath;
            }

            else if (result == DialogResult.Cancel)
            {
                return;
            }

        }

        private void updateLog(string sMessage)
        {
            txtNotification.Text += "\r\n" + sMessage;
            txtNotification.Update();
            txtNotification.SelectionStart = txtNotification.Text.Length;
            txtNotification.ScrollToCaret();
        }

    }
}
