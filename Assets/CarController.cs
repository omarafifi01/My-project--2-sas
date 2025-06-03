using UnityEngine;

public class CarController : MonoBehaviour
{
    public AudioSource engineAudio;
    public Renderer carBody;
    public Color[] carColors;
    private int colorIndex = 0;

    public void StartEngine()
    {
        if (engineAudio && !engineAudio.isPlaying)
            engineAudio.Play();
    }

    public void ChangeColor()
    {
        if (carBody && carColors.Length > 0)
        {
            colorIndex = (colorIndex + 1) % carColors.Length;
            carBody.material.color = carColors[colorIndex];
        }
    }
}
