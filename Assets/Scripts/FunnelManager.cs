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
    private Vector3 scale;
    public float counterInsideBox;
    // Start is called before the first frame update
    void Start()
    {
        originalSize = ballsText.fontSize;
        ballsText.text = "0";
        scale = transform.localScale;


    }

    // Update is called once per frame
    public void ChangeColor(Color color)
    {
        counterInsideBox++;
        ballsText.text = counterInsideBox.ToString();
        var sequence = DOTween.Sequence();
        sequence.Append(DOTween.To(() => ballsText.fontSize, x => ballsText.fontSize = x, ballsText.fontSize + 1.5f, 0.1f));
        sequence.Join(DOTween.To(() => ballsText.fontSize, x => ballsText.fontSize = x, originalSize, 1f));
        
        var sequence2 = DOTween.Sequence();
        sequence2.Append(transform.DOScaleY(5.4f,0.5f));
        sequence2.Join(transform.DOScaleY(scale.y,2f));

        
        Funnel.material.color = Color.Lerp(   Funnel.material.color, new Color(color.r,color.g,color.b,0), counterInsideBox / 2000f);
    }
}
