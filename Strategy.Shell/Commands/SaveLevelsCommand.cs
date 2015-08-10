﻿// --------------------------------------------------------------------------------------------------------------------
// <copyright file="SaveLevelsCommand.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Commands
{
    using System.Reactive.Linq;

    using Events;

    using FunctionTable;

    using Localization;

    using Reactive.EventAggregator;

    /// <summary>The save levels file command.</summary>
    public class SaveLevelsCommand : CommandBase
    {
        /// <summary>The event aggregator.</summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>Initializes a new instance of the <see cref="SaveLevelsCommand"/> class.</summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        public SaveLevelsCommand(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            this.Icon = Resource.Save;
            this.ToolTip = LocalizationStrings.SaveLevels;
            this.CanExecute = true;
        }

        /// <summary>The execute.</summary>
        public override void Execute()
        {
            this.eventAggregator.GetEvent<SaveLevelsEvent>().Publish(new SaveLevelsEvent());
        }
    }
}