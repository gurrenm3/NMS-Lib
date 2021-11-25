namespace ModSDK.Api
{
    /// <summary>
    /// Contains info about the Player.
    /// </summary>
    public class PlayerStateData
    {
        /// <summary>
        /// Called whenever the player's health is changed.
        /// </summary>
        /// <value>Current health after change.</value>
        public ModEvent<int> HealthChanged { get; set; }

        /// <summary>
        /// Called whenever the player's units is changed.
        /// </summary>
        /// <value>Current units after change.</value>
        public ModEvent<int> UnitsChanged { get; set; }

        /// <summary>
        /// Called whenever the player's nanites is changed.
        /// </summary>
        /// <value>Current nanites after change.</value>
        public ModEvent<int> NanitesChanged { get; set; }

        /// <summary>
        /// Called whenever the player's quicksilver is changed.
        /// </summary>
        /// <value>Current quicksilver after change.</value>
        public ModEvent<int> QuicksilverChanged { get; set; }


        public PlayerStateData()
        {
            
        }
    }
}
