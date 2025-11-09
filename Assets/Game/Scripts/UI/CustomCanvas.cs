using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class CustomCanvas : MonoBehaviour
{
    public  Slider musicSlider;
    public Slider sfxSlider;
    public RatioPanel ratioPanel;

    void Awake()
    {
        UIManager.instance.musicSlider = this.musicSlider;
        UIManager.instance.sfxSlider = this.sfxSlider;
        UIManager.instance.ratioPanel = this.ratioPanel;
    }
}
