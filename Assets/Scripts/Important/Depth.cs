using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Depth : MonoBehaviour {

    //if you want to know how i did this, watch the video I saved in video game design youtube playlist 
    //But otherwise, copy this script, apply this script to ALL the game objects that will deal with this (including player)
    //(Make sure Sorting Layer is Default on all those applied objects)
    //Then for static objects that will not be moving, click Run Only Once option in the script component of the Inspector of the gameObject

    [SerializeField]
    private int sortingOrderBase = 5000;
    [SerializeField]
    private float offset = 0;
    private Renderer myRenderer;
    [SerializeField]
    private bool runOnlyOnce = false;

    private void Awake()
    {
        myRenderer = GetComponent<Renderer>();
    }
	
	// Update is called once per frame
	private void LateUpdate ()
    {
        myRenderer.sortingOrder = (int)(sortingOrderBase - transform.position.y - offset);
        //myRenderer.sortingOrder = (int)Camera.main.WorldToScreenPoint(transform.position).y * -1;
        if(runOnlyOnce)
        {
            Destroy(this);
        }
    }
}
