using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;


public class CustomCanvas : MonoBehaviour
{
    public  Slider musicSlider;
    public Slider sfxSlider;
    public RatioPanel ratioPanel;
    public PausePanel pausePanel;
    public Button pauseButton;
    public SettingPanel settingPanel;
    public MenuPanel menuPanel;
    void Awake()
    {
        if(!GameManager.instance.isPlaying)
        {
            UIManager.instance.menuPanel = this.menuPanel;
        }
        if (GameManager.instance.isPlaying)
        {
            UIManager.instance.pausePanel = this.pausePanel;
            UIManager.instance.pauseButton = this.pauseButton;
        }
        UIManager.instance.settingPanel = this.settingPanel;
        UIManager.instance.musicSlider = this.musicSlider;
        UIManager.instance.sfxSlider = this.sfxSlider;
        UIManager.instance.ratioPanel = this.ratioPanel;
    }
}
