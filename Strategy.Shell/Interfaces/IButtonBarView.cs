// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IButtonBarView.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Interfaces
{
    using System.Collections.Generic;

    using Commands;

    /// <summary>The ButtonBarView interface.</summary>
    public interface IButtonBarView
    {
        /// <summary>The set commands.</summary>
        /// <param name="commands">The commands.</param>
        void SetCommands(List<IButtonsCommand> commands);
    }
}