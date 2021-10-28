using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lightfunction : MonoBehaviour {

    public GameObject bed2;
    public SpriteRenderer bedsr;

    public bool triggered = false;
    GameObject currObj = null;

    void Update()
    {
        if (triggered == true)
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                bed2 = GameObject.Find("bedroom2");
                bedsr = bed2.GetComponent<SpriteRenderer>();
                bedsr.enabled = !bedsr.enabled;
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
