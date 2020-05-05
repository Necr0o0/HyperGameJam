using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Spawner : MonoBehaviour
{
    private float timer;
    public Transform trash;
    private ObjectPool _objectPool;

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
        if (timer > 0.2f + Random.Range(-0.05f, 0.05f))
        {
           
            trash = SpawnerManager.Manager.GetComponent<ObjectPool>().GetObject();
            trash.GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            trash.GetComponent<Rigidbody>().velocity = Vector3.zero;

            trash.position = transform.position+ new Vector3(Random.Range(-0.1f,0.1f),0,Random.Range(-0.1f,0.1f));
            Material material = Resources.Load<Material>("Materials/Trash/TrashMaterial" + Random.Range(0,4).ToString());
            trash.localScale = SpawnerManager.Manager.GetComponent<ObjectPool>().getScale() * Random.Range(0.7f, 1.0f);
            trash.GetComponent<MeshRenderer>().material = material;
            timer = 0f;
        }
    }
}
