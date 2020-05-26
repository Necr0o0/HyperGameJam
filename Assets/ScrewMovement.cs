using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using Random = UnityEngine.Random;

public class ScrewMovement : MonoBehaviour
{
    private Vector3 pos;
    private float seed;
    private bool _move;
    private bool _rotate;
    public float speed = 100.0f;
    private void Awake()
    {
        seed = Random.Range(-Mathf.PI, Mathf.PI);

        if (Random.value > 0.1)
            _move = true;

      
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
        angle.z = (Time.time + seed) * speed ;
        transform.localRotation = Quaternion.Euler(angle);
    }
}