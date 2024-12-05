namespace Games.Platformer2D
{
    public interface IPlatformGenerator
    {
        void GeneratePlatforms(float time);
        void GenerateNextPlatform();
        void RecyclePlatform(Chunk chunk);
    }
}