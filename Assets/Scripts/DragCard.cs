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

    private cardStack cs;
    private bool canDrag = true;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
        canvas = GameObject.Find("MainCanvas").GetComponent<Canvas>();
        zoomCard = GameObject.Find("ZoomCluster");
        cs = FindObjectOfType<cardStack>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            if (transform.parent.name != "Hand")
            {
                //transform.SetParent(FindObjectOfType<CardHandPosition>().transform);
                transform.SetParent(GameObject.Find("MainCanvas").transform);
                cs.removePlayedCard();
            }
            diactivateCardInteractions();
        }
        else
        {
            eventData.pointerDrag = null;
        }
    }

    public void OnDrag(PointerEventData eventData)
    {
        if (canDrag)
        {
            //Modificamos nuestra posición para añadir la cantidad de movimiento del mouse desde el ultimo frame
            rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
        }
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //No necesario porque el stack se encarga de activar o desactivar cartas
        //activateCard();
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        //none
    }

    public void OnPointerClick(PointerEventData eventData)
    {
        //ZOOM on card when clicked 
        Transform[] zoomElements = zoomCard.transform.GetComponentsInChildren<Transform>(true);
        zoomElements[1].gameObject.SetActive(true);
        
        //Here we set the info to show it in the zoomed card, for now is just the name of the card
        zoomElements[4].gameObject.transform.GetComponent<TextMeshProUGUI>().text = GetComponent<CardClass>().name;

        //GameObject[] cards = FindObjectOfType<CardHandPosition>().getCardsInHand();
        DragCard[] cards = FindObjectsOfType<DragCard>();

        foreach (DragCard card in cards)
        {
            card.GetComponent<DragCard>().diactivateCardInteractions();
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
                cs.addPlayerdCard(eventData.pointerDrag.gameObject.GetComponent<DragCard>());
            }
        }

        //if card is dropped on another card in the hand
        if(this.transform.parent.name == "Hand")
        {
                eventData.pointerDrag.gameObject.transform.SetParent(this.transform.parent);
                eventData.pointerDrag.gameObject.GetComponent<DragCard>().activateCardInteractions();
                eventData.pointerDrag.gameObject.GetComponent<DragCard>().activateCardDrag();
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

    //Hacer metodo y variable para solo desactivar el drag y no el click y llamarlo en el lugar apropiado
    public void diactivateCardInteractions()
    {
        canvasGroup.blocksRaycasts = false;
    }

    public void diactivateCardDrag()
    {
        canDrag = false;
    }

    public void activateCardInteractions()
    {
        canvasGroup.blocksRaycasts = true;
    }

    public void activateCardDrag()
    {
        canDrag = true;
    }

    public bool getDragCard()
    {
        return canDrag;
    }
}
