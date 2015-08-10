// --------------------------------------------------------------------------------------------------------------------
// <copyright file="OperationSelectedMessage.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Events
{
    using System;
    using System.Windows.Forms;

    /// <summary>The operation selected message.</summary>
    public class OperationSelectedMessage : EventArgs
    {
        /// <summary>Initializes a new instance of the <see cref="OperationSelectedMessage"/> class.</summary>
        /// <param name="operation">The operatio node.</param>
        public OperationSelectedMessage(TreeNode operation)
        {
            this.Operation = operation;
        }

        /// <summary>Gets the operatio node.</summary>
        public TreeNode Operation { get; private set; }
    }
}