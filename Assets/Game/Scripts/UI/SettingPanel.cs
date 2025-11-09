using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingPanel : UIBase
{
    public void Popup(bool isShowing)
    {
        base.Popup(0.3f,isShowing);
    }
}
