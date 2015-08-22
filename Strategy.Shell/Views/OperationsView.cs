// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationsView.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
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
            this.OperationsTreeView.ItemDrag += this.OnOperationDrag;
            this.OperationsTreeView.DragEnter += this.OnOperationDragEnter;
            this.OperationsTreeView.DragDrop += this.OnOperationDragDrop;

            this.Load += (s, e) => this.OnViewLoad();
        }

        #endregion

        #region Public Events

        /// <summary>The selection changed.</summary>
        public event EventHandler SelectionChanged;

        /// <summary>The view load.</summary>
        public event EventHandler ViewLoad;

        /// <summary>The operation drag enter.</summary>
        public event EventHandler OperationDragEnter;

        /// <summary>The operation drag drop.</summary>
        public event EventHandler OperationDragDrop;

        /// <summary>The operation drag.</summary>
        public event EventHandler OperationDrag;

        #endregion

        #region Public Properties

        /// <summary>Gets the selected node.</summary>
        public TreeNode SelectedNode => this.OperationsTreeView.SelectedNode;

        // public TreeNode MainTreeNode => this.OperationsTreeView.TopNode;

        /// <summary>The tree.</summary>
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

        /// <summary>The on view load.</summary>
        protected virtual void OnViewLoad()
        {
            var handler = this.ViewLoad;
            handler?.Invoke(this, EventArgs.Empty);
        }

        /// <summary>The on operation drag.</summary>
        protected virtual void OnOperationDrag(object sender, ItemDragEventArgs e)
        {
            var handler = this.OperationDrag;
            handler?.Invoke(sender, e);
        }

        /// <summary>The on operation drag enter.</summary>
        protected virtual void OnOperationDragEnter(object sender, DragEventArgs e)
        {
            var handler = this.OperationDragEnter;
            handler?.Invoke(sender, e);
        }

        /// <summary>The on operation drag drop.</summary>
        protected virtual void OnOperationDragDrop(object sender, DragEventArgs e)
        {
            var handler = this.OperationDragDrop;
            handler?.Invoke(sender, e);
        }

        #endregion
    }
}
