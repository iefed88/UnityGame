﻿using UnityEngine;
using UnityEngine.SceneManagement;

public delegate void UIController();

public class PauseButton : MonoBehaviour
{
    public static bool PauseClick = false;
    public GameObject ScreenBlur;
    public BlurTransparencyChange blurTransparencyChange;

    public event UIController PauseButtonClicked;
    void OnMouseDown()
    {
        PauseButtonClicked?.Invoke();
        Scene activeScene = SceneManager.GetActiveScene();
        if (!PauseClick)
        {
            PauseClick = true;
            ScreenBlur.SetActive(true);
            blurTransparencyChange.ButtonClicked = !blurTransparencyChange.ButtonClicked;
            if (activeScene.buildIndex > 7)
            {
                Time.timeScale = 0.0f;
                AndroidControlls.GameIsPaused = true;
                TapControlls.GameIsPaused = true;
            }
        }
        else if (PauseClick)
        {
            PauseClick = false;
            blurTransparencyChange.ButtonClicked = !blurTransparencyChange.ButtonClicked;
            if (activeScene.buildIndex > 7)
            {
                Time.timeScale = 1.0f;
                AndroidControlls.GameIsPaused = false;
                TapControlls.GameIsPaused = false;
            }
        }
    }
    public void PauseEventToNull() //обнуление события при загрузке новой сцены
    {
        PauseButtonClicked = null;
    }
}
