using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class MenuOptions : MonoBehaviour {

    public static EventSystem es;

    public UnityEngine.UI.Button btn;
    //public Animator buttonAnimator;


    public GameObject button1;


    // Use this for initialization
    void Start () {
        es = GameObject.Find("EventSystem").GetComponent<EventSystem>();
        
    }
    void OnEnable()
    {
        //buttonAnimator.SetTrigger(btn.animationTriggers.highlightedTrigger);
        StartCoroutine(highlight());

    }

    //The event system has a thing called First Selected. When the button appears, it will call this function and set the First Selected to show the Option1 button as pre-selected.
    IEnumerator highlight()
    {
        yield return null;
        //es.SetSelectedGameObject(null);
        //es.SetSelectedGameObject(button1);

        es.firstSelectedGameObject = null;
        es.firstSelectedGameObject = button1;

        Debug.Log("Event system button: " + es.firstSelectedGameObject);
    }
}
