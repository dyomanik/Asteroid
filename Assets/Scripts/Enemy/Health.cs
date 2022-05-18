namespace Asteroid
{
    internal sealed class Health
    {
        public float Max { get; }
        public float Current { get; private set; }
        public Health(float max, float current)
        {
            Max = max;
            Current = current;
        }
        public void ChangeCurrentHealth(float healthPoints)
        {
            Current = healthPoints;
        }
    }
}