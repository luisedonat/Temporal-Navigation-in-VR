using UnityEngine;
using UnityEngine.UI;

public class TimeControllerSlider : MonoBehaviour
{
    public Slider timeSlider;
    public ColorChanger ball1;
    public ColorChanger ball2;
    public ColorChanger ball3;
    public ColorChanger ball4;
    public ColorChanger ball5;

    void Start()
    {
        timeSlider.minValue = 0;
        timeSlider.maxValue = 1; // Normalize slider value between 0 and 1
        timeSlider.onValueChanged.AddListener(OnSliderValueChanged);
    }

    void OnSliderValueChanged(float value)
    {
        /**ball1.SetColor(value);
        ball2.SetColor(value);
        ball3.SetColor(value);
        ball4.SetColor(value);
        ball5.SetColor(value);*/

    }
}