using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ZoomCard : MonoBehaviour
{
    private bool canZoom = false;
    [SerializeField] GameObject ZoomCardObject;
    Vector3 ZoomCardPos;
    // Start is called before the first frame update
    void Start()
    {
        ZoomCardPos = ZoomCardObject.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (canZoom && Input.GetMouseButton(1))
        {
            Debug.Log("Zoom on this card");
            this.transform.position = new Vector3(ZoomCardPos.x, ZoomCardPos.y, ZoomCardPos.z);
        }
    }

    public void overCard()
    {
        canZoom = true;

        Debug.Log("Over card");
    }

    public void exitOverCard()
    {
        canZoom = false;
        FindAnyObjectByType<CardHandPosition>().resetHandPos();
    }
}
