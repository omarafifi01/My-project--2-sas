using TMPro;
using UnityEngine;
using UnityEngine.XR.ARFoundation;

public class DebugStatsFloating : MonoBehaviour
{
    public TextMeshProUGUI debugText;
    private float deltaTime = 0.0f;
    private ARSession arSession;

    void Start()
    {
        arSession = FindObjectOfType<ARSession>();
    }

    void Update()
    {
        deltaTime += (Time.unscaledDeltaTime - deltaTime) * 0.1f;
        float fps = 1.0f / deltaTime;

        string trackingStatus = "Unavailable";
        if (arSession != null)
        {
            trackingStatus = ARSession.state.ToString();
        }

        debugText.text = $"FPS: {Mathf.Ceil(fps)}\nTracking: {trackingStatus}";
    }
}
