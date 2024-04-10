using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "DataItem", menuName = "ScriptableObjects/DataItem", order = 1)]
public class DataItem : ScriptableObject
{
    public List<Item> listItem;

    [System.Serializable]
    public class Item
    {
        public string name;
        public int ID;        
        public Sprite icon;
    }
}
