using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.ParticleSystem;

public class PlayerPickUpDrop : MonoBehaviour
{
    public Transform playerCameraTransform;
    public Transform objectGrabPointTransform;
    public LayerMask pickUpLayerMask;

    // Update is called once per frame
    public ObjectGrabbable objectGrabbable;
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(objectGrabbable == null)
            {
                float pickUpDistance = 2f;
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance))
                {
                    if (raycastHit.transform.TryGetComponent(out ObjectGrabbable objectGrabbable))
                    {
                        objectGrabbable.Grab(objectGrabPointTransform);
                        //Debug.Log(objectGrabbable.name);
                        this.objectGrabbable = objectGrabbable;

                    }
                }
            }
            else
            {
                objectGrabbable.Drop();
                objectGrabbable = null;
            }
        }

        if (Input.GetKeyDown(KeyCode.F))
        {
            if (objectGrabbable != null)
            {
                var _dataItem = DataManagers.Instance._dataInventory;
                var lst = _dataItem.listItems;
                Item item = _dataItem.listItems.FirstOrDefault(x => x.id == objectGrabbable.idItem);
                InventoryController.Instance.AddItem(item);
                objectGrabbable.OnDetroys();
                objectGrabbable = null;
                

            }
        }
        
    }
}
