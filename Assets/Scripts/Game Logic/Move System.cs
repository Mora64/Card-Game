using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoveSystem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
{
    private float startPosX;
    private float startPosY;
    private float cardSpeed = 4;
    private bool isBeingHeld;
    private CardShift cardShift;

    private GameObject cardShopPlaces;
    private GameObject cardOfPlayer;
    private GameObject hand;

    private Vector3 startCardPos;

 
    private void Start()
    {
        cardShift = GameObject.FindGameObjectWithTag("BattleGroundShop").GetComponent<CardShift>();
        cardShopPlaces = GameObject.FindGameObjectWithTag("CardShopPlaces");
        cardOfPlayer = GameObject.FindGameObjectWithTag("CardsOfPlayer");
        hand = GameObject.FindGameObjectWithTag("Hand");

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
        switch (GetComponent<CardState>().state)
        {
            case CardState.State.ShopCard:
          
                if (transform.position.y < GameProcess.HandZone)
                {
                    foreach (Transform child in hand.transform)
                    {

                        if (child.childCount == 0)
                        {
                            transform.position = Vector2.MoveTowards(transform.position, child.position, cardSpeed);
                            transform.SetParent(child);
                            GetComponent<CardState>().state = CardState.State.HandCard;
                            break;
                        }
                    }

                }
                else
                {
                 
                    StartCoroutine(MoveCard(this.transform, startCardPos));
                  
                }
                break;

            case CardState.State.HandCard:
                if (transform.position.y > GameProcess.ShopZone)
                {
                   
                    this.transform.SetParent(null);
                    Destroy(this.gameObject);
                    Character.money++;
                    HandCardShift();
                    //MAKE CARDS IN HAND SHIFTING
                }
                if (transform.position.y > GameProcess.HandZone && transform.position.y < GameProcess.ShopZone)
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
                    HandCardShift();
                }
                else
                {
                    StartCoroutine(MoveCard(this.transform, startCardPos));
                 
                }
                break;
            case CardState.State.BattleGroundCard:
                if(transform.position.y > GameProcess.ShopZone)
                {
                    HandCardShift();
                    Destroy(this.gameObject);
                    Character.money++;
                    

                }
                if (transform.position.y > GameProcess.HandZone && transform.position.y < GameProcess.ShopZone)
                {
                    cardShift.CardMoving();
                }
                else
                {
                    StartCoroutine(MoveCard(this.transform, startCardPos));
             
                }
                break;
        }
        
    }
    public void HandCardShift()
    {
        print("call");

        for (int i = 0; i < hand.transform.childCount; i++)
            if (hand.transform.GetChild(i).childCount == 0)
            {
                print("Hand0");

               
                for (int j = i + 1; j < hand.transform.childCount; j++)
                    if (hand.transform.GetChild(j).childCount == 0) break;
                    else
                    {
    
                        StartCoroutine(MoveCard(hand.transform.GetChild(j).GetChild(0), hand.transform.GetChild(j - 1).position));

                        hand.transform.GetChild(j).GetChild(0).SetParent(hand.transform.GetChild(j - 1));
                        

                    }
                break;
            }

    }
    public void OnPointerDown(PointerEventData eventData)
    {
        startCardPos = transform.position;
        if (Input.GetMouseButton(0)) {
            
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - transform.localPosition.x;
            startPosY = mousePos.y - transform.localPosition.y;
            isBeingHeld = true;
        }
    }
   
    IEnumerator MoveCard(Transform target, Vector3 destination)
    {
        
        while (Vector2.Distance(target.position, destination) != 0)
        {
            target.position = Vector2.MoveTowards(target.position, destination, cardSpeed);
            yield return null;
        }
    }
}
