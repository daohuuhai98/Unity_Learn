using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataCharatcer", menuName = "ScriptableObjects/DataCharatcer", order = 1)]
public class DataCharatcer : ScriptableObject
{
    public List<Character1> listCharacter;
}
[System.Serializable]
public class Character1
{
    public int idChar;
    public string name;
    public Sprite icon;
    public float exp;
    public int level;
    public List<int> idStone;
}
