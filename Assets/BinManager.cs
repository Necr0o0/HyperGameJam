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
    private float orginalSize;
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
        orginalSize = ballsText.fontSize;

    }

    // Update is called once per frame
    public void ChangeColor(Color color)
    {
            counterInsideBox++;
            ballsText.text = counterInsideBox.ToString();
            var sequence = DOTween.Sequence();
            sequence.Append(DOTween.To(() => ballsText.fontSize, x => ballsText.fontSize = x, ballsText.fontSize + 7f, 0.1f));
            sequence.Join(DOTween.To(() => ballsText.fontSize, x => ballsText.fontSize = x, orginalSize, 0.8f));

            
            for (int i = 0; i < BinWalls.Count; i++)
            {
                BinWalls[i].material.color = Color.Lerp(BinWalls[i].material.color, new Color(color.r,color.g,color.b,  BinWalls[i].material.color.a), counterInsideBox / 2000f);
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
