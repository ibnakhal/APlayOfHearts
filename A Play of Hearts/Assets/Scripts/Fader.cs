using UnityEngine;
using System.Collections;
using UnityEngine.SceneManagement;

public class Fader : MonoBehaviour {

    [SerializeField]
    private float waitTime, aStart, aEnd, lerpValue, timer, duration;
    [SerializeField]
    private bool isFading = false, lastPiece = false, fadeOutBool = false;
    [SerializeField]
    private int levelLoad;

    [SerializeField]
    private bool speedTrigger;

    private CanvasGroup g;
    void Start()
    {
        g = this.GetComponent<CanvasGroup>();
        if (speedTrigger)
        {
            StartCoroutine(Starter(waitTime));
        }
    }

    public void Update()
    {
        g.alpha = Mathf.Lerp(aStart, aEnd, lerpValue);

        if (isFading)
        {
        timer += Time.deltaTime;
        lerpValue = (timer / duration);
        }
        if (lerpValue >= 1)
        {
            if (lastPiece)
            {
                SceneManager.LoadScene(levelLoad);
            }
            isFading = false;
            if (fadeOutBool == true)
            {
                Debug.Log("FadeOutBool");
                this.gameObject.SetActive(false);
            }
        }
        //if(lerpValue <= 0 && isFading)
        //{
        //this.gameObject.SetActive(false);
        //}

    }


    public IEnumerator Starter(float waitingTime)
    {
        yield return new WaitForSeconds(waitingTime);

        isFading = true;

    }
    public void fadeIn()
    {
        this.gameObject.SetActive(true);
        aStart = 0;
        aEnd = 1;
        lerpValue = 0;
        timer = 0;
        isFading = true;
        fadeOutBool = false;
    }

    public void fadeOut()
    {
        Debug.Log("FadeOut");
        aStart = 1;
        aEnd = 0;
        lerpValue = 0;
        timer = 0;
        isFading = true;
        fadeOutBool = true;
        //this.gameObject.SetActive(false);
    }
    public void waitTrigger(float time)
    {
        StartCoroutine(Starter(waitTime));
    }
}