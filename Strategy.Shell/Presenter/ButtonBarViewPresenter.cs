// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ButtonBarViewPresenter.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Presenter
{
    using System.Collections.Generic;

    using Strategy.Shell.Commands;
    using Strategy.Shell.Interfaces;

    /// <summary>The button bar view presenter.</summary>
    public class ButtonBarViewPresenter
    {
        #region Fields

        /// <summary>The toolbar button view.</summary>
        private readonly IButtonBarView view;

        #endregion

        #region Construction

        /// <summary>Initializes a new instance of the <see cref="ButtonBarViewPresenter"/> class.</summary>
        /// <param name="view">The view.</param>
        /// <param name="commands">The commands.</param>
        public ButtonBarViewPresenter(
            IButtonBarView view, 
            List<IButtonsCommand> commands)
        {
            this.view = view;
            view.SetCommands(commands);
        }

        #endregion
    }
}