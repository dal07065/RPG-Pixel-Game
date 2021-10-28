using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class justDialogue : MonoBehaviour
{
    public string[] dialogueLines;

    private int currline;

    private DialogueManager dMan;

    void Start()
    {
        dMan = FindObjectOfType<DialogueManager>();
        (GameObject.FindGameObjectWithTag("Player")).GetComponent<PlayerController>().enabled = false;
        currline = 0;
    }
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Space))
        {
            Debug.Log("justdialogue has been played");

            if (currline >= dialogueLines.Length)
            {
                dMan.OffBox();
                gameObject.SetActive(false);

                (GameObject.FindGameObjectWithTag("Player")).GetComponent<PlayerController>().enabled = true;

                currline = 0;
            }


            else if (currline < dialogueLines.Length)
            {
                Debug.Log("Show box should show dialogue");
                dMan.ShowBox(dialogueLines[currline]);
                currline++;
            }

        }

    }
}

