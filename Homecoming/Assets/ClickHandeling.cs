using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClickHandeling : MonoBehaviour
{
    public PlayerController player;

    public void OnMouseDown()
    {
        // hide in an hidable in object
        player.Hide(gameObject);
    }
}
