using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InventoryCore : MonoBehaviour
{
    // Start is called before the first frame update
    public static InventoryCore Instance { get; private set; }

    //public List<Iteminv> items = new List<Iteminv>();

    //public List<Iteminv> ListItems => items;

    private void Awake()
    {
        // If there is an instance, and it's not me, delete myself.

        if (Instance != null && Instance != this)
        {
            Destroy(this);
        }
        else
        {
            Instance = this;
        }
    }

}
