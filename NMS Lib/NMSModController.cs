using System.Collections.Generic;
using NMSLib.Api;
using NMSLib.Interfaces;
using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;

namespace NMSLib
{
    class NMSModController : INmsController
    {
        private IModLoader modLoader;
        private ILogger logger;

        public NMSModController(IModLoader modLoader, ILogger logger)
        {
            this.modLoader = modLoader;
            this.logger = logger;
        }

        public List<INMSMod> NMSMods { get; set; } = new List<INMSMod>();

        public void RegisterNMSMod(INMSMod nmsMod, IModConfigV1 modInfo)
        {
            nmsMod.ModLoader = modLoader;
            nmsMod.ModInfo = modInfo;
            nmsMod.Logger = new NMSLogger(logger, modInfo);
            NMSMods.Add(nmsMod);
            nmsMod.Start();
        }
    }
}
