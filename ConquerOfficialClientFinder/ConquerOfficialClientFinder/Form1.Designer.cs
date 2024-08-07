﻿
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
            this.btnStopSearching = new ComponentFactory.Krypton.Toolkit.KryptonButton();
            ((System.ComponentModel.ISupportInitialize)(this.pboxAboutImage)).BeginInit();
            this.SuspendLayout();
            // 
            // btnFind
            // 
            this.btnFind.Location = new System.Drawing.Point(201, 416);
            this.btnFind.Name = "btnFind";
            this.btnFind.Size = new System.Drawing.Size(346, 43);
            this.btnFind.TabIndex = 2;
            this.btnFind.Values.Text = "Find Clients";
            this.btnFind.Click += new System.EventHandler(this.BtnFind_Click);
            // 
            // lstBoxClients
            // 
            this.lstBoxClients.Location = new System.Drawing.Point(12, 12);
            this.lstBoxClients.Name = "lstBoxClients";
            this.lstBoxClients.Size = new System.Drawing.Size(879, 345);
            this.lstBoxClients.TabIndex = 1;
            this.lstBoxClients.SelectedIndexChanged += new System.EventHandler(this.LstBoxClients_SelectedIndexChanged);
            // 
            // tbxLimitVersion
            // 
            this.tbxLimitVersion.Location = new System.Drawing.Point(81, 465);
            this.tbxLimitVersion.Name = "tbxLimitVersion";
            this.tbxLimitVersion.Size = new System.Drawing.Size(103, 32);
            this.tbxLimitVersion.TabIndex = 1;
            this.tbxLimitVersion.Text = "8000";
            this.tbxLimitVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // tbxStartVersion
            // 
            this.tbxStartVersion.Location = new System.Drawing.Point(81, 427);
            this.tbxStartVersion.Name = "tbxStartVersion";
            this.tbxStartVersion.Size = new System.Drawing.Size(103, 32);
            this.tbxStartVersion.TabIndex = 0;
            this.tbxStartVersion.Text = "4200";
            this.tbxStartVersion.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // worker
            // 
            this.worker.WorkerSupportsCancellation = true;
            this.worker.DoWork += new System.ComponentModel.DoWorkEventHandler(this.Worker_DoWork);
            // 
            // pBarProgress
            // 
            this.pBarProgress.Location = new System.Drawing.Point(12, 368);
            this.pBarProgress.Name = "pBarProgress";
            this.pBarProgress.Size = new System.Drawing.Size(879, 38);
            this.pBarProgress.TabIndex = 4;
            this.pBarProgress.Visible = false;
            // 
            // btnDownload
            // 
            this.btnDownload.Enabled = false;
            this.btnDownload.Location = new System.Drawing.Point(675, 416);
            this.btnDownload.Name = "btnDownload";
            this.btnDownload.Size = new System.Drawing.Size(216, 92);
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
            this.lblFrom.Location = new System.Drawing.Point(12, 430);
            this.lblFrom.Name = "lblFrom";
            this.lblFrom.Size = new System.Drawing.Size(63, 29);
            this.lblFrom.TabIndex = 6;
            this.lblFrom.Values.Text = "FROM";
            // 
            // lblTo
            // 
            this.lblTo.Location = new System.Drawing.Point(39, 468);
            this.lblTo.Name = "lblTo";
            this.lblTo.Size = new System.Drawing.Size(36, 29);
            this.lblTo.TabIndex = 7;
            this.lblTo.Values.Text = "TO";
            // 
            // pboxAboutImage
            // 
            this.pboxAboutImage.Image = global::ConquerOfficialClientFinder.Properties.Resources.foxlogo;
            this.pboxAboutImage.Location = new System.Drawing.Point(897, 12);
            this.pboxAboutImage.Name = "pboxAboutImage";
            this.pboxAboutImage.Size = new System.Drawing.Size(340, 345);
            this.pboxAboutImage.SizeMode = System.Windows.Forms.PictureBoxSizeMode.CenterImage;
            this.pboxAboutImage.TabIndex = 8;
            this.pboxAboutImage.TabStop = false;
            // 
            // rtboxAbout
            // 
            this.rtboxAbout.InputControlStyle = ComponentFactory.Krypton.Toolkit.InputControlStyle.Ribbon;
            this.rtboxAbout.Location = new System.Drawing.Point(897, 368);
            this.rtboxAbout.Name = "rtboxAbout";
            this.rtboxAbout.ReadOnly = true;
            this.rtboxAbout.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.rtboxAbout.Size = new System.Drawing.Size(340, 140);
            this.rtboxAbout.TabIndex = 100;
            this.rtboxAbout.Text = "Created with Love for DaRkFoxDeveloper.\nWebsite: www.darkfoxdeveloper.com";
            this.rtboxAbout.WordWrap = false;
            // 
            // btnFindPatches
            // 
            this.btnFindPatches.Location = new System.Drawing.Point(201, 465);
            this.btnFindPatches.Name = "btnFindPatches";
            this.btnFindPatches.Size = new System.Drawing.Size(346, 43);
            this.btnFindPatches.TabIndex = 3;
            this.btnFindPatches.Values.Text = "Find Patches";
            this.btnFindPatches.Click += new System.EventHandler(this.BtnFindPatches_Click);
            // 
            // btnStopSearching
            // 
            this.btnStopSearching.Enabled = false;
            this.btnStopSearching.Location = new System.Drawing.Point(553, 416);
            this.btnStopSearching.Name = "btnStopSearching";
            this.btnStopSearching.Size = new System.Drawing.Size(116, 92);
            this.btnStopSearching.TabIndex = 4;
            this.btnStopSearching.Values.Text = "Stop Search";
            this.btnStopSearching.Click += new System.EventHandler(this.BtnStopSearching_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(9F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1249, 516);
            this.Controls.Add(this.btnStopSearching);
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
            this.Name = "Form1";
            this.Text = "ConquerOfficialClientFinder";
            this.Load += new System.EventHandler(this.Form1_Load);
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
        private ComponentFactory.Krypton.Toolkit.KryptonButton btnStopSearching;
    }
}

