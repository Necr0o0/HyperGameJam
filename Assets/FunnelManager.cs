using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using TMPro;
using UnityEngine;

public class FunnelManager : MonoBehaviour
{
    public Renderer Funnel;
    public TextMeshPro ballsText;
    private float originalSize;
    public float counterInsideBox;
    // Start is called before the first frame update
    void Start()
    {
        originalSize = ballsText.fontSize;
        ballsText.text = "0";

    }

    // Update is called once per frame
    public void ChangeColor(Color color)
    {
        counterInsideBox++;
        ballsText.text = counterInsideBox.ToString();
        var sequence = DOTween.Sequence();
        sequence.Append(DOTween.To(() => ballsText.fontSize, x => ballsText.fontSize = x, ballsText.fontSize + 1.5f, 0.1f));
        sequence.Join(DOTween.To(() => ballsText.fontSize, x => ballsText.fontSize = x, originalSize, 1f));
        
        Funnel.material.color = Color.Lerp(   Funnel.material.color, new Color(color.r,color.g,color.b,0), counterInsideBox / 2000f);
    }
}
