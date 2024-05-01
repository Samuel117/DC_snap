using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnergyController : MonoBehaviour
{
    public int MaxEnergy;
    public int CurrentEnergy;

    void Start()
    {
        MaxEnergy = 1;
        CurrentEnergy = MaxEnergy;
    }
    void Update()
    {
           
    }
    public void PlusMaxEnergy()
    {
        MaxEnergy += 1;
    }
    public void MinusMaxEnergy()
    {
        MaxEnergy -= 1;
    }
    public void PlusEnergy(int x)
    {
        CurrentEnergy += x;
    }
    public void MinusEnergy(int x)
    {
        CurrentEnergy -= x;
    }
}
