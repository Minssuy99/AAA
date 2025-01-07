using System;
using UnityEngine;

public class ButtonTiltEffect : MonoBehaviour
{
    private RectTransform rectTransform;

    void Awake()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    void Update()
    {
        Vector2 mousePos = Input.mousePosition;

        if (RectTransformUtility.RectangleContainsScreenPoint(rectTransform, mousePos, Camera.main))
        {
            TiltEffect(mousePos);
        }
    }

    void TiltEffect(Vector2 mousePos)
    {
        
    }

}