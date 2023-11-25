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
    private bool leafVisible = false;

    private GameObject playerSpriteGameObject;
    private GameObject playerHatGameObject;
    private GameObject playerScarfGameObject;
    private GameObject playerLeafRightGameObject;
    private GameObject playerLeafLeftGameObject;

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

        playerHatGameObject = transform.Find("Sprites").Find("Hat").gameObject;
        playerScarfGameObject = transform.Find("Sprites").Find("Scarf").gameObject;
        playerLeafRightGameObject = transform.Find("Sprites").Find("Leaf Right").gameObject;
        playerLeafLeftGameObject = transform.Find("Sprites").Find("Leaf Left").gameObject;

        playerHatGameObject.GetComponent<Animator>().keepAnimatorStateOnDisable = true;
        playerScarfGameObject.GetComponent<Animator>().keepAnimatorStateOnDisable = true;
        playerLeafRightGameObject.GetComponent<Animator>().keepAnimatorStateOnDisable = true;
        playerLeafLeftGameObject.GetComponent<Animator>().keepAnimatorStateOnDisable = true;

        playerInputActions.Enable();
    }

    private void Update()
    {
        Vector2 direction = playerInputActions.Player.Movement.ReadValue<Vector2>();
        rigidbody.AddForce(MovementSpeed * Time.deltaTime * direction);

        bool movingRight = direction.x >= 0.0f;

        float xScaleModifier = movingRight ? 1.0f : -1.0f;
        Vector2 scale = playerScale;
        scale.x *= xScaleModifier;
        transform.localScale = scale;

        if (leafVisible)
        {
            playerLeafRightGameObject.transform.localScale = scale;
            playerLeafLeftGameObject.transform.localScale = scale;
            playerLeafRightGameObject.SetActive(movingRight);
            playerLeafLeftGameObject.SetActive(!movingRight);
        }
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

        items |= item;

        switch (item)
        {
            case Item.Hat:
                playerHatGameObject.SetActive(true);
                break;
            case Item.Scarf:
                playerScarfGameObject.SetActive(true);
                break;
            case Item.Leaf:
                leafVisible = true;
                break;
        }
    }

    /// <summary>
    /// Determine if player has specified items.
    /// </summary>
    /// <param name="items">Specified items.</param>
    public bool HasItems(Item items)
        => (this.items & items) > Item.None;
}
