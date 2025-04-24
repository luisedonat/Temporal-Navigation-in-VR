using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;
using TMPro;

public class RandomBallColorManager : MonoBehaviour
{
    public Color[] randomColors = { Color.red, Color.yellow, Color.green, Color.blue, Color.cyan, Color.magenta, Color.grey, Color.black, Color.white, new Color(1f, 0.65f, 0f), new Color(0.5f, 0f, 0.5f) };
    public GameObject[] balls;
    public Button randomizeButton;
    public Button confirmButton;
    public TextMeshProUGUI timerText;

    private float startTime;
    private bool isTiming = false;

    void Start()
    {
        randomizeButton.onClick.AddListener(RandomizeColors);
        confirmButton.onClick.AddListener(CheckFourRedBalls);
        RandomizeColors();
        StartTimer();
    }

    void RandomizeColors()
    {
        foreach (GameObject ball in balls)
        {
            Color randomColor = randomColors[Random.Range(0, randomColors.Length)];
            ball.GetComponent<Renderer>().material.color = randomColor;
        }
    }

    void CheckFourRedBalls()
    {
        int redCount = 0;
        foreach (GameObject ball in balls)
        {
            if (ball.GetComponent<Renderer>().material.color == Color.red)
            {
                redCount++;
            }
        }

        if (redCount == 4)
        {
            StopTimer();
        }
        else
        {
            Debug.Log("There are not exactly four red balls. Try again!");
        }
    }

    void StartTimer()
    {
        startTime = Time.time;
        isTiming = true;
    }

    void StopTimer()
    {
        isTiming = false;
        float elapsedTime = Time.time - startTime;
        timerText.text = "Time: " + elapsedTime.ToString("F2") + " seconds";
        Debug.Log("Task completed in " + elapsedTime.ToString("F2") + " seconds.");
    }

    void Update()
    {
        if (isTiming)
        {
            float currentTime = Time.time - startTime;
            timerText.text = "Time: " + currentTime.ToString("F2") + " seconds";
        }
    }
}
