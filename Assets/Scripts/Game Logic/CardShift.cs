using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Linq;
public class CardShift : MonoBehaviour
{
   
    public GameObject CharacterCardPlaces;
    public GameObject Hand;
    private Transform t;
    private List<GameObject> Cards;
    private List<GameObject> CardPlaces;
    private float smoothTime = 0.05f;
    private void Start()
    {
        Cards = new List<GameObject>();
        CardPlaces = new List<GameObject>();

/*
        foreach (Transform child in CharacterCardPlaces.transform)
        {

            GameObject card = child.GetChild(0).gameObject;
            Cards.Add(card);
            CardPlaces.Add(child.gameObject);

        }*/

    }
    public void CardMoving(char flag)
    {

        Cards.Clear();
        CardPlaces.Clear();
       
        if (flag == 'b') t = CharacterCardPlaces.transform;
        if(flag == 'h') t = Hand.transform;

        foreach (Transform child in t)
        {
            if(child.childCount == 0) continue;
            GameObject card = child.GetChild(0).gameObject;
            Cards.Add(card);
            CardPlaces.Add(child.gameObject);

        }
        Cards.Sort((x, y) => x.transform.position.x.CompareTo(y.transform.position.x));
       

        for (int i = 0; i < Cards.Count; i++)
        {
            StartCoroutine(MakeShift(Cards[i], CardPlaces[i]));
        }
    }
    IEnumerator MakeShift(GameObject currentCard, GameObject currentCardPosition)
    {

        while (Vector2.Distance(currentCard.transform.position, currentCardPosition.transform.position) != 0) 
        {
            currentCard.transform.position = Vector2.MoveTowards(currentCard.transform.position, currentCardPosition.transform.position, smoothTime);
            yield return null;
        }
    }
}
