// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationsViewPresenter.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Strategy.Shell.Presenter
{
    using System;
    using System.Linq;

    using Events;

    using Interfaces;

    using Mastercam.Database.Types;
    using Mastercam.IO;
    using Mastercam.Support;

    using Operations;

    using Reactive.EventAggregator;

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
            // Clear memory to be safe
            FileManager.New(false);

            if (!FileManager.Open(e.Library))
            {
                return;
            }

            var operations = SearchManager.GetOperations();

            if (operations.Any())
            {
                foreach (var operation in operations.Where(operation => this.OperationTypeSupported(operation.Type)))
                {
                    var thisOperation = new MastercamOperation { Operation = operation };

                    // TODO: Build tree, async?
                }
            }
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

        }

        #endregion

        #region Private Methods

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