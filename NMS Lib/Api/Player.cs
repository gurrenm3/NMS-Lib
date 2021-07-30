using NMSLib.Api.Game_Classes;
using NMSLib.Api.Interfaces.Player;

namespace NMSLib.Api
{
    /// <summary>
    /// Class that controls the Player
    /// </summary>
    public static class Player
    {
        public static IPlayerStateData GetPlayerStateData()
        {
            return new PlayerStateData();
        }
    }
}
