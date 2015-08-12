// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationsView.Designer.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the OperationsView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Views
{
    /// <summary>The operations view.</summary>
    partial class OperationsView
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
            this.OperationsTreeView = new System.Windows.Forms.TreeView();
            this.ToolbarButtonPanelRegion = new System.Windows.Forms.Panel();
            this.SuspendLayout();
            // 
            // OperationsTreeView
            // 
            this.OperationsTreeView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.OperationsTreeView.Location = new System.Drawing.Point(0, 51);
            this.OperationsTreeView.Name = "OperationsTreeView";
            this.OperationsTreeView.Size = new System.Drawing.Size(367, 414);
            this.OperationsTreeView.TabIndex = 0;
            // 
            // ToolbarButtonPanelRegion
            // 
            this.ToolbarButtonPanelRegion.Dock = System.Windows.Forms.DockStyle.Top;
            this.ToolbarButtonPanelRegion.Location = new System.Drawing.Point(0, 0);
            this.ToolbarButtonPanelRegion.Name = "ToolbarButtonPanelRegion";
            this.ToolbarButtonPanelRegion.Size = new System.Drawing.Size(367, 45);
            this.ToolbarButtonPanelRegion.TabIndex = 3;
            // 
            // OperationsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ToolbarButtonPanelRegion);
            this.Controls.Add(this.OperationsTreeView);
            this.Name = "OperationsView";
            this.Size = new System.Drawing.Size(367, 465);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>The operations tree view.</summary>
        private System.Windows.Forms.TreeView OperationsTreeView;
        private System.Windows.Forms.Panel ToolbarButtonPanelRegion;
    }
}
