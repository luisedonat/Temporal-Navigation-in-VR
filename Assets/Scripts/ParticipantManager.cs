using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticipantManager : MonoBehaviour
{
    public static ParticipantManager Instance { get; private set; }

    // Global variables
    public string participantName = "Luise";
    public int colorSequenceOrder = 0;

    private void Awake()
    {
        // Ensure that only one instance of GameManager exists
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
