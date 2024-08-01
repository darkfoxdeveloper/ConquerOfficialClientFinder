using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Threading;
using System.Windows.Forms;

namespace ConquerOfficialClientFinder
{
    public partial class Form1 : Form
    {
        private uint VersionCounter = 0;
        private bool FindClientsActived = false;
        private bool FindPatchesActived = false;
        private List<COCFConfig> Configs = new List<COCFConfig>();
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
            btnStopSearching.Enabled = true;
        }

        private void FindClients(DoWorkEventArgs workerEventArgs)
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
                if (worker.CancellationPending)
                {
                    workerEventArgs.Cancel = true;
                    canExit = true;
                }
                bool ValidDownload = ExistClientFile(VersionCounter);
                this.Invoke(new MethodInvoker(delegate {
                    Text = $"ConquerOfficialClientFinder - Searching clients (V{VersionCounter}/V{LimitVersion})";
                }));

                if (ValidDownload)
                {
                    this.Invoke(new MethodInvoker(delegate {
                        lstBoxClients.Items.Add(Configs.FirstOrDefault().ClientMirrorURI.Replace("#CO_VERSION#", VersionCounter.ToString()));
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

        private void FindPatches(DoWorkEventArgs workerEventArgs)
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
                if (worker.CancellationPending)
                {
                    workerEventArgs.Cancel = true;
                    canExit = true;
                }
                bool ValidDownload = ExistPatchFile(VersionCounter);
                this.Invoke(new MethodInvoker(delegate {
                    Text = $"ConquerOfficialClientFinder - Searching patches (V{VersionCounter}/V{LimitVersion})";
                }));

                if (ValidDownload)
                {
                    this.Invoke(new MethodInvoker(delegate {
                        lstBoxClients.Items.Add(Configs.FirstOrDefault().PatchMirrorURI.Replace("#CO_VERSION#", VersionCounter.ToString()));
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
            string searchUrl = Configs.FirstOrDefault().ClientMirrorURI.Replace("#CO_VERSION#", VersionForSearch.ToString());
            bool ValidDownload = RemoteFileExists(searchUrl);
            return ValidDownload;
        }

        public bool ExistPatchFile(uint VersionForSearch)
        {
            string searchUrl = Configs.FirstOrDefault().PatchMirrorURI.Replace("#CO_VERSION#", VersionForSearch.ToString());
            bool ValidDownload = RemoteFileExists(searchUrl);
            return ValidDownload;
        }

        private void Worker_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            if (FindClientsActived)
            {
                FindClients(e);
            }
            if (FindPatchesActived)
            {
                FindPatches(e);
            }
            this.Invoke(new MethodInvoker(delegate {
                btnFind.Enabled = true;
                btnFindPatches.Enabled = true;
            }));
        }

        private void BtnDownload_Click(object sender, EventArgs e)
        {
            if (!worker.IsBusy)
            {
                if (lstBoxClients.Items.Count > 0)
                {
                    pBarProgress.Value = 0;
                    pBarProgress.Visible = true;
                    downloadWorker.RunWorkerAsync();
                } else
                {
                    MessageBox.Show("No items selected in list for download", "ConquerOfficialClientFinder", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                }
            } else
            {
                MessageBox.Show("Wait for finish search or force stop with the Button", "ConquerOfficialClientFinder", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
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
            btnStopSearching.Enabled = true;
        }

        private void BtnStopSearching_Click(object sender, EventArgs e)
        {
            if (worker.IsBusy)
            {
                worker.CancelAsync();
                btnDownload.Enabled = true;
                btnStopSearching.Enabled = true;
                btnFind.Enabled = true;
                btnFindPatches.Enabled = true;
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            if (!File.Exists("COCLConfig.json"))
            {
                Configs = new List<COCFConfig>
                {
                    new COCFConfig() { ClientMirrorURI = "http://conquer.download.99.com/en_zf/Conquer_v#CO_VERSION#.exe", PatchMirrorURI = "http://copatch.99.com/enzf/enco_#CO_VERSION#.exe" }
                };
                File.WriteAllText("COCLConfig.json", Newtonsoft.Json.JsonConvert.SerializeObject(Configs));
            }
            Configs = Newtonsoft.Json.JsonConvert.DeserializeObject<List<COCFConfig>>(File.ReadAllText("COCLConfig.json"));
            if (Configs.FirstOrDefault() != null)
            {
                rtboxAbout.Text += Environment.NewLine + $"Loaded mirror for clients: {Configs.FirstOrDefault().ClientMirrorURI.Replace("#CO_VERSION", "0000")}";
                rtboxAbout.Text += Environment.NewLine + $"Loaded mirror for patches: {Configs.FirstOrDefault().PatchMirrorURI.Replace("#CO_VERSION", "0000")}";
            } else
            {
                rtboxAbout.Text += Environment.NewLine + $"Invalid mirrors detected.";
            }
        }
    }
}
