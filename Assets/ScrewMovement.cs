using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;
using Random = UnityEngine.Random;

public class ScrewMovement : MonoBehaviour
{
    private Vector3 pos;
    private float seed = 0.0f;
    public bool _move;
    public bool _rotate;
    public bool MoveClockWise = true;
    public bool useSeed = true;
    public float speed = 100.0f;

    private float rotateDir = 1.0f;
    private void Awake()
    {
        if(useSeed)
            seed = Random.Range(-Mathf.PI, Mathf.PI);
        
            
        _rotate = true;
        if (MoveClockWise)
            rotateDir = -1f;
    }

    void LateUpdate()
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
        angle.z = (Time.time + seed) * speed * rotateDir ;
        transform.localRotation = Quaternion.Euler(angle);
    }
}