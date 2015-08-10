// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IButtonsCommand.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Strategy.Shell.Commands
{
    using System.Drawing;
    using System.Windows.Forms;

    /// <summary>The CommandButtonView interface.</summary>
    public interface IButtonsCommand : ICommandBase
    {
        /// <summary>Gets or sets the location.</summary>
        Point Location { get; set; }

        /// <summary>Gets or sets the anchor.</summary>
        AnchorStyles Anchor { get; set; }
    }
}