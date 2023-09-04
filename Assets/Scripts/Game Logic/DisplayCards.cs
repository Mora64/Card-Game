using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class DisplayCards : MonoBehaviour
{
    string previousSceneName = "Menu";
    private Transform battleGroundPlay;
    private Transform battleGroundShop;
    [SerializeField] GameObject cardPrefab;
    private GameObject cardPrefabCopy;
    private Image cardImage;
    private TextMeshProUGUI cardName;
    private TextMeshProUGUI cardDescription;
    private TextMeshProUGUI cardAttack;
    private TextMeshProUGUI cardHealth;
    private TextMeshProUGUI cardLevel;
    private CardStats stats;
    // Start is called before the first frame update
    void Start()
    {
        cardPrefabCopy = cardPrefab;
        
    }
    private void Load()
    {
        switch (SceneManager.GetActiveScene().name)
        {

            case "Shop":
                print("Start display");
                battleGroundShop = GameObject.FindGameObjectWithTag("BattleGroundShop").transform;
                for (int i = 0; i < GameProcess.amountOfCardInShop; i++)
                {
                    
                    Card currentCard = GameProcess.currentCardsInShop[i];
                    GameObject cardToShop = ReadCard(currentCard, cardPrefabCopy);
                    CardStats stats = cardToShop.GetComponent<CardStats>();
                    stats.shopCard = true;
                    Instantiate(cardToShop, battleGroundShop.GetChild(0).GetChild(i));
                }
                for (int i = 0; i < Character.Cards.Count; i++)
                {
                    Card currentCard = Character.Cards[i];
                    GameObject cardOfCharacter = ReadCard(currentCard, cardPrefabCopy);
                    CardStats stats = cardOfCharacter.GetComponent<CardStats>();
                    stats.shopCard = false;
                    Instantiate(cardOfCharacter, battleGroundShop.GetChild(1).GetChild(i));
                }
                break;
            case "Play":
                battleGroundPlay = GameObject.FindGameObjectWithTag("BattleGroundPlay").transform;
                for (int i = 0; i < Character.Cards.Count; i++)
                {
                    Card currentCard = Character.Cards[i];
                    GameObject cardOfCharacter = ReadCard(currentCard, cardPrefabCopy);
                    Instantiate(cardOfCharacter, battleGroundPlay.GetChild(0).GetChild(i));
                }
                break;
            default:
                print(SceneManager.GetActiveScene().name);
                break;
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

        cardPrefabCopy = AddStats(cardPrefabCopy, card.attack, card.health, card.level, card.name, card.description, card.spriteImage);
        return cardPrefabCopy;
    }
    public GameObject AddStats(GameObject Card, int attack, int health, int level, string name, string description, Sprite sprite)
    {
        CardStats stats = Card.GetComponent<CardStats>();
        stats.attack = attack;
        stats.health = health;
        stats.level = level;
        stats.name = name;
        stats.description = description;
        stats.sprite = sprite;
        return Card;
    }
    private void Update()
    {
        if(SceneManager.GetActiveScene().name != previousSceneName) {
            previousSceneName = SceneManager.GetActiveScene().name;
            Load();
        }
    }
}
