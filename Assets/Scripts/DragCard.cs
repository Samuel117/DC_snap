using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;
using UnityEngine.XR;

public class DragCard : MonoBehaviour, IPointerDownHandler, 
                        IBeginDragHandler, IEndDragHandler, 
                        IDragHandler, IDropHandler, IPointerClickHandler
{
    private Canvas canvas;
    private GameObject zoomCard;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GameObject.Find("MainCanvas").GetComponent<Canvas>();
        zoomCard = GameObject.Find("ZoomCanvas");
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (transform.parent.name != "Hand")
        { 
            //transform.SetParent(FindObjectOfType<CardHandPosition>().transform);
            transform.SetParent(GameObject.Find("MainCanvas").transform);
        }
        diactivateCard();
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Modificamos nuestra posición para añadir la cantidad de movimiento del mouse desde el ultimo frame
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        activateCard();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //none
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //ZOOM on card when clicked 
        zoomCard.SetActive(true);
        //Here we set the info to show it in the zoomed card, for now is just the name of the card
        zoomCard.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = GetComponent<CardClass>().name; ;
        //GameObject[] cards = FindObjectOfType<CardHandPosition>().getCardsInHand();
        DragCard[] cards = FindObjectsOfType<DragCard>();

        foreach (DragCard card in cards)
        {
            card.GetComponent<DragCard>().diactivateCard();
        }
    }


    public void OnDrop(PointerEventData eventData)
    { 
        //If card was droped on another card in a game zone
        if (eventData.pointerDrag != null)
        {
            if(this.transform.parent.GetComponent<GameZone>() != null 
               && this.transform.parent.GetComponent<GameZone>().getCardsNumber() < 4)
            {
                eventData.pointerDrag.gameObject.transform.SetParent(this.transform.parent);
            }
        }

        //if card is dropped on another card in the hand
        if(this.transform.parent.name == "Hand")
        {
                eventData.pointerDrag.gameObject.transform.SetParent(this.transform.parent);
        }

        GameObject.FindObjectOfType<CardHandPosition>().fixPadding();
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void diactivateCard()
    {
        canvasGroup.blocksRaycasts = false;
    }

    public void activateCard()
    {
        canvasGroup.blocksRaycasts = true;
    }
}
