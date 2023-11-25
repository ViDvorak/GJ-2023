using UnityEngine;

public class BushInteractionHandeling : MonoBehaviour
{
    private PlayerController playerController;
    private float timeOfNextInteraction;
    private int bushCouner = 0;

    [Min(0)]
    public float HideInteractionPeriod = 0.5f;

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

        if (bushCouner >= 1 && !playerController.IsPlayerHidden && shouldInteract && timeOfNextInteraction < Time.time)
        {
            playerController.Hide();
        }
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        bushCouner++;
    }

    public void OnTriggerExit2D(Collider2D collision)
    {
        bushCouner--;
    }
}
