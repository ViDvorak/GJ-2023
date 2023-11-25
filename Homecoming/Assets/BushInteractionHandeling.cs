using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Threading;
using UnityEngine;

public class BushInteractionHandeling : MonoBehaviour
{
    private PlayerController playerController;
    private bool isIntersectingHidableObject = false;

    [Min(0)]public float HideInteractionPeriod = 0.5f;
    private float timeOfNextInteraction;

    public void Awake()
    {
        playerController = GetComponentInParent<PlayerController>();
    }

    private void Update()
    {
        bool shouldInteract = playerController.PlayerInputActions.Player.Interaction.WasPressedThisFrame();
        
        if (playerController.IsPlayerHidden && shouldInteract && timeOfNextInteraction < Time.time)
        {
            playerController.Unhide();
            timeOfNextInteraction = Time.time + HideInteractionPeriod;
        }

        if (isIntersectingHidableObject && !playerController.IsPlayerHidden && shouldInteract && timeOfNextInteraction < Time.time)
        {
            playerController.Hide(gameObject);
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        isIntersectingHidableObject = true;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        isIntersectingHidableObject = false;
    }
}
