using UnityEngine;

public class PlayerAuthenticityHandeling : MonoBehaviour
{
    public Bar authenticityMeter;

    public float aweraness = 0f;
    public float aweranessDegradationSpeed = 0.01f;
    public CameraController Camera;

    public float MaxShakeMagnitude;

    private void Update()
    {
        aweraness = Mathf.Clamp01(aweraness - aweranessDegradationSpeed * Time.deltaTime);

        authenticityMeter.SetValue(aweraness);

        if (aweraness > 0.0f)
        {
            Camera.Shake(1.0f, aweraness * MaxShakeMagnitude);
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "AlienDetection")
        {
            aweraness += collision.GetComponent<AlienDetectionHandeling>().AweranessIncreasSpeed * Time.deltaTime;
        }
    }
}
