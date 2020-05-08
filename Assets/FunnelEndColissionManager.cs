using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FunnelEndColissionManager : MonoBehaviour
{
    public FunnelManager FunnelManager;
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Trash"))
        {
            other.gameObject.SetActive(false);
        }
        FunnelManager.ChangeColor(other.GetComponent<Renderer>().material.color);
    }
}
