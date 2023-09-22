
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
//REMAKE IT
public class UpdateShop : MonoBehaviour
{

    private Transform battleGroundShop;
    [SerializeField] GameObject cardPrefab;
    private GameObject cardPrefabCopy;
    private Image cardImage;
    private TextMeshProUGUI cardName;
    private TextMeshProUGUI cardDescription;
    private TextMeshProUGUI cardAttack;
    private TextMeshProUGUI cardHealth;
    private TextMeshProUGUI cardLevel;

    private List<Vector2> places;
    // Start is called before the first frame update
    void Start()
    {
        cardPrefabCopy = cardPrefab;

    }

    public void ShopUpdate()
    {
        Character.money--;
        print("update shop");
        GameProcess.ShopCards.Clear();
        foreach(GameObject obj in GameObject.FindGameObjectsWithTag("Shop-Card"))
        {
            Destroy(obj.gameObject);
        }
        Shop.UpdateShop();
        for (int i = 0; i < GameProcess.amountOfCardInShop; i++)
        {

            Card currentCard = GameProcess.currentCardsInShop[i];
            GameObject cardToShop = ReadCard(currentCard, cardPrefabCopy);
            CardState state = cardToShop.GetComponent<CardState>();
            state.state = CardState.State.ShopCard;
            cardToShop.tag = "Shop-Card";
            GameProcess.ShopCards.Add(cardToShop);
        }
        for(int i = 0; i < GameProcess.ShopCards.Count; i++)
        {
            places = GameProcess.GetNewCardPlaces('s');
            GameProcess.ShopCards[i] = Instantiate(GameProcess.ShopCards[i], places[i], GameProcess.ShopCards[i].transform.rotation);
        }

    }
    public GameObject ReadCard(Card card, GameObject cardPrefabCopy)
    {
        if (cardPrefabCopy == null)
        {
            print("CardPrefabCopy");
        }

        cardName = cardPrefabCopy.transform.GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        cardDescription = cardPrefabCopy.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
        cardAttack = cardPrefabCopy.transform.GetChild(3).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        cardHealth = cardPrefabCopy.transform.GetChild(5).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        cardLevel = cardPrefabCopy.transform.GetChild(4).GetChild(0).GetChild(0).GetComponent<TextMeshProUGUI>();
        cardImage = cardPrefabCopy.transform.GetChild(1).GetComponent<Image>();
        cardImage.sprite = card.spriteImage;
        cardName.text = card.name;
        cardDescription.text = card.description;
        cardAttack.text = card.attack.ToString();
        cardHealth.text = card.health.ToString();
        cardLevel.text = card.level.ToString();
        //Instantiate(cardPrefabCopy, battleGround);
        return cardPrefabCopy;

    }
}