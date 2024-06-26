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

    int[] paddings = new int[8] {800,800,820,750,670,580,500,450};

    // Start is called before the first frame update
    void Awake()
    {
        horizontalLayoutGroup = GetComponent<HorizontalLayoutGroup>();
    }
    void Start()
    {
        
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
    
    }
   
    public void cardAnimation()
    {
        //Spawn cards in hand: padding = 900 y -100 por carta
        cardAnimDrawTest.gameObject.SetActive(true);
        Invoke(nameof(fixPadding), 1f);
        
    }
   
    public void resetHandPos()
    {
        LayoutRebuilder.MarkLayoutForRebuild(rectTransform);
    }

    public void fixPadding()
    {
        horizontalLayoutGroup.padding.left = paddings[this.transform.childCount];
        horizontalLayoutGroup.padding.right = paddings[this.transform.childCount];
        resetHandPos();
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (eventData.pointerDrag != null)
        {
            eventData.pointerDrag.gameObject.transform.SetParent(rectTransform);
            eventData.pointerDrag.gameObject.GetComponent<DragCard>().activateCardInteractions();
            eventData.pointerDrag.gameObject.GetComponent<DragCard>().activateCardDrag();
        }
        fixPadding();
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

    
    public int getHandSize()
    {
        return transform.childCount;
    }
}
