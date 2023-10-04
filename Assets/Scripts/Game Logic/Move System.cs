using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoveSystem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
{
    private bool isBeingHeld;
    private CardShift cardShift;
    private GameObject cardOfPlayer;
    private GameObject hand;
    private GameObject copyOfCard;
    private Vector3 startCardPos;
    private bool isScaled = false;
    private CardHandler cardHandler;
    private Vector2 minMaxY;
    private float timer = 0;
    private void Start()
    {
        startCardPos = transform.position;
        cardHandler = GameObject.FindGameObjectWithTag("GameProcess").GetComponent<CardHandler>();
    }
    void Update()
    {
        if (isBeingHeld) {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);
            gameObject.transform.position = new Vector2(mousePos.x, mousePos.y);
            
        }

    }

    public void OnPointerExit(PointerEventData eventData)
    {
        cardHandler.CardUnscale(this.gameObject);
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        if (this.GetComponent<CardState>().state != CardState.State.HandCard)
        {
            cardHandler.CardScale(this.gameObject);
        }
        
    }
   

public void OnPointerUp(PointerEventData eventData)
    {
        if(GetComponent<CardState>().moveable == true)
        {
            isBeingHeld = false;
            cardHandler.Insert(this.transform, startCardPos);
        }
      
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if(this.GetComponent<CardState>().moveable == true)
        {
            if (GetComponent<CardState>().moveable == true)
            {
                startCardPos = transform.position;
                if (Input.GetMouseButton(0))
                {
                    isBeingHeld = true;
                }
            }

        }
        
        cardHandler.CardUnscale(this.gameObject);  

    }
}
