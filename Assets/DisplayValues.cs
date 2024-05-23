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
        Debug.Log(cd.power);
        Debug.Log(cd.energy);
        
        if (isEnergy)
        {
            tx.text = cd.energy.ToString();
            Debug.Log("hola");
        }
        else
        {
            tx.text = cd.power.ToString();
        }
        
    }
}
