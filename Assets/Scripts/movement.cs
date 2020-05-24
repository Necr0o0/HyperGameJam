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
        //MoveLeftAndRight();
        Rotate();
    }

    private void MoveLeftAndRight()
    {
        pos = transform.localPosition;
        pos.x = Mathf.Sin(Time.time+seed) - 1.834354f;
        transform.localPosition = pos;
    }

    private void Rotate()
    {
        var angle = transform.localRotation.eulerAngles;
        angle.z = Mathf.Sin(Time.time + seed)*10f - 1.834354f;
        transform.localRotation = Quaternion.Euler(angle);
    }
}
