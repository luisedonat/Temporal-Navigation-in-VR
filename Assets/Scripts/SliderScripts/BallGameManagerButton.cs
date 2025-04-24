using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System; 
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;
using UnityEngine.XR.Interaction.Toolkit;
using static UnityEngine.Rendering.DebugUI;

public class BallGameManagerButton : MonoBehaviour
{
    public Transform player;
    public Transform controllerLeft; 
    public Transform controllerRight;
    public ColorChanger[] balls; // Array to store references to the BallColorChanger scripts
    public UnityEngine.UI.Button randomColorButton;
    public AudioSource ding;
    public AudioSource randomButton;
    public int sceneNumber;

    private ColorSequences colorSequences;
    private int currentSequenceIndex;
    private float startTime;
    private bool isTiming = false;
    private bool confirmButtonPressed = false;
    private int currentColorSequencesIndex;
    private int sequenceCounter = 0;
    public GameObject questionnaire;
    public GameObject handMenu;

    // Trigger for Continue
    public ActionBasedController rightController;

    // Input System
    private InputAction confirmAction;

    // CSV
    private string participantName;
    private int colorSequenceOrderIndex;
    private string condition = "SliderNoChoices";
    // CSV Data
    private List<ActionLogEntry> actionLogEntries = new List<ActionLogEntry>();
    private List<KeyFrame> positionKeyFrames = new List<KeyFrame>();

    void Start()
    {
        colorSequences = FindObjectOfType<ColorSequences>();
        participantName = ParticipantManager.Instance.participantName;
        colorSequenceOrderIndex = ParticipantManager.Instance.colorSequenceOrder;
        randomColorButton.onClick.AddListener(OnRandomizeButtonClicked);

        if (colorSequences == null)
        {
            Debug.LogError("Color Sequences not found in Scene!");
        }
        if (rightController == null)
        {
            Debug.LogError("Right controller not assigned!");
        }

        // Initialize the current color sequence based on scene number
        InitializeColorSequenceForScene();
        
    }

    private void OnDestroy()
    {
        SaveToFile();

        // Dispose InputAction
        confirmAction.Disable();
        confirmAction.Dispose();
    }

    private void LogPositionAndOrientation()
    {
        Vector3 position = player.position;
        Quaternion orientation = player.rotation;
        Vector3 controllerLeftPosition = controllerLeft.position;
        Vector3 controllerRightPosition = controllerRight.position;
        Quaternion controllerLeftOrientation = controllerLeft.rotation;
        Quaternion controllerRightOrientation = controllerRight.rotation;

        // Save as KeyFrame for position log
        positionKeyFrames.Add(new KeyFrame(
            DateTimeOffset.Now.ToUnixTimeMilliseconds() / 1000, position.x, position.y, position.z, orientation.x, orientation.y, orientation.z, orientation.w, 
            controllerLeftPosition.x, controllerLeftPosition.y, controllerLeftPosition.z, controllerLeftOrientation.x, controllerLeftOrientation.y, controllerLeftOrientation.z, 
            controllerLeftOrientation.w, controllerRightPosition.x, controllerRightPosition.y, controllerRightPosition.z, controllerRightOrientation.x, controllerRightOrientation.y, 
            controllerRightOrientation.z, controllerRightOrientation.w
            )); 
    }

    private void Update()
    {
        if (rightController != null)
        {
            // Debug.Log("Checking trigger button press.");
            if (rightController.activateAction.action.triggered) // Check if the trigger is pressed
            {
                Debug.Log("Trigger button pressed.");
                OnConfirmButtonClicked();
            }
        }
        else
        {
            Debug.LogError("Right controller is null in Update!");
        }

        LogPositionAndOrientation();
    }

    private void OnRandomizeButtonClicked()
    {
        // Generate a random sequence index within the valid range
        currentSequenceIndex = UnityEngine.Random.Range(0, colorSequences.colorSequences[currentColorSequencesIndex].Length);

        Debug.Log($"Random button pressed, changing to sequence index: {currentSequenceIndex}");

        randomButton.Play();
        ChangeBallColors(currentSequenceIndex);

        if (!isTiming)
        {
            startTime = Time.time;
            isTiming = true;
        }
    }

    private void ChangeBallColors(int sequenceIndex)
    {
        Debug.Log("Changing ball colors to sequence: " + sequenceIndex);
        if (sequenceIndex >= 0 && sequenceIndex < colorSequences.colorSequences[currentColorSequencesIndex].Length)
        {
            if (balls.Length == colorSequences.colorSequences[sequenceIndex].Length)
            {
                for (int i = 0; i < balls.Length; i++)
                {
                    Color[] singleColorSequence = new Color[1] { colorSequences.colorSequences[currentColorSequencesIndex][sequenceIndex][i] };
                    balls[i].SetupColors(singleColorSequence);
                    balls[i].SetColor(0); // Directly set the color at index 0
                    //Debug.Log($"Ball {balls[i].gameObject.name} color set to: {colorSequences.colorSequences[sequenceIndex][i]}");
                }
            }
            else
            {
                Debug.LogError("Number of balls does not match the length of the color sequence!");
            }
        }
        else
        {
            Debug.LogError($"Invalid sequence index: {sequenceIndex}");
        }

        if (!isTiming)
        {
            startTime = Time.time;
            isTiming = true;
        }
    }

    private void OnConfirmButtonClicked()
    {
        ding.Play();
        float elapsedTime = Time.time - startTime;
        bool isCorrectTime = CheckCorrectTime();
        string colors = GetCurrentColors();

        Debug.Log("Time taken: " + elapsedTime + " seconds");
        confirmButtonPressed = true;
        sequenceCounter++;

        actionLogEntries.Add(new ActionLogEntry(DateTimeOffset.Now.ToUnixTimeMilliseconds() / 1000, participantName, condition, isCorrectTime, currentColorSequencesIndex, elapsedTime, colors));

        ResetBallColors();
        
        OnPlayAgainButtonClicked();
        

        if (sequenceCounter >= 3)
        {
            handMenu.SetActive(false);
            questionnaire.SetActive(true);
        }

    }

    public void ResetBallColors() {
        foreach (var ball in balls)
        {
            ball.SetupColors(new Color[] { Color.white });
            ball.SetColor(0); // Set initial color to white
        }
    }

    private string GetCurrentColors()
    {
        List<string> colorList = new List<string>();
        foreach (Color color in colorSequences.colorSequences[currentColorSequencesIndex][currentSequenceIndex])
        {
            colorList.Add(ColorUtility.ToHtmlStringRGBA(color));
        }
        return string.Join(";", colorList);
    }

    private void OnPlayAgainButtonClicked()
    {
        if (confirmButtonPressed && sequenceCounter < 3)
        {
            
            InitializeColorSequenceForScene();
        }
        else return; 
        startTime = Time.time;
    }

    private bool CheckCorrectTime()
    {
        if (currentSequenceIndex == -1) return false;

        int redCount = 0;
        foreach (Color color in colorSequences.colorSequences[currentColorSequencesIndex][currentSequenceIndex])
        {
            if (color == Color.red)
            {
                redCount++;
            }
        }
        return redCount == 4;
    }

    private void InitializeColorSequenceForScene()
    {
        int colorSequenceOrderIndex = ParticipantManager.Instance.colorSequenceOrder;
        int startIndex = (sceneNumber % 9) * 3;

        var colorSequenceOrder = colorSequences.colorSequenceOrders[colorSequenceOrderIndex];
        
        currentColorSequencesIndex = colorSequenceOrder[startIndex];
        if (sequenceCounter == 1)
        {
            currentColorSequencesIndex = colorSequenceOrder[startIndex + 1];
        }
        else if (sequenceCounter == 2)
        {
            currentColorSequencesIndex = colorSequenceOrder[startIndex + 2];
        }

        // Log the name of the sequence
        Debug.Log($"Initializing color sequences for scene. Order index: {colorSequenceOrderIndex}, Scene index: {sceneNumber}, Initial index of the Order Array: {startIndex}, " +
            $"Initial Sequence Index: {currentColorSequencesIndex}, Initial Sequence: colorSequences[{currentColorSequencesIndex}]");

        ChangeBallColors(currentColorSequencesIndex);

    }

    private void SaveToFile()
    {
        // Save action log CSV
        string[] actionConditionNames = { "TotalTime", "ParticipantName", "Condition", "CorrectMoment", "ColorSequenceIndex", "ElapsedTime", "BallColors" };
        var actionLogContent = ToCSV(actionLogEntries, string.Join(";", actionConditionNames));
        SaveToFile($"actionLog_{participantName}_{condition}.csv", actionLogContent);

        // Save position log CSV
        string[] positionConditionNames = {"Time","PositionX","PositionY","PositionZ","OrientationX","OrientationY","OrientationZ","OrientationW" +
            "LeftControllerPosX","LeftControllerPosY","LeftControllerPosZ","LeftControllerOrX","LeftControllerOrY","LeftControllerOrZ","LeftControllerOrW" +
            "RightControllerPosX","RightControllerPosY","RightControllerPosZ","RightControllerOrX","RightControllerOrY","RightControllerOrZ","RightControllerOrW"};
        var positionLogContent = ToCSVPos(positionKeyFrames, string.Join(";", positionConditionNames));
        SaveToFile($"positionLog_{participantName}_{condition}.csv", positionLogContent);
    }

    private string ToCSV(List<ActionLogEntry> entries, string header)
    {
        var sb = new StringBuilder(header);
        foreach (var entry in entries)
        {
            sb.Append('\n')
              .Append(entry.TimeCSV).Append(';')
              .Append(entry.ParticipantNameCSV).Append(';')
              .Append(entry.ConditionCSV).Append(';')
              .Append(entry.IsCorrectTimeCSV).Append(';')
              .Append(entry.CurrentSequenceIndexCSV).Append(';')
              .Append(entry.ElapsedTimeCSV).Append(';')
              .Append(entry.ColorsCSV);
        }

        return sb.ToString();
    }

    private string ToCSVPos(List<KeyFrame> keyFrames, string header)
    {
        var sb = new StringBuilder(header);
        foreach (var keyFrame in keyFrames)
        {
            sb.Append('\n')
              .Append(keyFrame.Time).Append(';')
              .Append(keyFrame.PositionX).Append(';')
              .Append(keyFrame.PositionY).Append(';')
              .Append(keyFrame.PositionZ).Append(';')
              .Append(keyFrame.OrientationX).Append(';')
              .Append(keyFrame.OrientationY).Append(';')
              .Append(keyFrame.OrientationZ).Append(';')
              .Append(keyFrame.OrientationW).Append(';')
              .Append(keyFrame.PositionXControllerLeft).Append(';')
              .Append(keyFrame.PositionYControllerLeft).Append(';')
              .Append(keyFrame.PositionZControllerLeft).Append(';')
              .Append(keyFrame.OrientationXControllerLeft).Append(';')
              .Append(keyFrame.OrientationYControllerLeft).Append(';')
              .Append(keyFrame.OrientationZControllerLeft).Append(';')
              .Append(keyFrame.OrientationWControllerLeft).Append(';')
              .Append(keyFrame.PositionXControllerRight).Append(';')
              .Append(keyFrame.PositionYControllerRight).Append(';')
              .Append(keyFrame.PositionZControllerRight).Append(';')
              .Append(keyFrame.OrientationXControllerRight).Append(';')
              .Append(keyFrame.OrientationYControllerRight).Append(';')
              .Append(keyFrame.OrientationZControllerRight).Append(';')
              .Append(keyFrame.OrientationWControllerRight);
        }

        return sb.ToString();
    }

    private void SaveToFile(string fileName, string content)
    {
        var folder = Application.persistentDataPath;
        var filePath = Path.Combine(folder, fileName);

        File.WriteAllText(filePath, content);

        Debug.Log($"CSV file written to \"{filePath}\"");
    }
}
