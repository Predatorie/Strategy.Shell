// --------------------------------------------------------------------------------------------------------------------
// <copyright file="IStrategyService.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// <summary>
//   Defines the IStrategyService type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell.Services
{
    using System.Collections.Generic;
    using System.Windows.Forms;

    using Models;

    /// <summary>The StrategyService interface.</summary>
    public interface IStrategyService
    {
        /// <summary>The create operations tree.</summary>
        /// <param name="libraries">The libraries.</param>
        /// <returns>The <see cref="TreeNode"/>.</returns>
        List<TreeNode> LoadOperationData(List<string> libraries);

        /// <summary>The create levels data.</summary>
        /// <param name="strategy">The strategy.</param>
        /// <returns>The <see cref="TreeNode"/>.</returns>
        List<TreeNode> LoadStrategyData(Strategy strategy);
    }
}