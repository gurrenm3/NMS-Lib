using NMSLib.Api.Interfaces.Player;

namespace NMSLib.Api.Game_Classes
{
    public class PlayerStateData : IPlayerStateData
    {
        public int Health { get; set; }
        public int Units { get; set; }
        public int Nanites { get; set; }
        public int Quicksilver { get; set; }
    }
}
