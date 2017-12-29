using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lvl1SetUp : MonoBehaviour {
    public GameObject[] obj;
    int size;
    int index;


    // Use this for initialization
    void Start()
    {
        index = 0;
        size = obj.Length;
        for(int i=1; i < size; i++)
        {
            obj[i].SetActive(false);
        }
        
    }
    void FixedUpdate()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector2 mousePos2D = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            //StartCoroutine(Example());

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                //if(hit.collider.gameObject.name == obj[index].name)
                //    obj[index].GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;

                if (hit.collider.gameObject.name == obj[index].name&& size-1>index)
                {                  
                    index++;
                    obj[index].SetActive(true);
                }
            }
        }

    }

}
