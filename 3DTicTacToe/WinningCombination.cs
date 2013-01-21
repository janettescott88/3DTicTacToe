using System.Linq;

namespace _3DTicTacToe
{
    /// <summary>
    /// Represents a triplet of indicies that can be used to win the game. 
    /// Order does not matter
    /// </summary>
    public class WinningCombination
    {
        public int[] Indicies { get; private set; }

        public WinningCombination(int first, int second, int third)
        {
            Indicies = new[] { first, second, third };
        }

        /// <summary>
        /// Check if given index is a member of this combination
        /// </summary>
        /// <param name="indexToCheck"></param>
        /// <returns></returns>
        public bool Contains(int indexToCheck)
        {
            return Indicies.Any(t => t == indexToCheck);
        }
    }
}
