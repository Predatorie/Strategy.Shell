﻿namespace Strategy.Shell.Views
{
    partial class LevelsView
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
            this.LevelsTree = new System.Windows.Forms.TreeView();
            this.ToolbarButtonPanelRegion = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // LevelsTree
            // 
            this.LevelsTree.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.LevelsTree.Location = new System.Drawing.Point(0, 51);
            this.LevelsTree.Name = "LevelsTree";
            this.LevelsTree.Size = new System.Drawing.Size(349, 421);
            this.LevelsTree.TabIndex = 0;
            // 
            // ToolbarButtonPanelRegion
            // 
            this.ToolbarButtonPanelRegion.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolbarButtonPanelRegion.Location = new System.Drawing.Point(0, 0);
            this.ToolbarButtonPanelRegion.Name = "ToolbarButtonPanelRegion";
            this.ToolbarButtonPanelRegion.Size = new System.Drawing.Size(349, 45);
            this.ToolbarButtonPanelRegion.TabIndex = 2;
            // 
            // LevelsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ToolbarButtonPanelRegion);
            this.Controls.Add(this.LevelsTree);
            this.Name = "LevelsView";
            this.Size = new System.Drawing.Size(349, 472);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView LevelsTree;
        private System.Windows.Forms.Panel ToolbarButtonPanelRegion;
    }
}
