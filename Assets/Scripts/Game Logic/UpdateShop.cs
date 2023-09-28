
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
        
        if(Character.amountOfSpeciallUpdateShopCost != 0)
        {
            Character.money -= Character.updateShopCost;
            Character.amountOfSpeciallUpdateShopCost--;
        }
        else Character.money -= Character.defaultUpdateShopCost;
   
        for(int i = 0; i < GameProcess.ShopCards.Count; i++)
        {
            
            Destroy(GameProcess.ShopCards[i].gameObject);
        }
        GameProcess.ShopCards.Clear();
        print("Count +" + GameProcess.ShopCards.Count);
        Shop.UpdateShop();
        for (int i = 0; i < GameProcess.amountOfCardInShop; i++)
        {
            places = GameProcess.GetNewCardPlaces('s', GameProcess.amountOfCardInShop);
            Card currentCard = GameProcess.currentCardsInShop[i];
            GameObject cardToShop = ReadCard1(currentCard);
            
            cardToShop.tag = "Shop-Card";
            GameProcess.ShopCards.Add(Instantiate(cardToShop, places[i], cardToShop.transform.rotation));
            CardState state = GameProcess.ShopCards[i].GetComponent<CardState>();
            state.state = CardState.State.ShopCard;
            state.card = currentCard;
        }
    }
    
    public GameObject ReadCard1(Card card)
    {

        cardAttack = cardPrefabCopy.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
        cardHealth = cardPrefabCopy.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        cardLevel = cardPrefabCopy.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>();
        cardImage = cardPrefabCopy.transform.GetChild(0).GetChild(0).GetComponent<Image>();

        cardImage.sprite = card.spriteImage;
        cardAttack.text = card.attack.ToString();
        cardHealth.text = card.health.ToString();
        cardLevel.text = card.level.ToString();

        return cardPrefabCopy;
    }
}