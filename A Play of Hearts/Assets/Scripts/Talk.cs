using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class Talk : MonoBehaviour {
    public GameObject charPanel;
    public GameObject PlayerControl;

    public bool inteactable;
	// Use this for initialization
	void Start () {
        PlayerControl = GameObject.FindGameObjectWithTag("Player");
	}
	
	// Update is called once per frame
	void Update () {

		if(Input.GetKeyDown("e"))
        { 
            if(inteactable)
            {
                charPanel.SetActive(true);
                charPanel.GetComponent<Fader>().fadeIn();
                PlayerControl.GetComponent<Movement>().talking = true;

            }
        }
	}

    public void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log(other.name);
        if(other.tag == PlayerControl.tag)
        {
            inteactable = true;
        }
    }
    public void OnTriggerExit2D (Collider2D other)
    {
        inteactable = false;
        if(other.tag == PlayerControl.tag)
        {
            charPanel.SetActive(false);
        }
    }
}
