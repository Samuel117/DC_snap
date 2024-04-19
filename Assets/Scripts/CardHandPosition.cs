using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class CardHandPosition : MonoBehaviour
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
        //Spawn cards in hand: padding = 460 y -50 por carta
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
        Instantiate(card, this.transform);
        horizontalLayoutGroup.padding.left -= 50;
        horizontalLayoutGroup.padding.right -= 50;
        LayoutRebuilder.MarkLayoutForRebuild(rectTransform);
    }

    public void resetHandPos()
    {
        LayoutRebuilder.MarkLayoutForRebuild(rectTransform);
    }
}
