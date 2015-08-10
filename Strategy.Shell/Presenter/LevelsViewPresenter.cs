// --------------------------------------------------------------------------------------------------------------------
// <copyright file="LevelsViewPresenter.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Presenter
{
    using System;
    using System.Collections.Generic;
    using System.Drawing;
    using System.IO;
    using System.Linq;
    using System.Windows.Forms;
    using System.Windows.Forms.VisualStyles;

    using Events;

    using FunctionTable;

    using Interfaces;

    using Localization;

    using Mastercam.IO;

    using Reactive.EventAggregator;

    using Services;

    using Strategy.Shell.Models;

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
            this.eventAggregator.GetEvent<OpenPartEvent>().Subscribe(this.OnOpenParts);
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
                NodeFont = new Font(this.view.Tree.Font, FontStyle.Bold),
                Tag = "main"
            };

            this.view.Tree.Nodes.Add(mainNode);
            this.view.Tree.LabelEdit = true;
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

            this.AddLevel(level);
        }

        /// <summary>The on save levels.</summary>
        /// <param name="e">The e.</param>
        private void OnSaveLevels(SaveLevelsEvent e)
        {
            // TODO: Prompt for file name and save the levels to disk
            var levels = this.view.Tree.Nodes[0].Nodes;

            if (levels.Count > 0)
            {
                var filename = Mastercam.IO.SettingsManager.SharedDirectory + "\\text.xml";
                var levelsList = new Levels { Name = filename };

                foreach (TreeNode level in levels)
                {
                    levelsList.List.Add(level.Text);
                }

                this.fileManagerService.WriteObject(levelsList.Name, levelsList);
            }
        }

        /// <summary>The on open parts.</summary>
        /// <param name="e">The e.</param>
        private void OnOpenParts(OpenPartEvent e)
        {
            // Cache current file if there is one open
            var currentFile = FileManager.CurrentFileName;

            var levelsToAdd = new List<string>();

            // Open all selected files and add levels to our list
            foreach (var listOfNamedLevels in
                e.FilePath.Where(FileManager.Open).Select(file => LevelsManager.GetLevelNumbersWithNames()).Where(listOfNamedLevels => listOfNamedLevels.Any()))
            {
                levelsToAdd = listOfNamedLevels.Select(LevelsManager.GetLevelName).ToList();
            }

            // Sort the levels
            levelsToAdd.Sort();

            var distinctList = new List<string>();
            var previous = string.Empty;

            // Filter out duplicate names
            foreach (var name in levelsToAdd)
            {
                if (name != previous)
                {
                    distinctList.Add(name);
                }

                previous = name;
            }

            // Get the main node
            var treeLevels = this.view.Tree.Nodes[0].Nodes;
            if (treeLevels.Count > 0)
            {
                // TODO: Fix this as its failing. Filter out duplicate names already in our tree
                foreach (var level in distinctList.Where(level => !treeLevels.Find(level, true).Any()))
                {
                    this.AddLevel(new TreeNode(level));
                }
            }
            else
            {
                // Ok to add as is
                foreach (var level in distinctList)
                {
                    this.AddLevel(new TreeNode(level));
                }
            }

            // Re-open previous file
            if (File.Exists(currentFile))
            {
                FileManager.Open(currentFile);
            }
            else
            {
                FileManager.New();
            }
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

        /// <summary>The add level.</summary>
        /// <param name="name">The name.</param>
        /// <returns>The <see cref="int"/>.</returns>
        private int AddLevel(TreeNode name)
        {
            return this.view.Tree.Nodes[0].Nodes.Add(name);
        }

        #endregion
    }
}