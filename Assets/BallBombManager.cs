using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BallBombManager : MonoBehaviour
{
    private List<Transform> balls;
    private Vector3 scale;
    private float seed;

    [SerializeField] private float amplitude = 0.25f;
    [SerializeField] private float period = 5f;
    private void Awake()
    {
        scale = transform.localScale;
        seed = Random.Range(0f, 2137f);
    }

    private void LateUpdate()
    {
        transform.localScale = scale + new Vector3(Mathf.Sin(Time.time * period +seed)*amplitude ,Mathf.Sin(Time.time* period+seed)*amplitude ,Mathf.Sin(Time.time* period+seed)*amplitude);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.transform.CompareTag("Trash"))
        {
            for (int i = 0; i < 25; i++)
            {
                var x = ObjectPool.Instance.GetBallObject();
                x.position = transform.position;
                x.position += new Vector3(Random.Range(-0.5f, 0.5f), Random.Range(-0.5f, 0.5f),
                    Random.Range(-0.5f, 0.5f));
               // x.GetComponent<Rigidbody>().AddForce(Vector3.up *500.0f);
            }
            gameObject.SetActive(false);
        }
       
    }
}
