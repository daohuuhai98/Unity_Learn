using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class InventoryCard : MonoBehaviour
{
    public Image IconItem;
    public TextMeshProUGUI NameItem;
    public TextMeshProUGUI Amount;
    private Character data;

    public void SetInventoryData(Character _data)
    {
        data = _data;
        NameItem.text = data.name;
        IconItem.sprite = data.icon;
        Amount.text = data.level.ToString();
    }
}
