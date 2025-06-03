using UnityEngine;

public class WheelRotator : MonoBehaviour
{
    public float spinSpeed = 360f; // Degrees per second
    private bool isSpinning = false;
    private float spinTimer = 0f;

    public enum SpinAxis { X, Y, Z }
    public SpinAxis spinAxis = SpinAxis.X;

    public void StartSpinning(float duration = 10f)
    {
        Debug.Log($"{gameObject.name} starts spinning for {duration} seconds");
        isSpinning = true;
        spinTimer = duration;
    }

    void Update()
    {
        if (!isSpinning) return;

        Vector3 axis = spinAxis switch
        {
            SpinAxis.X => Vector3.right,
            SpinAxis.Y => Vector3.up,
            SpinAxis.Z => Vector3.forward,
            _ => Vector3.right
        };

        transform.Rotate(axis * spinSpeed * Time.deltaTime);

        spinTimer -= Time.deltaTime;
        if (spinTimer <= 0f)
        {
            isSpinning = false;
            Debug.Log($"{gameObject.name} stopped spinning");
        }
    }
}
