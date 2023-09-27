
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

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
    private static float CARDWIDTH = 2.10f;
    private static float SPACING = 0.84f;

    //card grid positions;
    private static Vector2 shopGridPosition;
    private static Vector2 battlegroundGridPosition;
    private static Vector2 handGridPosition;


    //Lists of Cards in
    public static List<GameObject> ShopCards;
    public static List<GameObject> BattleGroundCards;
    public static List<GameObject> HandCards;

    

    public static int amountOfCardsInShop;

    private void Awake()
    {
        DontDestroyOnLoad(this);

        _audioSource = GetComponent<AudioSource>();

        currentCardsInShop = new List<Card>();
        ShopCards = new List<GameObject>();
        BattleGroundCards = new List<GameObject>();
        HandCards = new List<GameObject>();
         
        //Music
        slider.value = 0.5f;
        _currentVolume = slider.normalizedValue;
        changeVolume();

        //CardDataBase
        CardDataBase.Load();

        //Shop
        Shop.cardsInShop = new List<Card>();
        Shop.UpdateShop();
      

        //card grid positions;
        shopGridPosition = new Vector2(0, 2.3f);
        battlegroundGridPosition = new Vector2(0, -0.28f);
        handGridPosition = new Vector2(0, -2.8f);
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

        Vector2 start = getLeftCorner(a, currentGridPosition);

        for (int i = 0; i < a; i++)
            places.Add(new Vector2(start.x + (CARDWIDTH / 2 + (i) * CARDWIDTH + SPACING * i), currentGridPosition.y));

        return places;
    }
    private static Vector2 getLeftCorner(int amount, Vector2 start)
    {
        if (amount == 1) return new Vector2(start.x - CARDWIDTH / 2, 0);
        switch (amount % 2)
        {
            case 1:
                return new Vector2(start.x - ((amount / 2) * CARDWIDTH + SPACING + (CARDWIDTH / 2)), 0);           
            case 0:
                return new Vector2(start.x - ((amount / 2) * CARDWIDTH + (SPACING / 2) * (amount-1)), 0);
            default:
                return Vector2.zero;
        }
    }
}


