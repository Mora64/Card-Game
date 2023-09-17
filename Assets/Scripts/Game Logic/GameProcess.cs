using System.Collections;
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
        shopGridPosition = new Vector2(0, 1.78f);
        battlegroundGridPosition = new Vector2(0, -1f);
        handGridPosition = new Vector2(0, -3.3f);

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
    public static Vector2 getPlaceToCard(char flag, int position) // flags: s = shop, b = battleground, h = hand
    {
        int amount = 0;
        Vector2 start = new Vector2();
        switch (flag)
        {
            case 's':
                start = shopGridPosition;
                amount = ShopCards.Count;
                break;
            case 'b':
                start = battlegroundGridPosition;
                amount = BattleGroundCards.Count;
                break;
            case 'h':
                start = handGridPosition;
                amount = HandCards.Count;
                break;
            default:
                print("Something went wrong in gameProcess/switch");
                break;
        }

        Vector2 leftGridCorner = new Vector2();

        leftGridCorner = getLeftCorner(amount, start);

        
        
        return new Vector2(leftGridCorner.x + (position - 1) * CARDWIDTH + (SPACING * (position - 1)) + CARDWIDTH / 2, start.y);
    }

    public static List<Vector2>GetNewCardPlaces(char flag)
    {
        List<Vector2> places = new List<Vector2>();
        
        switch (flag)
        {
            case 's':
                for (int i = 0; i < ShopCards.Count; i++)
                {
                    places.Add(getPlaceToCard('s', i+1));
                }
                
                break;
            case 'h':
                Vector2 start = getLeftCorner(GameProcess.HandCards.Count, handGridPosition);
                print(start);
                print(GameProcess.HandCards.Count);
                for (int i = 0; i < HandCards.Count; i++)
                {
                    float temp = CARDWIDTH/2;
                    float stemp = 0;
                    places.Add(new Vector2(start.x + (temp + (i)*CARDWIDTH + SPACING*i), handGridPosition.y));
                    temp += SPACING;
                }
                break;
                
        }
        return places;
        

    }
    private static Vector2 getLeftCorner(int amount, Vector2 start)
    {
        Vector2 leftGridCorner = new Vector2();

        switch (amount % 2)
        {
            case 1:
                leftGridCorner.x = start.x - ((amount / 2) * CARDWIDTH + SPACING + (CARDWIDTH / 2));
                break;
            case 0:
                leftGridCorner.x = start.x - ((amount / 2) * CARDWIDTH + (SPACING / 2) * (amount-1));
                break;
        }
        return leftGridCorner;

    }
    
}


