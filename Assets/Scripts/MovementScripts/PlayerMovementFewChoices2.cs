using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerMovementFewChoices2 : MonoBehaviour
{
    public float movementThreshold = 0.1f;
    public UnityEngine.UI.Button confirmButton;
    public TextMeshProUGUI resultText;

    private Vector3 lastPosition;
    private ColorChanger balls;
    private ColorSequences colorSequences;
    private int currentSequenceIndex = 4;
    private int totalSequences;

    // Start is called before the first frame update
    void Start()
    {
        lastPosition = transform.position;

        colorSequences = FindObjectOfType<ColorSequences>();
       //v  confirmButton.onClick.AddListener(OnConfirmButtonClicked);

        totalSequences = colorSequences.colorSequences.Length;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentPosition = transform.position;
        float movementDelta = currentPosition.x - lastPosition.x;

        if (Mathf.Abs(movementDelta) > movementThreshold)
        {
            if (movementDelta > 0)
            {
                if (currentSequenceIndex < totalSequences-1)
                {
                    currentSequenceIndex++;
                }
            }
            else if (movementDelta < 0)
            {
                if (currentSequenceIndex > 0)
                {
                    currentSequenceIndex--;
                }
            }
        }
    }
}
