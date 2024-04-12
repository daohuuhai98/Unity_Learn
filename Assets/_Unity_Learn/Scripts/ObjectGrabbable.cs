using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    public Transform objectGrabPointTransform;
    public int idItem;

    private Rigidbody objectRigibody;

    private void Awake()
    {
        objectRigibody = gameObject.GetComponent<Rigidbody>();
    }
    public void Grab(Transform _objectPoint)
    {
        objectGrabPointTransform = _objectPoint;
        objectRigibody.useGravity = false;
        objectRigibody.isKinematic = true;
    }

    public void Drop()
    {
        this.objectGrabPointTransform = null;
        objectRigibody.useGravity = true;
        objectRigibody.isKinematic = false;
    }

    public void OnDetroys()
    {
        Destroy(this.gameObject);
    }
    private void FixedUpdate()
    {
        if(objectGrabPointTransform != null)
        {
            float lerpSpeed = 10f;
            Vector3 newPosition = Vector3.Lerp(transform.position, objectGrabPointTransform.position, Time.deltaTime * lerpSpeed);
            objectRigibody.MovePosition(newPosition);
        }


    }


}
