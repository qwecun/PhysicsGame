using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Level_1 : MonoBehaviour {

    Scalar_checker scalar;
    Vector_checker vector;
    Animator ani;
    public GameObject playMusic;
    public AudioClip impact;
    AudioSource sound;
    bool controller = true;
    // Use this for initialization
    void Start () {
        //GameObject SC= GameObject.Find("scalar table_");
        //scalar.GetComponent<Scalar_checker>();

        //GameObject VE = GameObject.Find("vector table_");
        //vector.GetComponent<Vector_checker>();
        sound = playMusic.GetComponent<AudioSource>();

        if (GameObject.Find("scalar table_") != null)
        {
            GameObject SC = GameObject.Find("scalar table_");
            scalar = SC.GetComponent<Scalar_checker>();
        }
        else
        {
            Debug.Log("scalar table_ not found!");
        }
        if (GameObject.Find("vector table_") != null)
        {
            GameObject VE = GameObject.Find("vector table_");
            vector = VE.GetComponent<Vector_checker>();
        }
        else
        {
            Debug.Log("vector table_ not found!");
        }

        GameObject obj = GameObject.Find("Congratulation");
        ani = obj.GetComponent<Animator>();
        ani.enabled = false;
    }

    // Update is called once per frame
    void Update () {
        ////Debug.Log(scalar.checkerSC);
        //// Debug.Log(vector.checkerVE);
        if (scalar.checkerSC && vector.checkerVE)
        {
            Debug.Log("HelloWorld");
            ani.enabled = true;
            if (controller)
            {
                try
                {
                    GameObject.Find("start music").SetActive(false);
                }
                catch (System.NullReferenceException)
                {
                    Debug.Log("myLight was not set in the inspector");
                }

                StartCoroutine(Example());
                controller = false;
            }

        }

    }
    public void runSceneLevel1()
    {
        SceneManager.LoadScene("lvl1");
    }
    public void runSceneLevel2()
    {
        SceneManager.LoadScene("lvl2");
    }
    IEnumerator Example()
    {
        sound.PlayOneShot(impact, 1);
        yield return new WaitForSeconds("congratulation".Length-8);
        SceneManager.LoadScene("Subway");
    }
}
