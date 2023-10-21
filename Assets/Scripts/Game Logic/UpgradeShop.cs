using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UpgradeShop : MonoBehaviour
{
    public void Upgrade()
    {
        if (Character.level == 5)
        {
            GameObject.FindGameObjectWithTag("UpgradeShop").SetActive(false);
        }
        Character.level++;
        GameObject.FindGameObjectWithTag("UpgradeShop").GetComponent<TextMeshProUGUI>().text = Character.level.ToString();
        GameProcess.upgradeShopCost += 2;
    }
}
