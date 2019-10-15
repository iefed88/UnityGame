﻿using UnityEngine;

public class ButtonSlideX : MonoBehaviour
{
#pragma warning disable 649
    [SerializeField] private RectTransform rec;
    private Vector2 DefaultOffsetMin, DefaultOffsetMax;

    public float speed;
    public float checkPosON = 0f;
    public float checkPosLeft = -150f;

	void Start()
    {
        DefaultOffsetMin = new Vector2(rec.offsetMin.x, rec.offsetMin.y);
        DefaultOffsetMax = new Vector2(rec.offsetMax.x, rec.offsetMax.y);
    }

    void Update()
    {
        if (PauseButton.PauseClick == true )
        {
            if (rec.offsetMin.x < checkPosON)
            {
                MoveMenuButtonsX(HorizontalDirection.right);
            }

        }
        else if (PauseButton.PauseClick == false)
        {
            if (rec.offsetMin.x > checkPosLeft)
            {
                MoveMenuButtonsX(HorizontalDirection.left);
            }
        }
    }

    private void MoveMenuButtonsX(HorizontalDirection _direction)
    {
        rec.offsetMin += new Vector2(speed, rec.offsetMin.y) * (sbyte)_direction;
        rec.offsetMax += new Vector2(speed, rec.offsetMax.y) * (sbyte)_direction;
    }

    public void ButtonPositionReset()
    {
        rec.offsetMax = DefaultOffsetMax;
        rec.offsetMin = DefaultOffsetMin;
    }
}
