﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SaveStrategyCommand.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Strategy.Shell.Commands
{
    using Events;

    using FunctionTable;

    using Localization;

    using Reactive.EventAggregator;

    using Services;

    /// <summary>The save strategy command.</summary>
    public class SaveStrategyCommand : CommandBase
    {
        /// <summary>The event aggregator.</summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>The file browser service.</summary>
        private readonly IFileBrowserService fileBrowserService;

        /// <summary>Initializes a new instance of the <see cref="SaveStrategyCommand"/> class.</summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="fileBrowserService">The file Browser Service.</param>
        public SaveStrategyCommand(IEventAggregator eventAggregator, IFileBrowserService fileBrowserService)
        {
            this.eventAggregator = eventAggregator;
            this.fileBrowserService = fileBrowserService;

            this.Icon = Resource.NewStrategy;
            this.ToolTip = LocalizationStrings.SaveStrategy;
            this.CanExecute = true;

            //// TODO: Wire up CanExecute if no levels assigned to operations
        }

        /// <summary>The execute.</summary>
        public override void Execute()
        {
            var filepath = this.fileBrowserService.SaveFile(this.Parent, LocalizationStrings.Title, Globals.FileFilterXml, Globals.StrategiesFolder);
            if (string.IsNullOrWhiteSpace(filepath))
            {
                return;
            }

            this.eventAggregator.Publish(new SaveStrategyMessage { Name = filepath });
        }
    }
}