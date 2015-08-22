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
    using System.Runtime.Remoting.Channels;
    using System.Windows.Forms;

    using Interfaces;

    /// <summary>The levels view.</summary>
    public partial class LevelsView : UserControl, ILevelsView, IViewBase
    {
        #region Construction

        /// <summary>Initializes a new instance of the <see cref="LevelsView"/> class.</summary>
        public LevelsView()
        {
            this.InitializeComponent();

            this.LevelsTree.AfterSelect += (s, e) => this.OnSelectionChanged();

            this.LevelsTree.ItemDrag += this.OnLevelDrag;
            this.LevelsTree.DragDrop += this.OnLevelDragDrop;
            this.LevelsTree.DragEnter += this.OnLevelDragEnter;

            this.Load += (s, e) => this.OnViewLoad();
        }

        #endregion

        #region Public Events

        /// <summary>The selection changed.</summary>
        public event EventHandler SelectionChanged;

        public event EventHandler ViewLoad;

        public event EventHandler LevelDragEnter;

        public event EventHandler LevelDragDrop;

        public event EventHandler LevelDrag;

        #endregion

        #region Public Properties

        /// <summary>Gets the selected node.</summary>
        public TreeNode SelectedNode => this.LevelsTree.SelectedNode;

        /// <summary>
        /// Gets the levels treeview (used to set images list)
        /// </summary>
        public TreeView Tree => this.LevelsTree;

        #endregion

        #region Public Methods

        /// <summary>The select node.</summary>
        /// <param name="key">The key.</param>
        public void SelectNode(string key)
        {
            this.LevelsTree.SelectedNode = this.LevelsTree.Nodes[key];
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

        protected virtual void OnLevelDragEnter(object sender, DragEventArgs e)
        {
            var handler = this.LevelDragEnter;
            handler?.Invoke(sender, e);
        }

        protected virtual void OnLevelDragDrop(object sender, DragEventArgs e)
        {
            var handler = this.LevelDragDrop;
            handler?.Invoke(sender, e);
        }

        protected virtual void OnLevelDrag(object sender, ItemDragEventArgs e)
        {
            var handler = this.LevelDrag;
            handler?.Invoke(sender, e);
        }

        #endregion
    }
}
