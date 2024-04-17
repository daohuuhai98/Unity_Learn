using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataItem", menuName = "ScriptableObjects/DataItem", order = 1)]
public class DataItem : ScriptableObject
{
    public List<Itemdata> listItem;
}
[System.Serializable]
public class Itemdata
{
    public int idItem;
    public string nameItem;
    public Sprite iconItem;
    public int rarityItem;
    public ItemCategory categoryItem;
}
public enum ItemCategory
{
    All,
    Weapon,
    Shield,
    Consumable,
    Boosters
}