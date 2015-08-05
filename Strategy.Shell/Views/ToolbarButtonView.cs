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
    using System.Windows.Forms;

    using Interfaces;

    /// <summary>The toolbar button view.</summary>
    public partial class ToolbarButtonView : UserControl, IToolbarButtonView
    {
        /// <summary>Initializes a new instance of the <see cref="ToolbarButtonView"/> class.</summary>
        public ToolbarButtonView()
        {
            this.InitializeComponent();
        }
    }
}
