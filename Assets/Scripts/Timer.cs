using System;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    public Text timerDisplay;
    public float timer { get; set; }
    public Timer()
    {
        timer = ActiveLevelData.Timer;
    }

    public void TurnOn()
    {
        gameObject.SetActive(true);
    }

    void FixedUpdate()
    {
        if (timer > 0)
        {
            timer -= Time.deltaTime;
            timerDisplay.text = String.Format("{0:00}:{1:00}", (int)timer / 60, (int)timer % 60);
        }
    }
}
