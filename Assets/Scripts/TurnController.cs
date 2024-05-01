using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    public int MaxTurn;
    public int turn;

    DeckBehaviour db;
    EnergyController Eg;
    
    
    void Start()
    {
        turn = 0;
        MaxTurn = 6;
        db = this.gameObject.GetComponent<DeckBehaviour>();
        Eg = this.gameObject.GetComponent<EnergyController>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void passTurn()
    {
        turn += 1;
        db.drawCard();
        
        Eg.PlusMaxEnergy();
        Eg.PlusEnergy(1);
        if (turn > MaxTurn)
        {
            //endgame
        }
    }

}
