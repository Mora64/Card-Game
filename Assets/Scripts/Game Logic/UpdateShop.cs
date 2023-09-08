
using TMPro;
using UnityEngine;
using UnityEngine.UI;
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

    // Start is called before the first frame update
    void Start()
    {
        cardPrefabCopy = cardPrefab;
        battleGroundShop  = GameObject.FindGameObjectWithTag("BattleGroundShop").transform;
    }

    public void ShopUpdate()
    {
        print("update shop");
        foreach (Transform child in battleGroundShop.GetChild(0))
        {
            foreach (Transform child1 in child)
            {
                Destroy(child1.gameObject);
            }
        }
        Shop.UpdateShop();
        for (int i = 0; i < GameProcess.amountOfCardInShop; i++)
        {

            Card currentCard = GameProcess.currentCardsInShop[i];
            GameObject cardToShop = ReadCard(currentCard, cardPrefabCopy);
            Instantiate(cardToShop, battleGroundShop.GetChild(0).GetChild(i));
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