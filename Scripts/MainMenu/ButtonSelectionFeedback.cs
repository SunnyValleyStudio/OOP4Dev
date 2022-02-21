using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class ButtonSelectionFeedback : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    public Button button;

    public float delay = 0.5f;
    public Vector3 scaleOffset;

    Vector3 baseScale;

    private void Start()
    {
        baseScale = transform.localScale;
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(Scale(transform.localScale, baseScale + scaleOffset, delay));
    }

    private IEnumerator Scale(Vector3 start, Vector3 end, float delay)
    {
        float currentTIme = 0;
        while(currentTIme < delay)
        {
            currentTIme += Time.deltaTime;
            float step = Mathf.Clamp01(currentTIme / delay);
            transform.localScale = Vector3.Lerp(start, end, step);
            yield return null;
        }
        transform.localScale = end;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        StopAllCoroutines();
        StartCoroutine(Scale(transform.localScale, baseScale, delay));
    }
}
