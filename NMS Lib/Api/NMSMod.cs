using NMSLib.Interfaces;
using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;

namespace NMSLib.Api
{
    /// <summary>
    /// Parent class for all NMS mods
    /// </summary>
    public class NMSMod : INMSMod
    {
        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModConfigV1 ModInfo { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public INMSLogger Logger { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public IModLoader ModLoader { get; set; }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public virtual void Start()
        {
            
        }

        /// <summary>
        /// <inheritdoc/>
        /// </summary>
        public virtual void Update()
        {
            
        }
    }
}
