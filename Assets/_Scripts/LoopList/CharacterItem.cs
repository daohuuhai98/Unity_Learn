using System;
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
    private int _idChar;
    private Action<int> _callback;
    public void OnInit(Action<int> callback)
    {
        _callback = callback; // hứng type action
    }
    public void SetItemData(Character _data)
    {
        data = _data;
        _idChar = _data.idChar;
        NameCharacter.text = data.name;
        IconCharacter.sprite = data.icon;
        Level.text = data.level.ToString(); /// cơ bản 
    }


    public void OnClickAction()
    {

        _callback?.Invoke(_idChar); // invoke callback khi gọi vào phương thức này sẽ tự động callback về trước để mở popup
    }
}
