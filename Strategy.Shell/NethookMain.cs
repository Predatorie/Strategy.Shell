// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NethookMain.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell
{
    using System.Collections.Generic;

    using Commands;

    using Mastercam.App;
    using Mastercam.App.Types;

    using Presenter;

    using Properties;

    using Reactive.EventAggregator;

    using Services;

    using Views;

    /// <summary>
    /// Defines the NethookMain type
    /// </summary>
    public class NethookMain : NetHook3App
    {
        #region Public Override Methods

        /// <summary>
        /// This method is the first one run by Mastercam when it loads your NetHook app. It's designed to handle all
        /// of the initialization your app may need. If you decide you don't need any initialization it's
        /// perfectly fine to not override this method and just delete the following method declaration.
        /// </summary>
        /// <param name="param">System parameter.</param>
        /// <returns>A <c>MCamReturn</c> return type representing the outcome of this method.</returns>
        public override MCamReturn Init(int param)
        {
            return MCamReturn.NoErrors;
        }

        /// <summary>
        /// The main entry point for your NETHook.
        /// </summary>
        /// <param name="param">System parameter.</param>
        /// <returns>A <c>MCamReturn</c> return type representing the outcome of your NetHook application.</returns>
        public override MCamReturn Run(int param)
        {
            // First time user has run the app
            if (Settings.Default.FirstRun)
            {
                //// TODO: Do something first time running

                Settings.Default.FirstRun = false;
                Settings.Default.Save();
            }

            // TODO: Implement DI

            // Implement our services
            var msgBoxService = new MessageBoxService();
            var fileBrowserService = new FileBrowserService();
            var eventAggregator = new EventAggregator();
            var sysInfoService = new SystemInformationService();
            var fileManagerService = new FileManagerService();

            // Create all our toolbar buttons
            var toolbarCommands = new List<IToolbarCommand>
                               {
                                   new OpenOperationsCommand(eventAggregator, fileBrowserService),
                                   new ScanLevelCommand(eventAggregator, fileBrowserService),
                                   new OpenPartLevelsCommand(eventAggregator, fileBrowserService),
                                   new AddLevelCommand(eventAggregator),
                                   new RemoveLevelCommand(eventAggregator),
                                   new SaveLevelsCommand(eventAggregator)
                               };

            var buttonCommands = new List<IButtonsCommand>
            {
                                         new CloseShellCommand(eventAggregator)
                                     };

            // The ShellView is responsible for creating all child views and view presenters
            var shellView = new ShellView(msgBoxService, fileBrowserService, eventAggregator, toolbarCommands, fileManagerService, buttonCommands);

            // Wire up the main presenter
            var presenter = new ShellViewPresenter(shellView, msgBoxService, fileBrowserService, eventAggregator, sysInfoService);

            // TODO: Hook upto Mastercam window
            shellView.ShowDialog();

            return MCamReturn.NoErrors;
        }

        /// <summary>
        /// This is the method called when your application has ended it's execution loop and is getting ready to
        /// close. This method is where you would want to put any cleanup code or special closing functionality.
        /// Just like the Init method, this is also optional and can be omitted if you don't need to do anything on
        /// </summary>
        /// <param name="param">System parameter.</param>
        /// <returns>A <c>MCamReturn</c> return type representing the outcome of this method.</returns>
        public override MCamReturn Close(int param)
        {
            return MCamReturn.NoErrors;
        }

        #endregion
    }
}
