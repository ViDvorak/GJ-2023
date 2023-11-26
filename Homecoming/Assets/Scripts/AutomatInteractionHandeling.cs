using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class AutomatInteractionHandeling : MonoBehaviour
{
    public bool isInteractable = false;
    public GameObject text;

    PlayerInputActions input;

    public void Awake()
    {
        input = new PlayerInputActions();
        input.Enable();
    }

    public void Update()
    {
        if ( !GlobalGameState.HasItems(Item.Ticket) && input.Player.Interaction.WasPressedThisFrame())
        {
            GlobalGameState.PickUpItem(Item.Ticket);
        }
    }

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
