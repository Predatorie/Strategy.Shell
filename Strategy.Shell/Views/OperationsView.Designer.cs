namespace Strategy.Shell.Views
{
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
            this.SuspendLayout();
            // 
            // OperationsTreeView
            // 
            this.OperationsTreeView.Dock = System.Windows.Forms.DockStyle.Fill;
            this.OperationsTreeView.Location = new System.Drawing.Point(0, 0);
            this.OperationsTreeView.Name = "OperationsTreeView";
            this.OperationsTreeView.Size = new System.Drawing.Size(367, 465);
            this.OperationsTreeView.TabIndex = 0;
            // 
            // OperationsView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.OperationsTreeView);
            this.Name = "OperationsView";
            this.Size = new System.Drawing.Size(367, 465);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TreeView OperationsTreeView;
    }
}
