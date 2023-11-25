using UnityEngine;
using UnityEngine.SceneManagement;

/// <summary>
/// Script for handling object with ability to change scene.
/// </summary>
public class SceneChangerController : MonoBehaviour
{

    /// <summary>
    /// Scene which will become active upon entering scene changer area. Scene needs to be included in build settings
    /// (file -> build settings).
    /// </summary>
    public Object Scene;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<PlayerController>() == null)
            return;

        SceneManager.LoadScene(Scene.name);
    }
}
