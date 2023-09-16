using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class CardHandler : MonoBehaviour
{
    private float cardSpeed = 4f;
    public void CardMove(Transform card, Vector3 startCardPos)
    {

        switch (card.GetComponent<CardState>().state)
        {
            case CardState.State.ShopCard:

                if (card.position.y < GameProcess.HandZone)
                {
                 
                    GameProcess.HandCards.Add(card.gameObject);
                    card.GetComponent<CardState>().state = CardState.State.HandCard;
                    card.tag = "Hand-Card";
                 
                    List<Vector2> places = GameProcess.CardShift('h');
                    for(int i = 0; i < GameProcess.HandCards.Count; i++)
                    {
                        print(GameProcess.HandCards.Count);
                        StartCoroutine(MoveCard(GameProcess.HandCards[i].transform, places[i]));
                    }

                }
                else
                {
                    print("22222");
                    StartCoroutine(MoveCard(card, startCardPos));
                }
                break;

            //case CardState.State.HandCard:
            //    if (card.position.y > GameProcess.ShopZone)
            //    {

            //        card.SetParent(null);
            //        Destroy(card.gameObject);
            //        Character.money++;
            //        HandCardShift(hand);
            //        //MAKE CARDS IN HAND SHIFTING
            //    }
            //    if (card.position.y > GameProcess.HandZone && card.position.y < GameProcess.ShopZone)
            //    {
            //        foreach (Transform child in cardOfPlayer.transform)
            //        {

            //            if (child.childCount == 0)
            //            {
            //                card.position = Vector2.MoveTowards(card.position, child.position, cardSpeed);
            //                card.SetParent(child);
            //                card.GetComponent<CardState>().state = CardState.State.BattleGroundCard;
                         


            //                break;
            //            }
            //        }
            //        HandCardShift(hand);
            //    }
            //    else
            //    {
            //        StartCoroutine(MoveCard(card, startCardPos));

            //    }
            //    break;
            //case CardState.State.BattleGroundCard:
            //    if (card.position.y > GameProcess.ShopZone)
            //    {
            //        HandCardShift(hand);
            //        Destroy(card.gameObject);
            //        Character.money++;
            //    }
            //    else if (card.position.y > GameProcess.HandZone && card.position.y < GameProcess.ShopZone)
            //    {
            //        cardShift.CardMoving();
            //    }
            //    else
            //    {
            //        StartCoroutine(MoveCard(card, startCardPos));

            //    }
            //    break;
        }
    }
    //public void HandCardShift(GameObject hand)
    //{
        

    //    for (int i = 0; i < hand.transform.childCount; i++)
    //        if (hand.transform.GetChild(i).childCount == 0)
    //        {

    //            for (int j = i + 1; j < hand.transform.childCount; j++)
    //            {
                    
    //                if (hand.transform.GetChild(j).childCount == 0) break;
    //                else
    //                {

    //                    StartCoroutine(MoveCard(hand.transform.GetChild(j).GetChild(0), hand.transform.GetChild(j - 1).position));

    //                    hand.transform.GetChild(j).GetChild(0).SetParent(hand.transform.GetChild(j - 1));
    //                }
    //                break;
    //            }
                    
    //        }

    //}
    IEnumerator MoveCard(Transform target, Vector3 destination)
    {
        print('_');
        print("target" + target.position);
        print("destination " + destination);
        while (Vector2.Distance(target.position, destination) != 0)
        {
            target.position = Vector2.MoveTowards(target.position, destination, Time.deltaTime);
            yield return new WaitForEndOfFrame();
        }
    }

}
