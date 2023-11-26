using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script handling bus logic.
/// </summary>
public class BusController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;
    /// <summary>
    /// Determine if bus started movement.
    /// </summary>
    private bool departed;
    /// <summary>
    /// Sprite renderer of bus texture.
    /// </summary>
    private SpriteRenderer spriteRenderer;

    /// <summary>
    /// Bus movement speed.
    /// </summary>
    public float Speed;
    /// <summary>
    /// Bus movement direction.
    /// </summary>
    public Vector2 Direction;
    /// <summary>
    /// Scene which will become active when bus leaves current scene. Scene needs to be included in build settings
    /// (file -> build settings).
    /// </summary>
    public Object Scene;
    /// <summary>
    /// Controller of main camera.
    /// </summary>
    public CameraController Camera;
    /// <summary>
    /// Items required in order to enter the bus.
    /// </summary>
    public Item RequiredItems;

    private void Start()
    {
        spriteRenderer = transform.parent.Find("Texture").GetComponent<SpriteRenderer>();

        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
    }

    private void Update()
    {
        if (!departed)
            return;

        transform.parent.localPosition += (Vector3)(Direction * Speed * Time.deltaTime);

        if (!spriteRenderer.isVisible)
        {
            SceneManager.LoadScene(Scene.name);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        // TODO: show tooltip "Press E to enter the bus."

        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

        if (playerController == null)
            return;

        // TODO: show tooltip "You need xyz items in order to enter the bus."
        if (playerInputActions.Player.Interaction.IsPressed() && GlobalGameState.HasItems(RequiredItems))
        {
            playerController.Hide();
            departed = true;
            Camera.Target = transform.parent;
        }
    }
}
