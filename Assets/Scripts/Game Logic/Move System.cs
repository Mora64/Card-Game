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

        //if (!isScaled && GetComponent<CardState>().moveable && GetComponent<CardState>().scalable)
        //{
        //    copyOfCard = Instantiate(this.gameObject);
        //    copyOfCard.GetComponent<CardState>().moveable = false;
        //    copyOfCard.GetComponent<CardState>().scalable = false;
        //    copyOfCard.transform.localScale = new Vector2(copyOfCard.transform.localScale.x * 2, copyOfCard.transform.localScale.y * 2);
        //    print(copyOfCard.transform.localScale);
        //    Instantiate(copyOfCard);
        //    copyOfCard.transform.SetParent(null);
        //    isScaled = true;
        //    print(copyOfCard.GetComponent<CardState>().moveable);

        //}



    }
   

public void OnPointerUp(PointerEventData eventData)
    {
      
        if(GetComponent<CardState>().moveable == true)
        {
            isBeingHeld = false;
            cardHandler.CardMove(this.transform, startCardPos);
        }
        
        
    }
    public void OnPointerDown(PointerEventData eventData)
    {
        if(GetComponent<CardState>().moveable == true)
        {
            startCardPos = transform.position;
            if (Input.GetMouseButton(0))
            {
                isBeingHeld = true;
            }
        }
        
    }
   
   
}
