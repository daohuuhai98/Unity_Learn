using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectGrabbable : MonoBehaviour
{
    public Transform objectGrabPointTransform;

    private Rigidbody objectRigibody;
    private void Awake()
    {
        objectRigibody = gameObject.GetComponent<Rigidbody>();
    }
    public void Grab(Transform _objectPoint)
    {
        objectGrabPointTransform = _objectPoint;
        objectRigibody.useGravity = false;
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
