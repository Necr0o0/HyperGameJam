using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class SplashManager : MonoBehaviour
{
   private void OnCollisionEnter(Collision other)
   {
      other.gameObject.SetActive(false);
      var decal = SpawnerManager.Manager.GetComponent<ObjectPool>().GetSplashObject();

      decal.GetComponent<Renderer>().material.color = other.transform.GetComponent<Renderer>().material.color;
      decal.transform.position = other.transform.position;

   }
}
