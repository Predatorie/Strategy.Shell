// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShellView.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Views
{
    using System;
    using System.Collections.Generic;
    using System.Windows.Forms;

    using Reactive.EventAggregator;

    using Interfaces;
    using Presenter;
    using Services;

    using Commands;
    using Events;

    /// <summary>The shell view.</summary>
    public partial class ShellView : Form, IShellView
    {
        #region Fields

        /// <summary>The button bar view.</summary>
        private readonly ButtonBarView buttonBarView;

        /// <summary>The toolbar button view.</summary>
        private readonly ToolbarButtonView toolbarOperationsButtonView;

        private readonly ToolbarButtonView toolbarLevelsButtonView;

        /// <summary>The levels view.</summary>
        private readonly LevelsView levelsView;

        /// <summary>The operations view.</summary>
        private readonly OperationsView operationsView;

        /// <summary>
        /// The Event Aggregator singleton
        /// </summary>
        private readonly IEventAggregator eventAggregator;

        #endregion

        #region Construction

        /// <summary>Initializes a new instance of the <see cref="ShellView"/> class.</summary>
        /// <param name="msgBoxService">The msg Box Service.</param>
        /// <param name="fileBrowserService">The file Browser Service.</param>
        /// <param name="eventAggregator">The event Aggregator.</param>
        /// <param name="operationscommands"></param>
        /// <param name="levelscommands"></param>
        /// <param name="fileManagerService"></param>
        /// <param name="buttonsCommands"></param>
        /// <param name="strategyService"></param>
        public ShellView(IMessageBoxService msgBoxService, 
            IFileBrowserService fileBrowserService, 
            IEventAggregator eventAggregator,
            List<IToolbarCommand> operationscommands, 
            List<IToolbarCommand> levelscommands, 
            IFileManagerService fileManagerService, 
            List<IButtonsCommand> buttonsCommands, 
            IStrategyService strategyService)
        {
            this.InitializeComponent();

            // Wire up our view presenters
            var toolbarOperationsView = new ToolbarButtonView { Dock = DockStyle.Top };
            var toolbarViewPresenter = new ToolbarViewPresenter(toolbarOperationsView, operationscommands);

            var toolbarLevelsView = new ToolbarButtonView { Dock = DockStyle.Top };
            var toolbarLevelsViewPresenter = new ToolbarViewPresenter(toolbarLevelsView, levelscommands);


            var buttonView = new ButtonBarView { Dock = DockStyle.Fill };
            var buttonViewPresenter = new ButtonBarViewPresenter(buttonView, buttonsCommands);

            var levelView = new LevelsView { Dock = DockStyle.Fill, Margin = new Padding(5) };
            var levelViewPresenter = new LevelsViewPresenter(levelView, msgBoxService, fileBrowserService, eventAggregator, fileManagerService, strategyService);

            var opsView = new OperationsView { Dock = DockStyle.Fill, Margin = new Padding(5) };
            var opsViewPresenter = new OperationsViewPresenter(opsView, msgBoxService, fileBrowserService, eventAggregator);

            // Wire up the views
            this.buttonBarView = buttonView;
            this.toolbarOperationsButtonView = toolbarOperationsView;
            this.toolbarLevelsButtonView = toolbarLevelsView;
            this.levelsView = levelView;
            this.operationsView = opsView;

            this.eventAggregator = eventAggregator;
            this.eventAggregator.GetEvent<CloseShellMessage>().Subscribe(this.OnCloseShell);
           
            // Place the views in the correct regions
            this.InjectViews();
        }

        #endregion

        #region Public Properties

        /// <summary>Gets the button bar view.</summary>
        public IButtonBarView ButtonBarView => this.buttonBarView;

        /// <summary>Gets the levels view.</summary>
        public ILevelsView LevelsView => this.levelsView;

        /// <summary>Gets the operations view.</summary>
        public IOperationsView OperationsView => this.operationsView;

        /// <summary>Gets the toolbar button view.</summary>
        public IToolbarButtonView ToolbarButtonView => this.toolbarOperationsButtonView;

        /// <summary>
        /// Returns the handle to this form, usefull for setting modal dialogs to this form
        /// </summary>
        public IWin32Window WindowHandle => FromHandle(this.Handle);

        #endregion

        #region Private Methods

        /// <summary>The inject views.</summary>
        private void InjectViews()
        {
            this.ShellContainer.Panel1.Controls.Add(this.toolbarOperationsButtonView);
            this.ShellContainer.Panel1.Controls.Add(this.operationsView);

            this.ShellContainer.Panel2.Controls.Add(this.toolbarLevelsButtonView);
            this.ShellContainer.Panel2.Controls.Add(this.levelsView);

            this.ButtonPanelRegion.Controls.Add(this.buttonBarView);
        }

        /// <summary>
        /// Closes the main view, called from the button close
        /// </summary>
        /// <param name="e"></param>
        private void OnCloseShell(CloseShellMessage e)
        {
            this.Close();
        }

        #endregion
    }
}
