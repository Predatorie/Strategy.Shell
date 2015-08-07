// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToolbarButtonView.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Strategy.Shell.Views
{
    using System;
    using System.Windows.Forms;

    using Strategy.Shell.Interfaces;

    /// <summary>The toolbar button view.</summary>
    public partial class ToolbarButtonView : UserControl, IToolbarButtonView, IViewBase
    {
        #region Construction

        /// <summary>Initializes a new instance of the <see cref="ToolbarButtonView"/> class.</summary>
        public ToolbarButtonView()
        {
            this.InitializeComponent();

            this.Load += (s, e) => this.OnViewLoad();
        }

        #endregion

        #region Public Properties

        /// <summary>
        /// Returns the handle to this form, usefull for setting modal dialogs to this form
        /// </summary>
        public IWin32Window WindowHandle => FromHandle(this.Handle);

        #endregion

        #region Event Handlers

        /// <summary>The add level.</summary>
        public event EventHandler AddLevel
        {
            add { this.ButtonAddLevel.Click += value; }
            remove { this.ButtonAddLevel.Click -= value; }
        }

        /// <summary>The remove level.</summary>
        public event EventHandler RemoveLevel
        {
            add { this.ButtonRemoveLevel.Click += value; }
            remove { this.ButtonRemoveLevel.Click -= value; }
        }

        /// <summary>The import part levels.</summary>
        public event EventHandler ImportPartLevels
        {
            add { this.ButtonImportPartLevels.Click += value; }
            remove { this.ButtonImportPartLevels.Click -= value; }
        }

        /// <summary>The save level list.</summary>
        public event EventHandler SaveLevelList
        {
            add { this.ButtonSaveLevelList.Click += value; }
            remove { this.ButtonSaveLevelList.Click -= value; }
        }

        /// <summary>The level scan.</summary>
        public event EventHandler LevelScan
        {
            add { this.ButtonLevelScan.Click += value; }
            remove { this.ButtonLevelScan.Click -= value; }
        }

        /// <summary>The load level list.</summary>
        public event EventHandler LoadLevelList
        {
            add { this.ButtonLoadLevelList.Click += value; }
            remove { this.ButtonLoadLevelList.Click -= value; }
        }

        /// <summary>The open operations library.</summary>
        public event EventHandler OpenOperationsLibrary
        {
            add { this.ButtonOpenOperationsLibrary.Click += value; }
            remove { this.ButtonOpenOperationsLibrary.Click -= value; }
        }

        /// <summary>The view load.</summary>
        public event EventHandler ViewLoad;

        /// <summary>The on view load.</summary>
        protected virtual void OnViewLoad()
        {
            var handler = this.ViewLoad;
            handler?.Invoke(this, EventArgs.Empty);
        }

        #endregion
    }
}
