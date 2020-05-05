
using UnityEngine;

public class TrashDetector : MonoBehaviour
{
    void OnTriggerEnter(Collider collider)
    {
        if(collider.CompareTag("Trash"))
            SpawnerManager.Manager.spawnedTrash++;
    }
}
