using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class FadeCanvas : MonoBehaviour
{
    [SerializeField]
    private Image panelImg;

    [SerializeField]
    private float duration;

    [SerializeField]
    private TextMeshProUGUI txt; 

    private Color initcolor;

    private Color endColor;

    private float elapsedTime = 0.0f;

    private float initTime = 0.0f;

    void Start()
    {
        initcolor = panelImg.color;
        endColor = new Color(255.0f, 255.0f, 255.0f, 255.0f);
        initTime = Time.realtimeSinceStartup;
        //FadePanel();
        //StartCoroutine(FadePanel());
    }

    private void Update()
    {
        elapsedTime += Time.deltaTime;
        float t = Mathf.Clamp01(elapsedTime / duration);
        Color lerpColor = Color.Lerp(initcolor, endColor, t);
        panelImg.color = lerpColor;
        txt.text = lerpColor.a.ToString();
        //panelImg.color = lerpColor;
        // (int)lerpColor.a
        //if (elapsedTime >= duration)
        //{
        //    colorFinal = true;
        //}
    }



    private IEnumerator FadePanel()
    {
        bool colorFinal = false;
        do
        {
            elapsedTime += Time.deltaTime;
            float t = Mathf.Clamp01(elapsedTime / duration);
            Color lerpColor = Color.Lerp(initcolor, endColor, t);
            panelImg.color = lerpColor;
            // (int)lerpColor.a
            if (elapsedTime >= duration) 
            {
                colorFinal = true;
            }
        }
        while (!colorFinal);
        yield return null;
        elapsedTime = 0.0f;
    }
}
