using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script for handling object with ability to change scene.
/// </summary>
public class SceneChangerController : MonoBehaviour
{
    private PlayerInputActions playerInputActions;

    private GameObject tooltips;
    private GameObject tooltipText;
    private GameObject neededItemsText;

    /// <summary>
    /// Scene which will become active upon entering scene changer area. Scene needs to be included in build settings
    /// (file -> build settings).
    /// </summary>
    public Object Scene;
    /// <summary>
    /// Items required in order to change the scene.
    /// </summary>
    public Item RequiredItems;

    private void Start()
    {
        tooltips = transform.parent.Find("Tooltips").gameObject;
        tooltipText = transform.parent.Find("Tooltips").Find("Tooltip Text").gameObject;
        neededItemsText = transform.parent.Find("Tooltips").Find("Needed items Text").gameObject;

        playerInputActions = new PlayerInputActions();
        playerInputActions.Enable();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() == null)
            return;

        tooltips.SetActive(true);

        TextMesh textMesh = neededItemsText.GetComponent<TextMesh>();
        textMesh.text = textMesh.text.Replace("#", RequiredItems.ToString());
        Debug.Log(textMesh.text);

        bool hasItems = GlobalGameState.HasItems(RequiredItems);
        tooltipText.SetActive(hasItems);
        neededItemsText.SetActive(!hasItems);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() == null)
            return;

        tooltips.SetActive(false);
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        PlayerController playerController = collision.gameObject.GetComponent<PlayerController>();

        if (playerController == null)
            return;

        bool hasItems = GlobalGameState.HasItems(RequiredItems);

        tooltipText.SetActive(hasItems);
        neededItemsText.SetActive(!hasItems);

        if (playerInputActions.Player.Interaction.IsPressed() && hasItems)
        {
            SceneManager.LoadScene(Scene.name);
        }
    }
}
