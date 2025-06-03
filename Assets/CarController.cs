using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    public AudioSource engineAudio;

    [Tooltip("All parts that should change color (e.g. body, doors)")]
    public List<Renderer> carParts = new List<Renderer>();

    [Tooltip("The colors to cycle through")]
    public Color[] carColors;

    private int colorIndex = 0;

    public void StartEngine()
    {
        if (engineAudio && !engineAudio.isPlaying)
            engineAudio.Play();

        // ✅ Spin back wheels for 10 seconds
        foreach (WheelRotator wheel in GetComponentsInChildren<WheelRotator>())
        {
            wheel.StartSpinning(10f); // spins for 10 seconds
        }
    }

    public void ChangeColor()
    {
        if (carParts.Count > 0 && carColors.Length > 0)
        {
            colorIndex = (colorIndex + 1) % carColors.Length;

            foreach (Renderer part in carParts)
            {
                if (part != null)
                    part.material.color = carColors[colorIndex];
            }
        }
    }
}
