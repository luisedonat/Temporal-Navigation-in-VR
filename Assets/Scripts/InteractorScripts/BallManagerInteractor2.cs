using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.UIElements;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

[Serializable]
public class KeyFrame
{
    public long Time;
    public float PositionX;
    public float PositionY;
    public float PositionZ;
    public float OrientationX;
    public float OrientationY;
    public float OrientationZ;
    public float OrientationW;
    public float PositionXControllerLeft;
    public float PositionYControllerLeft;
    public float PositionZControllerLeft;
    public float OrientationXControllerLeft;
    public float OrientationYControllerLeft;
    public float OrientationZControllerLeft;
    public float OrientationWControllerLeft;
    public float PositionXControllerRight;
    public float PositionYControllerRight;
    public float PositionZControllerRight;
    public float OrientationXControllerRight;
    public float OrientationYControllerRight;
    public float OrientationZControllerRight;
    public float OrientationWControllerRight;

    public KeyFrame(long time, float positionX, float positionY, float positionZ, float orientationX, float orientationY, float orientationZ, float orientationW, 
    float positionXControllerLeft, float positionYControllerLeft, float positionZControllerLeft, float orientationXControllerLeft, float orientationYControllerLeft, 
    float orientationZControllerLeft, float orientationWControllerLeft, float positionXControllerRight, float positionYControllerRight, float positionZControllerRight, 
    float orientationXControllerRight, float orientationYControllerRight, float orientationZControllerRight, float orientationWControllerRight)
    {
        Time = time;
        PositionX = positionX;
        PositionY = positionY;
        PositionZ = positionZ;
        OrientationX = orientationX;
        OrientationY = orientationY;
        OrientationZ = orientationZ;
        OrientationW = orientationW;   
        PositionXControllerLeft = positionXControllerLeft;
        PositionYControllerLeft = positionYControllerLeft; 
        PositionZControllerLeft = positionZControllerLeft;
        OrientationXControllerLeft = orientationXControllerLeft;
        OrientationYControllerLeft = orientationYControllerLeft;
        OrientationZControllerLeft = orientationZControllerLeft;
        OrientationWControllerLeft = orientationWControllerLeft;
        PositionXControllerRight = positionXControllerRight;
        PositionYControllerRight = positionYControllerRight;
        PositionZControllerRight = positionZControllerRight;
        OrientationXControllerRight = orientationXControllerRight;
        OrientationYControllerRight = orientationYControllerRight;
        OrientationZControllerRight = orientationZControllerRight;
        OrientationWControllerRight = orientationWControllerRight; 
    }
}

[Serializable]
public class ActionLogEntry
{
    public long TimeCSV; 
    public String ParticipantNameCSV;
    public String ConditionCSV;
    public bool IsCorrectTimeCSV;
    public int CurrentSequenceIndexCSV;
    public float ElapsedTimeCSV;
    public string ColorsCSV; 

    public ActionLogEntry(long time, string participantName, string condition, bool isCorrectTime, int currentSequenceIndex, float elapsedTime, string colors)
    {
        TimeCSV = time;
        ParticipantNameCSV = participantName;
        ConditionCSV = condition;
        IsCorrectTimeCSV = isCorrectTime;
        CurrentSequenceIndexCSV = currentSequenceIndex;
        ElapsedTimeCSV = elapsedTime;
        ColorsCSV = colors;
    }
}

public class BallManagerInteractor2 : MonoBehaviour
{
    public Transform player;
    public Transform controllerLeft; 
    public Transform controllerRight;
    public ColorChanger[] balls;
    public AudioSource ding;
    public AudioSource change;
    public GameObject questionnaire;
    public GameObject handMenu;

    // Which participant, scene and
    public int sceneNumber;

    private float startTime;
    private bool isTiming = false;
    private ColorSequences colorSequences;
    private int currentSequenceIndex;
    private SpriteManager spriteManager;
    private bool confirmButtonPressed = false;
    private int currentColorSequencesIndex;
    private int sequenceCounter = 0;

    public ActionBasedController rightController;

    // Input System
    private InputAction confirmAction;

    private string participantName;
    private int colorSequenceOrderIndex;
    private string condition;

    // CSV Data
    private List<ActionLogEntry> actionLogEntries = new List<ActionLogEntry>();
    private List<KeyFrame> positionKeyFrames = new List<KeyFrame>();

    void Start()
    {
        colorSequences = FindObjectOfType<ColorSequences>();
        spriteManager = FindObjectOfType<SpriteManager>();
        participantName = ParticipantManager.Instance.participantName;
        colorSequenceOrderIndex = ParticipantManager.Instance.colorSequenceOrder;

        if (SceneManager.GetActiveScene().name == "Interactor_NoChoices")
        {
            condition = "InteractorNoChoices";
        }
        if (SceneManager.GetActiveScene().name == "Interactor_FewChoices")
        {
            condition = "InteractorFewChoices";
        }
        if (SceneManager.GetActiveScene().name == "Interactor_ManyChoices")
        {
            condition = "InteractorManyChoices";
        }

        if (colorSequences == null)
        {
            Debug.LogError("ColorSequences not found in the scene!");
        }

        if (spriteManager == null)
        {
            Debug.LogError("SpriteManager not found in the scene!");
        }

        if (rightController == null)
        {
            Debug.LogError("Right controller not assigned!");
        }

        // Initialize the balls to match the colors of the first x pictures
        InitializeColorSequenceForScene();
        InitializeBallsToPictureColors();

        // Ensure all pictures are initialized properly
        PictureManager.Instance.InitializePictures(0);

        //StartCoroutine(LogPositionData());
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

    void Update()
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

    public void OnPictureTouched(int sequenceIndex, GameObject touchedPicture)
    {
        // Ensure the correct sequence index is set for the touched picture
        if (touchedPicture != null)
        {
            ClickablePicture clickablePicture = touchedPicture.GetComponent<ClickablePicture>();
            if (clickablePicture != null)
            {
                clickablePicture.sequenceIndex = sequenceIndex;
            }
        }

        Debug.Log("Picture touched, changing ball colors to index: " + sequenceIndex);

        if (colorSequences != null && sequenceIndex >= 0 && sequenceIndex < colorSequences.colorSequences[currentColorSequencesIndex].Length)
        {
            currentSequenceIndex = sequenceIndex; // Update current index
            Color[] sequence = colorSequences.colorSequences[currentColorSequencesIndex][sequenceIndex];

            if (balls.Length == sequence.Length)
            {
                for (int i = 0; i < balls.Length; i++)
                {
                    Color color = sequence[i];
                    Color[] singleColorSequence = new Color[1] { colorSequences.colorSequences[currentColorSequencesIndex][sequenceIndex][i] };
                    balls[i].SetupColors(singleColorSequence);
                    balls[i].SetColor(0); // Set initial color
                    //Debug.Log($"Ball {balls[i].gameObject.name} color set to: {singleColorSequence[0]}");

                    // Ensure the sprites are updated for the touched picture
                    if (touchedPicture != null)
                    {
                        ClickablePicture clickablePicture = touchedPicture.GetComponent<ClickablePicture>();
                        if (clickablePicture != null)
                        {
                            clickablePicture.sequenceIndex = sequenceIndex;
                        }
                    }
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
        change.Play();
        RandomizeOtherPictures(touchedPicture);
        RandomizeSamePicture();
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
   

    void OnConfirmButtonClicked()
    {
        ding.Play();
        float elapsedTime = Time.time - startTime;
        bool isCorrectTime = CheckCorrectTime();
        string colors = GetCurrentColors();

        Debug.Log("Time taken: " + elapsedTime + " seconds");

        confirmButtonPressed = true;
        sequenceCounter++;
        if (sequenceCounter == 1) {  
            PictureManager.Instance.InitializePictures(1);
        } 
        if (sequenceCounter == 2) {  
            PictureManager.Instance.InitializePictures(2);
        }

        actionLogEntries.Add(new ActionLogEntry(DateTimeOffset.Now.ToUnixTimeMilliseconds() / 1000, participantName, condition, isCorrectTime, currentColorSequencesIndex, elapsedTime, colors));

        ResetBallColors();
        
        OnPlayAgainButtonClicked();
        Debug.Log("Current Color Sequence: " + currentColorSequencesIndex);
        

        if (sequenceCounter >= 3)
        {
            handMenu.SetActive(false);
            questionnaire.SetActive(true);
        }

        // Reset picture positions when the continue button is pressed
        PictureManager.Instance.ResetPicturePositions();
        // Change the sequence of the pictures if there are 10 
 
    }

     public void ResetBallColors() {
        foreach (var ball in balls)
        {
            ball.SetupColors(new Color[] { Color.white });
            ball.SetColor(0); // Set initial color to white
        }
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
    string GetCurrentColors()
    {
        List<string> colorList = new List<string>();
        foreach (Color color in colorSequences.colorSequences[currentColorSequencesIndex][currentSequenceIndex])
        {
            colorList.Add(ColorUtility.ToHtmlStringRGBA(color));
        }
        return string.Join(";", colorList);
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

    private void UpdatePictureSprites()
    {
        for (int i = 0; i < PictureManager.Instance.pictureObjects.Length; i++)
        {
            UpdatePictureSprites(i);
        }
    }

    private void UpdatePictureSprites(int index)
    {
        if (index < colorSequences.colorSequences.Length)
        {
            Color[] sequence = colorSequences.colorSequences[currentColorSequencesIndex][index];
            PictureManager.Instance.SetPictureSprites(PictureManager.Instance.pictureObjects[index], sequence);
        }
    }

    private void InitializeBallsToPictureColors()
    {
        if (spriteManager == null)
        {
            Debug.LogError("SpriteManager is not assigned!");
            return;
        }
        if (PictureManager.Instance.pictureObjects.Length > 0)
        {
            int initialSequenceIndex = PictureManager.Instance.pictureObjects[0].GetComponent<ClickablePicture>().sequenceIndex;

            Color[] sequence = colorSequences.colorSequences[currentColorSequencesIndex][initialSequenceIndex];

            if (balls.Length == sequence.Length)
            {
                for (int i = 0; i < balls.Length; i++)
                {
                    Color color = sequence[i];
                    Color[] singleColorSequence = new Color[1] { colorSequences.colorSequences[currentColorSequencesIndex][initialSequenceIndex][i] };
                    balls[i].SetupColors(singleColorSequence);
                    balls[i].SetColor(0);
                    //Debug.Log($"Ball {balls[i].gameObject.name} color set to: {singleColorSequence[0]}");
                }
            }
            else
            {
                Debug.LogError("Number of balls does not match the length of the color sequence!");
            }
        }
    }


    public void RandomizeOtherPictures(GameObject touchedPicture)
    {
        // Check if there are fewer than 10 picture objects
        if (PictureManager.Instance.pictureObjects.Length >= 10)
        {
            Debug.Log("There are already 10 pictures in the scene, no more randomizing.");
            return;
        }
        List<int> availableIndices = new List<int>();
        for (int i = 0; i < colorSequences.colorSequences[currentColorSequencesIndex].Length; i++)
        {
            if (i != currentSequenceIndex)
            {
                availableIndices.Add(i);
            }
        }

        foreach (GameObject picture in PictureManager.Instance.pictureObjects)
        {
            if (picture != touchedPicture)
            {
                if (availableIndices.Count > 0)
                {
                    int randomIndex = UnityEngine.Random.Range(0, availableIndices.Count);
                    int newSequenceIndex = availableIndices[randomIndex];
                    availableIndices.RemoveAt(randomIndex);

                    // Update the ClickablePicture's sequence index
                    ClickablePicture clickablePicture = picture.GetComponent<ClickablePicture>();
                    clickablePicture.sequenceIndex = newSequenceIndex;

                    // Update the sprites of the picture to match the new sequence
                    Color[] sequence = colorSequences.colorSequences[currentColorSequencesIndex][newSequenceIndex];
                    PictureManager.Instance.SetPictureSprites(picture, sequence);
                }
            }
        }
    }

    public void RandomizeSamePicture()
    {
        // Check if there is exactly one picture
        if (PictureManager.Instance.pictureObjects.Length != 1)
        {
            Debug.Log("There are more than 1 pictures in the scene.");
            return;
        }

        List<int> availableIndices = new List<int>();
        for (int i = 0; i < colorSequences.colorSequences[currentColorSequencesIndex].Length; i++)
        {
            if (i != currentSequenceIndex)
            {
                availableIndices.Add(i);
            }
        }

        foreach (GameObject picture in PictureManager.Instance.pictureObjects)
        {

            if (availableIndices.Count > 0)
            {
                int randomIndex = UnityEngine.Random.Range(0, availableIndices.Count);
                int newSequenceIndex = availableIndices[randomIndex];
                availableIndices.RemoveAt(randomIndex);

                // Update the ClickablePicture's sequence index
                ClickablePicture clickablePicture = picture.GetComponent<ClickablePicture>();
                clickablePicture.sequenceIndex = newSequenceIndex;

                // Update the sprites of the picture to match the new sequence
                Color[] sequence = colorSequences.colorSequences[currentColorSequencesIndex][newSequenceIndex];
                PictureManager.Instance.SetPictureSprites(picture, sequence);
            }
        }
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
        Debug.Log($"Balls: Initializing color sequences for scene. Order index: {colorSequenceOrderIndex}, Scene index: {sceneNumber}, Initial index of the Order Array: {startIndex}, " +
            $"Initial Sequence Index: {currentColorSequencesIndex}, Initial Sequence: colorSequences[{currentColorSequencesIndex}]");

        UpdatePictureSprites(currentColorSequencesIndex);

    }

    

}