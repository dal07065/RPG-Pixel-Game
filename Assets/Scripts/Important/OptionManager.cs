using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class OptionManager : MonoBehaviour {

    public string gname;

    public GameObject goobj;
    public GameObject oBox;

	// Use this for initialization
	void Start () {

    }
	
	// Update is called once per frame
	void Update () {
        
    }
    public void opt1()
    {
        Debug.Log("Reached opt1");
        gname = gameObject.GetComponent<Text>().text;
        goobj = GameObject.Find(gname);
        goobj.GetComponent<OptionHolder>().Choice(0);
        oBox.SetActive(false);
    }
    public void opt2()
    {
        Debug.Log("Reached opt2");
        gname = gameObject.GetComponent<Text>().text;
        goobj = GameObject.Find(gname);
        goobj.GetComponent<OptionHolder>().Choice(1);
        oBox.SetActive(false);
    }
    public void opt3()
    {
        Debug.Log("Reached opt3");
        gname = gameObject.GetComponent<Text>().text;
        goobj = GameObject.Find(gname);
        goobj.GetComponent<OptionHolder>().Choice(2);
        oBox.SetActive(false);
    }
    public void opt4()
    {
        Debug.Log("Reached opt4");
        gname = gameObject.GetComponent<Text>().text;
        goobj = GameObject.Find(gname);
        goobj.GetComponent<OptionHolder>().Choice(3);
        oBox.SetActive(false);
    }
}
