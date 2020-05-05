using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class Trapdoor : MonoBehaviour
{
    public Transform bin;
    public Rigidbody trapDoorLeft;
    public Rigidbody trapDoorRight;
    
    
    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            OpenDoor();
            Camera.main.transform.DOLocalMoveY(-0.5f, 5f);
        }
    }

    //method to open the trapdoor
    void OpenDoor()
    {
        trapDoorLeft.isKinematic = false;
        trapDoorRight.isKinematic = false;
    }
    
}
