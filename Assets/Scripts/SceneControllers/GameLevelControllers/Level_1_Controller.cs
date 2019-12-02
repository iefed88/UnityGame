using System;
using UnityEngine.UI;
public class Level_1_Controller : LevelSceneController
{
    public Timer timer;
    public Text TimerReplacementText;
    private const string levelName = "GameLevel 1";
    public Level_1_Controller() : base(/*buildindex =*/ 8, levelName) { }

    void Start()
    {
        BaseStart();
        SceneController.LastLevel = levelName;        // перезапись последнего уровня в который играл игрок
        timer.TimerEnded += new Action(TimerAtZero);
        // подписка на событие окончания вступительного текста += new Action(LevelStartTextEnded);
    }

    private void LevelStartTextEnded() // метод для события окончания проигрывания вступительного текста
    {
        //выключение текста через его внутренний метод
        //запуск таймера
        timer.TurnOn();
        // включение Enemy_Creator
    }

    private void TimerAtZero()
    {
        timer.TurnOff();
        TimerReplacementText.gameObject.SetActive(true);
        // выключение Enemy_Creator
        // ожидание окончания падения фигур
        // загрузка сцены с очками
        SceneLoad("WinScore");
    }
}
