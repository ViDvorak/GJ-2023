using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class alienInteractionHandeling : MonoBehaviour
{
    public bool isInteractable = false;
    public GameObject text;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (isInteractable)
        {
            text.SetActive(true);

        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (isInteractable)
        {
            text.SetActive(false);

        }
    }
}
