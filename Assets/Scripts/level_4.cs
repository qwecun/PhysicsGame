using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class level_4 : MonoBehaviour {

    public TextAsset rootsText;
    string[] lines;

    public GameObject check;
    public GameObject cross;
    public GameObject question_;
    public GameObject button_1;
    public GameObject button_2;
    public GameObject button_3;
    Text question;
    Text answer_1;
    Text answer_2;
    Text answer_3;
    int QIdex;

    public GameObject ground;
    public GameObject ball_1;
    public GameObject ball_2;

    Vector2 ballPosition_1;
    Vector2 ballPosition_2;

    Animator ani;

    public GameObject playMusic;
    public AudioClip right;
    public AudioClip wrong;
    public AudioClip win;
    AudioSource sound;
    void Start()
    {
        sound = playMusic.GetComponent<AudioSource>();

        GameObject obj1 = GameObject.Find("Congratulation");

        ani = obj1.GetComponent<Animator>();
        ani.enabled = false;

        lines = rootsText.text.Split("\n"[0]);
        question = question_.GetComponent<Text>();
        answer_1 = button_1.GetComponent<Text>();
        answer_2 = button_2.GetComponent<Text>();
        answer_3 = button_3.GetComponent<Text>();
        QIdex = 0;

        ballPosition_1 = ball_1.transform.position;
        ballPosition_2 = ball_2.transform.position;

        Run();
        
    }
    void FixedUpdate()
    {
        if (QIdex >= 2)
        {
            // Animation Congra
            ani.enabled = true;
            StartCoroutine(ReturnMain());
        }

    }
    void Run()
    {
        if (QIdex == 0)
        {
            question.text = lines[0];
            answer_1.text = lines[2];
            answer_2.text = lines[3];
            answer_3.text = lines[1];
        }
        if (QIdex == 1)
        {          

            ball_1.SetActive(false);
            ball_2.SetActive(false);
            ground.SetActive(false);
            question.text = lines[4];
            answer_1.text = lines[5];
            answer_2.text = lines[6];
            answer_3.text = lines[7];
        }
    }
    public void Question_1()
    {
        ball_1.transform.position = ballPosition_1;
        ball_2.transform.position = ballPosition_2;
        ball_1.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        ball_2.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.None;
        //StartCoroutine(Example());

    }
    public void Wrong()
    {
        if (QIdex == 0)
        {
            Question_1();
        }

        sound.PlayOneShot(wrong, 1);
        check.SetActive(false);
        cross.SetActive(true);
    }
    public void Right()
    {
        if (QIdex == 0)
        {
            sound.PlayOneShot(right, 1);
            Question_1();
            StartCoroutine(Example());
        }

        check.SetActive(true);
        cross.SetActive(false);
        if (QIdex == 1)
        {
            sound.PlayOneShot(win, 1);
            QIdex++;
        }

        //Run();
    }
    IEnumerator Example()
    {
        yield return new WaitForSeconds(2);
        QIdex++;
        check.SetActive(false);
        cross.SetActive(false);
        Run();
    }
    public string GetAnswer()
    {
        if (QIdex == 0)
        {
            return lines[1];
        }
        else
        {
            return lines[5];
        }
    }
    IEnumerator ReturnMain()
    {
        question_.SetActive(false);
        button_1.transform.parent.gameObject.SetActive(false);
        button_2.transform.parent.gameObject.SetActive(false);
        button_3.transform.parent.gameObject.SetActive(false);
        yield return new WaitForSeconds("congratulation".Length - 6);
        SceneManager.LoadScene("Subway");
    }
}
