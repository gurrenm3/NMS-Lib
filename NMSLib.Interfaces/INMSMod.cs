using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;

namespace NMSLib.Interfaces
{
    /// <summary>
    /// Parent class for all NMS mods
    /// </summary>
    public interface INMSMod
    {
        /// <summary>
        /// Info about this mod, such as the ModName, ModId, ModDescription, etc.
        /// </summary>
        IModConfigV1 ModInfo { get; set; }

        /// <summary>
        /// A NMSLogger for this mod.
        /// </summary>
        INMSLogger Logger { get; set; }

        /// <summary>
        /// The ModLoader instance.
        /// </summary>
        IModLoader ModLoader { get; set; }

        /// <summary>
        /// Called once when the mod is loaded.
        /// <br/>Happens when the mod is Registered in <see cref="INmsController"/>
        /// </summary>
        void Start();

        /// <summary>
        /// Called once every tick
        /// </summary>
        /// <remarks>This is a pseudo-Update method. Not actually synced to NMS's tick</remarks>
        void Update();
    }
}