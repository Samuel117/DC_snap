using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DisplayEnergy : MonoBehaviour
{
    TextMeshProUGUI Tx;
    EnergyController Eg;
    [SerializeField] GameObject gameController;
    private string s;
    private void Start()
    {
        Eg = gameController.GetComponent<EnergyController>();
        Tx = this.gameObject.GetComponent<TextMeshProUGUI>();
        Tx.text = "";
    }

    // Update is called once per frame
    void Update()
    {
        Tx.text = Eg.CurrentEnergy.ToString();
        
    }



}
