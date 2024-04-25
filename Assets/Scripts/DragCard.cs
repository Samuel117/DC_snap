using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.XR;

public class DragCard : MonoBehaviour, IPointerDownHandler, 
                        IBeginDragHandler, IEndDragHandler, 
                        IDragHandler, IDropHandler, IPointerClickHandler
{
    [SerializeField] private Canvas canvas;

    private RectTransform rectTransform;
    private CanvasGroup canvasGroup;

    private void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
        canvasGroup = GetComponent<CanvasGroup>();
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        Debug.Log("start drag");
        diactivateCard();
    }

    public void OnDrag(PointerEventData eventData)
    {
        //Modificamos nuestra posición para añadir la cantidad de movimiento del maouse desde el ultimo frame
        rectTransform.anchoredPosition += eventData.delta / canvas.scaleFactor;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        //Debug.Log("stop drag");
        if(this.gameObject.transform.parent.gameObject.GetComponent<CardHandPosition>() != null)
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
        Debug.Log("click on card");
    }


    public void OnDrop(PointerEventData eventData)
    {
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
