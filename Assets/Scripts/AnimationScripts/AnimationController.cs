using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class AnimationController : MonoBehaviour
{
    public Slider timeSlider;
    public Button confirmButton;
    public TextMeshProUGUI resultText; // Use TextMeshProUGUI for the result text
    public float animationDuration = 10.0f; // Total duration of the animation
    public float specialMomentDuration = 1.0f; // Duration of the special moment
    private float specialMomentStart;
    private float specialMomentEnd;
    private List<ColorChanger> colorChangers;
    private float startTime;
    //private bool conditionMet = false;
    /*
    void Start()
    {
        // Initialize color changers
        colorChangers = new List<ColorChanger>(GameObject.FindObjectsOfType<ColorChanger>());

        // Initialize slider
        timeSlider.minValue = 0;
        timeSlider.maxValue = 1; // Normalized between 0 and 1
        timeSlider.onValueChanged.AddListener(OnSliderValueChanged);

        // Initialize button
        confirmButton.onClick.AddListener(OnConfirmButtonClicked);

        // Calculate special moment times
        specialMomentStart = 0.5f * animationDuration; // For example, halfway through the duration
        specialMomentEnd = specialMomentStart + specialMomentDuration;

        // Start timing
        startTime = Time.time;
    }
    
    void OnSliderValueChanged(float value)
    {
        float currentTime = value * animationDuration;
        foreach (var changer in colorChangers)
        {
            changer.SetColorAtTime(currentTime, animationDuration, specialMomentStart, specialMomentEnd);
        }
    }

    void OnConfirmButtonClicked()
    {
        // Check if the condition is met
        int redCount = 0;
        foreach (var changer in colorChangers)
        {
            if (changer.GetColor() == changer.specialColor)
            {
                redCount++;
            }
        }
        if (redCount == 5)
        {
            conditionMet = true;
            float elapsedTime = Time.time - startTime;
            resultText.text = $"Correct! Time taken: {elapsedTime:F2} seconds";
        }
        else
        {
            resultText.text = "Incorrect! Try again.";
        }
    }
    */
}
