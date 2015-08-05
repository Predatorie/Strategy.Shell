// --------------------------------------------------------------------------------------------------------------------
// <copyright file="MastercamOperation.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Holds a reference to a Mastercam operation type
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Operations
{
    using Mastercam.Database;

    /// <summary>The operation.</summary>
    public class MastercamOperation : IMastercamOperation
    {
        /// <summary>Gets or sets the mastercam operation.</summary>
        public Operation Operation { get; set; }
    }
}
