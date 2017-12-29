using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dragging : MonoBehaviour {


    public GameObject returnPoint;
    public GameObject obj;

    public GameObject playMusic;
    public AudioClip impact;
    AudioSource sound;

    bool returnControl = false;
	void Start () {
        sound = playMusic.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
        //if (obj.transform.position == returnPoint.transform.position)
        //    returnControl = false;
        

    }
    void OnMouseDrag()
    {
        


        if (returnControl)
        {
            Vector3 here = returnPoint.transform.position;
            transform.position = here;
            
        }
        else
        {
            Vector2 mousePosition = new Vector2(Input.mousePosition.x, Input.mousePosition.y);
            Vector2 objPosition = Camera.main.ScreenToWorldPoint(mousePosition);
            transform.position = objPosition;
        }

        
    }
    void OnMouseDown()
    {
        returnControl = false;
    }
    void OnTriggerEnter2D(Collider2D other)
    {

        if (obj.tag == "vector")
        {
            if (other.name == "scalar table_")
            {
                //Debug.Log(obj.tag);
                returnControl = true;
                sound.PlayOneShot(impact, 1);

            }
        }
        if (obj.tag == "scalar")
        {
            if (other.name == "vector table_")
            {
                returnControl = true;
                sound.PlayOneShot(impact, 1);
            }
        }

    }

}
