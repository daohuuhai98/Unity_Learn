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
    public Dictionary<int, int> GetUniqueInventoryItems()
    {
        Dictionary<int, int> uniqueItems = new Dictionary<int, int>();

        foreach (var item in listInventoryItem)
        {
            if (uniqueItems.ContainsKey(item.itemID))
            {
                uniqueItems[item.itemID] += item.itemAmount;
            }
            else
            {
                uniqueItems.Add(item.itemID, item.itemAmount);
            }
        }

        return uniqueItems;
    }
}
[System.Serializable]
public class InventoryItem
{
    public int itemID;
    public int itemAmount;
}
