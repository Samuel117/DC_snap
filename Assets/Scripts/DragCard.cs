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
    [SerializeField] private Canvas canvas;
    [SerializeField] private GameObject zoomCard;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    public string cardName;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
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
        Debug.Log("stop drag");
        if (this.gameObject.transform.parent.gameObject.GetComponent<CardHandPosition>() != null)
        {
            activateCard();
        }
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
        zoomCard.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = cardName;
        //GameObject[] cards = FindObjectOfType<CardHandPosition>().getCardsInHand();
        DragCard[] cards = FindObjectsOfType<DragCard>();

        foreach (DragCard card in cards)
        {
            card.GetComponent<DragCard>().diactivateCard();
        }
    }


    public void OnDrop(PointerEventData eventData)
    { 
        //If card was droped on nothing, restart hand position
        if (eventData.pointerDrag != null)
        {
            GameObject.FindObjectOfType<CardHandPosition>().resetHandPos();
        }
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
