// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToolbarViewPresenter.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Strategy.Shell.Presenter
{
    using System;
    using System.IO;

    using Events;

    using Interfaces;

    using Localization;

    using Mastercam.IO;
    using Mastercam.Support;

    using Reactive.EventAggregator;

    using Services;

    /// <summary>The toolbar view presenter.</summary>
    public class ToolbarViewPresenter
    {
        #region Fields

        /// <summary>The toolbar button view.</summary>
        private readonly IToolbarButtonView view;

        /// <summary>The msg box service.</summary>
        private readonly IMessageBoxService msgBoxService;

        /// <summary>The file browser service.</summary>
        private readonly IFileBrowserService fileBrowserService;

        /// <summary>The event aggregator.</summary>
        private readonly IEventAggregator eventAggregator;

        #endregion

        #region Construction

        /// <summary>Initializes a new instance of the <see cref="ToolbarViewPresenter"/> class.</summary>
        /// <param name="view">The toolbar button view.</param>
        /// <param name="msgBoxService">The msg box service.</param>
        /// <param name="fileBrowserService">The file browser service.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        public ToolbarViewPresenter(IToolbarButtonView view, IMessageBoxService msgBoxService, IFileBrowserService fileBrowserService, IEventAggregator eventAggregator)
        {
            // Wire up our services
            this.msgBoxService = msgBoxService;
            this.fileBrowserService = fileBrowserService;
            this.eventAggregator = eventAggregator;

            this.view = view;

            view.ViewLoad += this.ViewOnViewLoad;
            view.AddLevel += this.ViewOnAddLevel;
            view.ImportPartLevels += this.ViewOnImportPartLevels;
            view.LevelScan += this.ViewOnLevelScan;
            view.LoadLevelList += this.ViewOnLoadLevelList;
            view.OpenOperationsLibrary += this.ViewOnOpenOperationsLibrary;
            view.RemoveLevel += this.ViewOnRemoveLevel;
            view.SaveLevelList += this.ViewOnSaveLevelList;
        }

        #endregion

        #region Event Handlers

        /// <summary>The toolbar button view on save level list.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event args.</param>
        private void ViewOnSaveLevelList(object sender, EventArgs eventArgs)
        {
            this.msgBoxService.Ok("ViewOnSaveLevelList", string.Empty);
        }

        /// <summary>The toolbar button view on remove level.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event args.</param>
        private void ViewOnRemoveLevel(object sender, EventArgs eventArgs)
        {
            this.msgBoxService.Ok("ViewOnRemoveLevel", string.Empty);
        }

        /// <summary>The toolbar button view on open operations library.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event args.</param>
        private void ViewOnOpenOperationsLibrary(object sender, EventArgs eventArgs)
        {
            // Determine what operations library folder we will open too.
            var libraryLocation = Path.Combine(SettingsManager.SharedDirectory, MachineDefManager.IsCurrentMachineGroupRouter() ? "router\\OPS" : "mill\\Ops");

            // Prompr user to select an operations library
            var operationsLib = this.fileBrowserService.BrowseForFile(this.view.WindowHandle, LocalizationStrings.PromptForOperationsLibrary, Globals.FileFilterOperations, libraryLocation);

            if (File.Exists(operationsLib))
            {
                // Notify our subscribers
                var payload = new OperationsLibraryLoadEvent { Library = operationsLib };
                this.eventAggregator.Publish(payload);
            }
        }

        /// <summary>The toolbar button view on load level list.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event args.</param>
        private void ViewOnLoadLevelList(object sender, EventArgs eventArgs)
        {

        }

        /// <summary>The toolbar button view on level scan.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event args.</param>
        private void ViewOnLevelScan(object sender, EventArgs eventArgs)
        {
            this.msgBoxService.Ok("ViewOnLevelScan", string.Empty);
        }

        /// <summary>The toolbar button view on import part levels.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event args.</param>
        private void ViewOnImportPartLevels(object sender, EventArgs eventArgs)
        {
            this.msgBoxService.Ok("ViewOnImportPartLevels", string.Empty);
        }

        /// <summary>The toolbar button view on add level.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event args.</param>
        private void ViewOnAddLevel(object sender, EventArgs eventArgs)
        {
            this.msgBoxService.Ok("ViewOnAddLevel", string.Empty);
        }

        /// <summary>The toolbar button view on view loaded.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event args.</param>
        private void ViewOnViewLoad(object sender, EventArgs eventArgs)
        {
        }

        #endregion

        #region Private Methods   

        #endregion

    }
}
