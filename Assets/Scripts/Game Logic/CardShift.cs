using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class CardShift : MonoBehaviour
{
   
    public GameObject CharacterCardPlaces;
    public GameObject cardPlace;
    private List<GameObject> Cards;
    private List<GameObject> CardPlaces;
    private List<Transform> CardsPositions;
    private void Start()
    {
        print("Start CardShift");
        
        Cards = new List<GameObject>();
        CardPlaces = new List<GameObject>();
        CardsPositions = new List<Transform>();

        foreach (Transform child in CharacterCardPlaces.transform)
        {
            
            GameObject card = child.GetChild(0).gameObject;
            Cards.Add(card);
            CardPlaces.Add(child.gameObject);
            CardsPositions.Add(card.transform);

        }
     
    }
    public void cardMoving()
    {
        int i = 0;
        CardsPositions.Sort((x, y) => x.position.x.CompareTo(y.position.y));
        foreach (Transform card in CardsPositions)
        {
            Vector3.Lerp(card.position, CardPlaces[i].transform.position, Time.deltaTime);
            i++;
        }
    }
}
