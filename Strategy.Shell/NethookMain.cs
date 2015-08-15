// --------------------------------------------------------------------------------------------------------------------
// <copyright file="NethookMain.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Strategy.Shell
{
    using System.Collections.Generic;

    using Commands;

    using Mastercam.App;
    using Mastercam.App.Types;

    using Models;

    using Ninject;
    using Ninject.Parameters;

    using Properties;

    using Views;

    /// <summary>
    /// Defines the NethookMain type
    /// </summary>
    public class NethookMain : NetHook3App
    {
        #region Public Override Methods

        /// <summary>This method is the first one run by Mastercam when it loads your NetHook app. It's designed to handle all
        /// of the initialization your app may need. If you decide you don't need any initialization it's
        /// perfectly fine to not override this method and just delete the following method declaration.</summary>
        /// <param name="param">System parameter.</param>
        /// <returns>A <c>MCamReturn</c> return type representing the outcome of this method.</returns>
        public override MCamReturn Init(int param)
        {
            return MCamReturn.NoErrors;
        }

        /// <summary>The main entry point for your NETHook.</summary>
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

            // Using Ninject for IoC
            using (var kernel = new StandardKernel(new ShellModules()))
            {
                // build our operations toolbar list
                var operations = new List<IToolbarCommand>
                                     {
                                         kernel.Get<OpenOperationsCommand>(),
                                         kernel.Get<OpenStrategyCommand>(),
                                         kernel.Get<SaveStrategyCommand>()
                                     };

                // build our levels toolbar list
                var levels = new List<IToolbarCommand>
                             {
                                 kernel.Get<ScanLevelCommand>(),
                                 kernel.Get<OpenPartLevelsCommand>(),
                                 kernel.Get<AddLevelCommand>(),
                                 kernel.Get<RemoveLevelCommand>(),
                                 kernel.Get<SaveLevelsCommand>()
                             };

                using (var shell = kernel.Get<ShellView>(
                        new ConstructorArgument("operationscommands", operations),
                        new ConstructorArgument("levelscommands", levels)))
                {
                    shell.ShowDialog();
                }
            }

            return MCamReturn.NoErrors;
        }

        /// <summary>This is the method called when your application has ended it's execution loop and is getting ready to
        /// close. This method is where you would want to put any cleanup code or special closing functionality.
        /// Just like the Init method, this is also optional and can be omitted if you don't need to do anything on</summary>
        /// <param name="param">System parameter.</param>
        /// <returns>A <c>MCamReturn</c> return type representing the outcome of this method.</returns>
        public override MCamReturn Close(int param)
        {
            return MCamReturn.NoErrors;
        }

        #endregion
    }
}
