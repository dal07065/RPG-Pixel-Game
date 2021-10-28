using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class DialogueManager : MonoBehaviour {

    //
    //HOW DOES THE DIALOGUE WORK? 
    //go look at dialogue Holder first
    public static EventSystem es;
    //letterPause is the pause between each letter's appearance when being "typed out" in the dialogue box on screen
    public float letterPause = 0.2f;

    //what the text says
    string message;

    //dbox = gameObject Dialogue Box under gameObject Dialogue Manager
    public GameObject dBox;

    public GameObject oBox;

    //dText = text under Dialogue Box under Dialogue Manager
	public Text dText;

    public GameObject o1;
    public GameObject o2;
    public GameObject o3;
    public GameObject o4;

    //dialogueActive = Dialogue Active public boolean on Dialogue Manager script component inside gameObject Dialogue Manager
    //public bool dialogueActive;

	void Start () {

        //dialogueActive = false;
        es = GameObject.Find("EventSystem").GetComponent<EventSystem>();

    }

	void Update () {
        
	}
    public void ShowBox(string dialogue)
    {
        //This enables the Dialogue Box allowing it to appear on screen while setting the "dialogue" as the text of the Dialogue Box

        //dialogueActive = !dialogueActive;
        message = dialogue;
        dText.text = "";

        dBox.SetActive(true);
        StartCoroutine(TypeText());

        Debug.Log("ShowBox method has been reached");
    }
    public void OffBox()
    {
        //This disables the Dialogue Box 

        //dialogueActive = !dialogueActive;
        dBox.SetActive(false);
        dText.text = "";
        Debug.Log("dialogue box is off");
    }
    public void Options(string[] options)
    {
        Debug.Log("Reached Options in Dialogue Manager");
        float size = options.Length;

        if (size == 2)
        {
            o1.GetComponentInChildren<Text>().text = options[0];
            o2.GetComponentInChildren<Text>().text = options[1];
            o1.SetActive(true);// = !o1.enabled;
            o2.SetActive(true);// = !o2.enabled;

            oBox.SetActive(true);

            //allow the first option to be pre-selected to show the players that they should choose between the options
            StartCoroutine("highlightBtn");

            //wait for the player to make a choice (Update function of Option script)

            Debug.Log("Choice Box was set active");

        }
        else if (size == 3)
        {

        }
        else if (size == 4)
        {

        }
        else if (size == 5)
        {

        }
    }
    IEnumerator TypeText()
    {
        foreach (char letter in message.ToCharArray())
        {
            dText.text += letter;
            yield return new WaitForSeconds(0.013F);
        }
    }
    //The event system has a thing called First Selected. When the button appears, it will call this function and set the First Selected to show the Option1 button as pre-selected.
    IEnumerator highlightBtn()
    {
        es.SetSelectedGameObject(null);
        yield return null;
        es.SetSelectedGameObject(es.firstSelectedGameObject);
    }
}
