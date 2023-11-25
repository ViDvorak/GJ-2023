using UnityEngine;

/// <summary>
/// Script for handling logic around items.
/// </summary>
public class ItemController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    /// <summary>
    /// Which item this items's game object represent.
    /// </summary>
    public Item Item;

    private void Awake()
    {
        Debug.Assert(Item != Item.None);

        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

        if (playerController == null)
            return;

        // TODO: show press 'E' to pick up item message

        if (playerInputActions.Player.Interaction.IsPressed())
        {
            playerController.PickUpItem(Item);
            Destroy(gameObject);
        }
    }
}
