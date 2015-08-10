// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ScanLevelCommand.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the ScanLevelCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Commands
{
    using FunctionTable;

    using Localization;

    using Reactive.EventAggregator;

    using Services;

    /// <summary>The scan level command.</summary>
    public class ScanLevelCommand : CommandBase
    {
        /// <summary>The event aggregator.</summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>The file browser service.</summary>
        private readonly IFileBrowserService fileBrowserService;

        /// <summary>Initializes a new instance of the <see cref="ScanLevelCommand"/> class. Initializes a new instance of the <see cref="RemoveLevelCommand"/> class.</summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="fileBrowserService">The file browser service.</param>
        public ScanLevelCommand(IEventAggregator eventAggregator, IFileBrowserService fileBrowserService)
        {
            this.eventAggregator = eventAggregator;
            this.fileBrowserService = fileBrowserService;

            this.Icon = Resource.NewLevelScan;
            this.ToolTip = LocalizationStrings.RunScan;
            this.CanExecute = true;
        }

        /// <summary>The execute.</summary>
        public override void Execute()
        {
            // TODO: Browse for folder 
            var files = this.fileBrowserService.BrowseForFolder(LocalizationStrings.SelectFolder);

            if (!string.IsNullOrWhiteSpace(files))
            {
                // TODO: Scan
            }
        }
    }
}