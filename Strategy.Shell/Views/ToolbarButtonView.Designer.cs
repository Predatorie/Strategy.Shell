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
            this.ToolBarButtonsCollection = new System.Windows.Forms.ToolStrip();
            this.SuspendLayout();
            // 
            // ToolBarButtonsCollection
            // 
            this.ToolBarButtonsCollection.Location = new System.Drawing.Point(0, 0);
            this.ToolBarButtonsCollection.Name = "ToolBarButtonsCollection";
            this.ToolBarButtonsCollection.RenderMode = System.Windows.Forms.ToolStripRenderMode.System;
            this.ToolBarButtonsCollection.Size = new System.Drawing.Size(700, 25);
            this.ToolBarButtonsCollection.TabIndex = 0;
            // 
            // ToolbarButtonView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ToolBarButtonsCollection);
            this.Name = "ToolbarButtonView";
            this.Size = new System.Drawing.Size(700, 45);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ToolStrip ToolBarButtonsCollection;
    }
}
