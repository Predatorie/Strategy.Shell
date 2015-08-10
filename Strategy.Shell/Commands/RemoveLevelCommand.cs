// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RemoveLevelCommand.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Strategy.Shell.Commands
{
    using System;
    using System.Windows.Forms;

    using Events;

    using FunctionTable;

    using Localization;

    using Reactive.EventAggregator;

    /// <summary>The remove level command.</summary>
    public class RemoveLevelCommand : CommandBase
    {
        /// <summary>The event aggregator.</summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>The level.</summary>
        private TreeNode level;

        /// <summary>Initializes a new instance of the <see cref="RemoveLevelCommand"/> class.</summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        public RemoveLevelCommand(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            this.Icon = Resource.Tree_View_Remove;
            this.ToolTip = LocalizationStrings.RemoveLevel;
            this.CanExecute = false;

            // TODO: This seems a little iffy at the moment
            this.eventAggregator.GetEvent<LevelSelectedMessage>().Subscribe(e => this.CanExecute = true);
            this.eventAggregator.GetEvent<OperationSelectedMessage>().Subscribe(e => this.CanExecute = false);

            this.eventAggregator.GetEvent<LevelSelectedMessage>().Subscribe(this.OnLevelToRemove);

        }

        /// <summary>The execute.</summary>
        public override void Execute()
        {
            this.eventAggregator.Publish(new RemoveLevelMessage { Level = this.level });
        }

        /// <summary>The on level to remove.</summary>
        /// <param name="e">The e.</param>
        private void OnLevelToRemove(LevelSelectedMessage e)
        {
            this.level = e.Level;
        }
    }
}