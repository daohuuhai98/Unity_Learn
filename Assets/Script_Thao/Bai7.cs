using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bai7 : MonoBehaviour
{
    public int[] So = { 100, 100, 100 };
    // Start is called before the first frame update
    void Start()
    {
        if (So[0] > So[1])
        {
            if (So[0] > So[2])
            {
                Debug.Log("So lon nhat la: " + So[0]);
                if (So[1] > So[2])
                {
                    Debug.Log("So nho nhat la: " + So[2]);
                }
                else Debug.Log("So nho nhat la: " + So[1]);
            }
            else
            {
                Debug.Log("So lon nha la: " + So[2]);
                Debug.Log("So nho nhat la: " + So[1]);
            }
        }
        else if (So[0] < So[2])
        {
            if (So[1] > So[2])
            {
                Debug.Log("So lon nha la: " + So[1]);
            }
            else
            {
                Debug.Log("So lon nha la: " + So[2]);
            }
            Debug.Log("So nho nhat la: " + So[0]);
        }
        else if (So[1] > So[2]) {
            Debug.Log("So lon nha la: " + So[1]);
            Debug.Log("So nho nhat la: " + So[2]);
        }
        else
        {
            Debug.Log("So lon nha la: " + So[2]);
            Debug.Log("So nho nhat la: " + So[1]);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
