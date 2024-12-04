using UnityEngine;

namespace Games.Platformer2D
{
    public class PlatformTileGenerator : IPlatformTileGenerator
    {
        private readonly GameObject normalTilePrefab;
        private readonly GameObject topTilePrefab;
        private readonly GameObject bottomTilePrefab;
        private readonly GameObject topLeftTilePrefab;
        private readonly GameObject topRightTilePrefab;
        private readonly GameObject bottomLeftTilePrefab;
        private readonly GameObject bottomRightTilePrefab;
        private readonly GameObject midLeftTilePrefab;
        private readonly GameObject midRightTilePrefab;

        public PlatformTileGenerator(
            GameObject normalTilePrefab,
            GameObject topTilePrefab,
            GameObject bottomTilePrefab,
            GameObject topLeftTilePrefab,
            GameObject topRightTilePrefab,
            GameObject bottomLeftTilePrefab,
            GameObject bottomRightTilePrefab,
            GameObject midLeftTilePrefab,
            GameObject midRightTilePrefab)
        {
            this.normalTilePrefab = normalTilePrefab;
            this.topTilePrefab = topTilePrefab;
            this.bottomTilePrefab = bottomTilePrefab;
            this.topLeftTilePrefab = topLeftTilePrefab;
            this.topRightTilePrefab = topRightTilePrefab;
            this.bottomLeftTilePrefab = bottomLeftTilePrefab;
            this.bottomRightTilePrefab = bottomRightTilePrefab;
            this.midLeftTilePrefab = midLeftTilePrefab;
            this.midRightTilePrefab = midRightTilePrefab;
        }

        public void GenerateTiles(GameObject parent, int width, int height)
        {
            for (int x = 0; x < width; x++)
            {
                for (int y = 0; y < height; y++)
                {
                    GameObject tilePrefab = normalTilePrefab;

                    if (y == 0) tilePrefab = bottomTilePrefab;
                    else if (y == height - 1) tilePrefab = topTilePrefab;
                    else if (x == 0 && y == height - 1) tilePrefab = topLeftTilePrefab;
                    else if (x == width - 1 && y == height - 1) tilePrefab = topRightTilePrefab;

                    GameObject tile = Object.Instantiate(tilePrefab, parent.transform);
                    tile.transform.localPosition = new Vector3(x, y - height, 0f);
                }
            }
        }
    }
}
