// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShellView.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Views
{
    using System.Windows.Forms;

    using Reactive.EventAggregator;

    using Interfaces;
    using Presenter;
    using Services;

    /// <summary>The shell view.</summary>
    public partial class ShellView : Form, IShellView
    {
        #region Fields

        /// <summary>The button bar view.</summary>
        private readonly ButtonBarView buttonBarView;

        /// <summary>The toolbar button view.</summary>
        private readonly ToolbarButtonView toolbarButtonView;

        /// <summary>The levels view.</summary>
        private readonly LevelsView levelsView;

        /// <summary>The operations view.</summary>
        private readonly OperationsView operationsView;

        #endregion

        #region Construction

        /// <summary>Initializes a new instance of the <see cref="ShellView"/> class.</summary>
        /// <param name="msgBoxService">The msg Box Service.</param>
        /// <param name="fileBrowserService">The file Browser Service.</param>
        /// <param name="eventAggregator">The event Aggregator.</param>
        public ShellView(IMessageBoxService msgBoxService, IFileBrowserService fileBrowserService, IEventAggregator eventAggregator)
        {
            this.InitializeComponent();

            // Wire up our view presenters
            var toolbarView = new ToolbarButtonView { Dock = DockStyle.Fill };
            var toolbarViewPresenter = new ToolbarViewPresenter(toolbarView, msgBoxService, fileBrowserService, eventAggregator);

            var buttonView = new ButtonBarView { Dock = DockStyle.Fill };
            var buttonViewPresenter = new ButtonBarViewPresenter(buttonView, msgBoxService, fileBrowserService, eventAggregator);

            var levelView = new LevelsView { Dock = DockStyle.Fill };
            var levelViewPresenter = new LevelsViewPresenter(levelView, msgBoxService, fileBrowserService, eventAggregator);

            var opsView = new OperationsView { Dock = DockStyle.Fill };
            var opsViewPresenter = new OperationsViewPresenter(opsView, msgBoxService, fileBrowserService, eventAggregator);

            // Wire up the views
            this.buttonBarView = buttonView;
            this.toolbarButtonView = toolbarView;
            this.levelsView = levelView;
            this.operationsView = opsView;

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
        public IToolbarButtonView ToolbarButtonView => this.toolbarButtonView;

        /// <summary>
        /// Returns the handle to this form, usefull for setting modal dialogs to this form
        /// </summary>
        public IWin32Window WindowHandle => FromHandle(this.Handle);

        #endregion

        #region Private Methods

        /// <summary>The inject views.</summary>
        private void InjectViews()
        {
            this.ShellContainer.Panel1.Controls.Add(this.levelsView);
            this.ShellContainer.Panel2.Controls.Add(this.operationsView);

            this.ButtonPanelRegion.Controls.Add(this.buttonBarView);
            this.ToolbarButtonPanelRegion.Controls.Add(this.toolbarButtonView);
        }

        #endregion
    }
}
