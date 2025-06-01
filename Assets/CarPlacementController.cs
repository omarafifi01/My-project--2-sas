using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARSubsystems;
using System.Collections.Generic;

public class CarPlacementController : MonoBehaviour
{
    public GameObject carPrefab;
    private GameObject spawnedCar;
    private ARRaycastManager raycastManager;

    private static List<ARRaycastHit> hits = new List<ARRaycastHit>();

    void Awake()
    {
        raycastManager = GetComponent<ARRaycastManager>();
    }

    void Update()
    {
#if UNITY_EDITOR
        if (spawnedCar == null && Input.GetMouseButtonDown(0))
        {
            Vector3 spawnPos = Camera.main.transform.position + Camera.main.transform.forward * 1.5f;
            spawnedCar = Instantiate(carPrefab, spawnPos, Quaternion.identity);
        }
#else
        if (Input.touchCount == 0 || spawnedCar != null)
            return;

        Touch touch = Input.GetTouch(0);
        if (touch.phase == TouchPhase.Began)
        {
            if (raycastManager.Raycast(touch.position, hits, TrackableType.PlaneWithinPolygon))
            {
                Pose hitPose = hits[0].pose;
                spawnedCar = Instantiate(carPrefab, hitPose.position, hitPose.rotation);
            }
        }
#endif
    }
}
