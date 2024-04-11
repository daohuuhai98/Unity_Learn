using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataCharacter", menuName = "ScriptableObjects/DataCharacter", order = 1)]
public class DataCharacter : ScriptableObject
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
    public List<InventoryItem> listInventoryItem;    
}
[System.Serializable]
public class InventoryItem
{
    public int itemID;
    public int itemAmount;
}
