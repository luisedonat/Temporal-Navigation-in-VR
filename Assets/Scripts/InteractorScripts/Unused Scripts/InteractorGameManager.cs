using System.Collections;
using System.Collections.Generic;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;

public class InteractorGameManager : MonoBehaviour
{
    public GameObject[] balls; // Array to store references to the BallColorChanger scripts
    public Button confirmButton;
    public TextMeshProUGUI resultText;
    private ColorSequences colorSequences;
    private float startTime;
    private bool isTiming = false;
    private int currentSequenceIndex = -1;


    void Start()
    {
        colorSequences = FindObjectOfType<ColorSequences>();
        startTime = Time.time;
        confirmButton.onClick.AddListener(OnConfirmButtonClicked);      
    }

    public void SetBallColors(int index)
    {
        if (index >= 0 && index < colorSequences.colorSequences.Length)
        {
            currentSequenceIndex = index;
            for (int i = 0; i < balls.Length; i++)
            {
                balls[i].GetComponent<Renderer>().material.color = colorSequences.colorSequences[currentSequenceIndex][index][i];
            }
        }
        if (!isTiming)
        {
            startTime = Time.time;
            isTiming = true;
        }
    }

    bool CheckFourRedBalls()
    {
        int redCount = 0;
        foreach (Color color in colorSequences.colorSequences[currentSequenceIndex][currentSequenceIndex])
        {
            if (color == Color.red)
            {
                redCount++;
            }
        }
        return redCount == 4;
    }

    void OnConfirmButtonClicked()
    {
        float elapsedTime = Time.time - startTime;
        bool isCorrectTime = CheckFourRedBalls();

        if (isCorrectTime)
        {
            resultText.text = $"Correct! Time taken: " + elapsedTime + " seconds";
            resultText.color = Color.green;
        }
        else
        {
            resultText.text = "Incorrect! Try again.";
            resultText.color = Color.red;
        }
        Debug.Log("Time taken: " + elapsedTime + " seconds");
    }

}
