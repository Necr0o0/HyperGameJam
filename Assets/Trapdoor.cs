using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using UnityEngine;

public class Trapdoor : MonoBehaviour
{
    public GameObject trapDoor;
    [SerializeField] private float period = 2f;
    [SerializeField] private float rotationSpeed = 20f;
    [SerializeField] private float xAngle = 110f;
    private float _yAngle;
    private float _zAngle;
    private float _timer;
    private bool _areDoorOpen = false;

    private void Start()
    {
        _timer = 0f;
        _yAngle = trapDoor.transform.rotation.y;
        _zAngle = trapDoor.transform.rotation.z;
    }

    private void Update()
    {
        //float touches = 0;
        if (Input.GetMouseButtonUp(0))
        {
            OpenDoor();
            //touches++;
        }

        if (_areDoorOpen)
        {
            trapDoor.transform.Rotate(-xAngle*rotationSpeed*Time.deltaTime, _yAngle, _zAngle, Space.Self);
            _timer += Time.deltaTime;
            if (_timer > period)
            {
                CloseDoor();
                _timer = 0f;
                trapDoor.transform.Rotate(xAngle*rotationSpeed*Time.deltaTime, _yAngle, _zAngle, Space.Self);
            }
        }
        
        //Debug.Log(touches);
    }

    //method to open the trapdoor
    void OpenDoor()
    {
        _areDoorOpen = true;
        //trapDoor.SetActive(false);
        Debug.Log("open");
        Debug.Log(_areDoorOpen);
        //trapDoor.transform.Rotate(-xAngle*rotationSpeed*Time.deltaTime, _yAngle, _zAngle, Space.Self);
    }
    
    void CloseDoor()
    {
        //trapDoor.SetActive(true);
        Debug.Log("close");
        _areDoorOpen = false;
    }
}
