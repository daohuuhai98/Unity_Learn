using System.Collections;
using System.Collections.Generic;
using Unity.Mathematics;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour
{
    public Transform playerCameraTransform;
    public Transform objectGrabPointTransform;
    public LayerMask pickUpLayerMask;
    private bool IsPickupItem;
    private ObjectGrabbable Obj;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.F))
        {
            if (!IsPickupItem)
            {
                float pickUpDistance = 2f;
                if (Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance))
                {
                    if (raycastHit.transform.TryGetComponent(out ObjectGrabbable objectGrabbable))
                    {
                        Obj = objectGrabbable;
                        objectGrabbable.Grab(objectGrabPointTransform);
                        Debug.Log(objectGrabbable.name);
                        IsPickupItem = true;
                    }
                }
            }
            else if (IsPickupItem && Obj != null)
            {
                Obj.Drop();
                Obj = null;
                IsPickupItem = false;
            }
        }

        if (Input.GetKey(KeyCode.Q) && Obj != null)
        {
            Obj.RotateXaxis();
        }

        if (Input.GetKey(KeyCode.E) && Obj != null)
        {
            Obj.RotateYaxis();
        }

    }
}
