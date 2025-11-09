using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEditor.AssetImporters;
using UnityEngine;

public class RatioPanel : UIBase
{
    [SerializeField] TextMeshProUGUI player1;
    [SerializeField] TextMeshProUGUI player2;
    public void Popup(bool isShowing)
    {
        base.Popup(0.3f, isShowing);
    }
    public void UpdateRatio()
    {
        player1.text = $"{DataManager.instance.MatchScore().x}";
        player2.text = $"{DataManager.instance.MatchScore().y}";
    }
}
