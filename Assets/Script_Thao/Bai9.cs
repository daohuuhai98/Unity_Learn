using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bai9 : MonoBehaviour
{
    public int N = 1000;
    int Ketqua = 0;
    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < N; i++)
        {
            if (i % 3 == 0 || i % 5 ==0)
            {
                Ketqua += i;
            }
        }
        Debug.Log("Ket qua la: " + Ketqua);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
