using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Character : MonoBehaviour
{
    public static int money = 3;
    public static List<Card> Cards;
    public static int defaultUpdateShopCost = 1;
    public static int updateShopCost = 1;
    public static int amountOfSpeciallUpdateShopCost = 0;
/*    [SerializeField] private TextMeshProUGUI moneyText;*/
    public static int Money
    {
        get {
            return money < 10 ? money : 10;
        }
        
    }
    private void Awake() 
    {
        DontDestroyOnLoad(this);
       /* moneyText.text = money.ToString();*/
        Cards = new List<Card>
        {
            CardDataBase.cards[0],
            CardDataBase.cards[1],

        };
        
    }
    /*private void Update()
    {
        moneyText.text = money.ToString();
    }*/
}
