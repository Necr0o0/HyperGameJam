using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PortalManager : MonoBehaviour
{
    public GameObject portalOUT;

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Trash"))
        {
            other.gameObject.SetActive(false);
            other.transform.position = portalOUT.transform.position;
            other.gameObject.SetActive(true);
    
        }
    }
}
