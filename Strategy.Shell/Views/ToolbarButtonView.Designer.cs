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
            this.toolStripSeparator1 = new System.Windows.Forms.ToolStripSeparator();
            this.toolStripButton1 = new System.Windows.Forms.ToolStripButton();
            this.ComboOperationTypes = new System.Windows.Forms.ToolStripComboBox();
            this.ToolBarButtonsCollection.SuspendLayout();
            this.SuspendLayout();
            // 
            // ToolBarButtonsCollection
            // 
            this.ToolBarButtonsCollection.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.ButtonAddLevel,
            this.ButtonRemoveLevel,
            this.toolStripButton1,
            this.toolStripSeparator1,
            this.ComboOperationTypes});
            this.ToolBarButtonsCollection.Location = new System.Drawing.Point(0, 0);
            this.ToolBarButtonsCollection.Name = "ToolBarButtonsCollection";
            this.ToolBarButtonsCollection.Size = new System.Drawing.Size(699, 45);
            this.ToolBarButtonsCollection.TabIndex = 0;
            // 
            // ButtonAddLevel
            // 
            this.ButtonAddLevel.Image = ((System.Drawing.Image)(resources.GetObject("ButtonAddLevel.Image")));
            this.ButtonAddLevel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonAddLevel.Margin = new System.Windows.Forms.Padding(5);
            this.ButtonAddLevel.Name = "ButtonAddLevel";
            this.ButtonAddLevel.Size = new System.Drawing.Size(63, 35);
            this.ButtonAddLevel.Text = "Add Level";
            this.ButtonAddLevel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // ButtonRemoveLevel
            // 
            this.ButtonRemoveLevel.Image = ((System.Drawing.Image)(resources.GetObject("ButtonRemoveLevel.Image")));
            this.ButtonRemoveLevel.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.ButtonRemoveLevel.Margin = new System.Windows.Forms.Padding(5);
            this.ButtonRemoveLevel.Name = "ButtonRemoveLevel";
            this.ButtonRemoveLevel.Size = new System.Drawing.Size(84, 35);
            this.ButtonRemoveLevel.Text = "Remove Level";
            this.ButtonRemoveLevel.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // toolStripSeparator1
            // 
            this.toolStripSeparator1.Name = "toolStripSeparator1";
            this.toolStripSeparator1.Size = new System.Drawing.Size(6, 45);
            // 
            // toolStripButton1
            // 
            this.toolStripButton1.Image = ((System.Drawing.Image)(resources.GetObject("toolStripButton1.Image")));
            this.toolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta;
            this.toolStripButton1.Margin = new System.Windows.Forms.Padding(5);
            this.toolStripButton1.Name = "toolStripButton1";
            this.toolStripButton1.Size = new System.Drawing.Size(106, 35);
            this.toolStripButton1.Text = "Import Part Levels";
            this.toolStripButton1.TextImageRelation = System.Windows.Forms.TextImageRelation.ImageAboveText;
            // 
            // ComboOperationTypes
            // 
            this.ComboOperationTypes.Items.AddRange(new object[] {
            "Router Operations",
            "Mill Operations"});
            this.ComboOperationTypes.Name = "ComboOperationTypes";
            this.ComboOperationTypes.Size = new System.Drawing.Size(121, 45);
            // 
            // ToolbarButtonView
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.ToolBarButtonsCollection);
            this.Name = "ToolbarButtonView";
            this.Size = new System.Drawing.Size(699, 53);
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
        private System.Windows.Forms.ToolStripButton toolStripButton1;
        private System.Windows.Forms.ToolStripComboBox ComboOperationTypes;
    }
}
