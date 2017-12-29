using System.Collections;
using System.Collections.Generic;
using UnityEngine;
// © 2017 TheFlyingKeyboard
// theflyingkeyboard.net
public class move : MonoBehaviour
{
    private Rigidbody2D obj;
    void Start()
    {
        obj = GetComponent<Rigidbody2D>();
        obj.constraints = RigidbodyConstraints2D.FreezeAll;
        
    }


    
    void OnMouseDrag()
    {
        Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
        Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);

        transform.position = objPosition;
        obj.constraints = RigidbodyConstraints2D.None;
    }
    void OnMouseExit()
    {
        
    }

}