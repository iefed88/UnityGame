using UnityEngine;
using System.Collections.Generic;

class Enemy_Creator : EnemySpawnRandomizer 
{
    // фигуры врагов для копирования
#pragma warning disable 649
    public GameObject cube_enemy;
#pragma warning disable 649
    public GameObject sphere_enemy;
#pragma warning disable 649
    public GameObject cylinder_enemy;
#pragma warning disable 649
    public GameObject cone_enemy;
#pragma warning disable 649
    public GameObject points_figure;
#pragma warning disable 649
    public GameObject Diamond;
    // лист для фигур со стандартным поведением, то есть просто падающих вниз, для выбора, после выбора по шансам фигур специального поведения
    private List<GameObject> StandardBehaviorEnemy;
    // переменные для контроля уровня сложност
    // контроль частоты появления фигур
    public static float spawnInterval;
    private float timeCount = 0;

    private byte EnemyCounter = 0;

    public StepType stepType = StepType.FloatStep;

    public static float figuresize = 0.3f;
    private float spawnPosY;

    private float[] positionArray;
    private void Start()
    {
        StandardBehaviorEnemy = new List<GameObject> { cube_enemy, cylinder_enemy, cone_enemy, sphere_enemy };
        spawnInterval = ActiveLevelData.GetNewSpawnInterval(stepType);
        spawnPosY = ScreenBorders.Top + ScreenBorders.Top / 10;
        positionArray = SpawnPositionCalculator();    
    }
    void Update()
    {
        timeCount += Time.deltaTime;
        if (timeCount > spawnInterval)
        {
            Enemy_Spawner();
            ++EnemyCounter;
            timeCount = default;
            if (EnemyCounter >= ActiveLevelData.DifficultyIncreaseStep)
            {
                spawnInterval = ActiveLevelData.GetNewSpawnInterval(stepType, ActiveLevelData.SpawnIntervalStep);
                EnemyCounter = default;
            }
            else
                spawnInterval = ActiveLevelData.GetNewSpawnInterval(stepType);
        }
    }
    public void Enemy_Spawner()
    {
        Instantiate(Figure_Randomiser(), new Vector3(Position_Randomizer(positionArray), spawnPosY, 0), Quaternion.identity);     
    }

    GameObject Figure_Randomiser()
    {
        if (SpawnChance.Get(ActiveLevelData.PointsFigureSpawnMultiplier))
        {
            return points_figure;
        }
        else if (SpawnChance.Get(ActiveLevelData.DiamondSpawnMultiplier))
        {
            return Diamond;
        }
        else
        {
            int i = Random.Range(0, StandardBehaviorEnemy.Count);
            return StandardBehaviorEnemy[i] ?? cube_enemy;
        }
    }
}



