using UnityEngine;
using UnityEngine.UI;

public class dialogueHolder2 : MonoBehaviour
{
    
    public string[] dialogueLines;

    //This is second array of dialogues for second runtime
    public string[] dialogueLines2;

    public string[] dialogueToRun;

    public string[] options;


    private bool played;
    
    private int currline;

    private DialogueManager dMan;

    public GameObject oMan;

    //private OTD otd;

    private bool triggered;
    
    GameObject currObj = null;

    void Start()
    {
        Debug.Log("reached dialogue holder 2");
        dMan = FindObjectOfType<DialogueManager>();
        oMan = GameObject.Find("OptionManager");
        currline = 0;
        played = false;
        dialogueToRun = dialogueLines;
        //otd = FindObjectOfType<OTD>();
        //otd.Current(gameObject.name);
    }
    void Update()
    {

        if (Input.GetKeyUp(KeyCode.Space))
        {
           
            if (triggered == true)
            {
               
                Debug.Log("played is false and triggered is true");

                currObj.GetComponent<PlayerController>().enabled = false;

                if(played == true && dialogueLines2.Length != 0)
                {
                    dialogueToRun = dialogueLines2;
                }

                if (currline >= dialogueToRun.Length)
                {
                    dMan.OffBox();

                    currObj.GetComponent<PlayerController>().enabled = true;

                    played = true;

                    currline = 0;
                    Debug.Log("dialogue is over");

                }
                else if (dialogueToRun[currline] == "[options]")
                {
                    dMan.OffBox();
                    Debug.Log("About to call the options method in dman");
                    played = true;
                    triggered = false;
                    currline = 0;
                    Debug.Log("currline after options is " + currline);
                    dMan.Options(options);

                }
                else if (currline < dialogueToRun.Length)
                {
                    Debug.Log("Show box should show dialogue");

                    dMan.ShowBox(dialogueToRun[currline]);
                    currline++;

                }
                
                
                //The problem is we don't know when options would end like whent he players gonna finna choose their answer
                //so regardless, the system calls the option and this script will just keep on doin what it gotta do
                //and the currline is messed up cuz it dont know when to stop
                //how do i stop this loop and reset everything to zero when the options/dialogue finihses?
            }

        }
    }
    
    void OnTriggerEnter2D(Collider2D other)
    {
        //if the Tag of the gameObject that entered is tagged as Player
        if (other.CompareTag("Player"))
        {
            Debug.Log(other.name);
            currObj = other.gameObject;
            triggered = true;
            oMan.GetComponent<Text>().text = gameObject.name;
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
        //played = false;
    }
}
