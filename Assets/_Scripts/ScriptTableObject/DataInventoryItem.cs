using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Deployment.Internal;
using UnityEngine;

[CreateAssetMenu(fileName = "DataInventoryItem", menuName = "ScriptableObjects/DataInventoryItem", order = 1)]
public class DataInventoryItem : ScriptableObject
{
    public List<ItemInventoryData> listitem;
}

[System.Serializable]
public class ItemInventoryData
{
    public int iditem;
    public Sprite icon;
    public int maxquantity;
    public Type type;
    public string displayname;
    public int rarity;
}
public enum Type
{
    weapon = 0,
    consumable,
    Boosters
}