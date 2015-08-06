// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShellView.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
//
// TODO: Implement Presenter
//
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Strategy.Shell.Views
{
    using System.Drawing;
    using System.Windows.Forms;

    using Reactive.EventAggregator;

    using Interfaces;
    using Services;

    /// <summary>The shell view.</summary>
    public sealed partial class ShellView : Form, IShellView
    {
        /// <summary>The event aggregator.</summary>
        private IEventAggregator eventAggregator;

        private readonly ButtonBarView buttonBarView;

        private readonly ToolbarButtonView toolbarButtonView;

        private readonly LevelsView levelsView;

        private readonly OperationsView operationsView;

        /// <summary>Initializes a new instance of the <see cref="ShellView"/> class.</summary>
        /// <param name="messageBoxService">The message box service.</param>
        /// <param name="fileBrowserService">The file browser service.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        public ShellView(IMessageBoxService messageBoxService, IFileBrowserService fileBrowserService, IEventAggregator eventAggregator)
        {
            this.InitializeComponent();

            this.eventAggregator = eventAggregator;

            this.buttonBarView = new ButtonBarView { Dock = DockStyle.Fill };
            this.toolbarButtonView = new ToolbarButtonView { Dock = DockStyle.Fill };
            this.levelsView = new LevelsView { Dock = DockStyle.Fill };
            this.operationsView = new OperationsView { Dock = DockStyle.Fill };

            this.InjectViews();

            // Handles high contrast
            if (!SystemInformation.HighContrast)
            {
                this.BackColor = Color.White;
            }
        }

        /// <summary>Gets the button bar view.</summary>
        public IButtonBarView ButtonBarView => this.buttonBarView;

        /// <summary>Gets the levels view.</summary>
        public ILevelsView LevelsView => this.levelsView;

        /// <summary>Gets the operations view.</summary>
        public IOperationsView OperationsView => this.operationsView;

        /// <summary>Gets the toolbar button view.</summary>
        public IToolbarButtonView ToolbarButtonView => this.toolbarButtonView;

        /// <summary>The inject views.</summary>
        private void InjectViews()
        {
            this.ShellContainer.Panel1.Controls.Add(this.levelsView);
            this.ShellContainer.Panel2.Controls.Add(this.operationsView);

            this.ButtonPanelRegion.Controls.Add(this.buttonBarView);
            this.ToolbarButtonPanelRegion.Controls.Add(this.toolbarButtonView);
        }
    }
}
