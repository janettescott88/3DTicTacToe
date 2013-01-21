using System.ComponentModel;

namespace _3DTicTacToe
{
    class Utilities
    {
        /// <summary>
        /// Switches from Human to Computer, and vice versa. 
        /// Given Player must not be None. 
        /// </summary>
        /// <param name="player"></param>
        /// <returns></returns>
        public static Player SwitchPlayer(Player player)
        {
            switch (player)
            {
                case Player.Computer:
                    return Player.Human;
                case Player.Human:
                    return Player.Computer;
            }
            throw new InvalidEnumArgumentException(@"Can only swith between computer and human.");
        }
    }
}
