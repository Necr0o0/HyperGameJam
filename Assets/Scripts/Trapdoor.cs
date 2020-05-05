using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class Trapdoor : MonoBehaviour
{
    
    public Rigidbody trapDoorLeft;
    public Rigidbody trapDoorRight;
    
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) || Input.touchCount>0)
        {
            OpenDoor();
        }
    }

    //method to open the trapdoor
    void OpenDoor()
    {
        trapDoorLeft.isKinematic = false;
        trapDoorRight.isKinematic = false;
    }
    
}
