using UnityEngine;

/// <summary>
/// Script for controlling the player.
/// </summary>
public class PlayerController : MonoBehaviour
{
    /// <summary>
    /// Contain input actions for controlling the player.
    /// </summary>
    private PlayerInputActions playerInputActions;
    private new Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    /// <summary>
    /// Flags bitset which contains player items.
    /// </summary>
    private Item items = Item.None;
    private Vector3 playerScale;

    /// <summary>
    /// Speed of the player movement.
    /// </summary>
    public float MovementSpeed;

    public float MaxDistanceToHide = 4;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerInputActions = new PlayerInputActions();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>(true);
        playerScale = transform.localScale;

        playerInputActions.Enable();
    }

    private void Update()
    {
        Vector2 direction = playerInputActions.Player.Movement.ReadValue<Vector2>();
        rigidbody.AddForce(MovementSpeed * Time.deltaTime * direction);

        float xScaleModifier = direction.x >= 0.0f ? 1.0f : -1.0f;
        Vector2 scale = playerScale;
        scale.x *= xScaleModifier;
        transform.localScale = scale;
    }

    public void Hide(GameObject objectToHideIn)
    {
        if ((objectToHideIn.transform.position - transform.position).magnitude < MaxDistanceToHide)
        {
            spriteRenderer.enabled = !spriteRenderer.enabled;
            // forbid movement
            if (!spriteRenderer.enabled)
            {
                rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;

            }
            else
            {
                rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
            }
        }
    }

    /// <summary>
    /// Pick up an item.
    /// </summary>
    /// <param name="item">item to pick up.</param>
    public void PickUpItem(Item item)
    {
        Debug.Assert(!HasItems(item));

        // TODO: make some change based on picked item (for example change appearance)

        items |= item;
        Debug.Log("Item picked up!");
    }

    /// <summary>
    /// Determine if player has specified items.
    /// </summary>
    /// <param name="items">Specified items.</param>
    public bool HasItems(Item items)
        => (this.items & items) > Item.None;
}
