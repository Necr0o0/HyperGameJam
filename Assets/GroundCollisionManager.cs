using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;

public class GroundCollisionManager : MonoBehaviour
{
   private float timer;
   private float value= 0.0f;
   private Material _material;
   private Renderer _renderer;
   private bool start = false;
   private MaterialPropertyBlock _materialPropertyBlock;
   private void Update()
   {
      
   }

   private void OnCollisionEnter(Collision other)
   {
      var decal = SpawnerManager.Manager.GetComponent<ObjectPool>().GetSplashObject();
      decal.GetComponent<SplashManager>().TriggerAnimation(other.transform);
      

   }
}
