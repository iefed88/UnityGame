﻿using UnityEngine;
using UnityEngine.UI;

public class AvaliabilityDisplay : MonoBehaviour
{
    public Sprite LockedIcon;
    public Sprite UnlockedIcon;
    public Button thisButton;
    public Component InspectorAssignmentSceneController;
    private IDictionarySupport thisSceneController;
    void Start()
    {
        thisSceneController = InspectorAssignmentSceneController as IDictionarySupport;
        if (StatusCheck())
        {
            IconeChange();
        }
    }
    private bool StatusCheck() 
    {
        return thisSceneController.UnlockDictionary.GetState(thisButton.name);       
    }
    public void IconeChange()
    {
        thisButton.image.overrideSprite = UnlockedIcon;
    }
}
