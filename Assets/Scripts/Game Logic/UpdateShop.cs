
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
//REMAKE IT
public class UpdateShop : MonoBehaviour
{

    private static Transform battleGroundShop;
    [SerializeField] GameObject cardPrefab;
    private static GameObject cardPrefabCopy;
    private static Image cardImage;
    private static TextMeshProUGUI cardName;
    private static TextMeshProUGUI cardDescription;
    private static TextMeshProUGUI cardAttack;
    private static TextMeshProUGUI cardHealth;
    private static TextMeshProUGUI cardLevel;

    private static List<Vector3> places;
    // Start is called before the first frame update
    void Start()
    {
        cardPrefabCopy = cardPrefab;
        
    }

    public static void ShopUpdate()
    {

        if (Character.amountOfSpeciallUpdateShopCost != 0)
        {
            if (Character.money > Character.updateShopCost)
            {
                Character.money -= Character.updateShopCost;
                Character.amountOfSpeciallUpdateShopCost--;
            }

        }

       
        
            else if(Character.money >= Character.defaultUpdateShopCost)
            {
                Character.money -= Character.defaultUpdateShopCost;
            }

        
        else
        {
            return;
        }
        
        for(int i = 0; i < GameProcess.ShopCards.Count; i++)
        {
            
            Destroy(GameProcess.ShopCards[i].gameObject);
        }
        GameProcess.ShopCards.Clear();
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
    
    public static  GameObject ReadCard1(Card card)
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