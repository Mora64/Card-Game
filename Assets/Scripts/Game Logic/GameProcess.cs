
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;
public class GameProcess : MonoBehaviour
{
    //Music on Background
    private AudioSource _audioSource;
    static private float _currentVolume = 0;
    [SerializeField] private Slider slider;
    //Shop
    static public int amountOfCardInShop = 3;
    static public List<Card> currentCardsInShop;

    //Zones
    public static float HandZone = -2.5f;
    public static float BattleGroundZone = 0.35f;
    public static float ShopZone = 3f;
    //Card size
    private static float CARDHEIGHT = 3f;
    private static float DEFAULTCARDWIDTH = 1.756f;
    private static float HANDCARDWIDTH = 1.34f;
    private static float DEFAULTSPACING = 0.25f;
    private static float HANDCARDSPACING = 0f;

    //card grid positions;
    private static Vector2 shopGridPosition;
    private static Vector2 battlegroundGridPosition;
    private static Vector2 handGridPosition;


    //Lists of Cards in
    public static List<GameObject> ShopCards;
    public static List<GameObject> BattleGroundCards;
    public static List<GameObject> HandCards;
    public static List<GameObject> EnemyCards;

    public static bool FreezeShop = false;

    public static int amountOfCardsInShop;
    [SerializeField] private static GameObject _cardPrefab;
    private void Awake()
    {
        DontDestroyOnLoad(this);
        
        _audioSource = GetComponent<AudioSource>();

        currentCardsInShop = new List<Card>();
        ShopCards = new List<GameObject>();
        BattleGroundCards = new List<GameObject>();
        HandCards = new List<GameObject>();
        EnemyCards = new List<GameObject> ();

        //Music
        slider.value = 0.5f;
        _currentVolume = slider.normalizedValue;
        changeVolume();

        //CardDataBase
        CardDataBase.Load();

        //Shop
        Shop.cardsInShop = new List<Card>();

        //card grid positions;
        shopGridPosition = new Vector2(0, 3.5f);
        battlegroundGridPosition = new Vector2(0, -0.28f);
        handGridPosition = new Vector2(0, -4f);
    }
    public static void goToFightScene()
    {
        SceneManager.LoadScene("Play");
    }
    public void changeVolume()
    {
        _currentVolume = slider.normalizedValue;
        _audioSource.volume = _currentVolume;
    }

    public static List<Vector2>GetNewCardPlaces(char flag, int a)
    {
        List<Vector2> places = new List<Vector2>();
        List<GameObject> currentListOfCard = new List<GameObject>();
        Vector2 currentGridPosition = Vector2.zero;
        float spacing   = flag == 'h' ? HANDCARDSPACING : DEFAULTSPACING;
        float cardWidth = flag == 'h' ? HANDCARDWIDTH   : DEFAULTCARDWIDTH;

        switch (flag)
        {
            case 's':
                currentListOfCard = ShopCards;
                currentGridPosition = shopGridPosition;
              break;
            case 'h':
                currentListOfCard = HandCards;
                currentGridPosition = handGridPosition;
                break;
            case 'b':
                currentListOfCard = BattleGroundCards;
                currentGridPosition = battlegroundGridPosition;
                break;
        }

        Vector2 start = getLeftCorner(a, currentGridPosition, spacing, cardWidth);
        
        for (int i = 0; i < a; i++)
            places.Add(new Vector2(start.x + (cardWidth / 2 + (i) * (cardWidth) + spacing * i), currentGridPosition.y));
       
        return places;
    }
    private static Vector2 getLeftCorner(int amount, Vector2 start, float spacing, float width)
    {
        
        if (amount == 1) return new Vector2(start.x - width / 2, 0);
        switch (amount % 2)
        {
            case 1:
                return new Vector2(start.x - ((amount / 2) * width + (spacing*(amount/2)) + (width / 2)), 0);           
            case 0:
                return new Vector2(start.x - ((amount / 2) * width + (spacing / 2) * (amount-1)), 0);
            default:
                return Vector2.zero;
        }
    }
    public static void UpdateCard(GameObject obj, Card card, bool decorate)
    {
        TextMeshProUGUI _cardAttack;
        TextMeshProUGUI _cardHealth;
        TextMeshProUGUI _cardLevel;

        _cardAttack = obj.transform.GetChild(2).GetChild(0).GetComponent<TextMeshProUGUI>();
        _cardHealth = obj.transform.GetChild(1).GetChild(0).GetComponent<TextMeshProUGUI>();
        _cardLevel = obj.transform.GetChild(3).GetChild(0).GetComponent<TextMeshProUGUI>();
     
        _cardAttack.text = card.attack.ToString();
        _cardHealth.text = card.health.ToString();
        _cardLevel.text = card.level.ToString();

        if (decorate)
        {
            _cardAttack.color = Color.green;
            _cardHealth.color = Color.green;
            _cardLevel.color = Color.green;

        }
        
    }
    public static void SaveCardsBetweenScenes()
    {
        foreach (GameObject obj in HandCards) {
            DontDestroyOnLoad(obj);
            obj.SetActive(false);
        }
        /*foreach (GameObject obj in ShopCards)
        {
            DontDestroyOnLoad(obj);
            obj.SetActive(false);
        }*/
        ShopCards.Clear();
        foreach (GameObject obj in BattleGroundCards) {
            DontDestroyOnLoad(obj);
            obj.SetActive(false);
        }
    }
   

}


