using System;
using UnityEngine;

namespace Games.Platformer2D
{
    [Serializable]
    public class Chunk
    {
        public GameObject chunk;
        public Vector3 position;
        public int width;
        public int height;

        public Chunk(GameObject chunk, Vector3 position, int width, int height)
        {
            this.chunk = chunk;
            this.position = position;
            this.width = width;
            this.height = height;
        }
    }
}