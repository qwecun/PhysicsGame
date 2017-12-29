using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Door : MonoBehaviour {
    public GameObject text;
    public GameObject playMusic;
    public AudioClip impact;
    AudioSource sound;

    private Animator anim;
    // Use this for initialization
    void Start () {
        anim = GetComponent<Animator>();
        sound = playMusic.GetComponent<AudioSource>();
    }
	
	// Update is called once per frame
	void Update () {
		
	}
    void OnTriggerEnter2D(Collider2D other)
    {
        sound.PlayOneShot(impact);
        text.SetActive(true);
        anim.SetBool("Enter", true);
    }
    void OnTriggerExit2D(Collider2D other)
    {
        text.SetActive(false);
        anim.SetBool("Enter", false);
    }
    void OnTriggerStay2D(Collider2D other)
    {
        if (Input.GetKey(KeyCode.UpArrow))
        {
            if(this.name=="door_A")
                SceneManager.LoadScene("lvl1");
            else if (this.name == "door_B")
                SceneManager.LoadScene("lvl2");
            else if (this.name == "door_C")
                SceneManager.LoadScene("lvl3");
            else if (this.name == "door_D")
                SceneManager.LoadScene("lvl4");
        }
    }
}
