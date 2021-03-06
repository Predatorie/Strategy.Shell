﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpenLevelsCommand.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the OpenLevelsFileCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Commands
{
    using System.Linq;

    using Events;

    using FunctionTable;

    using Localization;

    using Reactive.EventAggregator;

    using Services;

    /// <summary>The open levels file command.</summary>
    public class OpenLevelsCommand : CommandBase
    {
        /// <summary>The event aggregator.</summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>The file browser service.</summary>
        private readonly IFileBrowserService fileBrowserService;

        /// <summary>Initializes a new instance of the <see cref="OpenLevelsCommand"/> class.</summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="fileBrowserService">The file browser service.</param>
        public OpenLevelsCommand(IEventAggregator eventAggregator, IFileBrowserService fileBrowserService)
        {
            this.eventAggregator = eventAggregator;
            this.fileBrowserService = fileBrowserService;

            this.Icon = Resource.AddNewLevel;
            this.ToolTip = LocalizationStrings.OpenLevels;
            this.CanExecute = true;
        }

        /// <summary>The execute.</summary>
        public override void Execute()
        {
            var filepath = this.fileBrowserService.BrowseForFile(this.Parent, LocalizationStrings.Title, Globals.FileFilterXml, Globals.LevelsFolder, false);

            if (!filepath.Any())
            {
                return;
            }

            this.eventAggregator.Publish(new OpenLevelsMessage { FilePath = filepath[0] });
        }
    }
}