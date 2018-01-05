using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadLevel : MonoBehaviour {


    public void _Load(int levelNumber)
    {
        StartCoroutine(loading(levelNumber, 2.0f));
    }

    public IEnumerator loading(int levelNumber, float waitTime)
    {
        yield return new WaitForSeconds(waitTime);
        SceneManager.LoadScene(levelNumber);

    }

}
