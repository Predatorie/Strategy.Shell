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
    using System.Windows.Forms;

    using Interfaces;

    /// <summary>The button bar view.</summary>
    public partial class ButtonBarView : UserControl, IButtonBarView
    {
        /// <summary>Initializes a new instance of the <see cref="ButtonBarView"/> class.</summary>
        public ButtonBarView()
        {
            this.InitializeComponent();
        }
    }
}
