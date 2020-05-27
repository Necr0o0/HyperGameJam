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
    private bool _move;
    private bool _rotate;

    private float _speedSeed;
    private void Awake()
    {
        _speedSeed = Random.Range(0.7f, 1.0f);
        seed = Random.Range(-Mathf.PI, Mathf.PI);

        if (Random.value > 0.1)
            _move = true;

        if (Random.value > 0.5)
            _rotate = true;
    }

    void Update()
    {
        if(_move)
            MoveLeftAndRight();
        if(_rotate)
             Rotate();
    }

    private void MoveLeftAndRight()
    {
        pos = transform.localPosition;
        pos.x = Mathf.Sin(Time.time + seed) - 2.0f;
        transform.localPosition = pos;
    }

    private void Rotate()
    {
        var angle = transform.localRotation.eulerAngles;
        angle.z = Mathf.Sin(Time.time + seed) * 10f *_speedSeed - 2.0f;
        transform.localRotation = Quaternion.Euler(angle);
    }
}
