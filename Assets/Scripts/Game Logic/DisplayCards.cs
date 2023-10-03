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
    void Start()
    {
        _cardPrefabCopy = _cardPrefab;
        List<GameObject> cardstepm = new List<GameObject>();
        switch (SceneManager.GetActiveScene().name)
        {

            case "Shop":
                /*           UpdateShop.ShopUpdate();*/
                Shop.UpdateShop();
                places = GameProcess.GetNewCardPlaces('s', GameProcess.amountOfCardInShop);
                //Displaying card in shop
                for (int i = 0; i < GameProcess.amountOfCardInShop; i++)
                {

                    Card currentCard = GameProcess.currentCardsInShop[i];
                    GameObject cardToShop = CardHandler.MakeSmallCard(_cardPrefab,currentCard);


                    cardToShop.tag = "Shop-Card";

                    GameProcess.ShopCards.Add(Instantiate(cardToShop, places[i], cardToShop.transform.rotation));
                    CardState state = GameProcess.ShopCards[i].GetComponent<CardState>();
                    state.state = CardState.State.ShopCard;
                    state.card = new Card(currentCard);

                }



                //Displaying cards of Character
                if (GameProcess.HandCards.Count != 0)
                {
                    foreach(GameObject card in GameProcess.HandCards)
                    {
                        card.SetActive(true);
                    }
                }
                if(GameProcess.BattleGroundCards.Count != 0)
                {
                    foreach (GameObject card in GameProcess.BattleGroundCards)
                    {
                        card.SetActive(true);
                    }
                }

                break;
            case "Play":

            default:
                print("Something went wrong in DisplayCards.cs/switch");
                break;
        }

    }
}