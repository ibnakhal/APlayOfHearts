using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Falling : MonoBehaviour {

    public GameObject player;
    public Transform dropSpot;

	// Use this for initialization
	void Start () {
        player = GameObject.FindGameObjectWithTag("Player");
	}
	
    public void OnTriggerEnter2D (Collider2D other)
    {
        Debug.Log(other.name);

        if (other.tag == player.tag)
        {
            player.transform.position = dropSpot.position;
        }
    }
}
