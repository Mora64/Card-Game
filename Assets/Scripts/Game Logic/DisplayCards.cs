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
    void Awake()
    {
        _cardPrefabCopy = _cardPrefab;
        switch (SceneManager.GetActiveScene().name)
        {

            case "Shop":
         

                //Displaying card in shop
                for (int i = 0; i < GameProcess.amountOfCardInShop; i++)
                {
                    Card currentCard = GameProcess.currentCardsInShop[i];
                    GameObject cardToShop = ReadCard(currentCard, _cardPrefabCopy);    
                    CardState state = cardToShop.GetComponent<CardState>();
                    state.state = CardState.State.ShopCard;
                    state.moveable = true;
                    state.scalable = false;
                    cardToShop.tag = "Shop-Card";
                    GameProcess.ShopCards.Add(cardToShop);    
                }
         
                
                for (int i = 0; i < GameProcess.ShopCards.Count; i++)
                   Instantiate(GameProcess.ShopCards[i], GameProcess.getPlaceToCard('s', i + 1), GameProcess.ShopCards[i].transform.rotation);
                    
                //Displaying cards of Character
                for (int i = 0; i < Character.Cards.Count; i++)
                {
                    Card currentCard = Character.Cards[i];
                    GameObject cardOfCharacter = ReadCard(currentCard, _cardPrefabCopy);
                    CardState state = cardOfCharacter.GetComponent<CardState>();
                    state.state = CardState.State.HandCard;
                    state.moveable = true;
                    state.scalable = true;
                    cardOfCharacter.tag = "Hand-Card";
                    GameProcess.HandCards.Add(cardOfCharacter);
                }

               
                for (int i = 0; i < GameProcess.HandCards.Count; i++)
                   Instantiate(GameProcess.HandCards[i], GameProcess.getPlaceToCard('h', i + 1), GameProcess.HandCards[i].transform.rotation);
                break;
            case "Play":
       
            default:
                print("Something went wrong in DisplayCards.cs/switch");
                break;
        }
      
    }
    
    
    public GameObject ReadCard(Card card, GameObject cardPrefabCopy)
    {
        if (cardPrefabCopy == null)
        {
            print("CardPrefabCopy");
        }

        _cardName = cardPrefabCopy.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        _cardDescription = cardPrefabCopy.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
        _cardAttack = cardPrefabCopy.transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        _cardHealth = cardPrefabCopy.transform.GetChild(5).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        _cardLevel = cardPrefabCopy.transform.GetChild(4).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        _cardImage = cardPrefabCopy.transform.GetChild(1).GetComponent<Image>();
        
        _cardImage.sprite = card.spriteImage;
        _cardName.text = card.name;
        _cardDescription.text = card.description;
        _cardAttack.text = card.attack.ToString();
        _cardHealth.text = card.health.ToString();
        _cardLevel.text = card.level.ToString();
        return cardPrefabCopy;
    }
}
