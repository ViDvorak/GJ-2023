using UnityEngine;

/// <summary>
/// Script for controlling the player.
/// </summary>
public class PlayerController : MonoBehaviour
{
    private const float idleThreshold = 1.7f;

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
    
    private Vector3 playerScale;
    private bool leafVisible = false;

    public GameObject playerSpriteGameObject;

    private GameObject playerMovementSprites;
    private GameObject playerIdleSprites;

    private GameObject playerMovementHatGameObject;
    private GameObject playerMovementScarfGameObject;
    private GameObject playerMovementLeafRightGameObject;
    private GameObject playerMovementLeafLeftGameObject;

    private GameObject playerIdleHatGameObject;
    private GameObject playerIdleScarfGameObject;
    private GameObject playerIdleLeafGameObject;

    /// <summary>
    /// Speed of the player movement.
    /// </summary>
    public float MovementSpeed;

    public float MaxDistanceToHide = 4;

    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerInputActions = new PlayerInputActions();
        playerScale = transform.localScale;

        playerMovementSprites = transform.Find("Movement Sprites").gameObject;
        playerIdleSprites = transform.Find("Idle Sprites").gameObject;

        playerMovementHatGameObject = transform.Find("Movement Sprites").Find("Hat").gameObject;
        playerMovementScarfGameObject = transform.Find("Movement Sprites").Find("Scarf").gameObject;
        playerMovementLeafRightGameObject = transform.Find("Movement Sprites").Find("Leaf Right").gameObject;
        playerMovementLeafLeftGameObject = transform.Find("Movement Sprites").Find("Leaf Left").gameObject;

        playerIdleHatGameObject = transform.Find("Idle Sprites").Find("Hat").gameObject;
        playerIdleScarfGameObject = transform.Find("Idle Sprites").Find("Scarf").gameObject;
        playerIdleLeafGameObject = transform.Find("Idle Sprites").Find("Leaf").gameObject;

        playerMovementHatGameObject.GetComponent<Animator>().keepAnimatorStateOnDisable = true;
        playerMovementScarfGameObject.GetComponent<Animator>().keepAnimatorStateOnDisable = true;
        playerMovementLeafRightGameObject.GetComponent<Animator>().keepAnimatorStateOnDisable = true;
        playerMovementLeafLeftGameObject.GetComponent<Animator>().keepAnimatorStateOnDisable = true;
        
        colliderComponent = GetComponent<Collider2D>();
        playerInputActions.Enable();
    }

    private void Update()
    {
        if (IsPlayerHidden)
            return;

        playerMovementHatGameObject.SetActive(GlobalGameState.HasItems(Item.Hat));
        playerIdleHatGameObject.SetActive(GlobalGameState.HasItems(Item.Hat));
        playerMovementScarfGameObject.SetActive(GlobalGameState.HasItems(Item.Scarf));
        playerIdleScarfGameObject.SetActive(GlobalGameState.HasItems(Item.Scarf));
        playerIdleLeafGameObject.SetActive(GlobalGameState.HasItems(Item.Leaf));
        leafVisible = GlobalGameState.HasItems(Item.Leaf);

        Vector2 direction = playerInputActions.Player.Movement.ReadValue<Vector2>();
        rigidbody.AddForce(MovementSpeed * Time.deltaTime * direction);

        float velocity = rigidbody.velocity.magnitude;

        bool moving = velocity > idleThreshold && direction != Vector2.zero;

        playerMovementSprites.SetActive(moving);
        playerIdleSprites.SetActive(!moving);

        if (direction == Vector2.zero)
            return;

        bool movingRight = direction.x >= 0.0f;

        float xScaleModifier = movingRight ? 1.0f : -1.0f;
        Vector2 scale = playerScale;
        scale.x *= xScaleModifier;
        transform.localScale = scale;

        if (leafVisible)
        {
            playerMovementLeafRightGameObject.transform.localScale = scale;
            playerMovementLeafLeftGameObject.transform.localScale = scale;
            playerMovementLeafRightGameObject.SetActive(movingRight);
            playerMovementLeafLeftGameObject.SetActive(!movingRight);
        }
    }

    public void Hide()
    {
        playerSpriteGameObject.SetActive(false);
        playerIdleSprites.SetActive(false);
        colliderComponent.enabled = false;
        isPlayerHidden = true;

        // forbid movement
        rigidbody.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    public void Unhide()
    {
        playerSpriteGameObject.SetActive(true);
        playerIdleSprites.SetActive(true);
        colliderComponent.enabled = true;
        isPlayerHidden = false;

        rigidbody.constraints = RigidbodyConstraints2D.FreezeRotation;
    }
}
