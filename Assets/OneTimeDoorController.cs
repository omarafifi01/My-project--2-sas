using UnityEngine;

public class OneTimeDoorController : MonoBehaviour
{
    public Transform door;               // Door mesh
    public float openAngle = 70f;
    public float openSpeed = 5f;

    private bool hasOpened = false;
    private Quaternion closedRotation;
    private Quaternion openRotation;

    void Start()
    {
        if (door == null)
            door = transform;

        closedRotation = door.localRotation;
        openRotation = Quaternion.Euler(door.localRotation.eulerAngles + new Vector3(0, openAngle, 0));
    }

    public void OpenDoorOnce()
    {
        if (hasOpened) return;

        hasOpened = true;
        Debug.Log("Opening door one time");
    }

    void Update()
    {
        if (hasOpened)
        {
            door.localRotation = Quaternion.Lerp(door.localRotation, openRotation, Time.deltaTime * openSpeed);
        }
    }
}
