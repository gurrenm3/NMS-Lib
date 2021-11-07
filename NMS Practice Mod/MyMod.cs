using NMSLib.Api;

namespace NMS_Practice_Mod
{
    public class MyMod : NMSMod
    {
        public override void Start()
        {
            Logger.WriteLine($"{ModInfo.ModName} has just Started!");
        }

        public override void Update()
        {
            
        }
    }
}