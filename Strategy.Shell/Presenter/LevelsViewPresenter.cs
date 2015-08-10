// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LevelsViewPresenter.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Presenter
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    using Events;

    using FunctionTable;

    using Interfaces;

    using Localization;

    using Reactive.EventAggregator;

    using Services;

    /// <summary>The levels view presenter.</summary>
    public class LevelsViewPresenter
    {
        #region Fields

        /// <summary>The toolbar button view.</summary>
        private readonly ILevelsView view;

        /// <summary>The msg box service.</summary>
        private readonly IMessageBoxService msgBoxService;

        /// <summary>The file browser service.</summary>
        private readonly IFileBrowserService fileBrowserService;

        /// <summary>The event aggregator.</summary>
        private IEventAggregator eventAggregator;

        /// <summary>The file manager service.</summary>
        private IFileManagerService fileManagerService;

        #endregion

        #region Construction

        /// <summary>Initializes a new instance of the <see cref="LevelsViewPresenter"/> class.</summary>
        /// <param name="view">The view.</param>
        /// <param name="msgBoxService">The msg box service.</param>
        /// <param name="fileBrowserService">The file browser service.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="fileManagerService">The file Manager Service.</param>
        public LevelsViewPresenter(
            ILevelsView view, 
            IMessageBoxService msgBoxService, 
            IFileBrowserService fileBrowserService, 
            IEventAggregator eventAggregator, 
            IFileManagerService fileManagerService)
        {
            // Wire up our services
            this.msgBoxService = msgBoxService;
            this.fileBrowserService = fileBrowserService;
            this.eventAggregator = eventAggregator;
            this.fileManagerService = fileManagerService;

            this.view = view;
            view.ViewLoad += this.LevelsViewOnViewLoad;
            view.SelectionChanged += this.LevelsViewOnSelectionChanged;

            this.eventAggregator.GetEvent<SaveLevelsEvent>().Subscribe(this.OnSaveLevels);
            this.eventAggregator.GetEvent<AddLevelEvent>().Subscribe(this.OnAddLevel);
            this.eventAggregator.GetEvent<RemoveLevelEvent>().Subscribe(this.OnRemoveLevel);
        }

        #endregion

        #region Event Handlers

        /// <summary>The levels view on selection changed.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event args.</param>
        private void LevelsViewOnSelectionChanged(object sender, EventArgs eventArgs)
        {
        }

        /// <summary>The levels view on view loaded.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event args.</param>
        private void LevelsViewOnViewLoad(object sender, EventArgs eventArgs)
        {
            this.LoadImages();

            // Create the top node
            var mainNode = new TreeNode(LocalizationStrings.MainLevelsNode, (int)LevelsTreeIconIndex.MainLevel, (int)LevelsTreeIconIndex.MainLevel)
            {
                NodeFont = new Font(this.view.Tree.Font, FontStyle.Bold)
            };

            this.view.Tree.Nodes.Add(mainNode);
        }

        #endregion

        #region Private Methods

        /// <summary>The on remove level.</summary>
        /// <param name="e">The e.</param>
        private void OnRemoveLevel(RemoveLevelEvent e)
        {
            // Test for main node...?
            this.view.Tree.Nodes[0].Nodes.Remove(e.Level);
        }

        /// <summary>The on add level.</summary>
        /// <param name="e">The e.</param>
        private void OnAddLevel(AddLevelEvent e)
        {
            // Get the count of nodes below the main node
            var count = this.view.Tree.Nodes[0].Nodes.Count + 1;
            var level = new TreeNode(LocalizationStrings.NewLevelName + " " + count);
            this.view.Tree.Nodes[0].Nodes.Add(level);
        }

        /// <summary>The on save levels.</summary>
        /// <param name="e">The e.</param>
        private void OnSaveLevels(SaveLevelsEvent e)
        {
            // TODO: Prompt for file name and save the levels to disk
            var levels = this.view.Tree.Nodes[0].Nodes;

            if (levels.Count > 0)
            {
                foreach (TreeNode level in levels)
                {

                }
            }

            //// TODO: Iterated all levels/Operations add to list

            //// TODO: Serialize list
        }

        /// <summary>The load images.</summary>
        private void LoadImages()
        {
            // Load the images in an ImageList.
            var list = new ImageList();

            // NOTE: Sync order with Operations Tree enum in Globals.cs
            list.Images.Add(Resource.MainLevel);
            list.Images.Add(Resource.BlockDrill);
            list.Images.Add(Resource.CircleMill);
            list.Images.Add(Resource.Contour);
            list.Images.Add(Resource.Drill);
            list.Images.Add(Resource.Engrave);
            list.Images.Add(Resource.HelixBore);
            list.Images.Add(Resource.Pocket);
            list.Images.Add(Resource.SlotMill);
            list.Images.Add(Resource.ThreadMill);
            list.Images.Add(Resource.NestingOperation);
            list.Images.Add(Resource.Tree_View_Add);
            list.Images.Add(Resource.Tree_View_Delete);

            this.view.Tree.ImageList = list;
        }

        #endregion
    }
}