using ModSDK.Interfaces;
using Reloaded.Hooks.ReloadedII.Interfaces;
using Reloaded.Mod.Interfaces;
using Reloaded.Mod.Interfaces.Internal;
using System;

namespace ModSDK
{
    internal class Program : IMod, IExports
    {
        /// <summary>
        /// Your mod if from ModConfig.json, used during initialization.
        /// </summary>
        private const string ModID = "NMS_Lib";

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
        /// Instance of the NMSModController
        /// </summary>
        ModController _nmsModController;

        /// <summary>
        /// Instance of the API's NMSMod
        /// </summary>
        NMS_ApiMod _apiMod;

        /// <summary>
        /// Mod Info about the API
        /// </summary>
        IModConfigV1 _apiConfig;

        /// <summary>
        /// Entry point for your mod.
        /// </summary>
        public void StartEx(IModLoaderV1 loader, IModConfigV1 config)
        {
            _modLoader = (IModLoader)loader;
            _logger = (ILogger)_modLoader.GetLogger();
            _modLoader.GetController<IReloadedHooks>().TryGetTarget(out _hooks);

            /* Your mod code starts here. */
            _apiConfig = config;
            InitAPI();
        }

        private void InitAPI()
        {
            // Set API Logger
            ModLogger.SetAPILogger(new ModLogger(_logger, _apiConfig));

            // Init ModController
            _nmsModController = new ModController(_modLoader, _logger);
            RegisterAPI();
            _modLoader.AddOrReplaceController<IModController>(this, _nmsModController);

            // Mod Updater
            //   TODO

            // Update Loop
            ModLogger.APIWriteLine("Starting Update Loop...");
            UpdateLoop update = new UpdateLoop(_nmsModController.LoadedMods);
            update.StartUpdateLoopAsync();
            ModLogger.APIWriteLine("Update Loop started!");
        }

        private void RegisterAPI()
        {
            _apiMod = new NMS_ApiMod();
            _nmsModController.RegisterMod(_apiMod, _apiConfig);
            _apiMod.Logger = ModLogger.apiLogger;
        }

        #region Reloaded2 Methods

        public void Suspend() {  }
        public void Resume() {  }
        public void Unload() {  }
        public bool CanUnload() => false;
        public bool CanSuspend() => false;
        public Action Disposing { get; }
        public Type[] GetTypes() => new Type[] { typeof(IModController) };
        public static void Main() { }

        #endregion
    }
}
