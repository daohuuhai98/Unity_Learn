using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bai8 : MonoBehaviour
{
    public string Time1 = "03:25:10";
    public string Time2 = "01:20:05";
    // Start is called before the first frame update

    // Update is called once per frame
    void Start()
    {
        int Tong = Timetosecond(Time1) + Timetosecond(Time2);
        int Hieu = System.Math.Abs(Timetosecond(Time1) - Timetosecond(Time2));
        Debug.Log("Tong cua 2 gio la: "+Secondtotime(Tong));
        Debug.Log("Hieu cua 2 gio la: " + Secondtotime(Hieu));
    }

    public int Timetosecond(string Timeinput)
    {
        string[] Timesplit = Timeinput.Split(':');
        int Hours = int.Parse(Timesplit[0]);
        int Minutes = int.Parse(Timesplit[1]);
        int Seconds = int.Parse(Timesplit[2]);
        return (Hours*3600 + Minutes*60 + Seconds);
    }

    public string Secondtotime(int Timeinput)
    {
        int Hours = Timeinput / 3600;
        int Minutes = (Timeinput - (Hours * 3600))/60;
        int Seconds = Timeinput - Hours * 3600 - Minutes * 60;
        return AddZero(Hours)+':'+ AddZero(Minutes) + ':'+ AddZero(Seconds);
    }

    public string AddZero(int Timeinput)
    {
        if (Timeinput < 10)
        {
            return ("0" + Timeinput.ToString());
        }
        return Timeinput.ToString();
    }
}
