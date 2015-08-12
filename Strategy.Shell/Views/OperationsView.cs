// --------------------------------------------------------------------------------------------------------------------
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
    public partial class OperationsView : UserControl, IOperationsView, IViewBase
    {
        #region Construction

        /// <summary>Initializes a new instance of the <see cref="OperationsView"/> class.</summary>
        public OperationsView()
        {
            this.InitializeComponent();
            this.OperationsTreeView.AfterSelect += (s, e) => this.OnSelectionChanged();
            this.OperationsTreeView.ItemDrag += (s, e) => this.OnOperationDrag();
            this.OperationsTreeView.DragEnter += (s, e) => this.OnOperationDragEnter();
            this.OperationsTreeView.DragDrop += (s, e) => this.OnOperationDragDrop();

            this.Load += (s, e) => this.OnViewLoad();
        }

        #endregion

        #region Public Events

        /// <summary>The selection changed.</summary>
        public event EventHandler SelectionChanged;

        public event EventHandler ViewLoad;

        public event EventHandler OperationDragEnter;

        public event EventHandler OperationDragDrop;

        public event EventHandler OperationDrag;

        #endregion

        #region Public Properties

        /// <summary>Gets the selected node.</summary>
        public TreeNode SelectedNode => this.OperationsTreeView.SelectedNode;

        // public TreeNode MainTreeNode => this.OperationsTreeView.TopNode;

        public TreeView Tree => this.OperationsTreeView;

        #endregion

        #region Public Methods

        /// <summary>The select node.</summary>
        /// <param name="key">The key.</param>
        public void SelectNode(string key)
        {
            this.OperationsTreeView.SelectedNode = this.OperationsTreeView.Nodes[key];
        }

        #endregion

        #region Protected Methods

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

        protected virtual void OnOperationDrag()
        {
            var handler = this.OperationDrag;
            handler?.Invoke(this, (ItemDragEventArgs)EventArgs.Empty);
        }

        protected virtual void OnOperationDragEnter()
        {
            var handler = this.OperationDragEnter;
            handler?.Invoke(this, (ItemDragEventArgs)EventArgs.Empty);
        }

        protected virtual void OnOperationDragDrop()
        {
            var handler = this.OperationDragDrop;
            handler?.Invoke(this, (ItemDragEventArgs)EventArgs.Empty);
        }

        #endregion
    }
}
