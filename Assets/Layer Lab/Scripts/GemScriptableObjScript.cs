using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GemData", menuName = "ScriptableObject/GemData", order = 1)]

public class GemData : ScriptableObject
{
    public List<Gem> ListGem;
}

[System.Serializable]

public class Gem
{
    public int id;
    public Sprite icon;
}