using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bai6 : MonoBehaviour
{
    public char Kytu;
    // Start is called before the first frame update
    void Start()
    {
        string Ketqua;
        Ketqua = Kytu.ToString().ToUpper();
        Debug.Log(Ketqua);
    }

    // Update is called once per frame
    void Update()
    {

    }
}
