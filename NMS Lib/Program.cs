using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;
using System;

namespace NMSLib
{
    public class Program : IMod
    {
        /// <summary>
        /// Your mod if from ModConfig.json, used during initialization.
        /// </summary>
        private const string MyModId = "NMS_Lib";

        /// <summary>
        /// Used for writing text to the console window.
        /// </summary>
        private ILogger _logger;

        /// <summary>
        /// Provides access to the mod loader API.
        /// </summary>
        private IModLoader _modLoader;

        /// <summary>
        /// An interface to Reloaded's the function hooks/detours library.
        /// See: https://github.com/Reloaded-Project/Reloaded.Hooks
        ///      for documentation and samples. 
        /// </summary>
        private IReloadedHooks _hooks;

        /// <summary>
        /// Entry point for your mod.
        /// </summary>
        public void Start(IModLoaderV1 loader)
        {
            _modLoader = (IModLoader)loader;
            _logger = (ILogger)_modLoader.GetLogger();
            _modLoader.GetController<IReloadedHooks>().TryGetTarget(out _hooks);

            /* Your mod code starts here. */
            NMS_MainMod mainMod = new NMS_MainMod();
            mainMod.Start();
        }

        /* Mod loader actions. */
        public void Suspend()
        {
            /*  Some tips if you wish to support this (CanSuspend == true)
             
                A. Undo memory modifications.
                B. Deactivate hooks. (Reloaded.Hooks Supports This!)
            */
        }

        public void Resume()
        {
            /*  Some tips if you wish to support this (CanSuspend == true)
             
                A. Redo memory modifications.
                B. Re-activate hooks. (Reloaded.Hooks Supports This!)
            */
        }

        public void Unload()
        {
            /*  Some tips if you wish to support this (CanUnload == true).
             
                A. Execute Suspend(). [Suspend should be reusable in this method]
                B. Release any unmanaged resources, e.g. Native memory.
            */
        }

        /*  If CanSuspend == false, suspend and resume button are disabled in Launcher and Suspend()/Resume() will never be called.
            If CanUnload == false, unload button is disabled in Launcher and Unload() will never be called.
        */
        public bool CanUnload() => false;
        public bool CanSuspend() => false;

        /* Automatically called by the mod loader when the mod is about to be unloaded. */
        public Action Disposing { get; }

        /* Contains the Types you would like to share with other mods.
           If you do not want to share any types, please remove this method and the
           IExports interface.
        
           Inter Mod Communication: https://github.com/Reloaded-Project/Reloaded-II/blob/master/Docs/InterModCommunication.md
        */
        public Type[] GetTypes() => new Type[0];

        /* This is a dummy for R2R (ReadyToRun) deployment.
           For more details see: https://github.com/Reloaded-Project/Reloaded-II/blob/master/Docs/ReadyToRun.md
        */
        public static void Main() { }
    }
}
