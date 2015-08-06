// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IShellView.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the IShellView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Interfaces
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>The ShellView interface.</summary>
    public interface IShellView
    {
        event EventHandler Load;

        event FormClosedEventHandler FormClosed;

        event HelpEventHandler HelpRequested;

        event KeyEventHandler KeyUp;


        IButtonBarView ButtonBarView { get; }

        ILevelsView LevelsView { get; }

        IOperationsView OperationsView { get; }

        IToolbarButtonView ToolbarButtonView { get; }

        Color BackColor { get; set; }
    }
}