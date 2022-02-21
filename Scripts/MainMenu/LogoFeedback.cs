using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LogoFeedback : MonoBehaviour
{
    public Image image;
    public float lerpTime = 3;

    public Color baseColor = Color.white, newColor;

    public Vector3 scaleOffset;

    Vector3 baseScale;

    private void Start()
    {
        baseScale = transform.localScale;
        StartCoroutine(LogoLerp(baseColor, newColor, true));
    }

    private IEnumerator LogoLerp(Color startColor, Color endColor, bool addScaleOffset)
    {
        float currentTime = 0;
        while(currentTime < lerpTime)
        {
            currentTime += Time.deltaTime;
            float step = Mathf.Clamp01(currentTime / lerpTime);
            transform.localScale = 
                Vector3.Lerp(
                    baseScale, 
                    baseScale + scaleOffset, 
                    addScaleOffset ? step : 1- step
                    );

            image.color = Color.Lerp(startColor, endColor, step);
            yield return null;
        }
        StartCoroutine(LogoLerp(endColor, startColor, !addScaleOffset));
    }
}
