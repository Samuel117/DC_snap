using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeckBehaviour : MonoBehaviour
{
    [SerializeField] GameObject card;
    List<string> Deck; //Lista de cartas
    [SerializeField] int startingHand = 3; //tamaño de la mano inicial
    public int top; // La siguiente carta a robar
    CardHandPosition cd;
    
    void Start()
    {
        Deck = this.gameObject.GetComponent<DeckLoad>().DeckList;
        cd = FindObjectOfType<CardHandPosition>().gameObject.GetComponent<CardHandPosition>();

        //roba mano inicial
        for (int i = 0; i < startingHand; i++)
        {
            refreshTop();
            drawCard();
            Debug.Log(Deck[top]);
            Deck.RemoveAt(top);
        }

        refreshTop();
        
    }

    // Update is called once per frame
    void Update()
    {
   
    }

    public void refreshTop() //llamar cada vez que la cantidad de cartas del mazo se modifique
    {
        if(Deck.Count > 0)
        {
            top = Random.Range(0, Deck.Count);
        }
    }

   public void drawCard() //llamar cada vez que se quiera robar una carta
    {
        
        if(Deck.Count > 0 && cd.getHandSize() < 7)
        {
            //Deck behaviour
            Debug.Log(Deck[top]);
            Deck.RemoveAt(top);
            refreshTop();
            
            
            GameObject test = Instantiate (card,cd.gameObject.transform);
            test.GetComponent<CardClass>().constructor(1,1,1,"batman",true,false);
            cd.FixCard();
        }
    } 
}
