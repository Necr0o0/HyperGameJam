using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gasd : MonoBehaviour
{
    private float timer;
    private float value= 0.0f;
    private Material _material;
    private Renderer _renderer;
    private bool start = false;
    private MaterialPropertyBlock _materialPropertyBlock;
    private void Update()
    {
      
    }

    /*
    private void OnCollisionEnter(Collision other)
    {
        if(other.transform.CompareTag("Trash"))
        {
            Debug.Log(other);
            var decal = SpawnerManager.Manager.GetComponent<ObjectPool>().GetSplashObject();
            decal.GetComponent<SplashManager>().TriggerAnimation(other.transform);
        }
     
    }*/
}
