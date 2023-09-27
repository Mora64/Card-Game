using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DisplayCards : MonoBehaviour
{
    private Transform _battleGroundPlay;
    private Transform _battleGroundShop;
    [SerializeField] private GameObject _cardPrefab;
    private GameObject _cardPrefabCopy;
    private Image _cardImage;
    private TextMeshProUGUI _cardName;
    private TextMeshProUGUI _cardDescription;
    private TextMeshProUGUI _cardAttack;
    private TextMeshProUGUI _cardHealth;
    private TextMeshProUGUI _cardLevel;
    private List<Vector2> places;
    void Awake()
    {
        _cardPrefabCopy = _cardPrefab;
        List<GameObject> cardstepm = new List<GameObject>();
        switch (SceneManager.GetActiveScene().name)
        {

            case "Shop":

                places = GameProcess.GetNewCardPlaces('s', GameProcess.amountOfCardInShop);
                //Displaying card in shop
                for (int i = 0; i < GameProcess.amountOfCardInShop; i++)
                {
                    Card currentCard = GameProcess.currentCardsInShop[i];
                    GameObject cardToShop = ReadCard1(currentCard);    
                    CardState state = cardToShop.GetComponent<CardState>();
                    state.state = CardState.State.ShopCard;
                    cardToShop.tag = "Shop-Card";
                    GameProcess.ShopCards.Add(Instantiate(cardToShop, places[i], cardToShop.transform.rotation));

                }



                //Displaying cards of Character
                places = GameProcess.GetNewCardPlaces('h', GameProcess.amountOfCardInShop);
                for (int i = 0; i < Character.Cards.Count; i++)
                {
                    Card currentCard = Character.Cards[i];
                    GameObject cardOfCharacter = ReadCard1(currentCard);
                    CardState state = cardOfCharacter.GetComponent<CardState>();
                    state.state = CardState.State.HandCard;
                    state.moveable = true;
                    state.scalable = true;
                    cardOfCharacter.tag = "Hand-Card";

                    GameProcess.HandCards.Add(Instantiate(cardOfCharacter, places[i], cardOfCharacter.transform.rotation));
                }
              
              /*  for (int i = 0; i < GameProcess.HandCards.Count; i++)
                {
                    places = GameProcess.GetNewCardPlaces('h', GameProcess.HandCards.Count);
                    GameProcess.HandCards[i] = Instantiate(GameProcess.HandCards[i], places[i], GameProcess.HandCards[i].transform.rotation);
                }*/
                    
                break;
            case "Play":
       
            default:
                print("Something went wrong in DisplayCards.cs/switch");
                break;
        }
      
    }
    
    
 /*   public GameObject ReadCard(Card card)
    {
        *//*if (cardPrefabCopy == null)
        {
            print("CardPrefabCopy");
        }*//*
        
        _cardName = _cardPrefabCopy.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        
        _cardDescription = _cardPrefabCopy.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
        _cardAttack = _cardPrefabCopy.transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        _cardHealth = _cardPrefabCopy.transform.GetChild(5).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        _cardLevel = _cardPrefabCopy.transform.GetChild(4).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        _cardImage = _cardPrefabCopy.transform.GetChild(1).GetComponent<Image>();
        
        _cardImage.sprite = card.spriteImage;
        _cardName.text = card.name;
        _cardDescription.text = card.description;
        _cardAttack.text = card.attack.ToString();
        _cardHealth.text = card.health.ToString();
        _cardLevel.text = card.level.ToString();
      
        return _cardPrefabCopy;
    }*/
    public GameObject ReadCard1(Card card)
    {

        _cardAttack = _cardPrefabCopy.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
        _cardHealth = _cardPrefabCopy.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        _cardLevel = _cardPrefabCopy.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>();
        _cardImage = _cardPrefabCopy.transform.GetChild(0).GetChild(0).GetComponent<Image>();

        _cardImage.sprite = card.spriteImage;
        _cardAttack.text = card.attack.ToString();
        _cardHealth.text = card.health.ToString();
        _cardLevel.text = card.level.ToString();

        return _cardPrefabCopy;
    }
}
