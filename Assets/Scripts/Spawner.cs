using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    private float timer;
    public Transform trash;
    private ObjectPool _objectPool;
    public int trashSpawnMax = 100;
    private int trashCounter = 0;
    public bool done = false;

    public int materialsCount=4;
    // Start is called before the first frame update
    void Start()
    {
         timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > 0.02f + Random.Range(-0.03f, 0.03f) && trashCounter < trashSpawnMax) 
        {
            SpawnTrash();
        }
        else if( trashCounter >= trashSpawnMax && !done)
        {
            GameManager.gameManager.SetStartCamera();
            done = true;
        }
    }

    void SpawnTrash()
    {
        trash = SpawnerManager.Manager.GetComponent<ObjectPool>().GetBallObject();
        trash.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
        trash.GetComponent<Rigidbody>().velocity = Vector3.zero;

        trash.position = transform.position+ new Vector3(Random.Range(-0.4f,0.4f),Random.Range(0f,0.8f),Random.Range(-0.4f,0.4f));
        Material material = Resources.Load<Material>("Materials/Trash/TrashMaterial" + Random.Range(0,2).ToString());
        trash.localScale = SpawnerManager.Manager.GetComponent<ObjectPool>().getScale() * Random.Range(0.7f, 1.0f);
        trash.GetComponent<MeshRenderer>().material = material;
        trashCounter++;
        timer = 0f;
    }
}
