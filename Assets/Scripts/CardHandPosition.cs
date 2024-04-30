using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class CardHandPosition : MonoBehaviour, IDropHandler
{
    [SerializeField] private GameObject card;
    private HorizontalLayoutGroup horizontalLayoutGroup;
    private RectTransform rectTransform;
    [SerializeField] private CardAnimDrawTest cardAnimDrawTest;

    // Start is called before the first frame update
    void Start()
    {
        horizontalLayoutGroup = GetComponent<HorizontalLayoutGroup>();
        rectTransform = GetComponent<RectTransform>();

        drawInitialHand();
    }

    // Update is called once per frame
    void Update()
    {
        endTurn();

    }

    private void drawInitialHand()
    {
        for(int x = 0; x < 3; x++)
        {
            drawCard();
        }
    }

    private void drawCard()
    {
        //Spawn cards in hand: padding = 900 y -100 por carta
        if (this.transform.childCount < 7)
        {
            //cardAnimDrawTest.activate();
            cardAnimDrawTest.gameObject.SetActive(true);
            Invoke(nameof(instantiateCard), 1f);
        }
    }

    private void endTurn()
    {
        if (Input.GetKeyDown(KeyCode.S))
        {
            drawCard();
        }
    }

    private void instantiateCard()
    {
        GameObject nextCard = Instantiate(card, this.transform);
        nextCard.GetComponent<DragCard>().cardName = "Batman " + this.transform.childCount;
        fixPadding(false);
        LayoutRebuilder.MarkLayoutForRebuild(rectTransform);
    }

    public void resetHandPos()
    {
        LayoutRebuilder.MarkLayoutForRebuild(rectTransform);
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.gameObject.transform.SetParent(rectTransform);
            eventData.pointerDrag.gameObject.GetComponent<DragCard>().activateCard();
            fixPadding(false);
        }
            resetHandPos();
    }

    public GameObject[] getCardsInHand()
    {
        GameObject[] cards = new GameObject[transform.childCount];

        for (int i = 0; i < this.transform.childCount; i++)
        {
            cards[i] = this.transform.GetChild(i).gameObject;
        }

        return cards;
    }

    public HorizontalLayoutGroup gethorizontalLayoutGroup()
    {
        return horizontalLayoutGroup;
    }

    public void fixPadding(bool morePadding)
    {
        if(morePadding)
        {
            horizontalLayoutGroup.padding.left += 100;
            horizontalLayoutGroup.padding.right += 100;
        }
        else
        {
            horizontalLayoutGroup.padding.left -= 100;
            horizontalLayoutGroup.padding.right -= 100;
        }
    }
}
