// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShellModules.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Strategy.Shell.Models
{
    using Commands;

    using Interfaces;

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
            this.Kernel.Bind<IStrategyService>().To<StrategyService>().InSingletonScope();

            // Operation specific commands
            this.Kernel.Bind<IToolbarCommand>().To<OpenOperationsCommand>().InSingletonScope();
            this.Kernel.Bind<IToolbarCommand>().To<SaveStrategyCommand>().InSingletonScope();
            this.Kernel.Bind<IToolbarCommand>().To<OpenStrategyCommand>().InSingletonScope();

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
            this.Kernel.Bind<IShellView>().To<ShellView>().InSingletonScope();
        }
    }
}
