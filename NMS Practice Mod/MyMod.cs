using ModSDK.Api;

namespace NMS_Practice_Mod
{
    public class MyMod : ModBase
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