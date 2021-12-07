using System;
using System.Net;
using System.Windows.Forms;
using System.Linq;
using System.IO;
using System.Threading;
using System.ComponentModel;

namespace ConquerOfficialClientFinder
{
    public partial class Form1 : Form
    {
        private uint VersionCounter = 0;
        private bool FindClientsActived = false;
        private bool FindPatchesActived = false;
        public Form1()
        {
            InitializeComponent();
        }

        private void BtnFind_Click(object sender, EventArgs e)
        {
            FindClientsActived = true;
            FindPatchesActived = false;
            worker.RunWorkerAsync();
            btnFindPatches.Enabled = false;
            (sender as Control).Enabled = false;
            btnDownload.Enabled = true;
        }

        private void FindClients()
        {
            this.Invoke(new MethodInvoker(delegate {
                lstBoxClients.Items.Clear();
                Text = $"ConquerOfficialClientFinder - Searching Clients...";
            }));
            uint FirstVersion = uint.Parse(tbxStartVersion.Text);
            VersionCounter = FirstVersion;
            uint LimitVersion = uint.Parse(tbxLimitVersion.Text);
            bool canExit = false;

            while (!canExit)
            {
                bool ValidDownload = ExistClientFile(VersionCounter);
                this.Invoke(new MethodInvoker(delegate {
                    Text = $"ConquerOfficialClientFinder - Searching clients (V{VersionCounter}/V{LimitVersion})";
                }));

                if (ValidDownload)
                {
                    this.Invoke(new MethodInvoker(delegate {
                        lstBoxClients.Items.Add("http://conquer.download.99.com/en_zf/Conquer_v" + VersionCounter + ".exe");
                    }));
                }

                if (VersionCounter > LimitVersion)
                {
                    canExit = true;
                    this.Invoke(new MethodInvoker(delegate {
                        Text = $"ConquerOfficialClientFinder - Found: " + lstBoxClients.Items.Count + " Clients";
                    }));
                }
                VersionCounter++;
            }
        }

        private void FindPatches()
        {
            this.Invoke(new MethodInvoker(delegate {
                lstBoxClients.Items.Clear();
                Text = $"ConquerOfficialClientFinder - Searching Patches...";
            }));
            uint FirstVersion = uint.Parse(tbxStartVersion.Text);
            VersionCounter = FirstVersion;
            uint LimitVersion = uint.Parse(tbxLimitVersion.Text);
            bool canExit = false;

            while (!canExit)
            {
                bool ValidDownload = ExistClientFile(VersionCounter);
                this.Invoke(new MethodInvoker(delegate {
                    Text = $"ConquerOfficialClientFinder - Searching patches (V{VersionCounter}/V{LimitVersion})";
                }));

                if (ValidDownload)
                {
                    this.Invoke(new MethodInvoker(delegate {
                        lstBoxClients.Items.Add("http://copatch.99.com/enzf/enco_" + VersionCounter + ".exe");
                    }));
                }

                if (VersionCounter > LimitVersion)
                {
                    canExit = true;
                    this.Invoke(new MethodInvoker(delegate {
                        Text = $"ConquerOfficialClientFinder - Found: " + lstBoxClients.Items.Count + " Patches";
                    }));
                }
                VersionCounter++;
            }
        }

        private bool RemoteFileExists(string url)
        {
            try
            {
                //Creating the HttpWebRequest
                HttpWebRequest request = WebRequest.Create(url) as HttpWebRequest;
                //Setting the Request method HEAD, you can also use GET too.
                request.Method = "HEAD";
                //Getting the Web Response.
                HttpWebResponse response = request.GetResponse() as HttpWebResponse;
                //Returns TRUE if the Status code == 200
                response.Close();
                return (response.StatusCode == HttpStatusCode.OK);
            }
            catch
            {
                //Any exception will returns false.
                return false;
            }
        }

        public bool ExistClientFile(uint VersionForSearch)
        {
            string searchUrl = $"http://conquer.download.99.com/en_zf/Conquer_v" + VersionForSearch + ".exe";
            bool ValidDownload = RemoteFileExists(searchUrl);
            return ValidDownload;
        }

        public bool ExistPatchFile(uint VersionForSearch)
        {
            string searchUrl = $"http://copatch.99.com/enzf/enco_" + VersionForSearch + ".exe";
            bool ValidDownload = RemoteFileExists(searchUrl);
            return ValidDownload;
        }

        private void Worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (FindClientsActived)
            {
                FindClients();
            }
            if (FindPatchesActived)
            {
                FindPatches();
            }
        }

        private void BtnDownload_Click(object sender, EventArgs e)
        {
            pBarProgress.Value = 0;
            pBarProgress.Visible = true;
            downloadWorker.RunWorkerAsync();
        }

        private void DownloadClientFile(string URI)
        {
            Thread thread = new Thread(() => {
                WebClient client = new WebClient();
                client.DownloadProgressChanged += new DownloadProgressChangedEventHandler(Client_DownloadProgressChanged);
                client.DownloadFileCompleted += Client_DownloadFileCompleted;
                string targetFilename = Path.GetFileName(URI);
                client.DownloadFileAsync(new Uri(URI), targetFilename);
            });
            thread.Start();
        }

        private void Client_DownloadFileCompleted(object sender, AsyncCompletedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                pBarProgress.Value = 100;
                pBarProgress.Visible = false;
                MessageBox.Show("Client Downloaded Successfully!", "Download Completed", MessageBoxButtons.OK, MessageBoxIcon.Information);
            });
        }

        private void Client_DownloadProgressChanged(object sender, DownloadProgressChangedEventArgs e)
        {
            this.BeginInvoke((MethodInvoker)delegate {
                double bytesIn = double.Parse(e.BytesReceived.ToString());
                double totalBytes = double.Parse(e.TotalBytesToReceive.ToString());
                double percentage = bytesIn / totalBytes * 100;
                pBarProgress.Value = int.Parse(Math.Truncate(percentage).ToString());
            });
        }

        private void DownloadWorker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            string URI = "";
            this.Invoke(new MethodInvoker(delegate {
                if (lstBoxClients.SelectedItem == null) return;
                URI = lstBoxClients.SelectedItem.ToString();
            }));
            if (URI.Length > 0) DownloadClientFile(URI);
        }

        private void LstBoxClients_SelectedIndexChanged(object sender, EventArgs e)
        {
            btnDownload.Enabled = true;
        }

        private void BtnFindPatches_Click(object sender, EventArgs e)
        {
            FindClientsActived = false;
            FindPatchesActived = true;
            worker.RunWorkerAsync();
            btnFind.Enabled = false;
            (sender as Control).Enabled = false;
            btnDownload.Enabled = true;
        }
    }
}
