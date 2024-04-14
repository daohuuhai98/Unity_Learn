using System.Collections;
using System.Collections.Generic;
using System.Drawing.Text;
using UnityEngine;
using static UnityEditor.Progress;

public class ObjectItem : MonoBehaviour
{
    public ItemInventoryData item;
    private InventoryCore core;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.R))
        {
            core.Additem(item);
        }
    }
}
