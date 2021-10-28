using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SceneChange : MonoBehaviour {
    public string Name;
    public Animator transitionAnim;

	// Use this for initialization
	void Start () {

        Debug.Log("Start-Coroutine");
        StartCoroutine(LoadScene());
    }

    IEnumerator LoadScene()
    {
        Debug.Log("load scene activated");
        transitionAnim.SetTrigger("end");
        yield return new WaitForSeconds(1.5f);
        SceneManager.LoadScene(Name);
    }

}
