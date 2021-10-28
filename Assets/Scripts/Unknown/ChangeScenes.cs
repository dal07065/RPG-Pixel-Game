using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChangeScenes : MonoBehaviour {

	public bool triggered = false;
	GameObject currObj = null;
	public string leveltoload;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (triggered == true)
		{
			if (Input.GetKeyDown(KeyCode.Space))
			{
				SceneManager.LoadScene(leveltoload);
			}
		}
	}
	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.gameObject.name == "madotsuki")
		{
			triggered = true;
			Debug.Log(other.name);
			currObj = other.gameObject;
		}
	}
	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("interObject"))
		{
			if (other.gameObject == currObj)
			{
				currObj = null;
				triggered = false;
			}
		}
		triggered = false;
	}
}
