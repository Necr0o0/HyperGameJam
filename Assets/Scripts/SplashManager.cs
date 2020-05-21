using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashManager : MonoBehaviour
{
    private Renderer _renderer;
    private Material _material;
    private MaterialPropertyBlock _materialPropertyBlock;
    private float timer = 0.0f;
    private float value = 0.0f;
    private bool start = false;
    private void Update()
    {
        if (start && timer<1.0f)
        {
            timer += Time.deltaTime ;
            value = Mathf.Lerp(0.0f, 1.0f, timer);
            _materialPropertyBlock.SetFloat("_Progress",value);
            _renderer.SetPropertyBlock(_materialPropertyBlock);
        }
        
    }

    public void TriggerAnimation(Transform other)
    {
        var _color = other.GetComponent<Renderer>().material.color;
        var decal = SpawnerManager.Manager.GetComponent<ObjectPool>().GetSplashObject();
        _renderer = decal.GetComponent<Renderer>();
       

        _material = new Material(decal.GetComponent<Renderer>().material);
        _renderer.material = _material;
        _materialPropertyBlock = new MaterialPropertyBlock();
        _renderer.GetPropertyBlock(_materialPropertyBlock);
      
        _materialPropertyBlock.SetColor("_Color",_color);
        timer = 0.0f;
        decal.transform.position = other.transform.position;
        other.gameObject.SetActive(false);

        start = true;
    }
}
