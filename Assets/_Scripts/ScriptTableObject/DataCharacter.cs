using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataCharatcer", menuName = "ScriptableObjects/DataCharatcer", order = 1)]
public class DataCharatcer : ScriptableObject
{
    public List<Character> listCharacter;
}
[System.Serializable]
public class Character
{
    public string name;
    public Sprite icon;
    public float exp;
    public int level;
}
