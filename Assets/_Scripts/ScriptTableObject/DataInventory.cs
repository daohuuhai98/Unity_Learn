using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataInventory", menuName = "ScriptableObjects/DataInventory", order = 1)]
public class DataInventory : ScriptableObject
{
    public List<InventoryItem> listInventory;
}
[System.Serializable]
public class InventoryItem
{
    public int idItem;
    public int qtyItem;
}
