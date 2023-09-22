using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CardHandler : MonoBehaviour
{
    private float cardSpeed = 0.04f;
    private bool isMoving = false;
    private char flag = 'o';
    private bool[] hasMoved = new bool[7];
    private List<Vector2> places;
    private List<GameObject> currentListOfCards;
    private Vector2 startCardPosition = Vector2.zero;
    private Transform currentCard;

    private void Update()
    {
        while (isMoving)
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
                currentCard.position = Vector2.MoveTowards(currentCard.position, startCardPosition, cardSpeed);
                break;
            }
            for (int i = 0; i < places.Count; i++)
            {
                currentListOfCards[i].transform.position = Vector2.MoveTowards(currentListOfCards[i].transform.position, places[i], cardSpeed);
                for (int j = 0; j < currentListOfCards.Count; j++)
                    if (Vector2.Distance(currentListOfCards[j].transform.position, places[j]) == 0)
                        hasMoved[j] = true;
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
                    isMoving = false;
                }

            }

        }

    }

    public void CardMove(Transform card, Vector3 startCardPos)
    {

        switch (card.GetComponent<CardState>().state)
        {
            case CardState.State.ShopCard:

                if (card.position.y < GameProcess.HandZone)
                {
                    GameProcess.HandCards.Add(card.gameObject);
                    places = GameProcess.GetNewCardPlaces('h');
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
                    //HandCardShift(hand);
                    //MAKE CARDS IN HAND SHIFTING
                }
                if (card.position.y > GameProcess.HandZone && card.position.y < GameProcess.ShopZone)
                {
                    GameProcess.HandCards.Remove(card.gameObject);
                    GameProcess.BattleGroundCards.Add(card.gameObject);
                    places = GameProcess.GetNewCardPlaces('b');
                    isMoving = true;
                    flag = 'b';

                    //HandCardShift(hand);
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
                    //cardShift.CardMoving();
                }
                else
                {
                    ReturnToStartPosition(card, startCardPos);
                }
                break;
        }
    }
    private void ReturnToStartPosition(Transform card, Vector3 startCardPos)
    {
        flag = 'r';
        isMoving = true;
        currentCard = card;
        startCardPosition = startCardPos;
    }

    private void HandCardShift(char flag)
    {
        List<GameObject> currentListOfCard = new List<GameObject>();
        //switch (flag)
        //{
        //    case 's':
        //        currentListOfCard =
        //}
        //.Sort((x, y) => x.transform.position.x.CompareTo(y.transform.position.x));

    }

        //}
        //    Cards.Sort((x, y) => x.transform.position.x.CompareTo(y.transform.position.x));


        //        for (int i = 0; i<Cards.Count; i++)
        //        {
        //            StartCoroutine(MakeShift(Cards[i], CardPlaces[i]));
        //}
        //    }
        //    IEnumerator MakeShift(GameObject currentCard, GameObject currentCardPosition)
        //{

        //    while (Vector2.Distance(currentCard.transform.position, currentCardPosition.transform.position) != 0)
        //    {
        //        currentCard.transform.position = Vector2.MoveTowards(currentCard.transform.position, currentCardPosition.transform.position, smoothTime);
        //        yield return null;
        //    }
        //}
        //}
    }
