using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OldCharacterItem : MonoBehaviour
{
    public Image IconCharacter;
    public TextMeshProUGUI NameCharacter;
    public TextMeshProUGUI Level;
    private Character data;
    public LoopListViewInventory Inventory;

    public void OldSetItemData(Character _data)
    {
        data = _data;
        NameCharacter.text = data.name;
        IconCharacter.sprite = data.icon;
        Level.text = data.level.ToString();
    }

    public void OnClick()
    {
        string nameChar = NameCharacter.text;
        Inventory.OnShow(nameChar);
    }    
}
