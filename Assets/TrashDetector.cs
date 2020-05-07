
using UnityEngine;

public class TrashDetector : MonoBehaviour
{
    public BinManager bin;
    void OnTriggerEnter(Collider collider)
    {
        if (collider.CompareTag("Trash"))
        {
            SpawnerManager.Manager.spawnedTrash++;
            bin.ChangeColor();
        }
    }
}
