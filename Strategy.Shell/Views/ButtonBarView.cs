// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ButtonBarView.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   The button bar view.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Views
{
    using System;
    using System.Windows.Forms;

    using Interfaces;

    /// <summary>The button bar view.</summary>
    public partial class ButtonBarView : UserControl, IButtonBarView, IViewBase
    {
        /// <summary>Initializes a new instance of the <see cref="ButtonBarView"/> class.</summary>
        public ButtonBarView()
        {
            this.InitializeComponent();

            this.Load += (s, e) => this.OnViewLoad();
        }

        /// <summary>
        /// Returns the handle to this form, usefull for setting modal dialogs to this form
        /// </summary>
        public IWin32Window WindowHandle => FromHandle(this.Handle);

        /// <summary>The close view.</summary>
        public event EventHandler CloseView
        {
            add { this.ButtonClose.Click += value; }
            remove { this.ButtonClose.Click -= value; }
        }

        public event EventHandler SaveStrategy
        {
            add { this.ButtonSave.Click += value; }
            remove { this.ButtonSave.Click -= value; }
        }

        public event EventHandler LoadStrategy
        {
            add { this.ButtonLoadStrategy.Click += value; }
            remove { this.ButtonLoadStrategy.Click -= value; }
        }

        public event EventHandler ViewLoad;

        protected virtual void OnViewLoad()
        {
            var handler = this.ViewLoad;
            handler?.Invoke(this, EventArgs.Empty);
        }
    }
}
