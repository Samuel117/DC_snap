using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCard : MonoBehaviour
{
    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //If this object is active, click to reactive cards in hand and remove zoomed card
        if (Input.GetMouseButtonDown(0))
        {
            //GameObject[] cards = FindObjectOfType<CardHandPosition>().getCardsInHand();
            DragCard[] cards = FindObjectsOfType<DragCard>();
            foreach (DragCard card in cards)
            {
                card.GetComponent<DragCard>().activateCard();
            }

            gameObject.SetActive(false);
        }
    }
}
