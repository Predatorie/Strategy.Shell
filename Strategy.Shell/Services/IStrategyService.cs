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
    using Models;

    /// <summary>The StrategyService interface.</summary>
    public interface IStrategyService
    {
        /// <summary>The serialize.</summary>
        /// <param name="strategy">The strategy.</param>
        void Serialize(Strategy strategy);

        /// <summary>The deserialize.</summary>
        /// <param name="filepath">The filepath.</param>
        /// <returns>The <see cref="Strategy"/>.</returns>
        Strategy Deserialize(string filepath);
    }
}