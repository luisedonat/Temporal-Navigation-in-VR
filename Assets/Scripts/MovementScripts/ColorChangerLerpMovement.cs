using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorChangerLerpMovement : MonoBehaviour
{
    public Color[] colors; // Array to store the colors over time
    private Renderer ballRenderer;
    private Color startColor;
    private Color targetColor;
    private float lerpDuration = 3.0f; // Duration of the lerp animation
    private float lerpStartTime;

    void Start()
    {
        ballRenderer = GetComponent<Renderer>();
    }

    public void SetColor(float t)
    {
        // calculate current color index based on time t: which color should be displayed?
        int index = Mathf.FloorToInt(t * (colors.Length - 1));
        ballRenderer.material.color = colors[index];
    }

    public void SetupColors(Color[] colorSequence)
    {
        colors = colorSequence;
        startColor = colors[0];
        targetColor = colors[0];
    }

    public void StartLerp(Color newTargetColor)
    {
        startColor = ballRenderer.material.color;
        targetColor = newTargetColor;
        lerpStartTime = Time.time;
    }

    void Update()
    {
        if (startColor != targetColor)
        {
            float t = (Time.time - lerpStartTime) / lerpDuration;
            ballRenderer.material.color = Color.Lerp(startColor, targetColor, t);

            if (t >= 1.0f)
            {
                startColor = targetColor;
            }
        }
    }
}