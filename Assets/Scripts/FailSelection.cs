using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FailSelection : MonoBehaviour {
    public GameObject windowL;
    public GameObject helping;
    public GameObject FailSound;
    public AudioClip impact;
    AudioSource audioSource;

    void Start()
    {
        audioSource = FailSound.GetComponent<AudioSource>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        GameObject.Find("start music").SetActive(false);
        audioSource.PlayOneShot(impact, 2);
        Debug.Log("u lose");
        windowL.SetActive(true);
        

    }
    public void runMain()
    {
        SceneManager.LoadScene("Subway");
    }
    public void restratGame()
    {
        int scene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(scene, LoadSceneMode.Single);
    }
    public void hiddenHelping()
    {
        helping.SetActive(false);
    }
    public void Next()
    {
        //SceneManager.LoadScene("lvl2");
    }
}
