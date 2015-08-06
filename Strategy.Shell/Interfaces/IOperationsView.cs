// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IOperationsView.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the IOperationsView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Interfaces
{
    using System;
    using System.Windows.Forms;

    /// <summary>The OperationsView interface.</summary>
    public interface IOperationsView
    {
        /// <summary>The selection changed.</summary>
        event EventHandler SelectionChanged;

        /// <summary>Gets the selected node.</summary>
        TreeNode SelectedNode { get; }

        /// <summary>The add operation node.</summary>
        /// <param name="node">The node.</param>
        void AddNode(TreeNode node);

        /// <summary>The remove level node.</summary>
        /// <param name="key">The key.</param>
        void RemoveNode(string key);

        /// <summary>The select level node.</summary>
        /// <param name="key">The key.</param>
        void SelectNode(string key);

        event EventHandler ViewLoaded;
    }
}