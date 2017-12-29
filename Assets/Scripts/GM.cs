using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GM : MonoBehaviour {
    private Animator anim;
    void Start()
    {
        anim = GetComponent<Animator>();
    }

    public void StartGame()
    {
        anim.SetBool("Start", true);
        StartCoroutine(LoadAfterAnim());
    }
    public IEnumerator LoadAfterAnim()
    {
        yield return new WaitForSeconds("start_1".Length-3);
        SceneManager.LoadScene("Subway");
    }
    public void StartCreditS()
    {
        anim.SetBool("Start", true);
        StartCoroutine(LoadAfterAnim_1());
    }
    public IEnumerator LoadAfterAnim_1()
    {
        yield return new WaitForSeconds("start_1".Length - 3);
        SceneManager.LoadScene("credit");
    }
}
