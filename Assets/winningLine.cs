using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class winningLine : MonoBehaviour {
    public double passTime;
    public GameObject windowW;

    public GameObject player;
    public AudioClip impact;
    AudioSource audioSource;

    public double leftTime;

    bool stopMusic;
    // Use this for initialization
    void Start()
    {
        leftTime = 3;
        audioSource = player.GetComponent<AudioSource>();
        stopMusic = true;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        leftTime = 3;
    }

    void OnTriggerStay2D(Collider2D other)
    {
        leftTime  = leftTime - Time.deltaTime;
    }
    void OnTriggerExit2D(Collider2D other)
    {
        leftTime = 3;

    }
    void Update()
    {
        //Debug.Log(leftTime);
        
        if (leftTime < 0&&stopMusic)
        {
            GameObject.Find("start music").SetActive(false);
            audioSource.PlayOneShot(impact, 1);
            Debug.Log("YYYY");
            windowW.SetActive(true);
            stopMusic = false;
        }
    }
}
