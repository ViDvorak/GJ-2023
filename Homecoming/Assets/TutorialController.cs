using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TutorialController : MonoBehaviour
{
    public GameObject tutorialCanvas;
    public GameObject player;

    bool canExit = false;
    Text text;

    // Start is called before the first frame update
    void Start()
    {        
        tutorialCanvas.SetActive(false);
        text = tutorialCanvas.GetComponentInChildren<Text>();
        text.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E) && canExit)
        {
            HideTutorial();
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Time.timeScale = 0f;
        tutorialCanvas.SetActive(true);
        StartCoroutine(ShowText());
    }

    private void HideTutorial()
    {
        tutorialCanvas.SetActive(false);
        GetComponent<BoxCollider2D>().enabled = false;
        Time.timeScale = 1f;
    }

    private IEnumerator ShowText()
    {
        yield return new WaitForSecondsRealtime(3);
        text.enabled = true;
        canExit = true;
    }
}
