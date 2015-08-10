// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoveLevelCommand.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Strategy.Shell.Commands
{
    using Reactive.EventAggregator;

    using Strategy.Shell.FunctionTable;
    using Strategy.Shell.Localization;

    /// <summary>The remove level command.</summary>
    public class RemoveLevelCommand : CommandBase
    {
        /// <summary>The event aggregator.</summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>Initializes a new instance of the <see cref="RemoveLevelCommand"/> class.</summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        public RemoveLevelCommand(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            this.Icon = Resource.Tree_View_Remove;
            this.ToolTip = LocalizationStrings.RemoveLevel;
            this.CanExecute = true;
        }

        /// <summary>The execute.</summary>
        public override void Execute()
        {
            // TODO: Publish level to remove
        }
    }
}