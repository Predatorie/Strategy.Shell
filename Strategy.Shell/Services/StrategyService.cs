// --------------------------------------------------------------------------------------------------------------------
// <copyright file="StrategyService.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Services
{
    using System.Collections.Generic;
    using System.IO;
    using System.Linq;
    using System.Runtime.Serialization;
    using System.Text;
    using System.Windows.Forms;
    using System.Xml;

    using Mastercam.Database;
    using Mastercam.Database.Types;
    using Mastercam.IO;
    using Mastercam.Operations;
    using Mastercam.Support;

    using Strategy.Shell.Localization;
    using Strategy.Shell.Models;
    using Strategy.Shell.Operations;

    /// <summary>The strategy service.</summary>
    public class StrategyService : IStrategyService
    {
        /// <summary>The serialize.</summary>
        /// <param name="strategy">The strategy.</param>
        /// <returns>The <see cref="bool"/>.</returns>
        public bool Serialize(Strategy strategy)
        {
            // TODO: Tokenize paths

            // Avoiding mutliple using's here, see-> CA2202: Do not dispose objects multiple times
            XmlWriter xmlWriter = null;
            try
            {
                xmlWriter = XmlWriter.Create(
                    strategy.Name, 
                    new XmlWriterSettings { Encoding = Encoding.UTF8, CloseOutput = false, Indent = true });
                using (var dictionaryWriter = XmlDictionaryWriter.CreateDictionaryWriter(xmlWriter))
                {
                    var serializer = new DataContractSerializer(typeof(Strategy));
                    serializer.WriteObject(dictionaryWriter, strategy);
                }
            }
            catch
            {
                //// TODO: Implement Logging
                return false;
            }
            finally
            {
                xmlWriter?.Dispose();
            }

            return true;
        }

        /// <summary>The deserialize.</summary>
        /// <param name="filepath">The filepath.</param>
        /// <returns>The <see cref="Strategy"/>.</returns>
        public Strategy Deserialize(string filepath)
        {
            Stream stream = null;
            try
            {
                stream = new FileStream(filepath, FileMode.Open, FileAccess.Read, FileShare.Read);
                using (var xmlReader = XmlDictionaryReader.CreateTextReader(stream, new XmlDictionaryReaderQuotas()))
                {
                    var serializer = new DataContractSerializer(typeof(Strategy));
                    return serializer.ReadObject(xmlReader) as Strategy;
                }
            }
            finally
            {
                stream?.Dispose();
            }
        }

        /// <summary>The load operation data.</summary>
        /// <param name="libraries">The libraries.</param>
        /// <returns>The <see cref="TreeNode"/>.</returns>
        public TreeNode LoadOperationData(List<string> libraries)
        {
            var nodes = new List<TreeNode>();

            // Iterate all libraries
            foreach (var lib in libraries)
            {
                FileManager.New(false);
                if (FileManager.Open(lib))
                {
                    var operations = SearchManager.GetOperations();
                    if (operations.Any())
                    {
                        // Only supported operations and those with a valid tool
                        foreach (var operation in operations.Where(operation => this.OperationTypeSupported(operation.Type) & operation.OperationTool != null))
                        {
                            var thisOperation = new MastercamOperation
                            {
                                Operation = operation, 
                                Path = Path.GetFullPath(lib), 
                                OperationType = operation.Type, 
                                Name = Path.GetFileName(lib)
                            };

                            var operationInformation = this.CreateOperationList(operation);
                            var toolinformation = this.CreateToolList(operation);

                            var index = this.GetToolIconIndex(thisOperation);
                            var node = new TreeNode(operation.Name, index, index) { Tag = thisOperation, };

                            var op = new TreeNode(operation.Type.ToString(), (int)TreeIconIndex.Params, (int)TreeIconIndex.Params);
                            var tool = new TreeNode(LocalizationStrings.Tool, (int)TreeIconIndex.MillFlat, (int)TreeIconIndex.MillFlat);

                            op.Nodes.AddRange(operationInformation.ToArray());
                            tool.Nodes.AddRange(toolinformation.ToArray());

                            node.Nodes.Add(op);
                            node.Nodes.Add(tool);

                            nodes.Add(node);
                        }
                    }
                }

                if (nodes.Any())
                {
                    return new TreeNode(lib, nodes.ToArray());
                }
            }

            return null;
        }

        /// <summary>Loads a strategy object into the Levels tree</summary>
        /// <param name="strategy"></param>
        /// <returns>The <see cref="TreeNode"/>.</returns>
        public TreeNode LoadStrategyData(Strategy strategy)
        {
            var nodes = new List<TreeNode>();

            foreach (var mapping in strategy.MappedLevels)
            {
                var lib = mapping.Library;
                if (File.Exists(lib))
                {
                    FileManager.New(false);
                    if (FileManager.Open(lib))
                    {
                        var operations = SearchManager.GetOperations();
                        if (operations.Any())
                        {
                            var opName = mapping.Comment;
                            var operation = OperationsManager.ImportOperation(lib, opName, false);
                            if (operation != null)
                            {
                                var thisOperation = new MastercamOperation
                                {
                                    Operation = operation, 
                                    Path = Path.GetFullPath(lib), 
                                    OperationType = operation.Type, 
                                    Name = Path.GetFileName(lib)
                                };

                                var operationInformation = this.CreateOperationList(operation);
                                var toolinformation = this.CreateToolList(operation);

                                var index = this.GetToolIconIndex(thisOperation);
                                var node = new TreeNode(operation.Name, index, index) { Tag = thisOperation, };
                                var op = new TreeNode(operation.Type.ToString(), (int)TreeIconIndex.Params, (int)TreeIconIndex.Params);
                                var tool = new TreeNode(LocalizationStrings.Tool, (int)TreeIconIndex.MillFlat, (int)TreeIconIndex.MillFlat);

                                op.Nodes.AddRange(operationInformation.ToArray());
                                tool.Nodes.AddRange(toolinformation.ToArray());

                                node.Nodes.Add(op);
                                node.Nodes.Add(tool);

                                nodes.Add(node);
                            }
                        }

                        if (nodes.Any())
                        {
                            return new TreeNode(lib, nodes.ToArray());
                        }
                    }
                }
            }

            return null;
        }

        #region Private Methods

        /// <summary>The get tool icon index.</summary>
        /// <param name="thisOperation">The this operation.</param>
        /// <returns>The <see cref="int"/>.</returns>
        private int GetToolIconIndex(IMastercamOperation thisOperation)
        {
            var index = 14;

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

            return index;
        }

        /// <summary>The create tool list.</summary>
        /// <param name="operation">The operation.</param>
        /// <returns>The <see cref="List"/>.</returns>
        private List<TreeNode> CreateToolList(Operation operation)
        {
            // Tool information TODO = Localize
            var filename = new TreeNode("File = " + operation.OperationTool.FileName, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);
            var mfg = new TreeNode("Manufacture Code = " + operation.OperationTool.MfgToolCode, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);
            var name = new TreeNode("Name = " + operation.OperationTool.Name, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);
            var diameter = new TreeNode("Diameter = " + operation.OperationTool.Diameter, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);
            var fluteLength = new TreeNode("FluteLength = " + operation.OperationTool.FluteLength, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);
            var flutes = new TreeNode("Flutes = " + operation.OperationTool.Flutes, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);
            var length = new TreeNode("Length = " + operation.OperationTool.Length, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);
            var holderDia = new TreeNode("Holder Diameter = " + operation.OperationTool.HolderDia, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);
            var holderLength = new TreeNode("Holder Length = " + operation.OperationTool.HolderLength, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);

            return new List<TreeNode>
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
        }

        /// <summary>The create operation list.</summary>
        /// <param name="operation">The operation.</param>
        /// <returns>The <see cref="List"/>.</returns>
        private List<TreeNode> CreateOperationList(Operation operation)
        {
            // Operation Information TODO: Localize
            var linkingDepth = new TreeNode("Depth = " + operation.Linking.Depth, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);
            var linkingClearance = new TreeNode("Clearance = " + operation.Linking.Clearance, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);
            var linkingClearanceOn = new TreeNode("Clearance On = " + operation.Linking.ClearanceOn, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);
            var spindleSpeed = new TreeNode("Spindle Speed = " + operation.SpindleSpeed, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);
            var feedRate = new TreeNode("FeedRate = " + operation.FeedRate, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);
            var plungeRate = new TreeNode("PlungeRate = " + operation.PlungeRate, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);
            var diameterOffset = new TreeNode("Diameter Offset = " + operation.DiameterOffset, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);
            var tlo = new TreeNode("Length Offset = " + operation.LengthOffset, (int)TreeIconIndex.Arrow2, (int)TreeIconIndex.Arrow2);

            return new List<TreeNode>
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