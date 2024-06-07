using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cardStack : MonoBehaviour
{
    //private DragCard[] playedCards = new DragCard[12];
    List<DragCard> playedCards = new List<DragCard>();

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void addPlayerdCard(DragCard card)
    {
        playedCards.Add(card);
        setActiveCard();
    }

    public void removePlayedCard()
    {
        playedCards.RemoveAt(playedCards.Count - 1);
        setActiveCard();
    }

    public void setActiveCard()
    {
        if(playedCards.Count >= 1)
        {
            for (int i = 0; i < playedCards.Count; i++)
            {
                playedCards[i].activateCardInteractions();
                playedCards[i].diactivateCardDrag();

                Debug.Log(playedCards[i].name);
            }
            playedCards[playedCards.Count - 1].activateCardInteractions();
            playedCards[playedCards.Count - 1].activateCardDrag();
        }
    }
}
