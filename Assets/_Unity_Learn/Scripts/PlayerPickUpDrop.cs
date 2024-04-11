using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPickUpDrop : MonoBehaviour
{
    public Transform playerCameraTransform;
    public Transform objectGrabPointTransform;
    public LayerMask pickUpLayerMask;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            float pickUpDistance = 2f;
            if(Physics.Raycast(playerCameraTransform.position, playerCameraTransform.forward, out RaycastHit raycastHit, pickUpDistance))
            {
                if(raycastHit.transform.TryGetComponent(out ObjectGrabbable objectGrabbable))
                {
                    objectGrabbable.Grab(objectGrabPointTransform);
                    Debug.Log(objectGrabbable.name);
                }
            }
        }
        
    }
}
