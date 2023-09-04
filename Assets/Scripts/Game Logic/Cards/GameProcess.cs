using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class GameProcess : MonoBehaviour
{

    static public int amountOfCardInShop = 3;
    static public List<Card> currentCardsInShop;
    static public float currentVolume = 0;
    [SerializeField] Slider slider;
    // Update is called once per frame
    private void Awake()
    {
        DontDestroyOnLoad(this);
        currentCardsInShop = new List<Card>();
        currentVolume = slider.normalizedValue;
        slider.value = 0.5f;
        print("Start gameprocess");
    }
    public static void goToFightScene()
    {
        SceneManager.LoadScene("Play");
    }
    public void changeVolume()
    {
        currentVolume = slider.normalizedValue;
    }
    
    
}
