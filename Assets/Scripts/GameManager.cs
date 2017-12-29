using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour {

	public void runSceneLevel1()
    {
        SceneManager.LoadScene("lvl1");
    }
    public void runSceneLevel2()
    {
        SceneManager.LoadScene("lvl2");
    }
}
