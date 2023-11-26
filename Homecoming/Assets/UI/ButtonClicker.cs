using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

//#if UNITY_EDITOR
//using UnityEditor;
//#endif

public class ButtonClicker : MonoBehaviour
{
    public Object Scene;

    UIDocument buttonsDocument;
    Button startButton;
    Button quitButton;

    private void OnEnable()
    {
        buttonsDocument = GetComponent<UIDocument>();

        if (buttonsDocument == null)
        {
            Debug.LogError("No UI Document found.");
        }

        startButton = buttonsDocument.rootVisualElement.Q("StartButton") as Button;
        quitButton = buttonsDocument.rootVisualElement.Q("QuitButton") as Button;

        startButton.RegisterCallback<ClickEvent>(OnStartButtonClick);
        quitButton.RegisterCallback<ClickEvent>(OnQuitButtonClick);
    }

    void OnStartButtonClick(ClickEvent e)
    {
        SceneManager.LoadScene(Scene.name);
    }

    void OnQuitButtonClick(ClickEvent e)
    {
        // Time.timeScale = 1f;

#if UNITY_EDITOR
        EditorApplication.isPlaying = false;
#else
	    Application.Quit();
#endif

    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
