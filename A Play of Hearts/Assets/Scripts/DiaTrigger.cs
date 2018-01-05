using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DiaTrigger : MonoBehaviour {
    public GameObject charPanel;
    public GameObject PlayerControl;
    public string topic;
    public Text storyText;
    // Use this for initialization
    void Start () {
        PlayerControl = GameObject.FindGameObjectWithTag("Player");

    }

    // Update is called once per frame
    void Update () {
		
	}

    public void OnTriggerEnter2D (Collider2D Other)
    {
        if (Other.gameObject == PlayerControl)
        {
            storyText.text = topic;
            charPanel.GetComponent<Fader>().fadeIn();
        }
    }

    public void OnTriggerExit2D (Collider2D Other)
    {
        if (Other.gameObject == PlayerControl)
        {

            charPanel.GetComponent<Fader>().fadeOut();
            this.gameObject.SetActive(false);

        }
    }
}
