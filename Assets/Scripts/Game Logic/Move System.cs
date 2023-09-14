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

    private Vector3 startCardPos;

    private CardHandler cardHandler;
    private void Start()
    {
        cardShift = GameObject.FindGameObjectWithTag("BattleGroundShop").GetComponent<CardShift>();

        cardOfPlayer = GameObject.FindGameObjectWithTag("CardsOfPlayer");
        hand = GameObject.FindGameObjectWithTag("Hand");
        cardHandler = GameObject.FindGameObjectWithTag("BattleGroundShop").GetComponent<CardHandler>();
        startCardPos = transform.position;

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
     
    }

    public void OnPointerEnter(PointerEventData eventData)
    {

    }
   

public void OnPointerUp(PointerEventData eventData)
    {
        isBeingHeld = false;
        cardHandler.CardMove(this.transform, hand, cardOfPlayer, cardShift, startCardPos);
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        startCardPos = transform.position;
        if (Input.GetMouseButton(0)) { 
            isBeingHeld = true;
        }
    }
   
   
}
