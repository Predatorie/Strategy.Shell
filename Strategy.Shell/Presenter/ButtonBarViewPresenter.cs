// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ButtonBarViewPresenter.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the ButtonBarViewPresenter type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Presenter
{
    using System;

    using Interfaces;

    using Reactive.EventAggregator;

    using Services;

    /// <summary>The button bar view presenter.</summary>
    public class ButtonBarViewPresenter
    {
        #region Fields

        /// <summary>The toolbar button view.</summary>
        private readonly IButtonBarView view;

        /// <summary>The msg box service.</summary>
        private readonly IMessageBoxService msgBoxService;

        /// <summary>The file browser service.</summary>
        private readonly IFileBrowserService fileBrowserService;

        /// <summary>The event aggregator.</summary>
        private IEventAggregator eventAggregator;

        #endregion

        #region Construction

        /// <summary>Initializes a new instance of the <see cref="ButtonBarViewPresenter"/> class.</summary>
        /// <param name="view">The view.</param>
        /// <param name="msgBoxService">The msg box service.</param>
        /// <param name="fileBrowserService">The file browser service.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        public ButtonBarViewPresenter(IButtonBarView view, IMessageBoxService msgBoxService, IFileBrowserService fileBrowserService, IEventAggregator eventAggregator)
        {
            // Wire up our services
            this.msgBoxService = msgBoxService;
            this.fileBrowserService = fileBrowserService;
            this.eventAggregator = eventAggregator;

            this.view = view;

            view.CloseView += this.ButtonBarViewOnCloseView;
            view.LoadStrategy += this.ButtonBarViewOnLoadStrategy;
            view.SaveStrategy += this.ButtonBarViewOnSaveStrategy;
            view.ViewLoad += this.ButtonBarViewOnViewLoad;
        }

        #endregion

        #region Event Handlers

        /// <summary>The button bar view on view loaded.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event args.</param>
        private void ButtonBarViewOnViewLoad(object sender, EventArgs eventArgs)
        {
        }

        /// <summary>The button bar view on save strategy.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event args.</param>
        private void ButtonBarViewOnSaveStrategy(object sender, EventArgs eventArgs)
        {
            this.msgBoxService.Ok("ButtonBarViewOnSaveStrategy", string.Empty);
        }

        /// <summary>The button bar view on load strategy.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event args.</param>
        private void ButtonBarViewOnLoadStrategy(object sender, EventArgs eventArgs)
        {
            this.msgBoxService.Ok("ButtonBarViewOnLoadStrategy", string.Empty);
        }

        /// <summary>The button bar view on close view.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event args.</param>
        private void ButtonBarViewOnCloseView(object sender, EventArgs eventArgs)
        {
            this.msgBoxService.Ok("ButtonBarViewOnCloseView", string.Empty);
        }

        #endregion
    }
}