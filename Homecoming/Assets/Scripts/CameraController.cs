using UnityEngine;

/// <summary>
/// Script for controlling the camera.
/// </summary>
public class CameraController : MonoBehaviour
{
    private AreaController areaController;
    private float shakeAccumulator;
    private bool shakeActive;
    private float shakeDuration;
    private float shakeMagnitude;

    /// <summary>
    /// Target which will camera follow. Camera will only follow the targe along the x axis.
    /// </summary>
    [field: SerializeField]
    public Transform Target { get; set; }
    public GameObject Area;

    public void Shake(float duration, float magnitude)
    {
        shakeDuration = duration;
        shakeMagnitude = magnitude;
        shakeActive = true;
    }

    private void Start()
    {
        areaController = Area.GetComponent<AreaController>();
    }

    private void Update()
    {
        float leftEdge = Camera.main.ViewportToWorldPoint(new Vector3(0f, 0.5f, 0)).x;
        float center = Camera.main.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0)).x;
        float rightEdge = Camera.main.ViewportToWorldPoint(new Vector3(1f, 0.5f, 0)).x;

        float distanceToLeftViewportEdge = center - leftEdge;
        float distanceToRightViewportEdge = rightEdge - center;

        if (Target == null)
            return;

        Vector3 position = transform.position;

        position.x = Mathf.Clamp(
            Target.position.x,
            distanceToLeftViewportEdge - (areaController.AreaSize.x + 1) / 2,
            (areaController.AreaSize.x + 1) / 2 - distanceToRightViewportEdge
        );
        position.y = 0.0f;

        transform.position = position;

        if (shakeActive)
        {
            transform.position += (Vector3)((Vector2)Random.onUnitSphere * shakeMagnitude);

            shakeAccumulator += Time.deltaTime;
            if (shakeAccumulator >= shakeDuration)
            {
                shakeAccumulator = 0.0f;
                shakeActive = false;
            }
        }
    }
}
