﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ILevelsView.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   The LevelsView interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Interfaces
{
    using System;
    using System.Windows.Forms;

    /// <summary>The LevelsView interface.</summary>
    public interface ILevelsView
    {
        /// <summary>The selection changed.</summary>
        event EventHandler SelectionChanged;

        /// <summary>The view loaded.</summary>
        event EventHandler ViewLoad;

        /// <summary>Gets the selected node.</summary>
        TreeNode SelectedNode { get; }

        /// <summary>Gets the tree.</summary>
        TreeView Tree { get; }

        /// <summary>The select level node.</summary>
        /// <param name="key">The key.</param>
        void SelectNode(string key);
    }
}
