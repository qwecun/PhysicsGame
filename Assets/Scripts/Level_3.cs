using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.IO;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Level_3 : MonoBehaviour {

    public GameObject check;
    public GameObject cross;
    Animator ani;

    public TextAsset rootsText;
    public GameObject question_;
    Text question;
    public GameObject button_1;
    Text answer_1;
    public GameObject button_2;
    Text answer_2;
    public GameObject button_3;
    Text answer_3;
    int QIdex;
    string[] lines;
    int ramN_1, ramN_2;

    bool[] lvl;
    string[] lvlAnswer;

    bool signal;

    public GameObject[] textObj;

    public GameObject playMusic;
    public AudioClip right;
    public AudioClip wrong;
    public AudioClip Impact;

    AudioSource sound;


    void Start () {

        GameObject obj1 = GameObject.Find("Congratulation");

        sound = playMusic.GetComponent<AudioSource>();
        ani = obj1.GetComponent<Animator>();
        ani.enabled = false;
        

        lines = rootsText.text.Split("\n"[0]);
        question = question_.GetComponent<Text>();
        answer_1 = button_1.GetComponent<Text>();
        answer_2 = button_2.GetComponent<Text>();
        answer_3 = button_3.GetComponent<Text>();
        lvlAnswer = new string[4];
        lvl = new bool[] { false, false, false, false };

        for(int i = 0; i < 4; i++)
        {
            lvlAnswer[i] = lines[i * 6 + 1];
           // print(lines[i * 6 + 1]);
        }
        

        QIdex = 0;
        ramN_1 = RamNum();
        ramN_2 = RamNum();
        while (ramN_1 == ramN_2)
        {
            ramN_2 = RamNum();

        }
        signal = true;
    }
	
	// Update is called once per frame
	void Update () {


        if (signal)
        {
            string[] texts = { lines[QIdex * 6 + 1], lines[ramN_1 + QIdex * 6], lines[ramN_2 + QIdex * 6] };
            // Knuth shuffle algorithm :: courtesy of Wikipedia :)
            for (int t = 0; t < texts.Length; t++)
            {
                string tmp = texts[t];
                int r = UnityEngine.Random.Range(t, texts.Length);
                texts[t] = texts[r];
                texts[r] = tmp;
            }
            signal = false;
            question.text = lines[QIdex * 6];
            answer_1.text = texts[0];
            answer_2.text = texts[1];
            answer_3.text = texts[2];
        }
        if (QIdex == 3)
        {
            for(int i=0; i < 5; i++)
            {
                textObj[i].SetActive(true);
            }
        }



    }

    int RamNum()
    {
        return UnityEngine.Random.Range(2, 6);
    }
    public string GetAnswer()
    {
        return lines[QIdex*6+1];
    }

    public void Wrong()
    {

        check.SetActive(false);
        cross.SetActive(true);
        sound.PlayOneShot(wrong,1);
        ramN_1 = RamNum();
        ramN_2 = RamNum();
        while (ramN_1 == ramN_2)
        {
            ramN_2 = RamNum();
        }
        signal = true;
        
    }
    public void Right()
    {
        check.SetActive(true);
        cross.SetActive(false);
        if (QIdex != 3)
        {
            sound.PlayOneShot(right, 1);
            lvl[QIdex] = true;
            QIdex++;
            ramN_1 = RamNum();
            ramN_2 = RamNum();
            while (ramN_1 == ramN_2)
            {
                ramN_2 = RamNum();
            }
            signal = true;
        }
        else
        {
            GameObject.Find("start music").SetActive(false);
            sound.PlayOneShot(Impact, 1);
            ani.enabled = true;
            StartCoroutine(Example());
        }

    }
    IEnumerator Example()
    {
        GameObject.Find("answer_1").SetActive(false);
        GameObject.Find("answer_2").SetActive(false);
        GameObject.Find("answer_3").SetActive(false);
        GameObject.Find("QWindow").SetActive(false);
        yield return new WaitForSeconds("congratulation".Length - 6);
        SceneManager.LoadScene("Subway");
    }

}
