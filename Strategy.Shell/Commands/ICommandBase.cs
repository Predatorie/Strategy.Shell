// --------------------------------------------------------------------------------------------------------------------
// <copyright file="ICommandBase.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Commands
{
    using System.ComponentModel;
    using System.Windows.Forms;

    /// <summary>The CommandBase interface.</summary>
    public interface ICommandBase : INotifyPropertyChanged
    {
        /// <summary>Gets or sets a value indicating whether can execute.</summary>
        bool CanExecute { get; set; }

        /// <summary>Gets or sets the tool tip.</summary>
        string ToolTip { get; set; }

        /// <summary>Gets or sets the shortcut key.</summary>
        Keys ShortcutKey { get; set; }

        /// <summary>The execute.</summary>
        void Execute();
    }
}