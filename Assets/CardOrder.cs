using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CardOrder : MonoBehaviour
{
    List<DragCard> order;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void saveCards(List<DragCard> cardsPlayed)
    {
        for(int i=0;i< cardsPlayed.Count ; i++)
        {
            order.Add(cardsPlayed[i]);
        }
    }
    public DragCard AccessLast(int x)
    {
        return order[order.Count - 1];
    }
}
