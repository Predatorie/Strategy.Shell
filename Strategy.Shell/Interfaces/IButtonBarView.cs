// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IButtonBarView.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the IButtonBarView type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Interfaces
{
    using System;

    /// <summary>The ButtonBarView interface.</summary>
    public interface IButtonBarView
    {
        /// <summary>The selection changed.</summary>
        event EventHandler CloseView;

        /// <summary>The remove level.</summary>
        event EventHandler SaveStrategy;

        /// <summary>The load strategy.</summary>
        event EventHandler LoadStrategy;

        /// <summary>The view loaded.</summary>
        event EventHandler ViewLoaded;
    }
}