using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoveSystem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
{
    private float startPosX;
    private float startPosY;
    private bool isBeingHeld;
    private CardShift cardShift;

    private GameObject cardShopPlaces;
    private GameObject cardOfPlayer;
    private GameObject hand;
   
    private void Start()
    {
        cardShift = GameObject.FindGameObjectWithTag("BattleGroundShop").GetComponent<CardShift>();
        cardShopPlaces = GameObject.FindGameObjectWithTag("CardShopPlaces");
        cardOfPlayer = GameObject.FindGameObjectWithTag("CardsOfPlayer");
        hand = GameObject.FindGameObjectWithTag("Hand");

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
   /* foreach (Transform child in CharacterCardPlaces.transform)
        {

            GameObject card = child.GetChild(0).gameObject;
            Cards.Add(card);
            CardPlaces.Add(child.gameObject);

        }*/

public void OnPointerUp(PointerEventData eventData)
    {
        isBeingHeld = false;
        switch (GetComponent<CardState>().state)
        {
            case CardState.State.ShopCard:
                if(transform.position.y < GameProcess.HandZone)
                {
                    foreach(Transform child in hand.transform)
                    {
           
                        if(child.childCount == 0)
                        {
                            transform.position =  Vector2.MoveTowards(transform.position, child.position, 4);
                            transform.SetParent(child);
                            GetComponent<CardState>().state = CardState.State.HandCard;
                            break;
                        }
                    }
                    
                }
                if (transform.position.y > GameProcess.HandZone && transform.position.y < GameProcess.ShopZone)
                {
                    foreach (Transform child in cardOfPlayer.transform)
                    {

                        if (child.childCount == 0)
                        {
                            transform.position = Vector2.MoveTowards(transform.position, child.position, 4);
                            transform.SetParent(null, false);
                            transform.SetParent(child, false);
                            
                            GetComponent<CardState>().state = CardState.State.BattleGroundCard;
                            break;
                        }
                    }
                }

                break;

            case CardState.State.HandCard:
                if(transform.position.y > GameProcess.ShopZone)
                {
                    Destroy(this.gameObject);
                    Character.money++;
                /*    cardShift.CardMoving('h');*/
                }
                if(transform.position.y > GameProcess.HandZone && transform.position.y < GameProcess.ShopZone)
                {
                    foreach (Transform child in cardOfPlayer.transform)
                    {
                    
                        if (child.childCount == 0)
                        {
                            transform.position = Vector2.MoveTowards(transform.position, child.position, 4);
                            transform.SetParent(child);
                            GetComponent<CardState>().state = CardState.State.BattleGroundCard;
                            break;
                        }
                    }
                }
                if(transform.position.y < GameProcess.HandZone)
                {
                    cardShift.CardMoving('h');
                }
                break;
            case CardState.State.BattleGroundCard:
                if(transform.position.y > GameProcess.ShopZone)
                {
                    Destroy(this.gameObject);
                    Character.money++;

                }
                break;
               
                
        }
        
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0)) {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - transform.localPosition.x;
            startPosY = mousePos.y - transform.localPosition.y;
            isBeingHeld = true;
        }
    }
}
