using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mirage : MonoBehaviour {
    public GameObject mirage;
    public GameObject PlayerControl;
    public GameObject flash;

    void Start()
    {
        PlayerControl = GameObject.FindGameObjectWithTag("Player");

    }

    public void OnTriggerEnter2D(Collider2D Other)
    {
        if (Other.gameObject == PlayerControl)
        {
            mirage.SetActive(false);
            flash.SetActive(true);
        }
                
    }



}
