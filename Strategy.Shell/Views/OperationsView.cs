﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationsView.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   The operations view.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Views
{
    using System;
    using System.Windows.Forms;

    using Interfaces;

    /// <summary>The operations view.</summary>
    public partial class OperationsView : UserControl, IOperationsView
    {
        /// <summary>Initializes a new instance of the <see cref="OperationsView"/> class.</summary>
        public OperationsView()
        {
            this.InitializeComponent();
            this.OperationsTreeView.AfterSelect += (s, e) => this.OnSelectionChanged();
        }

        /// <summary>The selection changed.</summary>
        public event EventHandler SelectionChanged;

        /// <summary>Gets the selected node.</summary>
        public TreeNode SelectedNode => this.OperationsTreeView.SelectedNode;

        /// <summary>The add node.</summary>
        /// <param name="levelNode">The level node.</param>
        public void AddNode(TreeNode levelNode)
        {
            this.OperationsTreeView.Nodes.Add(levelNode);
        }

        /// <summary>The remove node.</summary>
        /// <param name="key">The key.</param>
        public void RemoveNode(string key)
        {
            var node = this.OperationsTreeView.Nodes[key];
            this.OperationsTreeView.Nodes.Remove(node);
        }

        /// <summary>The select node.</summary>
        /// <param name="key">The key.</param>
        public void SelectNode(string key)
        {
            this.OperationsTreeView.SelectedNode = this.OperationsTreeView.Nodes[key];
        }

        /// <summary>The on selection changed.</summary>
        protected virtual void OnSelectionChanged()
        {
            var handler = this.SelectionChanged;
            handler?.Invoke(this, EventArgs.Empty);
        }
    }
}
