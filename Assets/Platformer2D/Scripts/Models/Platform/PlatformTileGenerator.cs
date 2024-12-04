using UnityEngine;

namespace Games.Platformer2D
{
    public class PlatformTileGenerator : IPlatformTileGenerator
    {
        private GameObject normalTilePrefab;
        private GameObject topTilePrefab;

        public PlatformTileGenerator(GameObject normalTilePrefab, GameObject topTilePrefab)
        {
            this.normalTilePrefab = normalTilePrefab;
            this.topTilePrefab = topTilePrefab;
        }

        public void GenerateTiles(GameObject chunk, int widthTiles, int heightTiles)
        {
            // Create and configure the top tile
            GameObject topTile = GameObject.Instantiate(topTilePrefab, chunk.transform);
            topTile.transform.localPosition = new Vector3(0, -0.5f, 0);
           // topTile.transform.localScale = new Vector3(widthTiles, 1, 1); // Scale top tile to width
            topTile.GetComponent<SpriteRenderer>().size = new Vector2(widthTiles, 0.5f);
            topTile.GetComponent<BoxCollider2D>().size = new Vector2(widthTiles, 0.5f);
            topTile.transform.localScale = Vector3.one;
            // Create and configure the normal tile
            GameObject normalTile = GameObject.Instantiate(normalTilePrefab, chunk.transform);
            normalTile.transform.localPosition = new Vector3(0, -(heightTiles / 2f) - 0.75f, 0);
            //normalTile.transform.localScale = new Vector3(widthTiles, heightTiles, 1); // Scale normal tile to width and height
            normalTile.GetComponent<SpriteRenderer>().size = new Vector2(widthTiles, heightTiles);
            normalTile.GetComponent<BoxCollider2D>().size = new Vector2(widthTiles, heightTiles);
            normalTile.transform.localScale = Vector3.one;
        }
    }
}