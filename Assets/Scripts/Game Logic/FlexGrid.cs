using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class FlexGrid : MonoBehaviour
{
    private GridLayoutGroup grid;
   /* private int cardAmount;
    private float cardSpacing;
    private float cardWidth;
    private float cardHeight;*/
    void Start()
    {
        grid = GetComponent<GridLayoutGroup>();
    
    }

    
    
    void UpdateGrid(GameObject card, int cardAmount)
    {
        
    }
}
