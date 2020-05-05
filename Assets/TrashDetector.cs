
using UnityEngine;

public class TrashDetector : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        SpawnerManager.Manager.spawnedTrash++;
    }
}
