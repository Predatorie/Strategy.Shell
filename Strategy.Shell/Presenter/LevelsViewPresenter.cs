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

    using Mastercam.IO;

    using Reactive.EventAggregator;

    using Events;
    using FunctionTable;
    using Interfaces;
    using Localization;
    using Models;
    using Operations;
    using Services;

    /// <summary>The levels view presenter.</summary>
    public class LevelsViewPresenter
    {
        #region Fields

        /// <summary>The file manager service.</summary>
        private readonly IFileManagerService fileManagerService;

        /// <summary>The toolbar button view.</summary>
        private readonly ILevelsView view;

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

        /// <summary>Initializes a new instance of the <see cref="LevelsViewPresenter"/> class.</summary>
        /// <param name="view">The view.</param>
        /// <param name="msgBoxService">The msg box service.</param>
        /// <param name="fileBrowserService">The file browser service.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="fileManagerService">The file Manager Service.</param>
        /// <param name="strategyService"></param>
        public LevelsViewPresenter(
            ILevelsView view,
            IMessageBoxService msgBoxService,
            IFileBrowserService fileBrowserService,
            IEventAggregator eventAggregator,
            IFileManagerService fileManagerService,
            IStrategyService strategyService)
        {
            // Wire up our services
            this.msgBoxService = msgBoxService;
            this.fileBrowserService = fileBrowserService;
            this.fileManagerService = fileManagerService;
            this.eventAggregator = eventAggregator;
            this.strategyService = strategyService;

            this.view = view;
            view.ViewLoad += this.LevelsViewOnViewLoad;
            view.SelectionChanged += this.LevelsViewOnSelectionChanged;
            view.Tree.ItemDrag += this.OnLevelItemDrag;
            view.Tree.DragDrop += this.OnLevelDragDrop;
            view.Tree.DragEnter += this.OnLevelDragEnter;
            view.Tree.AllowDrop = true;

            this.eventAggregator.GetEvent<SaveLevelsMessage>().Subscribe(this.OnSaveLevels);
            this.eventAggregator.GetEvent<AddLevelMessage>().Subscribe(this.OnAddLevel);
            this.eventAggregator.GetEvent<RemoveLevelMessage>().Subscribe(this.OnRemoveLevel);
            this.eventAggregator.GetEvent<OpenPartMessage>().Subscribe(this.OnOpenParts);
            this.eventAggregator.GetEvent<SaveStrategyMessage>().Subscribe(this.OnSaveStrategyEvent);
            this.eventAggregator.GetEvent<OpenStrategyMessage>().Subscribe(this.OnLoadStrategyEvent);
            this.eventAggregator.GetEvent<OpenLevelsMessage>().Subscribe(this.OnOpenLevelsEvent);
        }

        #endregion

        #region Event Handlers

        private void OnOpenLevelsEvent(OpenLevelsMessage e)
        {
            var levels = this.fileManagerService.DeserializeObject<Levels>(e.FilePath);
            if (levels == null)
            {
                return;
            }

            // Filter out duplicates from tree
            foreach (var node in levels.List.Select(level => new TreeNode(level) { Tag = "level" }))
            {
                if (this.view.Tree.Nodes[0].Nodes.Count > 0)
                {
                    if (this.view.Tree.Nodes[0].Nodes.Cast<TreeNode>().FirstOrDefault(n => n.Text == node.Text) == null)
                    {
                        this.AddLevel(node);
                    }
                }
                else
                {
                    this.AddLevel(node);
                }
            }

            this.view.Tree.Nodes[0].Expand();
        }

        /// <summary>The on save strategy event.</summary>
        /// <param name="e">The e.</param>
        private void OnSaveStrategyEvent(SaveStrategyMessage e)
        {
            var nodes = this.view.Tree.Nodes[0].Nodes;
            if (nodes.Count > 1)
            {
                var strategy = new Strategy { Name = e.Name, MappedLevels = new List<Mapping>() };

                // Iterate each level
                foreach (TreeNode level in nodes)
                {
                    var operations = level.Nodes;
                    if (operations.Count > 0)
                    {
                        var mapping = new Mapping();

                        // Iterate each operation for this level
                        foreach (TreeNode operation in operations)
                        {
                            var op = (MastercamOperation)operation.Tag;

                            // Keep the operation in sync with the lib it belongs too
                            mapping.Comment = operation.Text;
                            mapping.Library = op.Path;
                            mapping.Level = level.Text;

                            strategy.MappedLevels.Add(mapping);
                        }
                    }
                }

                // Serialize the strategy to disk
                if (this.fileManagerService.SerializeObject(strategy.Name, strategy))
                {
                    this.msgBoxService.Ok(LocalizationStrings.StrategySaved, LocalizationStrings.Title);
                }
            }
        }

        /// <summary>The on load strategy event.</summary>
        /// <param name="e">The e.</param>
        private void OnLoadStrategyEvent(OpenStrategyMessage e)
        {
            if (!File.Exists(e.Name))
            {
                return;
            }

            var strategy = this.fileManagerService.DeserializeObject<Strategy>(e.Name);
            if (strategy != null)
            {
                var node = this.strategyService.LoadStrategyData(strategy);
                if (node != null)
                {
                    this.view.Tree.Nodes.Clear();
                    this.CreateMainNode();

                    this.view.Tree.Nodes[0].Nodes.AddRange(node.ToArray());
                    this.view.Tree.Nodes[0].Expand();
                }
            }
        }

        /// <summary>The on level drag drop.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void OnLevelDragDrop(object sender, DragEventArgs e)
        {
            var node = (TreeNode)e.Data.GetData(typeof(TreeNode));

            if (node?.Tag != null)
            {
                if (node.Tag.GetType() == typeof(MastercamOperation))
                {
                    // Retrieve the client coordinates of the drop location.
                    var targetPoint = this.view.Tree.PointToClient(new Point(e.X, e.Y));

                    // Retrieve the node at the drop location.
                    var targetNode = this.view.Tree.GetNodeAt(targetPoint);

                    // Retrieve the node that was dragged.
                    var draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

                    // Confirm that the node at the drop location is not 
                    // the dragged node and that target node isn't null
                    // (for example if you drag outside the control)
                    // Also can't drop on the top level
                    if (!draggedNode.Equals(targetNode) && targetNode != null &&
                        targetNode.Tag?.GetType() != typeof(MastercamOperation) &&
                        targetNode.Level != 0)
                    {
                        var clone = (TreeNode)draggedNode.Clone();

                        // If we moving delete the original node
                        if (e.Effect == DragDropEffects.Move)
                        {
                            draggedNode.Remove();
                        }

                        targetNode.Nodes.Add(clone);

                        // Expand the node at the location to show the dropped node.
                        targetNode.Expand();
                    }
                }
            }
        }

        /// <summary>The on level drag enter.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void OnLevelDragEnter(object sender, DragEventArgs e)
        {
            var draggedNode = (TreeNode)e.Data.GetData(typeof(TreeNode));

            if (draggedNode.Parent?.Parent != null)
            {
                e.Effect = draggedNode.Parent.Parent.Text == LocalizationStrings.MainNode ? DragDropEffects.Copy : DragDropEffects.Move;
            }
        }

        /// <summary>The on level item drag.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="e">The e.</param>
        private void OnLevelItemDrag(object sender, ItemDragEventArgs e)
        {
            // Only allow the operation node to be draggable
            var item = (TreeNode)e.Item;

            if (item.Parent?.Parent != null)
            {
                if (item.Parent?.Parent.Text == LocalizationStrings.MainLevelsNode)
                {
                    this.view.Tree.DoDragDrop(e.Item, DragDropEffects.Move);
                }
            }
        }

        /// <summary>The levels view on selection changed.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event args.</param>
        private void LevelsViewOnSelectionChanged(object sender, EventArgs eventArgs)
        {
            var selectedLevel = this.view.SelectedNode;
            this.eventAggregator.Publish(new LevelSelectedMessage(selectedLevel));
        }

        /// <summary>The levels view on view loaded.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event args.</param>
        private void LevelsViewOnViewLoad(object sender, EventArgs eventArgs)
        {
            this.LoadImages();
            this.CreateMainNode();
        }

        #endregion

        #region Private Methods

        /// <summary>The create main node.</summary>
        private void CreateMainNode()
        {
            this.view.Tree.Nodes.Clear();

            // Create the top node
            var mainNode = new TreeNode(LocalizationStrings.MainLevelsNode, (int)TreeIconIndex.MainLevel, (int)TreeIconIndex.MainLevel)
            {
                NodeFont = new Font(this.view.Tree.Font, FontStyle.Bold),
                Tag = "main"
            };

            this.view.Tree.Nodes.Add(mainNode);
            this.view.Tree.LabelEdit = true;
        }

        /// <summary>The on remove level.</summary>
        /// <param name="e">The e.</param>
        private void OnRemoveLevel(RemoveLevelMessage e)
        {
            // Test for main node
            if (e.Level.Tag != null && e.Level.Tag.ToString() == "main")
            {
                return;
            }

            this.view.Tree.Nodes[0].Nodes.Remove(e.Level);
        }

        /// <summary>The on add level.</summary>
        /// <param name="e">The e.</param>
        private void OnAddLevel(AddLevelMessage e)
        {
            // Get the count of nodes below the main node
            var count = this.view.Tree.Nodes[0].Nodes.Count + 1;
            var level = new TreeNode(LocalizationStrings.NewLevelName + " " + count) { Tag = "level" };

            this.AddLevel(level);
            this.view.Tree.Nodes[0].Expand();

        }

        /// <summary>The on save levels.</summary>
        /// <param name="e">The e.</param>
        private void OnSaveLevels(SaveLevelsMessage e)
        {
            var levels = this.view.Tree.Nodes[0].Nodes;
            if (levels.Count > 0)
            {
                var levelsList = new Levels { Name = e.FilePath };
                foreach (TreeNode level in levels)
                {
                    levelsList.List.Add(level.Text);
                }

                this.fileManagerService.SerializeObject(levelsList.Name, levelsList);
            }
        }

        /// <summary>The on open parts.</summary>
        /// <param name="e">The e.</param>
        private void OnOpenParts(OpenPartMessage e)
        {
            // Cache current file if there is one open
            var currentFile = FileManager.CurrentFileName;

            var levelsToAdd = new List<string>();

            foreach (var file in e.FilePath)
            {
                if (FileManager.Open(file))
                {
                    var indexes = LevelsManager.GetLevelNumbersWithNames();

                    if (!indexes.Any())
                    {
                        continue;
                    }

                    levelsToAdd.AddRange(indexes.Select(LevelsManager.GetLevelName));
                }
            }

            if (levelsToAdd.Any())
            {
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
                    // Filter out duplicate names already in our tree
                    foreach (var node in treeLevels.Cast<TreeNode>().Where(node => distinctList.Contains(node.Text)))
                    {
                        distinctList.Remove(node.Text);
                    }

                    // Finally add our new level nodes
                    foreach (var level in distinctList)
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

                this.view.Tree.Nodes[0].Expand();
            }
        }

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