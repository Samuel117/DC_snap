using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

[Serializable]
public class CardInfo : MonoBehaviour
{
    [SerializeField] TextAsset CSVinfo;
    string[] CDdata;
    int tablesize;




    void Start()
    {
        
        //int tablesize = CDdata.Length / 4 - 1;
        
        //Debug.Log("hola");

    }

    public void fetchCard(int id,GameObject gb)
    {
        string[] CDdata = CSVinfo.text.Split(new string[] { ",", "\n" }, StringSplitOptions.None);
        /*
        Debug.Log(int.Parse(CDdata[6]));
        Debug.Log(int.Parse(CDdata[7]));
        Debug.Log(int.Parse(CDdata[8]));
        Debug.Log(CDdata[9]);
        Debug.Log(CDdata[10] == "true");
        Debug.Log(CDdata[10] == "true");
        */

        
        gb.GetComponent<CardClass>().constructor(int.Parse(CDdata[(id*6)]), int.Parse(CDdata[(id*6) +1]), 
        int.Parse(CDdata[(id * 6) + 2]),CDdata[(id * 6)+3], 
            CDdata[(id * 6) + 4] == "true", CDdata[(id * 6) + 5] == "true");
        
    }

}
