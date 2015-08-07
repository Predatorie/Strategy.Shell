// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IShellView.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Strategy.Shell.Interfaces
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>The ShellView interface.</summary>
    public interface IShellView
    {
        /// <summary>The form closed.</summary>
        event FormClosedEventHandler FormClosed;

        /// <summary>The help requested.</summary>
        event HelpEventHandler HelpRequested;

        /// <summary>The key up.</summary>
        event KeyEventHandler KeyUp;

        /// <summary>The view loaded.</summary>
        event EventHandler Load;

        /// <summary>Gets the button bar view.</summary>
        IButtonBarView ButtonBarView { get; }

        /// <summary>Gets the levels view.</summary>
        ILevelsView LevelsView { get; }

        /// <summary>Gets the operations view.</summary>
        IOperationsView OperationsView { get; }

        /// <summary>Gets the toolbar button view.</summary>t
        IToolbarButtonView ToolbarButtonView { get; }

        /// <summary>Gets the window handle.</summary>
        IWin32Window WindowHandle { get; }

        /// <summary>Gets or sets the back color.</summary>
        Color BackColor { get; set; }
    }
}