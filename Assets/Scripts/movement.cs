using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class movement : MonoBehaviour
{
    void FixedUpdate()
    {
        var pos = transform.position;
        pos.x += Mathf.Sin(Time.time- 3f)*0.005f;
        transform.position = pos;
    }
}
