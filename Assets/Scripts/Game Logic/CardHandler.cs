using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;


public class CardHandler : MonoBehaviour
{
    private float cardSpeed = 0.04f;
    private Vector2 startCardPosition = Vector2.zero;
    private Transform currentCard;
    private Transform scaledCard;
    public GameObject fullCardPrefab;
    public GameObject linkToUnscale;
    private Quaternion oldRotation;
    private float oldZPosition;
    private Vector3 oldLocalScale;
    public bool HoldongCard = false;

    [SerializeField] private GameObject _cardPrefab;

    public void Insert(Transform card, Vector3 startCardPos)
    {

        switch (card.GetComponent<CardState>().state)
        {
            case CardState.State.ShopCard:

                if (card.position.y < GameProcess.HandZone)
                {
                    if(Character.money >= Character.buyingCardCost)
                    {
                        GameObject fullcard = Instantiate(MakeFullCard(fullCardPrefab, card.GetComponent<CardState>().card), new Vector2(card.transform.position.x, card.transform.position.y), card.transform.rotation);
                        fullcard.transform.localScale *= 0.5f;

                        fullcard.GetComponent<CardState>().card = card.GetComponent<CardState>().card;
                        fullcard.GetComponent<CardState>().state = CardState.State.HandCard;
                        fullcard.GetComponent<CardState>().scalable = true;
                        GameProcess.HandCards.Add(fullcard.gameObject);
                        GameProcess.ShopCards.Remove(card.gameObject);

                        Destroy(card.gameObject);
                        //print(fullcard.transform.rotation);

                        //Shifting Hand-Cards
                        List<Vector3> places = GameProcess.GetNewCardPlaces('h', GameProcess.HandCards.Count);
                        StartCoroutine(Move('h', places));

                        //Shifting Shop-Cards
                        places = GameProcess.GetNewCardPlaces('s', GameProcess.ShopCards.Count);
                        StartCoroutine(Move('s', places));

                        Character.money -= Character.buyingCardCost;

                    }
                    else
                    {
                        ReturnToStartPosition(card, startCardPos);
                    }

                }
                else ReturnToStartPosition(card, startCardPos);
                break;

            case CardState.State.HandCard:
                //if we are selling the card
                if (card.position.y > GameProcess.ShopZone)
                {
                    GameProcess.HandCards.Remove(card.gameObject);
                    //Shifting Hand-Cards
                    List<Vector3> places = GameProcess.GetNewCardPlaces('h', GameProcess.HandCards.Count);
                    StartCoroutine(Move('h', places));

                    if (card.GetComponent<CardState>().card.cardSpeciallAbilities.Contains(Card.CardSpeciallAbility.AfterSelling))
                        CardAbility.UseCardAbility(card.GetComponent<CardState>().card.idOfAbility, card.gameObject);

                    Character.money += card.GetComponent<CardState>().card.costOfSelling;
                    Destroy(card.gameObject);
                }
                //if we are putting card on table
                else if (card.position.y > GameProcess.HandZone && card.position.y < GameProcess.ShopZone)
                {


                    GameObject smallCard = MakeSmallCard(_cardPrefab, card.GetComponent<CardState>().card);

                    GameProcess.HandCards.Remove(card.gameObject);

                    GameObject temp = Instantiate(smallCard, new Vector2(card.transform.position.x, card.transform.position.y), smallCard.transform.rotation);

                    temp.GetComponent<CardState>().card = card.GetComponent<CardState>().card;
                    temp.GetComponent<CardState>().state = CardState.State.BattleGroundCard;

                    GameProcess.BattleGroundCards.Add(temp);
                    GameProcess.BattleGroundCards.Sort((x, y) => x.transform.position.x.CompareTo(y.transform.position.x));

                    Destroy(card.gameObject);

                    //Shifting BattleGround-Cards
                    List<Vector3> places = GameProcess.GetNewCardPlaces('b', GameProcess.BattleGroundCards.Count);
                    StartCoroutine(Move('b', places));

                    //Shifting Hand-Cards
                    places = GameProcess.GetNewCardPlaces('h', GameProcess.HandCards.Count);
                    StartCoroutine(Move('h', places));

                    //if card has BattleCry Abillity, using it
                    if (card.GetComponent<CardState>().card.cardSpeciallAbilities.Contains(Card.CardSpeciallAbility.BattleCry))
                        CardAbility.UseCardAbility(card.GetComponent<CardState>().card.idOfAbility, card.gameObject);

                }
                else
                {
                    List<Vector3> places = GameProcess.GetNewCardPlaces('h', GameProcess.HandCards.Count);
                    ReturnToStartPosition(card, startCardPos);
                }
                break;

            case CardState.State.BattleGroundCard:
                if (card.position.y > GameProcess.ShopZone)
                {
                    GameProcess.BattleGroundCards.Remove(card.gameObject);

                    //Shifting Hand-Cards
                    List<Vector3> places = GameProcess.GetNewCardPlaces('b', GameProcess.HandCards.Count);
                    StartCoroutine(Move('b', places));

                    if (card.GetComponent<CardState>().card.cardSpeciallAbilities.Contains(Card.CardSpeciallAbility.AfterSelling))
                        CardAbility.UseCardAbility(card.GetComponent<CardState>().card.idOfAbility, card.gameObject);

                    Character.money += card.GetComponent<CardState>().card.costOfSelling;

                    Destroy(card.gameObject);
                }

                else if (card.position.y > GameProcess.HandZone && card.position.y < GameProcess.ShopZone) StartCoroutine(Shifting());

                else ReturnToStartPosition(card, startCardPos);
                break;
        }
    }
    public GameObject MakeFullCard(GameObject obj, Card card)
    {
        obj.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = card.attack.ToString();
        obj.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = card.health.ToString();
        obj.transform.GetChild(4).GetChild(0).GetComponent<TextMeshProUGUI>().text = card.level.ToString();
        obj.transform.GetChild(5).GetChild(0).GetComponent<TextMeshProUGUI>().text = card.name;
        obj.transform.GetChild(6).GetComponent<TextMeshProUGUI>().text = card.description;
        obj.transform.GetChild(1).GetChild(0).GetComponent<Image>().sprite = card.spriteImage;
        return obj;
    }
    public static GameObject MakeSmallCard(GameObject _cardPrefab, Card card)
    {
        _cardPrefab.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>().text = card.attack.ToString();
        _cardPrefab.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>().text = card.health.ToString();
        _cardPrefab.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>().text = card.level.ToString();
        _cardPrefab.transform.GetChild(0).GetChild(0).GetComponent<Image>().sprite = card.spriteImage;
        return _cardPrefab;
    }
    public void CardScale(GameObject card)
    {
        if (!HoldongCard)
        {
            if (card.GetComponent<CardState>().scalable)
            {
                if (card.GetComponent<CardState>().state != CardState.State.HandCard)
                {
                    
                    oldLocalScale = card.transform.localScale;
                    
                    scaledCard = Instantiate(MakeFullCard(fullCardPrefab, card.GetComponent<CardState>().card), new Vector2(card.transform.position.x + 3, card.transform.position.y), card.transform.rotation).transform;
                    scaledCard.transform.localScale /= 4;
                    StartCoroutine(SmoothScaling(scaledCard, oldLocalScale));
                }

                else
                {
                    scaledCard = Instantiate(card, new Vector3(card.transform.position.x, card.transform.position.y+2f, card.transform.position.z), card.transform.rotation).transform;
                    scaledCard.transform.localScale *= 2.5f;
                    scaledCard.transform.rotation = Quaternion.identity;
                    card.layer = LayerMask.NameToLayer("inv");
                    linkToUnscale = card;
                }
            }

        }


    }
    private IEnumerator SmoothScaling(Transform t, Vector3 v)
    {

        while (t.localScale != v)
        {
            t.localScale = Vector3.MoveTowards(t.localScale, v, Time.deltaTime*4);
            yield return null;
        }
        yield break;
    }
    public void CardUnscale(GameObject card)
    {
        if (scaledCard != null)
        {
            StopAllCoroutines();
            Destroy(scaledCard.gameObject);
        }
        if (linkToUnscale != null)
        {

            //print("aaaaa");
            linkToUnscale.layer = LayerMask.NameToLayer("Default");
            //linkToUnscale.transform.localScale /= 2.5f;
            //linkToUnscale.transform.position = new Vector3(linkToUnscale.transform.position.x, linkToUnscale.transform.position.y - 2f, oldZPosition);
            //linkToUnscale.transform.rotation = oldRotation;
            //linkToUnscale = null;
        }


    }
    private void ReturnToStartPosition(Transform card, Vector3 startCardPos)
    {

        currentCard = card;
        startCardPosition = startCardPos;
        StartCoroutine(Move('r', null));
    }
    private IEnumerator Shifting()
    {
        bool[] hasMoved = new bool[10];
        while (true)
        {
            Array.Clear(hasMoved, 0, hasMoved.Length);
            List<GameObject> currentListOfCards = new List<GameObject>(GameProcess.BattleGroundCards);
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
                    yield return null;
                    break;
                }
                else yield break;
            }
        }
    }
    private IEnumerator Move(char flag, List<Vector3> places)
    {

        bool[] hasMoved = new bool[places == null ? 1 : places.Count];
        while (true)
        {
            Array.Clear(hasMoved, 0, hasMoved.Length);
            List<GameObject> currentListOfCards = new List<GameObject>();

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
            FreezeCardScale(currentListOfCards, false);
            if (flag == 'r')
            {
                currentCard.gameObject.GetComponent<CardState>().scalable = false;
                while (Vector2.Distance(currentCard.position, startCardPosition) != 0)
                {
                    currentCard.position = Vector2.MoveTowards(currentCard.position, startCardPosition, cardSpeed);
                    yield return null;
                }
                currentCard.gameObject.GetComponent<CardState>().scalable = true;
                yield break;
            }
            for (int i = 0; i < places.Count; i++)
            {
                currentListOfCards[i].transform.position = Vector2.MoveTowards(currentListOfCards[i].transform.position, places[i], cardSpeed);
                for (int j = 0; j < currentListOfCards.Count; j++)
                    if (Vector2.Distance(currentListOfCards[j].transform.position, places[j]) == 0) hasMoved[j] = true;
            }
            bool stillMove = false;
            for (int i = 0; i < currentListOfCards.Count; i++)
            {
                if (!hasMoved[i]) { stillMove = true; break; }
                else stillMove = false;
            }
            if (stillMove) yield return null;
            else
            {
                FreezeCardScale(currentListOfCards, true);
                yield break;
            }
        }
    }
    private void FreezeCardScale(List<GameObject> list, bool FreezeOrUnfreeze)
    {
        for (int i = 0; i < list.Count; i++)
        {
            list[i].GetComponent<CardState>().scalable = FreezeOrUnfreeze;
        }
    }


}