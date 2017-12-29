using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class textTime : MonoBehaviour {
    double time;
    Text text_1;
    winningLine winningLine;
    // Use this for initialization
    void Start () {
        GameObject timeObj = GameObject.Find("winning");
        winningLine = timeObj.GetComponent<winningLine>();
        text_1 = GetComponent<Text>();
    }
	
	// Update is called once per frame
	void Update () {
        // text_1.text = time.ToString();
        double output = System.Math.Round(winningLine.leftTime,0);
        if (output < 0)
        {
            output = 0;
        }

        text_1.text = output.ToString();

    }
}
