using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class checker_lvl4 : MonoBehaviour {

    public Button obj;


    public GameObject ansObj;
    Text text;
    string ans;
    void Start()
    {
        text = obj.GetComponentInChildren<Text>();



    }

    // Update is called once per frame
    void Update()
    {

    }
    public void Check()
    {



        ans = ansObj.GetComponentInChildren<level_4>().GetAnswer();
        if (text.text == ans)
        {

            //print("True");
            ansObj.GetComponentInChildren<level_4>().Right();
        }
        else
        {
            //ani.enabled = true;
            //print("false");
            ansObj.GetComponentInChildren<level_4>().Wrong();
        }
    }
}
