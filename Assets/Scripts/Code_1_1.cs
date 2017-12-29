using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Code_1_1 : MonoBehaviour {

    // Use this for initialization
    Text []text;
     Image obj;

    void Start () {

        obj = GetComponent<Image>();
        text = GetComponentsInChildren<Text>();

    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (Input.GetMouseButtonDown(0))
        {
            //StartCoroutine(Example());
            for (int i = text.Length - 1; i >= 0; i--)
            {
                Destroy(text[i]);
            }
            //   obj.enabled = false;
            Destroy(obj);
        }
            
        
    }

    IEnumerator Example()
    {
        yield return new WaitForSeconds(5);
    }
}
