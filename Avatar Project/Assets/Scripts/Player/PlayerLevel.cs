namespace Assets.Scripts.Player
{
    /// <summary>
    /// Class manages player leveling
    /// </summary>
    public class PlayerLevel
    {
        public int currentLevel;
        public const int maxLevel = 30;

        public float currentExp;
        public float expToLevelUp;

        public PlayerLevel()
        {
            
        }
    }
}
