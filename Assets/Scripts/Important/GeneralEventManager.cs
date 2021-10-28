using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class GeneralEventManager : MonoBehaviour {

    public GameObject menuCanvas;
    public GameObject itemMenu;
    public GameObject mainMenu;
    public string currItem;
    public bool exitState;

    public GameObject[] itemArray;

	// Use this for initialization
	void Start () {
        (GameObject.FindGameObjectWithTag("Player")).GetComponent<PlayerController>().enabled = true;
        exitState = false;
        //menuCanvas.GetComponent<Canvas>().enabled = false;
    }
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyUp(KeyCode.Escape))
        {
            toggleExitMenu();
        }
	}
    public void exitGame()
    {
        Application.Quit();
    }
    public void addItem(string name, string desc)
    {
        Debug.Log("General Event Manager addItem reached for this item:" + name);
        
        //When option holder has the item bool marked true and has string description, it will call this method with indicated parameters
        //This method sorts through the array of items to check 
        for(int i = 0; i < itemArray.Length; i++)
        {
            if (itemArray[i].transform.GetChild(0).gameObject.GetComponent<Text>().text == "noObj")
            {
                itemArray[i].transform.GetChild(0).gameObject.GetComponent<Text>().text = name;
                itemArray[i].transform.GetChild(1).gameObject.GetComponent<Text>().text = desc;
                itemArray[i].SetActive(true);
                i = itemArray.Length;
                
                Debug.Log("new item added:" + itemArray[0].transform.GetChild(0).gameObject.GetComponent<Text>().text);
            }  
        }
    }
    public void toggleExitMenu()
    {
        exitState = !exitState;
        menuCanvas.SetActive(exitState);
        //menuCanvas.GetComponent<Canvas>().enabled = exitState;
        if (exitState == true)
        {
            (GameObject.FindGameObjectWithTag("Player")).GetComponent<PlayerController>().enabled = false;
        }
        else
        {
            (GameObject.FindGameObjectWithTag("Player")).GetComponent<PlayerController>().enabled = true;
            if(itemMenu.activeSelf == true)
            {
                itemMenu.SetActive(false);
                mainMenu.SetActive(true);
            }
        }
    }
    public void currentItem(GameObject item)
    {
        currItem = item.GetComponent<Text>().text;
    }
    public void removePressed()
    {
        EventSystem.current.SetSelectedGameObject(null);
    }

}
