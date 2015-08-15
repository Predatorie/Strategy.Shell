// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OpenStrategyCommand.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Commands
{
    using System.Linq;

    using Events;

    using FunctionTable;

    using Localization;

    using Reactive.EventAggregator;

    using Services;

    /// <summary>The open strategy command.</summary>
    public class OpenStrategyCommand : CommandBase
    {
        /// <summary>The event aggregator.</summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>The file browser service.</summary>
        private readonly IFileBrowserService fileBrowserService;

        /// <summary>Initializes a new instance of the <see cref="OpenStrategyCommand"/> class.</summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="fileBrowserService">The file browser service.</param>
        public OpenStrategyCommand(IEventAggregator eventAggregator, IFileBrowserService fileBrowserService)
        {
            this.eventAggregator = eventAggregator;
            this.fileBrowserService = fileBrowserService;

            this.Icon = Resource.NewStrategy;
            this.ToolTip = LocalizationStrings.LoadStrategy;
            this.CanExecute = true;
        }


        /// <summary>The execute.</summary>
        public override void Execute()
        {
            var filepath = this.fileBrowserService.BrowseForFile(this.Parent, LocalizationStrings.Title, Globals.FileFilterXml, Globals.StrategiesFolder, false);

            if (!filepath.Any())
            {
                return;
            }

            this.eventAggregator.Publish(new OpenStrategyMessage { Name = filepath[0] });
        }
    }
}
