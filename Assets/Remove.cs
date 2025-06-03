using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit.Samples.StarterAssets;

public class Remove : MonoBehaviour
{
    public ObjectSpawner spawner;

    public void RemoveCar()
    {
        if (spawner != null && spawner.activeCar != null)
        {
            Destroy(spawner.activeCar.gameObject);
            spawner.activeCar = null;
        }
    }
}
