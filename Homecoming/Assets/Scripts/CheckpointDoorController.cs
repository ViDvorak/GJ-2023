using UnityEngine;

/// <summary>
/// Handles logic for doors which opens when player is in proximity.
/// </summary>
public class CheckpointDoorController : MonoBehaviour
{
    private GameObject closedTexture;
    private GameObject openTexture;

    private void Start()
    {
        closedTexture = transform.Find("Texture Closed").gameObject;
        openTexture = transform.Find("Texture Open").gameObject;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() == null)
            return;

        closedTexture.SetActive(false);
        openTexture.SetActive(true);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() == null)
            return;

        closedTexture.SetActive(true);
        openTexture.SetActive(false);
    }
}
