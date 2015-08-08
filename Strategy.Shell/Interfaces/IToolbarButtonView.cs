// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IToolbarButtonView.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the IToolbarButtonView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Interfaces
{
    using System;
    using System.Windows.Forms;

    /// <summary>The ToolbarButtonView interface.</summary>
    public interface IToolbarButtonView
    {
        /// <summary>The add level.</summary>
        event EventHandler AddLevel;

        /// <summary>The remove level.</summary>
        event EventHandler RemoveLevel;

        /// <summary>The import part levels.</summary>
        event EventHandler ImportPartLevels;

        /// <summary>The save level list.</summary>
        event EventHandler SaveLevelList;

        /// <summary>The save level list.</summary>
        event EventHandler LevelScan;

        /// <summary>The load level list.</summary>
        event EventHandler LoadLevelList;

        /// <summary>The selection changed.</summary>
        event EventHandler OpenOperationsLibrary;

        /// <summary>The view loaded.</summary>
        event EventHandler ViewLoad;

        /// <summary>Gets the tool bar strip.</summary>
        ToolStrip ToolBarStrip { get; }

        /// <summary>Gets the window handle.</summary>
        IWin32Window WindowHandle { get; }
    }
}