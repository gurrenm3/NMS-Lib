using Reloaded.Mod.Interfaces;

namespace NMSLib.Api
{
    /// <summary>
    /// Parent class for all NMS mods
    /// </summary>
    public class NMSMod
    {
        /// <summary>
        /// The ModLoader from Reloaded2. Can also be found in Program.cs
        /// </summary>
        public IModLoader ModLoader { get; internal set; }

        /// <summary>
        /// The Logger from Reloaded2. Can also be found in Program.cs
        /// </summary>
        public ILogger Logger { get; internal set; }

        /// <summary>
        /// Called once when the mod is loaded.
        /// <br/>Happens after all mods have been registered by Reloaded2
        /// </summary>
        public virtual void Start()
        {

        }

        /// <summary>
        /// Called once every tick
        /// </summary>
        public virtual void Update()
        {

        }
    }
}
