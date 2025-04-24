using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangerInteractor : MonoBehaviour
{
    public Renderer ballRenderer;

    void Start()
    {
        if (ballRenderer == null)
        {
            ballRenderer = GetComponent<Renderer>();
        }
    }

    public void SetColor(Color color)
    {
        ballRenderer.material.color = color;
    }
}
