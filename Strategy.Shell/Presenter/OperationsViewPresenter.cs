// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationsViewPresenter.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Strategy.Shell.Presenter
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    using Mastercam.IO;

    using Reactive.EventAggregator;

    using Events;
    using FunctionTable;
    using Interfaces;
    using Localization;
    using Operations;
    using Services;

    /// <summary>The operations view presenter.</summary>
    public class OperationsViewPresenter
    {
        #region Fields

        /// <summary>The toolbar button view.</summary>
        private readonly IOperationsView view;

        /// <summary>The msg box service.</summary>
        private readonly IMessageBoxService msgBoxService;

        /// <summary>The file browser service.</summary>
        private readonly IFileBrowserService fileBrowserService;

        /// <summary>The event aggregator.</summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>The strategy service.</summary>
        private readonly IStrategyService strategyService;

        #endregion

        #region Construction

        /// <summary>Initializes a new instance of the <see cref="OperationsViewPresenter"/> class.</summary>
        /// <param name="view">The view.</param>
        /// <param name="msgBoxService">The msg box service.</param>
        /// <param name="fileBrowserService">The file browser service.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="strategyService">The Strategy Service</param>
        public OperationsViewPresenter(IOperationsView view,
            IMessageBoxService msgBoxService,
            IFileBrowserService fileBrowserService,
            IEventAggregator eventAggregator,
            IStrategyService strategyService)
        {
            // Wire up our services
            this.msgBoxService = msgBoxService;
            this.fileBrowserService = fileBrowserService;
            this.eventAggregator = eventAggregator;
            this.strategyService = strategyService;

            this.view = view;
            view.ViewLoad += this.OperationsViewOnViewLoad;
            view.SelectionChanged += this.OperationsViewOnSelectionChanged;
            view.OperationDrag += this.OnOperationItemDrag;
            view.OperationDragDrop += this.OnOperationDragDrop;
            view.OperationDragEnter += this.OnOperationDragEnter;
            view.Tree.AllowDrop = true;

            // Event subscriptions
            this.eventAggregator.GetEvent<OperationsLibraryLoadMessage>().Subscribe(this.OnOperationsLibraryLoadEvent);
        }

        #endregion

        #region Event Handlers

        /// <summary>The on operation drag drop.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The payload.</param>
        private void OnOperationDragDrop(object sender, EventArgs e)
        {
            var dragEventArgs = e as DragEventArgs;
            if (dragEventArgs != null)
            {
                dragEventArgs.Effect = DragDropEffects.None;
            }
        }

        /// <summary>The on operation drag enter.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">he payload.</param>
        private void OnOperationDragEnter(object sender, EventArgs e)
        {
            var dragEventArgs = e as DragEventArgs;
            if (dragEventArgs != null)
            {
                dragEventArgs.Effect = DragDropEffects.Copy;
            }
        }

        /// <summary>The on operation item drag.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="arg">The payload.</param>
        private void OnOperationItemDrag(object sender, EventArgs arg)
        {
            var e = arg as ItemDragEventArgs;

            // Only allow the operation node to be draggable
            var item = (TreeNode)e?.Item;
            if (item?.Tag == null || item.Tag.GetType() != typeof(MastercamOperation))
            {
                return;
            }

            this.view.Tree.DoDragDrop(e.Item, DragDropEffects.Copy);
        }

        /// <summary>The operations library load event.</summary>
        /// <param name="e">The payload event.</param>
        /// <summary>This event handles loading of the treeview for all operation files selected</summary>
        private void OnOperationsLibraryLoadEvent(OperationsLibraryLoadMessage e)
        {
            var nodes = this.strategyService.LoadOperationData(e.Libraries);
            if (nodes != null)
            {
                FileManager.New(false);

                // Append nodes to the parent node
                this.view.Tree.Nodes[0].Nodes.AddRange(nodes.ToArray());
                this.view.Tree.Nodes[0].Expand();
            }
        }

        /// <summary>The operations view on selection changed.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event args.</param>
        private void OperationsViewOnSelectionChanged(object sender, EventArgs eventArgs)
        {
            var selectedLevel = this.view.SelectedNode;
            if (selectedLevel != null)
            {
                this.eventAggregator.Publish(new OperationSelectedMessage(selectedLevel));
            }
        }

        /// <summary>The operations view on view loaded.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event args.</param>
        private void OperationsViewOnViewLoad(object sender, EventArgs eventArgs)
        {
            this.LoadImages();

            // Create the top node
            var mainNode = new TreeNode(LocalizationStrings.MainNode, (int)TreeIconIndex.OperationGroup, (int)TreeIconIndex.OperationGroup)
            {
                NodeFont = new Font(this.view.Tree.Font, FontStyle.Bold),
            };

            this.view.Tree.Nodes.Add(mainNode);
        }

        #endregion

        #region Private Methods

        /// <summary>The load images.</summary>
        private void LoadImages()
        {
            // Load the images in an ImageList.
            var list = new ImageList();

            // NOTE: Sync order with Tree enum in Globals.cs
            list.Images.Add(Resource.Operations);
            list.Images.Add(Resource.BlockDrill);
            list.Images.Add(Resource.CircleMill);
            list.Images.Add(Resource.Contour);
            list.Images.Add(Resource.Drill);
            list.Images.Add(Resource.Engrave);
            list.Images.Add(Resource.HelixBore);
            list.Images.Add(Resource.Pocket);
            list.Images.Add(Resource.Save);
            list.Images.Add(Resource.SaveAs);
            list.Images.Add(Resource.NewStrategy);
            list.Images.Add(Resource.SlotMill);
            list.Images.Add(Resource.ThreadMill);
            list.Images.Add(Resource.NestingOperation);
            list.Images.Add(Resource.millFlat);
            list.Images.Add(Resource.OperationGroup);
            list.Images.Add(Resource.Arrow);
            list.Images.Add(Resource.Arrow2);
            list.Images.Add(Resource.Params);
            list.Images.Add(Resource.Tree_View_Add);
            list.Images.Add(Resource.Tree_View_Delete);
            list.Images.Add(Resource.MainLevel);

            this.view.Tree.ImageList = list;
        }

        #endregion
    }
}