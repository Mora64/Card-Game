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


    
    private void Awake()
    {
        DontDestroyOnLoad(this);

        _audioSource = GetComponent<AudioSource>();

        currentCardsInShop = new List<Card>();

        //Music
        slider.value = 0.5f;
        _currentVolume = slider.normalizedValue;
        changeVolume();

        //CardDataBase
        CardDataBase.Load();

        //Shop
        Shop.cardsInShop = new List<Card>();
        Shop.UpdateShop();


        

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

    
}


