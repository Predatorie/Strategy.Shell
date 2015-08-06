namespace Strategy.Shell.Views
{
    partial class ToolbarButtonView
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if(disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ToolbarButtonView));
            this.ToolBarButtonsCollection = new System.Windows.Forms.ToolStrip();
            this.ButtonAddLevel = new System.Windows.Forms.ToolStripButton();
            this.ButtonRemoveLevel = new System.Windows.Forms.ToolStripButton();
            this.ButtonImportPartLevels = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.ButtonLoadLevelList = new System.Windows.Forms.ToolStripButton();
            this.toolStripSeparator2 = new System.Windows.Forms.ToolStripSeparator();
            this.ButtonSaveLevelList = new System.Windows.Forms.ToolStripButton();
            this.ButtonOpenOperationsLibrary = new System.Windows.Forms.ToolStripButton();
            this.ButtonLevelScan = new System.Windows.Forms.ToolStripButton();
            this.ToolBarButtonsCollection.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBarButtonsCollection
            // 
            this.ToolBarButtonsCollection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonLevelScan,
            this.ButtonImportPartLevels,
            this.ButtonAddLevel,
            this.ButtonRemoveLevel,
            this.toolStripSeparator1,
            this.ButtonLoadLevelList,
            this.ButtonSaveLevelList,
            this.toolStripSeparator2,
            this.ButtonOpenOperationsLibrary});
            this.ToolBarButtonsCollection.Location = new System.Drawing.Point(0, 0);
            this.ToolBarButtonsCollection.Name = "ToolBarButtonsCollection";
            this.ToolBarButtonsCollection.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolBarButtonsCollection.Size = new System.Drawing.Size(700, 39);
            this.ToolBarButtonsCollection.TabIndex = 0;
            // 
            // ButtonAddLevel
            // 
            this.ButtonAddLevel.Image = ((System.Drawing.Image)(resources.GetObject("ButtonAddLevel.Image")));
            this.ButtonAddLevel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonAddLevel.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonAddLevel.Name = "ButtonAddLevel";
            this.ButtonAddLevel.Size = new System.Drawing.Size(33, 35);
            this.ButtonAddLevel.Text = "Add";
            this.ButtonAddLevel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ButtonAddLevel.ToolTipText = "Add Level";
            // 
            // ButtonRemoveLevel
            // 
            this.ButtonRemoveLevel.Image = ((System.Drawing.Image)(resources.GetObject("ButtonRemoveLevel.Image")));
            this.ButtonRemoveLevel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonRemoveLevel.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonRemoveLevel.Name = "ButtonRemoveLevel";
            this.ButtonRemoveLevel.Size = new System.Drawing.Size(54, 35);
            this.ButtonRemoveLevel.Text = "Remove";
            this.ButtonRemoveLevel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ButtonRemoveLevel.ToolTipText = "Remove Level";
            // 
            // ButtonImportPartLevels
            // 
            this.ButtonImportPartLevels.Image = ((System.Drawing.Image)(resources.GetObject("ButtonImportPartLevels.Image")));
            this.ButtonImportPartLevels.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonImportPartLevels.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonImportPartLevels.Name = "ButtonImportPartLevels";
            this.ButtonImportPartLevels.Size = new System.Drawing.Size(32, 35);
            this.ButtonImportPartLevels.Text = "Part";
            this.ButtonImportPartLevels.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ButtonImportPartLevels.ToolTipText = "Import Part Levels";
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 39);
            // 
            // ButtonLoadLevelList
            // 
            this.ButtonLoadLevelList.Image = ((System.Drawing.Image)(resources.GetObject("ButtonLoadLevelList.Image")));
            this.ButtonLoadLevelList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonLoadLevelList.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonLoadLevelList.Name = "ButtonLoadLevelList";
            this.ButtonLoadLevelList.Size = new System.Drawing.Size(40, 35);
            this.ButtonLoadLevelList.Text = "Open";
            this.ButtonLoadLevelList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ButtonLoadLevelList.ToolTipText = "Open Level List";
            // 
            // toolStripSeparator2
            // 
            this.toolStripSeparator2.Name = "toolStripSeparator2";
            this.toolStripSeparator2.Size = new System.Drawing.Size(6, 39);
            // 
            // ButtonSaveLevelList
            // 
            this.ButtonSaveLevelList.Image = ((System.Drawing.Image)(resources.GetObject("ButtonSaveLevelList.Image")));
            this.ButtonSaveLevelList.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonSaveLevelList.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonSaveLevelList.Name = "ButtonSaveLevelList";
            this.ButtonSaveLevelList.Size = new System.Drawing.Size(35, 35);
            this.ButtonSaveLevelList.Text = "Save";
            this.ButtonSaveLevelList.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ButtonSaveLevelList.ToolTipText = "Save Level List";
            // 
            // ButtonOpenOperationsLibrary
            // 
            this.ButtonOpenOperationsLibrary.Image = ((System.Drawing.Image)(resources.GetObject("ButtonOpenOperationsLibrary.Image")));
            this.ButtonOpenOperationsLibrary.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonOpenOperationsLibrary.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonOpenOperationsLibrary.Name = "ButtonOpenOperationsLibrary";
            this.ButtonOpenOperationsLibrary.Size = new System.Drawing.Size(69, 35);
            this.ButtonOpenOperationsLibrary.Text = "Operations";
            this.ButtonOpenOperationsLibrary.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ButtonOpenOperationsLibrary.ToolTipText = "Open Mastercam Operations Library";
            // 
            // ButtonLevelScan
            // 
            this.ButtonLevelScan.Image = ((System.Drawing.Image)(resources.GetObject("ButtonLevelScan.Image")));
            this.ButtonLevelScan.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonLevelScan.Margin = new System.Windows.Forms.Padding(2);
            this.ButtonLevelScan.Name = "ButtonLevelScan";
            this.ButtonLevelScan.Size = new System.Drawing.Size(36, 35);
            this.ButtonLevelScan.Text = "Scan";
            this.ButtonLevelScan.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            this.ButtonLevelScan.ToolTipText = "Scan files for levels";
            // 
            // ToolbarButtonView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ToolBarButtonsCollection);
            this.Name = "ToolbarButtonView";
            this.Size = new System.Drawing.Size(700, 45);
            this.ToolBarButtonsCollection.ResumeLayout(false);
            this.ToolBarButtonsCollection.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToolBarButtonsCollection;
        private System.Windows.Forms.ToolStripButton ButtonAddLevel;
        private System.Windows.Forms.ToolStripButton ButtonRemoveLevel;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator1;
        private System.Windows.Forms.ToolStripButton ButtonImportPartLevels;
        private System.Windows.Forms.ToolStripButton ButtonLoadLevelList;
        private System.Windows.Forms.ToolStripSeparator toolStripSeparator2;
        private System.Windows.Forms.ToolStripButton ButtonSaveLevelList;
        private System.Windows.Forms.ToolStripButton ButtonOpenOperationsLibrary;
        private System.Windows.Forms.ToolStripButton ButtonLevelScan;
    }
}
