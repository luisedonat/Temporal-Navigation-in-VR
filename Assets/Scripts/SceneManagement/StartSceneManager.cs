using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class StartSceneManager : MonoBehaviour
{

    public string[] allScenes;
    private List<string> playedScenes;  // To keep track of scenes that have been played
    private int scenesPlayedCount = 0;  // Number of scenes played so far
    private int colorSequenceCounter = 0;  // Counter for color sequences in the current scene
    private bool isSceneChanging = false;  // Flag to check if the scene is changing
    // Start is called before the first frame update
    void Start()
    {
        allScenes = new string[] { "Slider_NoChoices", "Slider_FewChoices", "Slider_ManyChoices",
        "Interactor_NoChoices", "Interactor_FewChoices", "Interactor_ManyChoices",
        "Movement_NoChoices", "Movement_FewChoices", "Movement_ManyChoices"};
        LoadRandomScene();
    }

    private void LoadRandomScene()
    {
        // If we have played all scenes, end the game or restart (optional)
        if (playedScenes.Count >= allScenes.Length)
        {
            Debug.Log("All scenes have been played.");
            // You can add logic here to end the game or restart
            return;
        }

        // Select a random scene that hasn't been played yet
        string nextScene = allScenes[Random.Range(0, allScenes.Length)];
        while (playedScenes.Contains(nextScene))
        {
            nextScene = allScenes[Random.Range(0, allScenes.Length)];
        }

        playedScenes.Add(nextScene);
        scenesPlayedCount++;
        Debug.Log($"Loading scene: {nextScene}");
        SceneManager.LoadScene(nextScene);
    }
}
