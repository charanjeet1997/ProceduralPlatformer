using UnityEngine;

namespace Games.Platformer2D
{
    [System.Serializable]
    public class DifficultySettings
    {
        public float obstacleSpawnChance = 0.2f;
        public int minPlatformWidth = 4;
        public int maxPlatformWidth = 6;
        public float minGap = 3f;
        public float maxGap = 6f;
        public float amplitude = 1.5f;
        public float frequency = 0.5f;
    }
}