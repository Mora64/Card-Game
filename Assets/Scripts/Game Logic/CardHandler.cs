using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CardHandler : MonoBehaviour
{
    private float cardSpeed = 0.04f;
    private bool isMoving = false;
    private bool isShifting = false;
    private char flag = 'o';
    private bool[] hasMoved = new bool[7];
    private List<Vector2> places;
    private List<GameObject> currentListOfCards;
    private List<GameObject> lastListOfCards;
    private Vector2 startCardPosition = Vector2.zero;
    private Transform currentCard;
    private Transform scaledCard;
    private void Update()
    {
        if (isShifting) Shifting();

        if(isMoving) Move();
        

    }

    public void CardMove(Transform card, Vector3 startCardPos)
    {

        switch (card.GetComponent<CardState>().state)
        {
            case CardState.State.ShopCard:

                if (card.position.y < GameProcess.HandZone)
                {
                    card.GetComponent<CardState>().state = CardState.State.HandCard;
                    GameProcess.HandCards.Add(card.gameObject);
                    
                    places = GameProcess.GetNewCardPlaces('h', GameProcess.HandCards.Count);
                    
                    isMoving = true;
                    flag = 'h';
                    
                }
                else
                {
                    ReturnToStartPosition(card, startCardPos);
                }
                break;

            case CardState.State.HandCard:
                if (card.position.y > GameProcess.ShopZone)
                {

                    GameProcess.HandCards.Remove(card.gameObject);
                    Destroy(card.gameObject);
                    Character.money++;
                    /*HandCardShift('h');*/
                    //MAKE CARDS IN HAND SHIFTING
                }
                if (card.position.y > GameProcess.HandZone && card.position.y < GameProcess.ShopZone)
                {
                    GameProcess.HandCards.Remove(card.gameObject);
                    GameProcess.BattleGroundCards.Add(card.gameObject);
                    card.GetComponent<CardState>().state = CardState.State.BattleGroundCard;
                    places = GameProcess.GetNewCardPlaces('b', GameProcess.BattleGroundCards.Count);
                    isMoving = true;
                    flag = 'b';


                }
                else
                {
                    ReturnToStartPosition(card, startCardPos);
                   
                }
                break;
            case CardState.State.BattleGroundCard:
                if (card.position.y > GameProcess.ShopZone)
                {
                    
                    //HandCardShift(hand);
                    GameProcess.BattleGroundCards.Remove(card.gameObject);
                    Destroy(card.gameObject);
                    Character.money++;
                }
                else if (card.position.y > GameProcess.HandZone && card.position.y < GameProcess.ShopZone)
                {
                    isShifting = true;
                    
                }
                else
                {
                    ReturnToStartPosition(card, startCardPos);
                }
                break;
        }
    }
    public void Remove(Transform card)
    {
        
        switch (card.gameObject.GetComponent<CardState>().state)
        {
            case CardState.State.ShopCard:
                GameProcess.ShopCards.Remove(card.gameObject);
                places = GameProcess.GetNewCardPlaces('s', GameProcess.ShopCards.Count);
                flag= 's';
                isMoving = true;
                break;
            case CardState.State.HandCard:
                print("hand");
                GameProcess.HandCards.Remove(card.gameObject);
                places = GameProcess.GetNewCardPlaces('h', GameProcess.HandCards.Count);
                flag = 'h';
                isMoving = true;
                break;
            case CardState.State.BattleGroundCard:
                GameProcess.BattleGroundCards.Remove(card.gameObject);
                places = GameProcess.GetNewCardPlaces('s', GameProcess.BattleGroundCards.Count);
                flag = 'b';
                isMoving = true;
                break;
        }

    }
    public void CheckPlace(Transform card)
    {
        if (GetComponent<CardState>().isShopCard) return;
        if(card.position.y > GameProcess.HandZone && card.position.y < GameProcess.ShopZone)
        {
            List<GameObject> cards = new List<GameObject>(GameProcess.BattleGroundCards);
            cards.Add(card.gameObject);
            cards.Sort((x, y) => x.transform.position.x.CompareTo(y.transform.position.x));

        }
    }
    public  void CardScale(Transform card)
    {
       
        scaledCard = Instantiate(card, new Vector2(card.transform.position.x+3, card.transform.position.y), card.transform.rotation);
        scaledCard.gameObject.GetComponent<RectTransform>().localScale = new Vector3(scaledCard.gameObject.GetComponent<RectTransform>().localScale.x * 2, scaledCard.gameObject.GetComponent<RectTransform>().localScale.y * 2, scaledCard.gameObject.GetComponent<RectTransform>().localScale.z);
    }
    public  void CardUnscale()
    {
        if (scaledCard != null)
        {
            Destroy(scaledCard.gameObject);
        }
        
    }
    private void ReturnToStartPosition(Transform card, Vector3 startCardPos)
    {
        flag = 'r';
        isMoving = true;
        currentCard = card;
        startCardPosition = startCardPos;
    }
    private void Shifting()
    {
        Array.Clear(hasMoved, 0, hasMoved.Length);
        currentListOfCards = new List<GameObject>(GameProcess.BattleGroundCards);
        currentListOfCards.Sort((x, y) => x.transform.position.x.CompareTo(y.transform.position.x));

        for (int i = 0; i < GameProcess.BattleGroundCards.Count; i++)
        {
            if (Vector2.Distance(currentListOfCards[i].transform.position, GameProcess.GetNewCardPlaces('b', GameProcess.BattleGroundCards.Count)[i]) == 0) hasMoved[i] = true;
            currentListOfCards[i].transform.position = Vector2.MoveTowards(currentListOfCards[i].transform.position, GameProcess.GetNewCardPlaces('b', GameProcess.BattleGroundCards.Count)[i], 0.04f);

        }
        for (int i = 0; i < GameProcess.BattleGroundCards.Count; i++)
        {
            if (!hasMoved[i])
            {
                isShifting = true;
                break;
            }
            else
            {
                isShifting = false;
            }
        }
    }
    private void Move()
    {
       
        Array.Clear(hasMoved, 0, hasMoved.Length);
        currentListOfCards = new List<GameObject>();
        switch (flag)
        {
            case 'h':
                currentListOfCards = GameProcess.HandCards;
                break;
            case 's':
                currentListOfCards = GameProcess.ShopCards;
                break;
            case 'b':
                currentListOfCards = GameProcess.BattleGroundCards;
                break;
            default:
                break;
        }
        if (flag == 'r')
        {
            if (Vector2.Distance(currentCard.position, startCardPosition) == 0) isMoving = false;
            currentCard.position = Vector2.MoveTowards(currentCard.position, startCardPosition, cardSpeed);
            return;
        }
        for (int i = 0; i < places.Count; i++)
        {
            print("11111");
            currentListOfCards[i].transform.position = Vector2.MoveTowards(currentListOfCards[i].transform.position, places[i], cardSpeed);
            for (int j = 0; j < currentListOfCards.Count; j++)
                if (Vector2.Distance(currentListOfCards[j].transform.position, places[j]) == 0)
                {
                    print("distance");
                    hasMoved[j] = true;
                }
                    
        }
        for (int i = 0; i < currentListOfCards.Count; i++)
        {
            if (!hasMoved[i])
            {
                isMoving = true;
                break;
            }
            else
            {
                print("else");
                isMoving = false;
            }

        }
    }
}

 
