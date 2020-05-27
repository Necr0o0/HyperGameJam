using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class DestroyablePlatformController : MonoBehaviour
{
    private void OnCollisionEnter(Collision other)
    {
        if (other.transform.CompareTag("Trash"))
        {
            transform.GetComponent<Rigidbody>().isKinematic = false;
            transform.DOScale(Vector3.zero, 0.6f).OnComplete(()=>
            {
                gameObject.SetActive(false);
            });
        }
    }
}
