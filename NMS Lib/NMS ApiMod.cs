using NMSLib.Api;
using NMSLib.Interfaces;

namespace NMSLib
{
    internal class NMS_ApiMod : NMSMod
    {
        Input inputManager = new Input();

        public override void Start()
        {
            Logger.WriteLine("API is Initializing...");

            Logger.WriteLine("API finished Initializing!");
        }

        public override void Update()
        {
            inputManager.Update();
        }
    }
}
