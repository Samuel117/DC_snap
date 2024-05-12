using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CardClass : MonoBehaviour
{
    //atributos basicos
    [SerializeField] public int ID;
    [SerializeField] public int energy;
    [SerializeField] public int power;
    [SerializeField] public string cardname;
    //variables de habilidades
    [SerializeField] public bool destroyable;
    [SerializeField] public bool hability;
    [SerializeField] public bool isPlayed;
    [SerializeField] public bool canMove;
    //variables de modificadores
    [SerializeField] public int addedPower;
    [SerializeField]public int minusPower;

    private void Start()
    {
        
    }

   
    public void  constructor(int id, int x, int y, string s, bool D, bool move)
    {
        ID = id;
        energy = x;
        power = y;
        name = s;

        destroyable = D;
        hability  = true;
        canMove = move;
        isPlayed = false;

        addedPower = 0;
        minusPower = 0;
    }
    
    void AddPower(int x)
        {
            addedPower += x;
        }
    void MinusPower(int x)
        {
            minusPower += x;
        }
    int GetPower()
        {
            return power + addedPower - minusPower;
        }
    int GetEnergy()
        {
            return energy;
        }
    void SetPower(int x)
        {
            power = x;
        }
    }
