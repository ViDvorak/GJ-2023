using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ClickHandeling : MonoBehaviour
{
    public GameObject player;

    private SpriteRenderer spriteRenderer;

    public void Start()
    {
        spriteRenderer = player.transform.GetChild(0).GetComponent<SpriteRenderer>();
    }

    public void OnMouseDown()
    {
        // hide in an hidable in object
        spriteRenderer.enabled = !spriteRenderer.enabled;
        // forbid movement
    }
}
