using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class lvl3_1 : MonoBehaviour {

    public GameObject obj_0;
    public GameObject obj_1;
    public GameObject []question;
    int i;
    public GameObject car;
    Animator aniCar;
    Animator ani;
    private bool contr;

    // Use this for initialization
    void Start () {
        for (int j = 0; j < question.Length; j++)
        {
            question[j].SetActive(false);
        }
        obj_0.SetActive(false);
        obj_1.SetActive(false);
        i = 0;

        aniCar = car.GetComponent<Animator>();

        GameObject obj = GameObject.Find("Congratulation");
        ani = obj.GetComponent<Animator>();
        ani.enabled = false;
    }
	
	// Update is called once per frame
	void FixedUpdate () {
        if (question.Length > i) 
            question[i].SetActive(true);
        else
        {
            ani.enabled = true;
            StartCoroutine(Example1());
        }
        if(i == 2)
        {
            aniCar.SetBool("run", true);
            
        }
        if(i == 3)
        {
            
            aniCar.SetBool("run", true);
        }
    }
    public void Right()
    {
        obj_1.SetActive(false);
        obj_0.SetActive(true);
        StartCoroutine(Example());
    }
    public void Wrong()
    {
        obj_1.SetActive(true);
        obj_1.SetActive(true);
    }
    IEnumerator Example()
    {

        yield return new WaitForSeconds(1);
        aniCar.SetBool("run", false);
        question[i].SetActive(false);
        obj_0.SetActive(false);
        obj_1.SetActive(false);
        i++;
    }
    IEnumerator Example_1()
    {
        
        yield return new WaitForSeconds(1);

        question[i].SetActive(false);
        obj_0.SetActive(false);
        obj_1.SetActive(false);
        i--;
    }
    IEnumerator Example1()
    {
        //Ending of level 2
        yield return new WaitForSeconds("congratulation".Length - 6);
        SceneManager.LoadScene("MainScreen");
    }
    public void NextQusetion()
    {
        if (i != 3)
        {
            aniCar.SetBool("run", false);
            StartCoroutine(Example());
        }

    }
    public void BeforeQusetion()
    {
        if(i != 0)
        {
            aniCar.SetBool("run", false);
            StartCoroutine(Example_1());
        }

    }
}
