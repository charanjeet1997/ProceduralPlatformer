using UnityEngine;

namespace Games.Platformer2D
{
    public class DifficultyManager : MonoBehaviour
    {
        [SerializeField] private DifficultySettings easySettings;
        [SerializeField] private DifficultySettings mediumSettings;
        [SerializeField] private DifficultySettings hardSettings;

        public DifficultyLevel CurrentDifficulty { get; private set; } = DifficultyLevel.Medium;

        public DifficultySettings CurrentSettings
        {
            get
            {
                return CurrentDifficulty switch
                {
                    DifficultyLevel.Easy => easySettings,
                    DifficultyLevel.Medium => mediumSettings,
                    DifficultyLevel.Hard => hardSettings,
                    _ => mediumSettings
                };
            }
        }

        public void SetDifficulty(DifficultyLevel difficultyLevel)
        {
            CurrentDifficulty = difficultyLevel;
        }
    }
}