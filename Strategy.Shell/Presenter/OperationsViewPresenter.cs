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

    using Events;

    using Interfaces;

    using Mastercam.Database.Types;
    using Mastercam.IO;
    using Mastercam.Support;

    using Operations;

    using Reactive.EventAggregator;

    using Services;

    using Strategy.Shell.FunctionTable;
    using Strategy.Shell.Localization;

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
        private IEventAggregator eventAggregator;

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

            // Event subscriptions
            this.eventAggregator.GetEvent<OperationsLibraryLoadEvent>().Subscribe(this.OnOperationsLibraryLoadEvent);
        }

        #endregion

        #region Event Handlers

        /// <summary>The operations library load event.</summary>
        /// <param name="e">The payload event.</param>
        private void OnOperationsLibraryLoadEvent(OperationsLibraryLoadEvent e)
        {
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

                        foreach (var operation in operations.Where(operation => this.OperationTypeSupported(operation.Type) & operation.OperationTool != null))
                        {
                            var thisOperation = new MastercamOperation
                            {
                                Operation = operation,
                                Path = Path.GetFullPath(lib),
                                OperationType = operation.Type,
                                Name = Path.GetFileName(lib)
                            };

                            // Operation Information
                            var comment = new TreeNode("Comment: " + operation.Name);
                            var linkingDepth = new TreeNode("Depth: " + operation.Linking.Depth);
                            var linkingClearance = new TreeNode("Clearance: " + operation.Linking.Clearance);
                            var linkingClearanceOn = new TreeNode("Clearance On: " + operation.Linking.ClearanceOn);
                            var spindleSpeed = new TreeNode("Spindle Speed: " + operation.SpindleSpeed);
                            var feedRate = new TreeNode("FeedRate: " + operation.FeedRate);
                            var plungeRate = new TreeNode("PlungeRate: " + operation.PlungeRate);
                            var diameterOffset = new TreeNode("Diameter Offset: " + operation.DiameterOffset);
                            var tlo = new TreeNode("Length Offset: " + operation.LengthOffset);

                            var operationInformation = new List<TreeNode>
                                                           {
                                                               comment,
                                                               linkingDepth,
                                                               linkingClearance,
                                                               linkingClearanceOn,
                                                               spindleSpeed,
                                                               feedRate,
                                                               plungeRate,
                                                               diameterOffset,
                                                               tlo
                                                           };

                            // Tool information
                            var filename = new TreeNode("File: " + operation.OperationTool.FileName);
                            var mfg = new TreeNode("Name: " + operation.OperationTool.MfgToolCode);
                            var name = new TreeNode("Name: " + operation.OperationTool.Name);
                            var diameter = new TreeNode("Diameter: " + operation.OperationTool.Diameter);
                            var fluteLength = new TreeNode("FluteLength: " + operation.OperationTool.FluteLength);
                            var flutes = new TreeNode("Flutes: " + operation.OperationTool.Flutes);
                            var length = new TreeNode("Length: " + operation.OperationTool.Length);
                            var holderDia = new TreeNode("HolderDia: " + operation.OperationTool.HolderDia);
                            var holderLength = new TreeNode("HolderDia: " + operation.OperationTool.HolderLength);

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

                            // Default to contour
                            var index = 3;
                            switch (thisOperation.Operation.Type)
                            {
                                case OperationType.BlockDrill:
                                    index = 1;
                                    break;

                                case OperationType.CircleMill:
                                    index = 2;
                                    break;

                                case OperationType.Contour:
                                    index = 3;
                                    break;

                                case OperationType.Drill:
                                    index = 4;
                                    break;

                                case OperationType.Engrave:
                                    index = 5;
                                    break;

                                case OperationType.SlotMill:
                                case OperationType.ThreadMill:
                                case OperationType.HelixBore:
                                    index = 6;
                                    break;

                                case OperationType.Pocket:
                                    index = 7;
                                    break;
                            }

                            counter++;
                            var node = new TreeNode($"ID: {counter + ": " + thisOperation.Operation.Type}", index, index) { Tag = thisOperation };

                            var op = new TreeNode("Parameters");
                            var tool = new TreeNode("Tool");

                            op.Nodes.AddRange(operationInformation.ToArray());
                            tool.Nodes.AddRange(toolinformation.ToArray());

                            node.Nodes.Add(op);
                            node.Nodes.Add(tool);

                            nodes.Add(node);
                        }

                        var allnodes = new TreeNode(lib, nodes.ToArray());
                        this.view.MainTreeNode.Nodes.Add(allnodes);
                    }
                }
            }

            FileManager.New(false);
        }

        /// <summary>The operations view on selection changed.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event args.</param>
        private void OperationsViewOnSelectionChanged(object sender, EventArgs eventArgs)
        {

        }

        /// <summary>The operations view on view loaded.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event args.</param>
        private void OperationsViewOnViewLoad(object sender, EventArgs eventArgs)
        {
            // Create the top node
            var mainNode = new TreeNode(LocalizationStrings.MainNode);
            this.view.AddMainTreeNode(mainNode);

            this.LoadImages();
        }

        #endregion

        #region Private Methods

        private void LoadImages()
        {
            // Load the images in an ImageList.
            var list = new ImageList();

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
            list.Images.Add(Resource.AddMaterial);
            list.Images.Add(Resource.AddNewLevel);
            list.Images.Add(Resource.ClearCutlist);
            list.Images.Add(Resource.NewLevelScan);
            list.Images.Add(Resource.NewStrategy);
            list.Images.Add(Resource.Open);
            list.Images.Add(Resource.Options);

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