using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class CharacterItem : MonoBehaviour
{
    public Image IconCharacter;
    public TextMeshProUGUI NameCharacter;
    public TextMeshProUGUI Level;
    private Character data;
    public void SetItemData(Character _data)
    {
        data = _data;
        NameCharacter.text = data.name;
        IconCharacter.sprite = data.icon;
        Level.text = data.level.ToString();
    }
}
