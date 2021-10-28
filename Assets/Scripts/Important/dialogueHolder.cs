using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class dialogueHolder : MonoBehaviour {

    /*
     * How to use dialogues in your game (follow every step and read through all the comments on dialogueHolder and DialogueManager script
    //1. The character game object must be tagged as Player (check the ontriggerenter2d method below)
    //2. This script dialogueHolder must be attached to the object that will play the dialogue
    //3. Create a Game Canvas and create a game object inside it and name that object Dialogue Manager. Put the script Dialogue Manager in Dialogue Manager game object.
    //3. Create an Image object underneath Dialogue Manager and name that Dialogue Box.
    //5. Create a Text object underneath Dialogue Box and name that text.
    //4. Inside the Dialogue Manage game object on the Inspector window, there are empty spaces in the Dialogue Manager script for D Box and D Text
    //Drag the gameObjects Dialogue Box and text to those indicated empty spaces
    //5. customize the dialogue box as you like (this is the image of the background for the dialogue box)
    //7. customize the text size and color as you like

    //Put Box colliders (with IsTrigger on) on the objects large enough for the player to enter
    //In the script dialogueHolder on the objects in the inspector window, select the size of the dialogue lines you wish and put in each dialogues in each elements.
    //The actual physical colliding part should be done on the background image. (bedroom sprite image). (Just create bunch of box colliders 2d on that one bedroom sprite image game object)
    */

    //This array holds the dialogue lines. This shows on the inspector in the script component of the game object 
    //that its attached too. 
    public string[] dialogueLines;

    //played is a boolean that checks whether the player already saw the dialogue or not
    private bool played;

    //currline is a number that indicates which line of dialogue has been last played in the array dialogueLines
    private int currline;

    //dMan instatiates an object from Dialogue Manager (basically it acts as the dialogue manager gameobject in this script)
    private DialogueManager dMan;

    private bool triggered;

    //private Options script;

    public bool choice;

    //currObj is the current game object that has entered the trigger collider to interact with this object
    GameObject currObj = null;

    // Use this for initialization
    void Start ()
    {
        dMan = FindObjectOfType<DialogueManager>();
        currline = 0;
        played = false;
	}
    void Update()
    {
        //when the character presses space 
        if (Input.GetKeyUp(KeyCode.Space))
        {
            //Debug.Log("space pressed down");

            //if the character is within the trigger collider of the object (check OnTriggerEnter2D)
            if (triggered == true)
            {
                Debug.Log("played is false and triggered is true");

                //This disables the PlayerController script, meaning the player cant move
                currObj.GetComponent<PlayerController>().enabled = false;

                //if the current line of dialogue is beyond the given number of dialogue lines, meaning that all the dialogue lines has already been played and shown and currline has been increasing each time
                if (currline >= dialogueLines.Length)
                {
                    //disable the dialogue box (check Dialogue Manager method OffBox())
                    dMan.OffBox();

                    //This re-enables the PlayerController script, meaning the player can move again
                    currObj.GetComponent<PlayerController>().enabled = true;

                    //The dialogue has all been played 
                    played = true;

                    //Resets the currline to 0
                    currline = 0;
                    Debug.Log("dialogue is over");
                }

                //else if currline is 0 (dialogue has never been played) or currline is less than limit (there are more dialogues to be played left)
                else if (currline < dialogueLines.Length)
                {
                    Debug.Log("Show box should show dialogue");

                    //enable the dialogue box with the indicated current line of dialogue
                    dMan.ShowBox(dialogueLines[currline]);

                    //increase the currline to make sure to show the next line of dialogue
                    currline++;
                }
                
            }
            
        }
    }
    void OnTriggerEnter2D(Collider2D other)
    {
        //if the Tag of the gameObject that entered is tagged as Player
        if(other.CompareTag("Player"))
        {
            Debug.Log(other.name);
            currObj = other.gameObject;
            triggered = true;           
        }
    }
    // Update is called once per frame
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("interObject"))
        {
            if (other.gameObject == currObj)
            {
                currObj = null;
            }
        }
        triggered = false;
        played = false;
    }
}
