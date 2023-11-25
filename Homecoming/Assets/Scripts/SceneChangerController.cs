using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script for handling object with ability to change scene.
/// </summary>
public class SceneChangerController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    /// <summary>
    /// Scene which will become active upon entering scene changer area. Scene needs to be included in build settings
    /// (file -> build settings).
    /// </summary>
    public Object Scene;
    /// <summary>
    /// Items required in order to change the scene.
    /// </summary>
    public Item RequiredItems;

    private void Awake()
    {
        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

        if (playerController == null)
            return;

        Debug.Log(playerInputActions.Player.Interaction.IsPressed());
        Debug.Log(playerController.HasItems(RequiredItems));

        if (playerInputActions.Player.Interaction.IsPressed() && playerController.HasItems(RequiredItems))
        {
            SceneManager.LoadScene(Scene.name);
        }
    }
}
