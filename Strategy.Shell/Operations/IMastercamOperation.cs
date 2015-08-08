// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IMastercamOperation.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Strategy.Shell.Operations
{
    using Mastercam.Database;
    using Mastercam.Database.Types;

    /// <summary>The MastercamOperation interface.</summary>
    public interface IMastercamOperation
    {
        /// <summary>Gets or sets the comment.</summary>
        Operation Operation { get; set; }

        /// <summary>Gets or sets the path to the operations file.</summary>
        string Path { get; set; }

        /// <summary>Gets or sets the name of the operation file.</summary>
        string Name { get; set; }

        /// <summary>Gets or sets the t operation.</summary>
        OperationType OperationType { get; set; }
    }
}
