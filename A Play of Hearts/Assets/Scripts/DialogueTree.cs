using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class DialogueTree : MonoBehaviour {

    public Text text;
    public string result;
    public GameObject resultPanel;
    public GameObject parentPanel;



    public void _Action()
    {
        text.text = result;
        parentPanel.GetComponent<Fader>().fadeOut();
        //parentPanel.SetActive(false);
        resultPanel.GetComponent<Fader>().fadeIn();
        resultPanel.SetActive(true);
    }

    public void _End()
    {
        parentPanel.GetComponent<Fader>().fadeOut();

    }
}
