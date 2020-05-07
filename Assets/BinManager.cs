using System;
using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using Debug = System.Diagnostics.Debug;

public class BinManager : MonoBehaviour
{
    public List<Renderer> BinWalls;
    public ParticleSystem ParticleSystem;
    public TextMeshPro ballsText;
    private Color defaultColor;
    private Material _material;
    private bool usedParticle = false;

    public float counterInsideBox;
    // Start is called before the first frame update
    void Start()
    {
        defaultColor = BinWalls[0].material.color;
        _material = new Material(BinWalls[0].material);
        ballsText.text = "0";

    }

    // Update is called once per frame
    public void ChangeColor()
    {
            counterInsideBox++;
            ballsText.text = counterInsideBox.ToString();
            var seqence = DOTween.Sequence();
            Vector3 scale = ballsText.transform.localScale;
            //seqence.Append(ballsText.transform.DOScale(scale*1.1f, 0.1f));
            //seqence.Append(ballsText.transform.DOScale(1, 0.1f));

            
            for (int i = 0; i < BinWalls.Count; i++)
            {
                BinWalls[i].material.color = _material.color + new Color(0,1,0,0) * counterInsideBox * 0.005f;
            }

            if (counterInsideBox > 10 && !usedParticle)
            {
                if (GameManager.gameManager.currentBox == 0)
                {
                    usedParticle = true;
                    return;
                }
                ParticleSystem.Play();
                usedParticle = true;
            }
        
    }
}
