using UnityEngine;

/// <summary>
/// Script for handling logic around items.
/// </summary>
public class ItemController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    private GameObject tooltipTextGameObject;

    /// <summary>
    /// Which item this items's game object represent.
    /// </summary>
    public Item Item;

    private void Start()
    {
        Debug.Assert(Item != Item.None);

        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();

        tooltipTextGameObject = transform.Find("Tooltip Text").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        tooltipTextGameObject.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        tooltipTextGameObject.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

        if (playerController == null)
            return;

        // TODO: show press 'E' to pick up item message


        if (playerInputActions.Player.Interaction.IsPressed())
        {
            GlobalGameState.PickUpItem(Item);
            Destroy(gameObject);
        }
    }
}
