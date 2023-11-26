using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UIElements;

public class ButtonClicker : MonoBehaviour
{
    public Object Scene;
    UIDocument buttonDocument;
    Button uiStartButton;
    Button uiQuitButton;

    private void OnEnable()
    {
        buttonDocument = GetComponent<UIDocument>();

        if (buttonDocument == null)
        {
            Debug.LogError("No UI document found.");
        }

        uiStartButton = buttonDocument.rootVisualElement.Q("StartButton") as Button;
        uiQuitButton = buttonDocument.rootVisualElement.Q("QuitButton") as Button;

        uiStartButton.RegisterCallback<ClickEvent>(OnStartButtonClick);
        uiQuitButton.RegisterCallback<ClickEvent>(OnQuitButtonClick);

    }


    void OnStartButtonClick(ClickEvent e)
    {
        SceneManager.LoadScene(Scene.name);
    }

    void OnQuitButtonClick(ClickEvent e)
    {
        Time.timeScale = 1f;

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
