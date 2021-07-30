namespace NMSLib.Api.Interfaces.Player
{
    /// <summary>
    /// State data for the player.
    /// </summary>
    /// <remarks>Documentation: https://monkeyman192.github.io/MBINCompiler/classes/gc/GcPlayerStateData/ </remarks>
    public interface IPlayerStateData
    {
        /// <summary>
        /// Player's current health
        /// </summary>
        int Health { get; set; }

        /// <summary>
        /// Player's current Units
        /// </summary>
        int Units { get; set; }

        /// <summary>
        /// Player's current Nanites
        /// </summary>
        int Nanites { get; set; }

        /// <summary>
        /// Player's current Quicksilver
        /// </summary>
        int Quicksilver { get; set; }
    }
}
