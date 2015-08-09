// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToolbarViewPresenter.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Presenter
{
    using System.Collections.Generic;

    using Commands;

    using Interfaces;

    using Reactive.EventAggregator;

    using Services;

    /// <summary>The toolbar view presenter.</summary>
    public class ToolbarViewPresenter
    {
        #region Fields

        /// <summary>The toolbar button view.</summary>
        private readonly IToolbarButtonView view;

        /// <summary>The msg box service.</summary>
        private readonly IMessageBoxService msgBoxService;

        /// <summary>The file browser service.</summary>
        private readonly IFileBrowserService fileBrowserService;

        /// <summary>The event aggregator.</summary>
        private readonly IEventAggregator eventAggregator;

        #endregion

        #region Construction

        /// <summary>Initializes a new instance of the <see cref="ToolbarViewPresenter"/> class.</summary>
        /// <param name="view">The toolbar button view.</param>
        /// <param name="msgBoxService">The msg box service.</param>
        /// <param name="fileBrowserService">The file browser service.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        /// <param name="commands">The commands.</param>
        public ToolbarViewPresenter(
            IToolbarButtonView view,
            IMessageBoxService msgBoxService,
            IFileBrowserService fileBrowserService,
            IEventAggregator eventAggregator,
            List<IToolbarCommand> commands)
        {
            // Wire up our services
            this.msgBoxService = msgBoxService;
            this.fileBrowserService = fileBrowserService;
            this.eventAggregator = eventAggregator;

            this.view = view;
            view.SetCommands(commands);
        }

        #endregion 
    }
}
