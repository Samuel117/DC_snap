using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnController : MonoBehaviour
{
    public int MaxTurn;
    public int turn;

    DeckBehaviour db;
    EnergyController Eg;
    EndGame ed;
    cardStack cs;
    
    
    void Start()
    {
        turn = 1;
        MaxTurn = 6;
        db = this.gameObject.GetComponent<DeckBehaviour>();
        Eg = this.gameObject.GetComponent<EnergyController>();
        ed = this.gameObject.GetComponent<EndGame>();

        cs = FindAnyObjectByType<cardStack>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void passTurn()
    {
        turn += 1;
        if (turn > MaxTurn)
        {
            ed.end();
        }
        db.drawCard();
        
        Eg.PlusMaxEnergy();
        Eg.PlusEnergy(1);
        cs.emptyStack();
        
    }

}
