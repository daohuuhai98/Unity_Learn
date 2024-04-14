using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bai5 : MonoBehaviour
{
    public string Soxe = "1111";
    int Tongso = 0;
    // Start is called before the first frame update
    void Start()
    {
        Soxe = Soxe.Substring(0, 4);
        foreach (char c in Soxe)
        {
            if (char.IsDigit(c))
            {
                Tongso += Int32.Parse(c.ToString());
            }
        }
            Tongso %= 10;
        Debug.Log("So nut la: "+ Tongso);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
