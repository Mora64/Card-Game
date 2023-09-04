using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class MoveSystem : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler, IPointerDownHandler
{
    private float startPosX;
    private float startPosY;
    private bool isBeingHeld;

    private CardShift cardShift;
   
    private void Start()
    {
        cardShift = GameObject.FindGameObjectWithTag("BattleGroundShop").GetComponent<CardShift>();
    }
    void Update()
    {
        if (isBeingHeld) {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            gameObject.transform.position = new Vector2(mousePos.x, mousePos.y);

        }

    }
    
    public void OnPointerExit(PointerEventData eventData)
    {
     
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        cardShift.cardMoving();
        isBeingHeld = false;
        print("Mouse up");
    }

    public void OnPointerDown(PointerEventData eventData)
    {
        if (Input.GetMouseButton(0)) {
            Vector3 mousePos;
            mousePos = Input.mousePosition;
            mousePos = Camera.main.ScreenToWorldPoint(mousePos);

            startPosX = mousePos.x - transform.localPosition.x;
            startPosY = mousePos.y - transform.localPosition.y;
            isBeingHeld = true;
        }

        

    }
}
