// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShellView.Designer.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the ShellView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Views
{
    /// <summary>The shell view.</summary>
    public sealed partial class ShellView
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(ShellView));
            this.ButtonPanelRegion = new System.Windows.Forms.Panel();
            this.ShellContainer = new System.Windows.Forms.SplitContainer();
            ((System.ComponentModel.ISupportInitialize)(this.ShellContainer)).BeginInit();
            this.ShellContainer.SuspendLayout();
            this.SuspendLayout();
            // 
            // ButtonPanelRegion
            // 
            resources.ApplyResources(this.ButtonPanelRegion, "ButtonPanelRegion");
            this.ButtonPanelRegion.Name = "ButtonPanelRegion";
            // 
            // ShellContainer
            // 
            resources.ApplyResources(this.ShellContainer, "ShellContainer");
            this.ShellContainer.Name = "ShellContainer";
            // 
            // ShellContainer.Panel1
            // 
            this.ShellContainer.Panel1.Tag = "LevelsContainerRegion";
            // 
            // ShellContainer.Panel2
            // 
            this.ShellContainer.Panel2.Tag = "OperationsContainerRegion";
            this.ShellContainer.TabStop = false;
            // 
            // ShellView
            // 
            resources.ApplyResources(this, "$this");
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ShellContainer);
            this.Controls.Add(this.ButtonPanelRegion);
            this.MinimizeBox = false;
            this.Name = "ShellView";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Show;
            ((System.ComponentModel.ISupportInitialize)(this.ShellContainer)).EndInit();
            this.ShellContainer.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        /// <summary>The button panel region.</summary>
        private System.Windows.Forms.Panel ButtonPanelRegion;

        /// <summary>The shell container.</summary>
        private System.Windows.Forms.SplitContainer ShellContainer;
    }
}