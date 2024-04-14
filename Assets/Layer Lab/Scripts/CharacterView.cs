using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using DG.Tweening;
using System;

public class CharacterView : MonoBehaviour
{
    public Image iconcharacter;
    public TextMeshProUGUI namecharacter;
    public TextMeshProUGUI level;
    public GameObject scene;
    
    public void SetItemData(Character datainput)
    {
        iconcharacter.sprite = datainput.icon;
        namecharacter.text = datainput.name;
        level.text = datainput.level.ToString();
    }

    public void Start()
    {
        Button btn = GetComponent<Button>();
        btn.onClick.AddListener(ReadChar);
    }

    public void ReadChar()
    {
        var script = scene.GetComponent<GemListView>();
        script.OnShow(namecharacter.text);
    }

}
