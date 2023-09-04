using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ChangeTextColor : MonoBehaviour
{
    Color baseColor;
    Color hoverColor;
    TextMeshProUGUI text;
    void Start()
    {
        text = GetComponentInChildren<TextMeshProUGUI>();
        baseColor = Color.black;
        hoverColor = Color.white;
        text.color = baseColor;
    }

    public void onPointerEnter()
    {
        text.color = hoverColor;
    }
    public void onPointerExit()
    {
        text.color = baseColor;
    }
}
