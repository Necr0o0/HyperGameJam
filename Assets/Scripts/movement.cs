﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        var pos = transform.position;
        pos.x += Mathf.Sin(Time.time- 3f)*0.005f;
        transform.position = pos;
    }
}