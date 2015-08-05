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
    using Mastercam.App;
    using Mastercam.App.Types;

    using Reactive.EventAggregator;

    using Strategy.Shell.Properties;
    using Strategy.Shell.Services;

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
            if(Settings.Default.FirstRun)
            {
                //// TODO: Do something first time running

                Settings.Default.FirstRun = false;
                Settings.Default.Save();
            }

            // Implement our services
            var msgBoxService = new MessageBoxService();
            var fileBrowserService = new FileBrowserService();
            var eventAggregator = new EventAggregator();

            using(var view = new ShellView(msgBoxService, fileBrowserService, eventAggregator))
            {
                view.ShowDialog();
            }

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

        /// <summary>
        /// This method is used to handle notification messages from the main Mastercam app to your NetHook
        ///  application. This could allow you to include special handling of certain notification messages, such as
        ///  graphical repaints or file changes. Just like the Close and Init methods, this is entirely optional
        ///  and probably should only be used if you're very comfortable with the Mastercam messaging system and
        ///  want to do some very advanced application programming.
        /// </summary>
        /// <param name="eventFlag">Event type</param>
        /// <returns>A <c>MCamReturn</c> return type representing the outcome of this method.</returns>
        public override MCamReturn Notify(MCamEvent eventFlag)
        {
            return MCamReturn.NoErrors;
        }

        #endregion
    }
}
