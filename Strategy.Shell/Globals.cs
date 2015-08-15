// --------------------------------------------------------------------------------------------------------------------
// <copyright file="Globals.cs" company="Mick George @Osoy">
//   Copyright (c) 2015 Mick George aphextwin@seidr.net
// </copyright>
// --------------------------------------------------------------------------------------------------------------------
namespace Strategy.Shell
{
    using System.IO;

    using Mastercam.IO;

    /// <summary>The toolbar icon.</summary>
    public enum TreeIconIndex
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
        Arrow2, 

        /// <summary>The params.</summary>
        Params, 

        /// <summary>The tree view add.</summary>
        TreeViewAdd, 

        /// <summary>The tree view delete.</summary>
        TreeViewDelete, 

        /// <summary>The main level.</summary>
        MainLevel
    }

    /// <summary>The globals.</summary>
    public static class Globals
    {
        #region *** TODO: UPDATE FOR EACH MAJOR RELEASE ***

        /// <summary>
        /// The file filter operations-9
        /// </summary>
        public const string FileFilterOperations = "(*.operations-9)|*.operations-9";


        /// <summary>
        /// TODO: Add filter to include dxf, dwg, older mcx
        /// </summary>
        public const string FileFilterDrawings = "(*.dxf)|*.dxf";

        /// <summary>The file filter xml.</summary>
        public const string FileFilterXml = "(*.xml)|*.xml";

        #endregion

        /// <summary>The strategy folder.</summary>
        public static readonly string StrategiesFolder = Path.Combine(SettingsManager.SharedDirectory, "ATP\\Strategies");

        /// <summary>The levels folder.</summary>
        public static readonly string LevelsFolder = Path.Combine(SettingsManager.SharedDirectory, "ATP\\Levels");

        /// <summary>The definitions folder.</summary>
        public static readonly string DefinitionsFolder = Path.Combine(SettingsManager.SharedDirectory, "ATP\\Definitions");
    }
}
