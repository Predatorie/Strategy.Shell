// --------------------------------------------------------------------------------------------------------------------
// <copyright file="CloseShellCommand.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Strategy.Shell.Commands
{
    using System.Drawing;
    using System.Windows.Forms;

    using Events;

    using Localization;

    using Reactive.EventAggregator;

    /// <summary>The close shell command.</summary>
    public class CloseShellCommand : ButtonBase
    {
        /// <summary>The event aggregator.</summary>
        private readonly IEventAggregator eventAggregator;

        /// <summary>Initializes a new instance of the <see cref="CloseShellCommand"/> class.</summary>
        /// <param name="eventAggregator">The event aggregator.</param>
        public CloseShellCommand(IEventAggregator eventAggregator)
        {
            this.eventAggregator = eventAggregator;

            this.ToolTip = LocalizationStrings.CloseShell;
            this.CanExecute = true;
            this.Location = new Point(480, 4);
            this.Anchor = AnchorStyles.Right | AnchorStyles.Bottom;

        }

        /// <summary>The execute.</summary>
        public override void Execute()
        {
            // TODO: Add check state before closing
            this.eventAggregator.Publish(new CloseShellEvent());
        }
    }
}