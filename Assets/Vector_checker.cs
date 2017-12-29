using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Vector_checker : MonoBehaviour {

    public bool checkerVE;
    int total;
	// Use this for initialization
	void Start () {
        total = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if(total == 5)
        {
            checkerVE = true;
        }
        else
        {
            checkerVE = false;
        }
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "vector")
        {
            total += 1;
            //Debug.Log("Vector: "+total);
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "vector")
        {
            total -= 1;
            //Debug.Log("Vector: "+total);
        }
    }
}
