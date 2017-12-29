using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class hidden_5s : MonoBehaviour {
    //GameObject obj;

    void Start()
    {
        
    }
    void Update () {
        StartCoroutine(Example());

    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(5);
        gameObject.SetActive(false);
    }
}
