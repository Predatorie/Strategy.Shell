// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShellViewPresenter.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Presenter
{
    using System;
    using System.Drawing;
    using System.Windows.Forms;

    using Interfaces;

    using Reactive.EventAggregator;

    using Services;

    /// <summary>The shell view presenter.</summary>
    public class ShellViewPresenter
    {
        #region Fields

        /// <summary>The shell view.</summary>
        private readonly IShellView view;

        /// <summary>The msg box service.</summary>
        private readonly IMessageBoxService msgBoxService;

        /// <summary>The file browser service.</summary>
        private readonly IFileBrowserService fileBrowserService;

        /// <summary>The event aggregator.</summary>
        private IEventAggregator eventAggregator;

        /// <summary>The system information service.</summary>
        private ISystemInformationService systemInformationService;

        #endregion

        #region Construction

        /// <summary>Initializes a new instance of the <see cref="ShellViewPresenter"/> class.</summary>
        /// <param name="shell">The shell.</param>
        /// <param name="msgBoxService">The msg Box Service.</param>
        /// <param name="fileBrowserService">The file Browser Service.</param>
        /// <param name="eventAggregator">The event Aggregator.</param>
        /// <param name="systemInformationService">The system Information Service.</param>
        public ShellViewPresenter(IShellView shell, IMessageBoxService msgBoxService, IFileBrowserService fileBrowserService, IEventAggregator eventAggregator, ISystemInformationService systemInformationService)
        {
            // Wire up our services
            this.msgBoxService = msgBoxService;
            this.fileBrowserService = fileBrowserService;
            this.eventAggregator = eventAggregator;
            this.systemInformationService = systemInformationService;

            // Wire up our view
            this.view = shell;

            // Wire up view our events
            shell.FormClosed += this.ViewOnFormClosed;
            shell.Load += this.ViewOnLoad;
            shell.KeyUp += this.ViewOnKeyUp;
            shell.HelpRequested += this.ViewOnHelpRequested;

            // WindowHandle high contrast
            if (!this.systemInformationService.IsHighContrastColourScheme)
            {
                shell.BackColor = Color.White;
            }
        }

        #endregion

        #region Event Handlers

        /// <summary>The shell view on help requested.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="hlpevent">The hlpevent.</param>
        private void ViewOnHelpRequested(object sender, HelpEventArgs hlpevent)
        {
        }

        /// <summary>The shell view on key up.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="keyEventArgs">The key event args.</param>
        private void ViewOnKeyUp(object sender, KeyEventArgs keyEventArgs)
        {
        }

        /// <summary>The shell view on load.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="eventArgs">The event args.</param>
        private void ViewOnLoad(object sender, EventArgs eventArgs)
        {
        }

        /// <summary>The shell view on form closed.</summary>
        /// <param name="sender">The sender.</param>
        /// <param name="formClosedEventArgs">The form closed event args.</param>
        private void ViewOnFormClosed(object sender, FormClosedEventArgs formClosedEventArgs)
        {
        }

        #endregion
    }
}
