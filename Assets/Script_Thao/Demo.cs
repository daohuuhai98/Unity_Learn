using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Demo : MonoBehaviour
{
    // Start is called before the first frame update
    int score = 0;
    void Start()
    {
       int sc = UpdateScoreInt();

       Debug.Log("sc la gi " + sc);
       Debug.Log("score la gi " + score);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public int UpdateScoreInt()
    {
        int intR = score++;
        intR=score+1;
        return intR;
    }
}
