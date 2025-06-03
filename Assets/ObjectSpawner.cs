using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Utilities;

namespace UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets
{
    public class ObjectSpawner : MonoBehaviour
    {
        [SerializeField] private Camera m_CameraToFace;
        [SerializeField] private List<GameObject> m_ObjectPrefabs = new List<GameObject>();
        [SerializeField] private GameObject m_SpawnVisualizationPrefab;
        [SerializeField] private int m_SpawnOptionIndex = -1;
        [SerializeField] private bool m_OnlySpawnInView = true;
        [SerializeField] private float m_ViewportPeriphery = 0.15f;
        [SerializeField] private bool m_ApplyRandomAngleAtSpawn = true;
        [SerializeField] private float m_SpawnAngleRange = 45f;
        [SerializeField] private bool m_SpawnAsChildren = false;

        public CarController activeCar; // stores last spawned car
        public event Action<GameObject> objectSpawned;

        public Camera cameraToFace
        {
            get { EnsureFacingCamera(); return m_CameraToFace; }
            set => m_CameraToFace = value;
        }

        public List<GameObject> objectPrefabs
        {
            get => m_ObjectPrefabs;
            set => m_ObjectPrefabs = value;
        }

        public GameObject spawnVisualizationPrefab
        {
            get => m_SpawnVisualizationPrefab;
            set => m_SpawnVisualizationPrefab = value;
        }

        public int spawnOptionIndex
        {
            get => m_SpawnOptionIndex;
            set => m_SpawnOptionIndex = value;
        }

        public bool isSpawnOptionRandomized => m_SpawnOptionIndex < 0 || m_SpawnOptionIndex >= m_ObjectPrefabs.Count;

        public bool onlySpawnInView
        {
            get => m_OnlySpawnInView;
            set => m_OnlySpawnInView = value;
        }

        public float viewportPeriphery
        {
            get => m_ViewportPeriphery;
            set => m_ViewportPeriphery = value;
        }

        public bool applyRandomAngleAtSpawn
        {
            get => m_ApplyRandomAngleAtSpawn;
            set => m_ApplyRandomAngleAtSpawn = value;
        }

        public float spawnAngleRange
        {
            get => m_SpawnAngleRange;
            set => m_SpawnAngleRange = value;
        }

        public bool spawnAsChildren
        {
            get => m_SpawnAsChildren;
            set => m_SpawnAsChildren = value;
        }

        void Awake() => EnsureFacingCamera();

        void EnsureFacingCamera()
        {
            if (m_CameraToFace == null)
                m_CameraToFace = Camera.main;
        }

        public void RandomizeSpawnOption() => m_SpawnOptionIndex = -1;

        public bool TrySpawnObject(Vector3 spawnPoint, Vector3 spawnNormal)
        {
            if (activeCar != null)
                return false;

            if (m_OnlySpawnInView)
            {
                var inViewMin = m_ViewportPeriphery;
                var inViewMax = 1f - m_ViewportPeriphery;
                var pointInViewportSpace = cameraToFace.WorldToViewportPoint(spawnPoint);
                if (pointInViewportSpace.z < 0f || pointInViewportSpace.x > inViewMax || pointInViewportSpace.x < inViewMin ||
                    pointInViewportSpace.y > inViewMax || pointInViewportSpace.y < inViewMin)
                {
                    return false;
                }
            }

            int objectIndex = isSpawnOptionRandomized
                ? UnityEngine.Random.Range(0, m_ObjectPrefabs.Count)
                : m_SpawnOptionIndex;

            GameObject newObject = Instantiate(m_ObjectPrefabs[objectIndex]);

            if (m_SpawnAsChildren)
                newObject.transform.parent = transform;

            newObject.transform.position = spawnPoint;
            EnsureFacingCamera();

            Vector3 facePosition = m_CameraToFace.transform.position;
            Vector3 forward = facePosition - spawnPoint;
            BurstMathUtility.ProjectOnPlane(forward, spawnNormal, out var projectedForward);
            newObject.transform.rotation = Quaternion.LookRotation(projectedForward, spawnNormal);

            if (m_ApplyRandomAngleAtSpawn)
            {
                float randomRotation = UnityEngine.Random.Range(-m_SpawnAngleRange, m_SpawnAngleRange);
                newObject.transform.Rotate(Vector3.up, randomRotation);
            }

            if (m_SpawnVisualizationPrefab != null)
            {
                Transform visualizationTrans = Instantiate(m_SpawnVisualizationPrefab).transform;
                visualizationTrans.position = spawnPoint;
                visualizationTrans.rotation = newObject.transform.rotation;
            }

            activeCar = newObject.GetComponent<CarController>();
            objectSpawned?.Invoke(newObject);
            return true;
        }

        public void StartEngineOnActiveCar()
        {
            if (activeCar != null)
                activeCar.StartEngine();
        }

        public void ChangeColorOnActiveCar()
        {
            if (activeCar != null)
                activeCar.ChangeColor();
        }

#if UNITY_EDITOR
        void Update()
        {
            if (Input.GetMouseButtonDown(0) && activeCar == null)
            {
                Vector3 spawnPosition = Camera.main.transform.position + Camera.main.transform.forward * 1.5f;
                Vector3 spawnNormal = Vector3.up;
                TrySpawnObject(spawnPosition, spawnNormal);
            }
        }
#endif
    }
}
