using Reloaded.Mod.Interfaces.Internal;

namespace NMSLib.Interfaces
{
	/// <summary>
	/// NMS Mod Controller. Used to communicate between mod's and the API
	/// </summary>
	public interface INmsController
	{
		/// <summary>
		/// Register a NMSMod to the API. Allows access to methods like Start and Update
		/// </summary>
		/// <param name="nmsMod">Mod to register</param>
		/// <param name="modInfo">Info about this specific mod</param>
		public void RegisterNMSMod(INMSMod nmsMod, IModConfigV1 modInfo);
	}
}