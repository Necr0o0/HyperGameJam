using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    public int sign = 1;
    void FixedUpdate()
    {
        var x = transform.rotation.eulerAngles;
        x.z += Time.deltaTime * 160f *sign;
        transform.rotation = Quaternion.Euler(x);
    }
}
