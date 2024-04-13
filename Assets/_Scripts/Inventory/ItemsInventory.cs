using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using static UnityEditor.Progress;


[CreateAssetMenu(fileName = "DataItemInventory", menuName = "ScriptableObjects/DataItemInventory", order = 1)]
public class ItemsInventory : ScriptableObject
{
    public List<Item> listItems = new List<Item>();

   
}
[System.Serializable]
public class Item
{
    public int id;
    public string name;
    public int quantity;
    public int rarity;
    public ItemType ItemType;
}


public enum ItemType
{
    weapon = 0,
    shield,
    consumable,
    Boosters
}