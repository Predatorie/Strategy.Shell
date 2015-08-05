// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ShellView.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   The shell view.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Views
{
    using System.Drawing;
    using System.Windows.Forms;

    using Interfaces;

    using Properties;

    using Reactive.EventAggregator;

    using Services;

    /// <summary>The shell view.</summary>
    public sealed partial class ShellView : Form, IShellView
    {
        /// <summary>The event aggregator.</summary>
        private IEventAggregator eventAggregator;

        /// <summary>Initializes a new instance of the <see cref="ShellView"/> class.</summary>
        /// <param name="messageBoxService">The message box service.</param>
        /// <param name="fileBrowserService">The file browser service.</param>
        /// <param name="eventAggregator">The event aggregator.</param>
        public ShellView(IMessageBoxService messageBoxService, IFileBrowserService fileBrowserService, IEventAggregator eventAggregator)
        {
            this.InitializeComponent();

            this.eventAggregator = eventAggregator;

            // Handles high contrast
            if (!SystemInformation.HighContrast)
            {
                this.BackColor = Color.White;
            }

     
        }
    }
}
