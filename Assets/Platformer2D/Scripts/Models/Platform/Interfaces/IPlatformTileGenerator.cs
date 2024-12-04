using UnityEngine;

namespace Games.Platformer2D
{
    public interface IPlatformTileGenerator
    {
        void GenerateTiles(GameObject chunk, int widthTiles, int heightTiles);
    }
}