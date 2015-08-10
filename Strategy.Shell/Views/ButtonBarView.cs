// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ButtonBarView.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Views
{
    using System.Collections.Generic;
    using System.Windows.Forms;

    using Commands;
    using Interfaces;

    /// <summary>The button bar view.</summary>
    public partial class ButtonBarView : UserControl, IButtonBarView, IViewBase
    {
        #region Constrction

        /// <summary>Initializes a new instance of the <see cref="ButtonBarView"/> class.</summary>
        public ButtonBarView()
        {
            this.InitializeComponent();
        }

        #endregion

        /// <summary>The set commands.</summary>
        /// <param name="commands">The commands.</param>
        public void SetCommands(List<IButtonsCommand> commands)
        {
            this.Controls.Clear();

            foreach (var command in commands)
            {
                var button = new Button
                {
                    Text = command.ToolTip,
                    Enabled = command.CanExecute,
                    Margin = new Padding(2),
                    Location = command.Location,
                    Anchor = command.Anchor
                };

                var c = command; // Create a closure around the command
                command.PropertyChanged += (s, e) =>
                {
                    button.Text = c.ToolTip;
                    button.Enabled = c.CanExecute;
                };

                button.Click += (s, e) => c.Execute();

                this.Controls.Add(button);
            }
        }
    }
}
