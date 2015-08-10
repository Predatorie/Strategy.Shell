// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ToolbarViewPresenter.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Strategy.Shell.Presenter
{
    using System.Collections.Generic;

    using Strategy.Shell.Commands;
    using Strategy.Shell.Interfaces;

    /// <summary>The toolbar view presenter.</summary>
    public class ToolbarViewPresenter
    {
        #region Fields

        /// <summary>The toolbar button view.</summary>
        private readonly IToolbarButtonView view;

        #endregion

        #region Construction

        /// <summary>Initializes a new instance of the <see cref="ToolbarViewPresenter"/> class.</summary>
        /// <param name="view">The toolbar button view.</param>
        /// <param name="commands">The commands.</param>
        public ToolbarViewPresenter(
            IToolbarButtonView view, 
            List<IToolbarCommand> commands)
        {
            this.view = view;
            view.SetCommands(commands);
        }

        #endregion 
    }
}
