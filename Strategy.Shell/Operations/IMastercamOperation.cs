// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMastercamOperation.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   The MastercamOperation interface.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Operations
{
    using Mastercam.Database;

    /// <summary>The MastercamOperation interface.</summary>
    public interface IMastercamOperation
    {
        /// <summary>Gets or sets the comment.</summary>
        Operation Operation { get; set; }
    }
}
