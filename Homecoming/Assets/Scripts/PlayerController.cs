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

    /// <summary>
    /// Speed of the player movement.
    /// </summary>
    public float MovementSpeed;

    private void Awake()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        playerInputActions = new PlayerInputActions();

        playerInputActions.Enable();
    }

    private void Update()
    {
        Vector2 direction = playerInputActions.Player.Movement.ReadValue<Vector2>();

        rigidbody.AddForce(MovementSpeed * Time.deltaTime * direction);
    }
}
