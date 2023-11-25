using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class ButtonClicker : MonoBehaviour
{

    UIDocument buttonDocument;
    Button uiButton;

    private void OnEnable()
    {
        buttonDocument = GetComponent<UIDocument>();

        if (buttonDocument == null)
        {
            Debug.LogError("No UI document found.");
        }

        uiButton = buttonDocument.rootVisualElement.Q("StartButton") as Button;

        uiButton.RegisterCallback<ClickEvent>(OnButtonClick);

    }


    void OnButtonClick(ClickEvent e)
    {
        Debug.Log("hi");
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
