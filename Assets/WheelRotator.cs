using UnityEngine;

public class WheelRotator : MonoBehaviour
{
    public float rotationSpeed = 200f;
    private bool isSpinning = false;
    private float spinDuration = 0f;

    public void StartSpinning(float duration)
    {
        isSpinning = true;
        spinDuration = duration;
    }

    void Update()
    {
        if (isSpinning)
        {
            transform.Rotate(Vector3.right * rotationSpeed * Time.deltaTime);
            spinDuration -= Time.deltaTime;

            if (spinDuration <= 0f)
                isSpinning = false;
        }
    }
}
