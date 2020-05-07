using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using Random = UnityEngine.Random;

public class movement : MonoBehaviour
{
    private Vector3 pos;
    private float seed;
    private void Awake()
    {
        seed = Random.Range(-Mathf.PI, Mathf.PI);
    }

    void Update()
    {
        pos = transform.localPosition;
        pos.x = Mathf.Sin(Time.time+seed) - 1.834354f;
        transform.localPosition = pos;
    }
}
