// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Globals.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------

namespace Strategy.Shell
{
    /// <summary>The toolbar icon.</summary>
    public enum OperationTreeIconIndex
    {
        /// <summary>The operations.</summary>
        Operations = 0,

        /// <summary>The block drill.</summary>
        BlockDrill,

        /// <summary>The circle mill.</summary>
        CircleMill,

        /// <summary>The contour.</summary>
        Contour,

        /// <summary>The drill.</summary>
        Drill,

        /// <summary>The engrave.</summary>
        Engrave,

        /// <summary>The helix bore.</summary>
        HelixBore,

        /// <summary>The pocket.</summary>
        Pocket,

        /// <summary>The save.</summary>
        Save,

        /// <summary>The save as.</summary>
        SaveAs,

        /// <summary>The new strategy.</summary>
        NewStrategy,

        /// <summary>The slot mill.</summary>
        SlotMill,

        /// <summary>The thread mill.</summary>
        ThreadMill,

        /// <summary>The nesting operation.</summary>
        NestingOperation,

        /// <summary>The mill flat.</summary>
        MillFlat,

        /// <summary>The operation group.</summary>
        OperationGroup,

        /// <summary>The filler.</summary>
        Arrow,

        /// <summary>The arrow 2.</summary>
        Arrow2
    }

    /// <summary>The globals.</summary>
    public static class Globals
    {
        #region *** TODO: UPDATE FOR EACH MAJOR RELEASE ***

        /// <summary>
        /// The file filter operations-9
        /// </summary>
        public const string FileFilterOperations = "(*.operations-9)|*.operations-9";

        #endregion
    }
}
