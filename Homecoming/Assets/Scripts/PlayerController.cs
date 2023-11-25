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
    public PlayerInputActions PlayerInputActions {  get { return playerInputActions; } }


    private new Rigidbody2D rigidbody;
    private SpriteRenderer spriteRenderer;
    private Collider2D colliderComponent;


    private bool isPlayerHidden = false;
    public bool IsPlayerHidden { get { return isPlayerHidden; } }
    /// <summary>
    /// Flags bitset which contains player items.
    /// </summary>
    private Item items = Item.None;

    /// <summary>
    /// Speed of the player movement.
    /// </summary>
    public float MovementSpeed;

    public float MaxDistanceToHide = 4;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerInputActions = new PlayerInputActions();
        spriteRenderer = GetComponentInChildren<SpriteRenderer>(true);

        
        colliderComponent = GetComponent<Collider2D>();
        playerInputActions.Enable();
    }

    private void Start()
    {
        spriteRenderer = GetComponentInChildren<SpriteRenderer>(true);
    }

    private void Update()
    {
        Vector2 direction = playerInputActions.Player.Movement.ReadValue<Vector2>();

        rigidbody.AddForce(MovementSpeed * Time.deltaTime * direction);
    }

    public void Hide(GameObject objectToHideIn)
    {
        spriteRenderer.enabled = false;
        colliderComponent.enabled = false;
        isPlayerHidden = true;

        // forbid movement
        rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }
    public void Unhide()
    {
        spriteRenderer.enabled = true;
        colliderComponent.enabled = true;
        isPlayerHidden = false;

        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
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
