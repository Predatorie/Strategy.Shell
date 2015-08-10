// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpenPartLevelsCommand.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the OpenPartLevelsCommand type.
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

    /// <summary>The open part levels command.</summary>
    public class OpenPartLevelsCommand : CommandBase
    {
        /// <summary>The event aggregator.</summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>The file browser service.</summary>
        private readonly IFileBrowserService fileBrowserService;

        /// <summary>Initializes a new instance of the <see cref="OpenPartLevelsCommand"/> class.</summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="fileBrowserService">The file browser service.</param>
        public OpenPartLevelsCommand(IEventAggregator eventAggregator, IFileBrowserService fileBrowserService)
        {
            this.eventAggregator = eventAggregator;
            this.fileBrowserService = fileBrowserService;

            this.Icon = Resource.Open;
            this.ToolTip = LocalizationStrings.OpenPartFile;
            this.CanExecute = true;
        }

        /// <summary>The execute.</summary>
        public override void Execute()
        {
            var file = this.fileBrowserService.BrowseForFile(
                this.Parent,
                LocalizationStrings.Title,
                Globals.FileFilterDrawings,
                Mastercam.IO.SettingsManager.SharedDirectory);

            if (file.Any())
            {
                this.eventAggregator.Publish(new OpenPartMessage { FilePath = file });
            }
        }
    }
}