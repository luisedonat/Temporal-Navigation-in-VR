using UnityEngine;

public class ColorChanger : MonoBehaviour
{
    public Color[] colors; // Array to store the colors over time
    private Renderer ballRenderer;

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
    }

   
}