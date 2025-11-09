using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CustomButton : MonoBehaviour
{
    UIManager ui;
    void Awake()
    {
        ui = UIManager.instance;
    }
    
    public void ShowPausePanel()
    {
        ui.ShowPausePanel();
    }
    public void HidePausePanel()
    {
        ui.HidePausePanel();
    }
    public void ShowSettingPanel()
    {
        ui.ShowSettingPanel();
    }
    public void HideSettingPanel()
    {
        ui.HideSettingPanel();
    }
         public void Click()
    {
        ui.Click();
    }
    public void UpdateRatio()
    {
        ui.UpdateRatio();
    }
    public void PlayGame()
    {
        ui.PlayGame();
    }
    public void BackToMenu()
    {
        ui.BackToMenu();
    }
}
