using NMSLib.Api;
using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using NMSLib.Interfaces;

namespace NMSLib
{
    class NMSModRegister
    {
        public List<ModGenericTuple<IModConfigV1>> AllActiveMods { get; private set; } = new List<ModGenericTuple<IModConfigV1>>();
        public List<NMSMod> NMSMods { get; private set; } = new List<NMSMod>();
        public IModLoader ModLoader { get; internal set; }
        public ILogger Logger { get; internal set; }

        private bool areModsInit = false;

        public NMSModRegister()
        {

        }

        public void RegisterAllNMSMods(List<ModGenericTuple<IModConfigV1>> allActiveMods)
        {
            NMSLogger.APIWriteLine("Registering all NMS Mods...");
            AllActiveMods = allActiveMods;
            SortMods();            

            foreach (var mod in AllActiveMods)
            {
                var nmsMod = GetNMSMod(mod);
                if (nmsMod == null)
                    continue;

                NMSMods.Add(nmsMod);
            }
            NMSLogger.APIWriteLine("Finished registering all NMS Mods!");
        }

        public NMSMod GetNMSMod(ModGenericTuple<IModConfigV1> mod)
        {            
            var assembly = mod.Mod.GetType().Assembly;
            var nmsModTypes = assembly.GetTypesWithBase(typeof(NMSMod));
            var nmsModType = nmsModTypes?.FirstOrDefault();

            //NMSLogger.APIWriteLine("----- Trying to get NMSMod for " + mod.Generic.ModName + " -----");
            foreach (var type in assembly.GetTypes())
            {
                if (type.BaseType == typeof(NMSMod))
                {
                    //NMSLogger.APIWriteLine("TEST: Initializing mod: " + mod.Generic.ModName);
                    /*NMSLogger.APIWriteLine(type.Name);
                    Activator.CreateInstance(type);*/
                    var nmsMod = (NMSMod)Activator.CreateInstance(type);
                    nmsMod.ModInfo = mod.Generic;
                    return nmsMod;
                }    
            }


            /*if (nmsModType == null)
                return null;

            NMSLogger.APIWriteLine("TEST: Initializing mod: " + mod.Generic.ModName);
            var nmsMod = (NMSMod)Activator.CreateInstance(nmsModType);
            nmsMod.ModInfo = mod.Generic;
            return nmsMod;*/

            return null;
        }

        public void InitAllMods()
        {
            if (areModsInit)
                return;

            NMSLogger.APIWriteLine("Initializing all NMS Mods...");
            NMSMods.ForEach(mod => InitMod(mod));
            NMSLogger.APIWriteLine("All NMS Mods are initialized!");
            areModsInit = true;
        }
        private void InitMod(NMSMod mod)
        {
            NMSLogger.APIWriteLine("Initializing " + mod.ModInfo.ModName);
            //mod.ModLoader = ModLoader;
            //mod.Logger = new NMSLogger(Logger, mod.ModInfo);
            mod.Start();
        }

        private void SortMods()
        {
            int apiIndex = -1;
            for (int i = 0; i < AllActiveMods.Count; i++)
            {
                if (AllActiveMods[i].Generic.ModId == "NMS_Lib")
                {
                    apiIndex = i;
                    break;
                }
            }

            if (apiIndex != -1 && apiIndex != 0)
            {
                AllActiveMods.Insert(0, AllActiveMods[apiIndex]);
                AllActiveMods.RemoveAt(apiIndex + 1);
            }
        }
    }
}
