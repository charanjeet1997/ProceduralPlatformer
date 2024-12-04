using UnityEngine;

namespace Games.Platformer2D
{
    public interface IObstacleGenerator
    {
        void GenerateObstacles(GameObject chunk, int widthTiles, int heightTiles);
    }
}