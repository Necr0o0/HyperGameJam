using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    private float timer;
    public Transform trash;
    private ObjectPool _objectPool;
    private Rigidbody _trashRigidbody;
    public int trashSpawnMax = 100;
    private int trashCounter = 0;
    public bool done = false;

    public int materialsCount=4;
    // Start is called before the first frame update
    void Start()
    {
        _objectPool = ObjectPool.Instance;
        _trashRigidbody = trash.GetComponent<Rigidbody>();
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
        trash =  _objectPool.GetBallObject();
        _trashRigidbody.angularVelocity = Vector3.zero;
        _trashRigidbody.velocity = Vector3.zero;

        string random = Random.Range(0, 2).ToString();
        trash.position = transform.position+ new Vector3(Random.Range(-0.4f,0.4f),Random.Range(0f,0.8f),Random.Range(-0.4f,0.4f));
        Material material = Resources.Load<Material>("Materials/Trash/TrashMaterial" + random);
        Material materialTrace = Resources.Load<Material>("MaterialsNoShader/Trash/TrashMaterial" + random);

        trash.localScale =  _objectPool.getScale() * Random.Range(0.5f, 0.9f);
        if (trash.localScale.x > _objectPool.getScale().x * 0.85f)
        {
            trash.GetChild(0).gameObject.SetActive(true);
        }
        trash.GetComponent<MeshRenderer>().material = material;
        trash.GetChild(0).GetComponent<ParticleSystemRenderer>().material = materialTrace;
        trash.GetChild(0).GetComponent<ParticleSystemRenderer>().trailMaterial = materialTrace;

        trashCounter++;
        timer = 0f;
    }
}
