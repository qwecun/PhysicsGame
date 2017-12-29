using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class titleControl : MonoBehaviour {

    void Start()
    {
        StartCoroutine(Example());

    }

    IEnumerator Example()
    {
        
        yield return new WaitForSeconds(3);
        this.gameObject.SetActive(false);
    }
}
