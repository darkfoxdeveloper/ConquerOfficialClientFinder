
namespace ConquerOfficialClientFinder
{
    partial class Form1
    {
        /// <summary>
        /// Variable del diseñador necesaria.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Limpiar los recursos que se estén usando.
        /// </summary>
        /// <param name="disposing">true si los recursos administrados se deben desechar; false en caso contrario.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Código generado por el Diseñador de Windows Forms

        /// <summary>
        /// Método necesario para admitir el Diseñador. No se puede modificar
        /// el contenido de este método con el editor de código.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnFind = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.lstBoxClients = new ComponentFactory.Krypton.Toolkit.KryptonListBox();
            this.tbxLimitVersion = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.tbxStartVersion = new ComponentFactory.Krypton.Toolkit.KryptonTextBox();
            this.worker = new System.ComponentModel.BackgroundWorker();
            this.pBarProgress = new System.Windows.Forms.ProgressBar();
            this.btnDownload = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            this.downloadWorker = new System.ComponentModel.BackgroundWorker();
            this.lblFrom = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.lblTo = new ComponentFactory.Krypton.Toolkit.KryptonLabel();
            this.pboxAboutImage = new System.Windows.Forms.PictureBox();
            this.rtboxAbout = new ComponentFactory.Krypton.Toolkit.KryptonRichTextBox();
            this.btnFindPatches = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.pboxAboutImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(268, 520);
            this.btnFind.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(461, 54);
            this.btnFind.TabIndex = 0;
            this.btnFind.Values.Text = "Find Clients";
            this.btnFind.Click += new System.EventHandler(this.BtnFind_Click);
            // 
            // lstBoxClients
            // 
            this.lstBoxClients.Location = new System.Drawing.Point(16, 15);
            this.lstBoxClients.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lstBoxClients.Name = "lstBoxClients";
            this.lstBoxClients.Size = new System.Drawing.Size(1172, 431);
            this.lstBoxClients.TabIndex = 1;
            this.lstBoxClients.SelectedIndexChanged += new System.EventHandler(this.LstBoxClients_SelectedIndexChanged);
            // 
            // tbxLimitVersion
            // 
            this.tbxLimitVersion.Location = new System.Drawing.Point(108, 581);
            this.tbxLimitVersion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxLimitVersion.Name = "tbxLimitVersion";
            this.tbxLimitVersion.Size = new System.Drawing.Size(137, 32);
            this.tbxLimitVersion.TabIndex = 2;
            this.tbxLimitVersion.Text = "8000";
            this.tbxLimitVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxStartVersion
            // 
            this.tbxStartVersion.Location = new System.Drawing.Point(108, 534);
            this.tbxStartVersion.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.tbxStartVersion.Name = "tbxStartVersion";
            this.tbxStartVersion.Size = new System.Drawing.Size(137, 32);
            this.tbxStartVersion.TabIndex = 3;
            this.tbxStartVersion.Text = "4200";
            this.tbxStartVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // worker
            // 
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Worker_DoWork);
            // 
            // pBarProgress
            // 
            this.pBarProgress.Location = new System.Drawing.Point(16, 460);
            this.pBarProgress.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pBarProgress.Name = "pBarProgress";
            this.pBarProgress.Size = new System.Drawing.Size(1172, 48);
            this.pBarProgress.TabIndex = 4;
            this.pBarProgress.Visible = false;
            // 
            // btnDownload
            // 
            this.btnDownload.Enabled = false;
            this.btnDownload.Location = new System.Drawing.Point(737, 520);
            this.btnDownload.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(451, 115);
            this.btnDownload.TabIndex = 5;
            this.btnDownload.Values.Text = "Download Selected";
            this.btnDownload.Click += new System.EventHandler(this.BtnDownload_Click);
            // 
            // downloadWorker
            // 
            this.downloadWorker.WorkerReportsProgress = true;
            this.downloadWorker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.DownloadWorker_DoWork);
            // 
            // lblFrom
            // 
            this.lblFrom.Location = new System.Drawing.Point(16, 538);
            this.lblFrom.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(63, 29);
            this.lblFrom.TabIndex = 6;
            this.lblFrom.Values.Text = "FROM";
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(52, 585);
            this.lblTo.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(36, 29);
            this.lblTo.TabIndex = 7;
            this.lblTo.Values.Text = "TO";
            // 
            // pboxAboutImage
            // 
            this.pboxAboutImage.Image = global::ConquerOfficialClientFinder.Properties.Resources.foxlogo;
            this.pboxAboutImage.Location = new System.Drawing.Point(1196, 15);
            this.pboxAboutImage.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.pboxAboutImage.Name = "pboxAboutImage";
            this.pboxAboutImage.Size = new System.Drawing.Size(453, 431);
            this.pboxAboutImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pboxAboutImage.TabIndex = 8;
            this.pboxAboutImage.TabStop = false;
            // 
            // rtboxAbout
            // 
            this.rtboxAbout.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Ribbon;
            this.rtboxAbout.Location = new System.Drawing.Point(1196, 460);
            this.rtboxAbout.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.rtboxAbout.Name = "rtboxAbout";
            this.rtboxAbout.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rtboxAbout.Size = new System.Drawing.Size(453, 175);
            this.rtboxAbout.TabIndex = 9;
            this.rtboxAbout.Text = "Created with Love for DaRkFoxDeveloper.\nWebsite: www.darkfoxdeveloper.com";
            this.rtboxAbout.WordWrap = false;
            // 
            // btnFindPatches
            // 
            this.btnFindPatches.Location = new System.Drawing.Point(268, 581);
            this.btnFindPatches.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.btnFindPatches.Name = "btnFindPatches";
            this.btnFindPatches.Size = new System.Drawing.Size(461, 54);
            this.btnFindPatches.TabIndex = 10;
            this.btnFindPatches.Values.Text = "Find Patches";
            this.btnFindPatches.Click += new System.EventHandler(this.BtnFindPatches_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 25F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1665, 645);
            this.Controls.Add(this.btnFindPatches);
            this.Controls.Add(this.rtboxAbout);
            this.Controls.Add(this.pboxAboutImage);
            this.Controls.Add(this.lblTo);
            this.Controls.Add(this.lblFrom);
            this.Controls.Add(this.btnDownload);
            this.Controls.Add(this.pBarProgress);
            this.Controls.Add(this.tbxStartVersion);
            this.Controls.Add(this.tbxLimitVersion);
            this.Controls.Add(this.lstBoxClients);
            this.Controls.Add(this.btnFind);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Margin = new System.Windows.Forms.Padding(4, 4, 4, 4);
            this.Name = "Form1";
            this.Text = "ConquerOfficialClientFinder";
            ((System.ComponentModel.ISupportInitialize)(this.pboxAboutImage)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private ComponentFactory.Krypton.Toolkit.KryptonButton btnFind;
        private ComponentFactory.Krypton.Toolkit.KryptonListBox lstBoxClients;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox tbxLimitVersion;
        private ComponentFactory.Krypton.Toolkit.KryptonTextBox tbxStartVersion;
        private System.ComponentModel.BackgroundWorker worker;
        private System.Windows.Forms.ProgressBar pBarProgress;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnDownload;
        private System.ComponentModel.BackgroundWorker downloadWorker;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblFrom;
        private ComponentFactory.Krypton.Toolkit.KryptonLabel lblTo;
        private System.Windows.Forms.PictureBox pboxAboutImage;
        private ComponentFactory.Krypton.Toolkit.KryptonRichTextBox rtboxAbout;
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnFindPatches;
    }
}

