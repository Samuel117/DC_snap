using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCard : MonoBehaviour
{
    private cardStack cs;

    private void Awake()
    {
        cs = FindObjectOfType<cardStack>();    
    }

    void Start()
    {
       
    }

    // Update is called once per frame
    void Update()
    {
        //If this object is active, click to reactive cards in hand and remove zoomed card
        if (Input.GetMouseButtonDown(0))
        {
            GameObject[] cardsInHand = FindObjectOfType<CardHandPosition>().getCardsInHand();
            foreach (GameObject card in cardsInHand)
            {
                card.GetComponent<DragCard>().activateCardInteractions();
            }

            cs.setActiveCard();

            gameObject.SetActive(false);
        }
    }
}
