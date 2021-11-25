using ModSDK.Api;

namespace ModSDK
{
    internal class NMS_ApiMod : ModBase
    {
        public static NMS_ApiMod Instance { get; private set; }
        Input inputManager = new Input();

        public override void Awake()
        {
            Instance = this;
            Logger.WriteLine("API is Initializing...");
        }

        public override void Start()
        {
            Logger.WriteLine("API finished Initializing!");
        }

        public override void Update()
        {
            inputManager.Update();
        }
    }
}
