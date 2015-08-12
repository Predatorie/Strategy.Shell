// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationsViewPresenter.cs" company="Mick George @Osoy">
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

    using Mastercam.Database.Types;
    using Mastercam.IO;
    using Mastercam.Support;

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

        #endregion

        #region Construction

        /// <summary>Initializes a new instance of the <see cref="OperationsViewPresenter"/> class.</summary>
        /// <param name="view">The view.</param>
        /// <param name="msgBoxService">The msg box service.</param>
        /// <param name="fileBrowserService">The file browser service.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        public OperationsViewPresenter(IOperationsView view, IMessageBoxService msgBoxService, IFileBrowserService fileBrowserService, IEventAggregator eventAggregator)
        {
            // Wire up our services
            this.msgBoxService = msgBoxService;
            this.fileBrowserService = fileBrowserService;
            this.eventAggregator = eventAggregator;

            this.view = view;
            view.ViewLoad += this.OperationsViewOnViewLoad;
            view.SelectionChanged += this.OperationsViewOnSelectionChanged;
            view.Tree.ItemDrag += this.OnOperationItemDrag;
            view.Tree.DragDrop += this.OnOperationDragDrop;
            view.Tree.DragEnter += this.OnOperationDragEnter;
            view.Tree.AllowDrop = true;

            // Event subscriptions
            this.eventAggregator.GetEvent<OperationsLibraryLoadMessage>().Subscribe(this.OnOperationsLibraryLoadEvent);
        }

        #endregion

        #region Event Handlers

        private void OnOperationDragDrop(object sender, DragEventArgs e)
        {
            // TODO: Add code to handle drop
        }

        private void OnOperationDragEnter(object sender, DragEventArgs e)
        {
            e.Effect = DragDropEffects.Copy;
        }

        private void OnOperationItemDrag(object sender, ItemDragEventArgs e)
        {
            // Only allow the operation node to be draggable
            var item = (TreeNode)e.Item;
            if (item?.Tag == null || item.Tag.GetType() != typeof(MastercamOperation))
            {
                return;
            }

            this.view.Tree.DoDragDrop(e.Item, DragDropEffects.Copy);
        }

        /// <summary>The operations library load event.</summary>
        /// <param name="e">The payload event.</param>
        /// <summary> This event handles loading of the treeview for all operation files selected</summary>
        private void OnOperationsLibraryLoadEvent(OperationsLibraryLoadMessage e)
        {
            var totalOperations = 0;

            // Iterate all libraries
            foreach (var lib in e.Libraries)
            {
                FileManager.New(false);
                if (FileManager.Open(lib))
                {
                    var operations = SearchManager.GetOperations();
                    if (operations.Any())
                    {
                        var nodes = new List<TreeNode>();
                        var counter = 0;

                        // Only supported operations and those with a valid tool
                        foreach (var operation in operations.Where(operation => this.OperationTypeSupported(operation.Type) & operation.OperationTool != null))
                        {
                            totalOperations++;

                            var thisOperation = new MastercamOperation
                            {
                                Operation = operation,
                                Path = Path.GetFullPath(lib),
                                OperationType = operation.Type,
                                Name = Path.GetFileName(lib)
                            };

                            // Operation Information TODO: Localize
                            var linkingDepth = new TreeNode("Depth = " + operation.Linking.Depth, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);
                            var linkingClearance = new TreeNode("Clearance = " + operation.Linking.Clearance, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);
                            var linkingClearanceOn = new TreeNode("Clearance On = " + operation.Linking.ClearanceOn, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);
                            var spindleSpeed = new TreeNode("Spindle Speed = " + operation.SpindleSpeed, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);
                            var feedRate = new TreeNode("FeedRate = " + operation.FeedRate, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);
                            var plungeRate = new TreeNode("PlungeRate = " + operation.PlungeRate, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);
                            var diameterOffset = new TreeNode("Diameter Offset = " + operation.DiameterOffset, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);
                            var tlo = new TreeNode("Length Offset = " + operation.LengthOffset, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);

                            var operationInformation = new List<TreeNode>
                                                           {
                                                               linkingDepth,
                                                               linkingClearance,
                                                               linkingClearanceOn,
                                                               spindleSpeed,
                                                               feedRate,
                                                               plungeRate,
                                                               diameterOffset,
                                                               tlo
                                                           };

                            // Tool information TODO = Localize
                            var filename = new TreeNode("File = " + operation.OperationTool.FileName, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);
                            var mfg = new TreeNode("Manufacture Code = " + operation.OperationTool.MfgToolCode, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);
                            var name = new TreeNode("Name = " + operation.OperationTool.Name, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);
                            var diameter = new TreeNode("Diameter = " + operation.OperationTool.Diameter, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);
                            var fluteLength = new TreeNode("FluteLength = " + operation.OperationTool.FluteLength, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);
                            var flutes = new TreeNode("Flutes = " + operation.OperationTool.Flutes, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);
                            var length = new TreeNode("Length = " + operation.OperationTool.Length, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);
                            var holderDia = new TreeNode("HolderDia = " + operation.OperationTool.HolderDia, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);
                            var holderLength = new TreeNode("HolderDia = " + operation.OperationTool.HolderLength, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);

                            var toolinformation = new List<TreeNode>
                                           {
                                               filename,
                                               mfg,
                                               name,
                                               diameter,
                                               fluteLength,
                                               flutes,
                                               length,
                                               holderDia,
                                               holderLength
                                           };

                            var index = (int)TreeIconIndex.MillFlat;
                            switch (thisOperation.Operation.Type)
                            {
                                case OperationType.BlockDrill:
                                    index = (int)TreeIconIndex.BlockDrill;
                                    break;

                                case OperationType.CircleMill:
                                    index = (int)TreeIconIndex.CircleMill;
                                    break;

                                case OperationType.Contour:
                                    index = (int)TreeIconIndex.Contour;
                                    break;

                                case OperationType.Drill:
                                    index = (int)TreeIconIndex.Drill;
                                    break;

                                case OperationType.Engrave:
                                    index = (int)TreeIconIndex.Engrave;
                                    break;

                                case OperationType.HelixBore:
                                    index = (int)TreeIconIndex.HelixBore;
                                    break;

                                case OperationType.Pocket:
                                    index = (int)TreeIconIndex.Pocket;
                                    break;

                                case OperationType.SlotMill:
                                    index = (int)TreeIconIndex.SlotMill;
                                    break;

                                case OperationType.ThreadMill:
                                    index = (int)TreeIconIndex.ThreadMill;
                                    break;

                                case OperationType.Nesting:
                                    index = (int)TreeIconIndex.NestingOperation;
                                    break;
                            }

                            counter++;
                            var node = new TreeNode($"ID:{counter + " = " + thisOperation.Operation.Type + " - " + operation.Name}", index, index)
                            {
                                Tag = thisOperation,
                                NodeFont = new Font(this.view.Tree.Font, FontStyle.Bold)
                            };

                            // TODO: Localize
                            var op = new TreeNode("Params", (int)TreeIconIndex.Params, (int)TreeIconIndex.Params);
                            var tool = new TreeNode("Tool", (int)TreeIconIndex.MillFlat, (int)TreeIconIndex.MillFlat);

                            op.Nodes.AddRange(operationInformation.ToArray());
                            tool.Nodes.AddRange(toolinformation.ToArray());

                            node.Nodes.Add(op);
                            node.Nodes.Add(tool);

                            nodes.Add(node);
                        }

                        var allnodes = new TreeNode(lib, nodes.ToArray());
                        allnodes.Expand();

                        // Append nodes to the parent node
                        this.view.Tree.Nodes[0].Nodes.Add(allnodes);
                    }
                }
            }

            FileManager.New(false);

            this.view.Tree.Nodes[0].Expand();

            this.msgBoxService.Ok(
                totalOperations > 0 ? $"{totalOperations} " + LocalizationStrings.OperationsLoaded : LocalizationStrings.NoOperationsLoaded,
                LocalizationStrings.Title);
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
                NodeFont = new Font(this.view.Tree.Font, FontStyle.Bold)
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

        /// <summary>The is operation type supported at this time.</summary>
        /// <param name="operationType">The operation type.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        private bool OperationTypeSupported(OperationType operationType)
        {
            switch ((int)operationType)
            {
                case (int)OperationType.Contour:
                case (int)OperationType.Pocket:
                case (int)OperationType.Drill:
                case (int)OperationType.BlockDrill:
                case (int)OperationType.CircleMill:
                case (int)OperationType.HelixBore:
                case (int)OperationType.Engrave:
                case (int)OperationType.ThreadMill:
                case (int)OperationType.OnionSkinning:
                case (int)OperationType.SlotMill:
                    return true;

                default:
                    return false;
            }
        }

        #endregion
    }
}