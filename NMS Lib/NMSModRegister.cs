using NMS_Lib.Api;
using NMSLib.Api;
using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;
using System;
using System.Collections.Generic;
using System.Linq;

namespace NMSLib
{
    class NMSModRegister
    {
        public List<NMSMod> NMSMods { get; private set; } = new List<NMSMod>();
        public IModLoader ModLoader { get; internal set; }
        public ILogger Logger { get; internal set; }

        public NMSModRegister()
        {

        }

        public void LoadAllNMSMods(ModGenericTuple<IModConfigV1>[] allActiveMods)
        {
            foreach (var mod in allActiveMods)
            {
                var nmsMod = GetNMSMod(mod);
                if (nmsMod == null)
                    continue;

                nmsMod.ModLoader = ModLoader;
                nmsMod.Logger = Logger;
                nmsMod.Start();
                NMSMods.Add(nmsMod);
            }
        }

        public NMSMod GetNMSMod(ModGenericTuple<IModConfigV1> mod)
        {
            var assembly = mod.Mod.GetType().Assembly;
            var nmsModType = assembly.GetTypesWithBase(typeof(NMSMod))?.First();

            if (nmsModType == null)
                return null;

            var nmsMod = (NMSMod)Activator.CreateInstance(nmsModType);
            return nmsMod;
        }
    }
}
