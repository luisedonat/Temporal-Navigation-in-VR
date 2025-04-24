using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PictureManager : MonoBehaviour
{
    public static PictureManager Instance { get; private set; }

    public GameObject[] pictureObjects; // Array of picture GameObjects
    public int sceneNumber;
    private SpriteManager spriteManager;  // Reference to SpriteManager
    private ColorSequences colorSequences; // Reference to ColorSequences
    private Vector3[] initialPositions; // Array to store initial positions of the picture GameObjects
    private int currentColorSequencesIndex;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
        }

        // Get the SpriteManager and ColorSequences from the scene
        spriteManager = FindObjectOfType<SpriteManager>();
        colorSequences = FindObjectOfType<ColorSequences>();

        if (spriteManager == null)
        {
            Debug.LogError("SpriteManager not found in the scene!");
        }
        if (colorSequences == null)
        {
            Debug.LogError("ColorSequences not found in the scene!");
        }
        // Initialize the initial positions array
        initialPositions = new Vector3[pictureObjects.Length];
    }

    private void Start()
    {
        InitializePictures(0);
    }

    public void InitializePictures(int sequenceCounter)
    {
        int colorSequenceOrderIndex = ParticipantManager.Instance.colorSequenceOrder;
        int startIndex = (sceneNumber % 9) * 3;
        var colorSequenceOrder = colorSequences.colorSequenceOrders[colorSequenceOrderIndex];
        if (sequenceCounter == 0) {
            currentColorSequencesIndex = colorSequenceOrder[startIndex];
        }
        if (sequenceCounter == 1)
        {
            currentColorSequencesIndex = colorSequenceOrder[startIndex + 1];
        }
        if (sequenceCounter == 2)
        {
            currentColorSequencesIndex = colorSequenceOrder[startIndex + 2];
        }

        Debug.Log($"Pictures: Initializing color sequences for scene. Order index: {colorSequenceOrderIndex}, Scene index: {sceneNumber}, Initial index of the Order Array: {startIndex}, " +
            $"Initial Sequence Index: {currentColorSequencesIndex}, Initial Sequence: colorSequences[{currentColorSequencesIndex}]");
        // Initialize the picture sprites based on the first color sequence
        if (colorSequences != null && colorSequences.colorSequences[currentColorSequencesIndex].Length > 0)
        {
            // Store initial positions
            for (int i = 0; i < pictureObjects.Length; i++)
            {
                initialPositions[i] = pictureObjects[i].transform.position;
            }

            for (int i = 0; i < pictureObjects.Length; i++)
            {
                // Ensure the index is within bounds for both pictureObjects and colorSequences
                if (i < colorSequences.colorSequences[currentColorSequencesIndex].Length)
                {
                    Color[] sequence = colorSequences.colorSequences[currentColorSequencesIndex][i];
                    SetPictureSprites(pictureObjects[i], sequence);

                    // Set initial sequence index for ClickablePicture
                    ClickablePicture clickablePicture = pictureObjects[i].GetComponent<ClickablePicture>();
                    if (clickablePicture != null)
                    {
                        clickablePicture.sequenceIndex = i;
                    }
                }
                else
                {
                    Debug.LogError($"Index {i} is out of bounds for color sequences.");
                }
            }
        }
    }

    public int GetPictureObjectIndex(GameObject picture)
    {
        for (int i = 0; i < pictureObjects.Length; i++)
        {
            if (pictureObjects[i] == picture)
            {
                return i;
            }
        }
        Debug.LogError($"Picture object not found: {picture.name}");
        return -1;
    }

    public void SetPictureSprites(GameObject pictureObject, Color[] sequence)
    {
        Image[] images = pictureObject.GetComponentsInChildren<Image>();
        if (images.Length != sequence.Length)
        {
            Debug.LogError("Number of images does not match the length of the color sequence!");
            return;
        }

        for (int i = 0; i < images.Length; i++)
        {
            Color color = sequence[i];
            Sprite sprite = spriteManager.GetSpriteForColor(color);
            if (sprite != null)
            {
                images[i].sprite = sprite;
                //Debug.Log($"Set sprite for picture {pictureObject.name} at index {i} to {sprite.name} for color {color}");
            }
            else
            {
                Debug.LogError($"No sprite found for color: {color}");
            }
        }
    }

    public void ResetPicturePositions()
    {
        for (int i = 0; i < pictureObjects.Length; i++)
        {
            pictureObjects[i].transform.position = initialPositions[i];
        }
    }
}
