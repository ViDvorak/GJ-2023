using UnityEngine;

/// <summary>
/// Script for controlling the camera.
/// </summary>
public class CameraController : MonoBehaviour
{
    /// <summary>
    /// Target which will camera follow. Camera will only follow the targe along the x axis.
    /// </summary>
    [field: SerializeField]
    public Transform Target { get; set; }

    private void Update()
    {
        if (Target == null)
            return;

        Vector3 position = transform.position;

        position.x = Target.position.x;

        transform.position = position;
    }
}
