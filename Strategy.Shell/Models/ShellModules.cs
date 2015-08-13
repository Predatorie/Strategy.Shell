// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShellModules.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Models
{
    using System.Collections.Generic;

    using Commands;

    using Interfaces;

    using Ninject;
    using Ninject.Modules;

    using Reactive.EventAggregator;

    using Services;

    using Views;

    /// <summary>The shell modules.</summary>
    public class ShellModules : NinjectModule
    {
        /// <summary>The load.</summary>
        public override void Load()
        {
            // Services
            this.Kernel.Bind<IMessageBoxService>().To<MessageBoxService>().InSingletonScope();
            this.Kernel.Bind<IFileBrowserService>().To<FileBrowserService>().InSingletonScope();
            this.Kernel.Bind<IFileManagerService>().To<FileManagerService>().InSingletonScope();
            this.Kernel.Bind<IEventAggregator>().To<EventAggregator>().InSingletonScope();
            this.Kernel.Bind<ISystemInformationService>().To<SystemInformationService>().InSingletonScope();

            //// TODO: Seperate out IToolbarCommand's for Operations Toolbar and Levels Toolbar
            //// TODO: so they are not duplicated across both toolbars

            // Operation specific commands
            this.Kernel.Bind<IToolbarCommand>().To<OpenOperationsCommand>().InSingletonScope();

            // Levels specific commands
            this.Kernel.Bind<IToolbarCommand>().To<ScanLevelCommand>().InSingletonScope();
            this.Kernel.Bind<IToolbarCommand>().To<OpenPartLevelsCommand>().InSingletonScope();
            this.Kernel.Bind<IToolbarCommand>().To<AddLevelCommand>().InSingletonScope();
            this.Kernel.Bind<IToolbarCommand>().To<RemoveLevelCommand>().InSingletonScope();
            this.Kernel.Bind<IToolbarCommand>().To<SaveLevelsCommand>().InSingletonScope();

            // Bottom buttons
            this.Kernel.Bind<IButtonsCommand>().To<CloseShellCommand>().InSingletonScope();

            // Views            
            this.Kernel.Bind<IOperationsView>().To<OperationsView>().InSingletonScope();
            this.Kernel.Bind<ILevelsView>().To<LevelsView>().InSingletonScope();
            this.Kernel.Bind<IToolbarButtonView>().To<ToolbarButtonView>().InSingletonScope();

            ////// build our operations toolbar list
            ////var operations = new List<IToolbarCommand> { this.Kernel.Get<OpenOperationsCommand>() };

            ////// build our levels toolbar list
            ////var levels = new List<IToolbarCommand>
            ////                 {
            ////                     this.Kernel.Get<ScanLevelCommand>(),
            ////                     this.Kernel.Get<OpenPartLevelsCommand>(),
            ////                     this.Kernel.Get<AddLevelCommand>(),
            ////                     this.Kernel.Get<RemoveLevelCommand>(),
            ////                     this.Kernel.Get<SaveLevelsCommand>()
            ////                 };

            ////this.Kernel.Bind<IShellView>()
            ////    .To<ShellView>()
            ////    .WithConstructorArgument("operationscommands", operations)
            ////    .WithConstructorArgument("levelscommands", levels);

            this.Kernel.Bind<IShellView>().To<ShellView>().InSingletonScope();
        }
    }
}
