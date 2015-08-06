// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToolbarButtonView.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   The toolbar button view.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Views
{
    using System;
    using System.Windows.Forms;

    using Interfaces;

    /// <summary>The toolbar button view.</summary>
    public partial class ToolbarButtonView : UserControl, IToolbarButtonView
    {
        /// <summary>Initializes a new instance of the <see cref="ToolbarButtonView"/> class.</summary>
        public ToolbarButtonView()
        {
            this.InitializeComponent();

            this.Load += (s, e) => this.OnViewLoad();
        }

        public event EventHandler AddLevel
        {
            add { this.ButtonAddLevel.Click += value; }
            remove { this.ButtonAddLevel.Click -= value; }
        }

        public event EventHandler RemoveLevel
        {
            add { this.ButtonRemoveLevel.Click += value; }
            remove { this.ButtonRemoveLevel.Click -= value; }
        }

        public event EventHandler ImportPartLevels
        {
            add { this.ButtonImportPartLevels.Click += value; }
            remove { this.ButtonImportPartLevels.Click -= value; }
        }

        public event EventHandler SaveLevelList
        {
            add { this.ButtonSaveLevelList.Click += value; }
            remove { this.ButtonSaveLevelList.Click -= value; }
        }

        public event EventHandler LevelScan
        {
            add { this.ButtonLevelScan.Click += value; }
            remove { this.ButtonLevelScan.Click -= value; }
        }

        public event EventHandler LoadLevelList
        {
            add { this.ButtonLoadLevelList.Click += value; }
            remove { this.ButtonLoadLevelList.Click -= value; }
        }

        public event EventHandler OpenOperationsLibrary
        {
            add { this.ButtonOpenOperationsLibrary.Click += value; }
            remove { this.ButtonOpenOperationsLibrary.Click -= value; }
        }

        public event EventHandler ViewLoaded;

        protected virtual void OnViewLoad()
        {
            var handler = this.ViewLoaded;
            handler?.Invoke(this, EventArgs.Empty);
        }
    }
}
