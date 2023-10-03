using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Character : MonoBehaviour
{
    public static int money = 3;
    public static List<Card> Cards;
    private TextMeshProUGUI moneyText;
    public static int defaultUpdateShopCost = 1;
    public static int updateShopCost = 1;
    public static int amountOfSpeciallUpdateShopCost = 0;
    public static int buyingCardCost = 3;
    public static int Money
    {
        get
        {
            return money < 10 ? money : 10;
        }

    }
    private void Awake()
    {
        DontDestroyOnLoad(this);
        moneyText = GameObject.FindGameObjectWithTag("Money").GetComponent<TextMeshProUGUI>();
        moneyText.text = money.ToString();
        Cards = new List<Card>
        {
            CardDataBase.cards[0],
            CardDataBase.cards[1],
            CardDataBase.cards[2]
        };

    }
    private void Update()
    {
        moneyText.text = money.ToString();
    }
}
