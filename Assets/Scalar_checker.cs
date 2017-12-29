using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scalar_checker : MonoBehaviour {


    public bool checkerSC;
    int total;
    // Use this for initialization
    void Start()
    {
        total = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if (total == 5)
        {
            checkerSC = true;
        }
        else
        {
            checkerSC = false;
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.tag == "scalar")
        {
            total += 1;
            
        }

    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.tag == "scalar")
        {
            total -= 1;
            //Debug.Log("Scalar: " + total);
        }
    }
}
