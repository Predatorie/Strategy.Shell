// --------------------------------------------------------------------------------------------------------------------
// <copyright file="AddLevelCommand.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Strategy.Shell.Commands
{
    using Events;

    using FunctionTable;

    using Localization;

    using Reactive.EventAggregator;

    /// <summary>The add level command.</summary>
    public class AddLevelCommand : CommandBase
    {
        /// <summary>The event aggregator.</summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>Initializes a new instance of the <see cref="AddLevelCommand"/> class.</summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        public AddLevelCommand(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            this.Icon = Resource.Tree_View_Add;
            this.ToolTip = LocalizationStrings.AddLevel;
            this.CanExecute = true;
        }

        /// <summary>The execute.</summary>
        public override void Execute()
        {
            this.eventAggregator.Publish(new AddLevelEvent());
        }
    }
}