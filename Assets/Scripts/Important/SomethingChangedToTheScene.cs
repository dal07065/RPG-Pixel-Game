using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SomethingChangedToTheScene : MonoBehaviour {

    //This script is used when something has changed in the scene 
    //meaning when you need to swap the background img to a different img with the change on it
    //for example: bedroom img (with phone charging) switched to a different bedroom img (with the phone gone) 

    public GameObject old;

    //The item that was picked up
    public GameObject phone;

    public Sprite newImg;

    // Use this for initialization
	void Start () {
        old.GetComponent<SpriteRenderer>().sprite = newImg;

        //When the phone is gone, you don't want the player dealing with this phone object again.
        //Instead of destroying the phone obj, why not just hide it because ITS SO MUCH FUCKING WORK OMG MY GOODNESS GAME DEV IS A PAIN IN THE BUTT
        phone.GetComponent<BoxCollider2D>().enabled = false;
	}
	
}
