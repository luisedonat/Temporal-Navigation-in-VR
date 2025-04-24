using System.Collections;
using System.Collections.Generic;
using System.IO;
using System; 
using TMPro;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.SceneManagement;
using UnityEngine.InputSystem;
using System.Text;

public class PlayerMovementFewChoices : MonoBehaviour
{
    public Transform player;
    public Transform controllerLeft; 
    public Transform controllerRight;
    public ColorChanger[] balls;
    public float movementThreshold = 0.2f;  // Distance to trigger color change
    public float lingerDuration = 1.0f;     // Time to linger to trigger change
    // How much room in between where you can move without moving time?
    public float middlePartLeft = -0.1f;
    public float middlePartRight = 0.1f;
    public AudioSource ding;
    public AudioSource change;
    public GameObject questionnaire;
    public GameObject handMenu;
    public int sceneNumber;

    private Vector3 startingPoint = new Vector3(-0.0199999996f, 1, 7.15999985f);
    private float lingerTime;
    private ColorSequences colorSequences;
    private int currentSequenceIndex;
    private float startTime;
    private bool isTiming = false;
    private bool isLingering = false;
    private bool canChangeColor = true;
    private bool movingRight = true;
    private bool confirmButtonPressed = false;
    private int currentColorSequencesIndex;
    private int sequenceCounter = 0;

    // Trigger for Continue
    public ActionBasedController rightController;
    // Input System
    private InputAction confirmAction;

    // CSV
    private string participantName;
    private int colorSequenceOrderIndex;
    private string condition = "MovementFewChoices";
    // CSV Data
    private List<ActionLogEntry> actionLogEntries = new List<ActionLogEntry>();
    private List<KeyFrame> positionKeyFrames = new List<KeyFrame>();

    private void Start()
    {
        
        // StartPoint: 
        colorSequences = FindObjectOfType<ColorSequences>();
        participantName = ParticipantManager.Instance.participantName;
        colorSequenceOrderIndex = ParticipantManager.Instance.colorSequenceOrder;

        if (colorSequences != null)
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

        // what is the player distance from the starting point?
        float distanceFromStart = Vector3.Distance(player.position, startingPoint);

        if (player.position.x > 0)
        {
            movingRight = true; 
        }
        else if (player.position.x < 0)
        {
            movingRight = false;
        }

        bool isInMiddleRange = player.position.x >= middlePartLeft && player.position.x <= middlePartRight;

        // If the player has moved beyond the threshold
        if (distanceFromStart > movementThreshold && !isInMiddleRange)
        {
            // If not already lingering, start lingering time
            if (!isLingering)
            {
                lingerTime = Time.time;
                isLingering = true;
            }

            // Check if player has lingered for the required duration
            if (isLingering && Time.time - lingerTime > lingerDuration && canChangeColor)
            {
                if (movingRight)
                {
                    // forward color sequence
                    if (currentSequenceIndex < colorSequences.colorSequences[currentColorSequencesIndex].Length - 1)
                    {
                        currentSequenceIndex++;
                    }
                    // stop changing colors at end of sequence array    
                    else
                    {
                        //canChangeColor = false;
                    }
                }
                else
                {
                    // backward color sequence
                    if (currentSequenceIndex > 0)
                    {
                        currentSequenceIndex--;
                    }
                    // stop changing colors at start of sequence array  
                    else
                    {
                        //canChangeColor = false; 
                    }
                }

                ChangeBallColors(currentSequenceIndex);

                // reset time              
                lingerTime = Time.time;
                Debug.Log("Player moved, changing ball colors");
            }
        }
        else
        {
            // reset if player moves back to starting point
            isLingering = false;
            if (!canChangeColor)
            {
                // currentSequenceIndex = 4;
                canChangeColor = true;
                // ChangeBallColors(currentSequenceIndex);
            }
        }

        LogPositionAndOrientation();

    }

    void ChangeBallColors(int sequenceIndex)
    {
        Debug.Log("Step moved, changing ball colors to sequence: " + sequenceIndex);

        // Change ball colors to next in sequence
        if (sequenceIndex >= 0 && sequenceIndex < colorSequences.colorSequences[currentColorSequencesIndex].Length)
        {
            // currentSequenceIndex = sequenceIndex; //Update current index

            if (balls.Length == colorSequences.colorSequences[sequenceIndex].Length)
            {
                for (int i = 0; i < balls.Length; i++)
                {
                    Color[] singleColorSequence = new Color[1] { colorSequences.colorSequences[currentColorSequencesIndex][sequenceIndex][i] };
                    balls[i].SetupColors(singleColorSequence);
                    balls[i].SetColor(0); // Set initial color
                    //Debug.Log($"Ball {balls[i].gameObject.name} color set to: {colorSequences.colorSequences[sequenceIndex][i]}");
                    change.Play();
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

    void OnConfirmButtonClicked()
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

    string GetCurrentColors()
    {
        List<string> colorList = new List<string>();
        foreach (Color color in colorSequences.colorSequences[currentColorSequencesIndex][currentSequenceIndex])
        {
            colorList.Add(ColorUtility.ToHtmlStringRGBA(color));
        }
        return string.Join(";", colorList);
    }

    void OnPlayAgainButtonClicked()
    {
        if (confirmButtonPressed && sequenceCounter < 3)
        {
            
            InitializeColorSequenceForScene();
        }
        else return;
        startTime = Time.time;
    }


    bool CheckCorrectTime()
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
        
        player.position = startingPoint;
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
