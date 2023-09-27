using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    private List<Vector2> places;
    DisplayCards ds;
    void Start()
    {
        places = GameProcess.GetNewCardPlaces('s', Enemy.cards.Count);
        for(int i = 0; i < places.Count; i++)
        {
            
        }
    }
       


    // Update is called once per frame
    void Update()
    {
        
    }
}
