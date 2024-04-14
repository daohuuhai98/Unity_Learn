using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;

public class GemView : MonoBehaviour
{
    public Image icon;
    public TextMeshProUGUI itemquantity;
    public GemData GemList;
    public void SetItem(int ID, int Quantity)
    {
        foreach (var item in GemList.ListGem)
        {
            if (item.id == ID)
            {
                icon.sprite = item.icon;
            }
        };
        itemquantity.text = Quantity.ToString();
    }
}
