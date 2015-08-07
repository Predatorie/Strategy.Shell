// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LevelsView.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   The levels view.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Views
{
    using System;
    using System.Windows.Forms;

    using Interfaces;

    /// <summary>The levels view.</summary>
    public partial class LevelsView : UserControl, ILevelsView, IViewBase
    {
        /// <summary>Initializes a new instance of the <see cref="LevelsView"/> class.</summary>
        public LevelsView()
        {
            this.InitializeComponent();

            this.LevelsTree.AfterSelect += (s, e) => this.OnSelectionChanged();
            this.Load += (s, e) => this.OnViewLoad();
        }

        /// <summary>The selection changed.</summary>
        public event EventHandler SelectionChanged;

        /// <summary>Gets the selected node.</summary>
        public TreeNode SelectedNode => this.LevelsTree.SelectedNode;

        /// <summary>
        /// Returns the handle to this form, usefull for setting modal dialogs to this form
        /// </summary>
        public IWin32Window WindowHandle => FromHandle(this.Handle);

        /// <summary>The add node.</summary>
        /// <param name="levelNode">The level node.</param>
        public void AddNode(TreeNode levelNode)
        {
            this.LevelsTree.Nodes.Add(levelNode);
        }

        /// <summary>The remove node.</summary>
        /// <param name="key">The key.</param>
        public void RemoveNode(string key)
        {
            var node = this.LevelsTree.Nodes[key];
            this.LevelsTree.Nodes.Remove(node);
        }

        /// <summary>The select node.</summary>
        /// <param name="key">The key.</param>
        public void SelectNode(string key)
        {
            this.LevelsTree.SelectedNode = this.LevelsTree.Nodes[key];
        }

        public event EventHandler ViewLoad;

        /// <summary>The on selection changed.</summary>
        protected virtual void OnSelectionChanged()
        {
            var handler = this.SelectionChanged;
            handler?.Invoke(this, EventArgs.Empty);
        }
        protected virtual void OnViewLoad()
        {
            var handler = this.ViewLoad;
            handler?.Invoke(this, EventArgs.Empty);
        }
    }
}
