using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OptionHolder : MonoBehaviour {

    private string currentName;

    private GeneralEventManager gem;

    public GameObject[] options;

    public bool item;
    public string description;

    public void Choice(int input)
    {
        Debug.Log("Reached Choice Method of OptionHolder");
        options[input].SetActive(true);

        if(item == true && input == 0)
        {
            gem = FindObjectOfType<GeneralEventManager>();
            gem.addItem(this.name, description);
        }

        Debug.Log(options[input].activeSelf);
        (GameObject.FindGameObjectWithTag("Player")).GetComponent<PlayerController>().enabled = true;
    }

}
