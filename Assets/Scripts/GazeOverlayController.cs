using UnityEngine;

public class GazeOverlayController : MonoBehaviour
{
    public Camera recordingCamera;
    public float overlayDepth = 2.0f; // Distance in front of camera
    public float smoothSpeed = 15f;

    void Start()
    {
        if (recordingCamera == null) recordingCamera = Camera.main;
    }

    void Update()
    {
        // Get normalized eye-tracking coordinates (0.0 to 1.0)
        Vector2 normalizedGaze = GetLatestGaze();

        // Map to recording camera viewport
        Vector3 screenPoint = new Vector3(
            normalizedGaze.x * recordingCamera.pixelWidth,
            normalizedGaze.y * recordingCamera.pixelHeight,
            overlayDepth
        );

        Vector3 targetWorldPos = recordingCamera.ScreenToWorldPoint(screenPoint);

        // Move circle and face camera
        transform.position = Vector3.Lerp(transform.position, targetWorldPos, Time.deltaTime * smoothSpeed);
        transform.LookAt(recordingCamera.transform);
    }

    private Vector2 GetLatestGaze()
    {
        // Replace this with your Pupil Labs real-time gaze coordinate feed
        return new Vector2(0.5f, 0.5f); 
    }
}
