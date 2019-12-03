using UnityEngine;

static class ActiveLevelData 
{
    private static float fallingSpeed;
    private static float spawnIntervalStep;

    public static float FallingSpeed { get => -fallingSpeed; }
    public static bool TimerIsNeeded { get; private set; }
    public static int PointsPerSecond { get; private set; }
    public static float EnemySpawnInterval { get; private set; }
    public static float MinSpawnInterval { get; private set; }
    public static float SpawnIntervalStep
    {
        get
        {
            return spawnIntervalStep;
        }
        private set
        {
            value = Mathf.Clamp(value, 0.01f, EnemySpawnInterval);
            spawnIntervalStep = value;
        }
    }
    public static int DiamondSpawnMultiplier { get; private set; }
    public static int PointsFigureSpawnMultiplier { get; private set; }
    public static int PointsSubtractionAmount { get; private set; }
    public static int DiamondsSubtractAmount { get; private set; }
    public static int DifficultyIncreaseStep { get; private set; }
    public static int Timer { get; private set; }

    public static void Set(LevelDataInput data)
    {
        fallingSpeed = data.fallingSpeed;
        TimerIsNeeded = data.timerIsNeeded;
        PointsPerSecond = data.PointsPerSecond;
        EnemySpawnInterval = data.enemySpawnInterval;
        MinSpawnInterval = EnemySpawnInterval / 10;
        SpawnIntervalStep = data.SpawnIntervalStep;
        DiamondSpawnMultiplier = data.diamondSpawnMultiplier;
        PointsFigureSpawnMultiplier = data.pointsFigureSpawnMultiplier;
        PointsSubtractionAmount = data.PointsSubtractionAmount;
        DiamondsSubtractAmount = data.DiamondsSubtractAmount;
        DifficultyIncreaseStep = data.DifficultyIncreaseStep;
        Timer = data.Timer;
    }
}
