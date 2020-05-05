using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SplashManager : MonoBehaviour
{
   public GameObject splash;
   private void OnCollisionEnter(Collision other)
   {
      other.gameObject.SetActive(false);
      var decal = Instantiate(splash);
      decal.GetComponent<Renderer>().material.color = other.transform.GetComponent<Renderer>().material.color;
      decal.transform.position = other.transform.position;
   }
}
