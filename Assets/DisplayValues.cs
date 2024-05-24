using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayValues : MonoBehaviour
{
    CardClass cd;
    TextMeshProUGUI tx;
    [SerializeField] bool isEnergy;

    void OnEnable()
    {
        tx = this.gameObject.GetComponentInChildren<TextMeshProUGUI>();
        cd = gameObject.GetComponentInParent<CardClass>();
        tx.text = "";
    }

    // Update is called once per frame
    void Update()
    {
       
        if (isEnergy)
        {
            tx.text = cd.energy.ToString();
            
        }
        else
        {
            tx.text = cd.power.ToString();
        }
        
    }
}
