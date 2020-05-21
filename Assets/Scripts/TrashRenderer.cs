using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrashRenderer : MonoBehaviour
{
    private Renderer _renderer;
    void Awake()
    {
        _renderer = transform.GetComponent<Renderer>();
    }
    void Update()
    {
        if (!_renderer.isVisible)
        {
            //gameObject.SetActive(false);
        }
    }
}
