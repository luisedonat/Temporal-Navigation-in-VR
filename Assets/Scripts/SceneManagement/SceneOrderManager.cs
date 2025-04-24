using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneOrderManager : MonoBehaviour
{
    public string participantName { get; set; } 
    private List<string> scenes = new List<string> { 
        "Slider_NoChoices", "Slider_FewChoices", "Slider_ManyChoices", 
        "Interactor_NoChoices", "Interactor_FewChoices", "Interactor_ManyChoices", 
        "Movement_NoChoices", "Movement_FewChoices", "Movement_ManyChoices"
    };
    private List<int> colorSequenceIndices;
    private Queue<(string scene, int colorSequenceIndex)> sceneQueue;
    private int scenesPerSet = 3;

    private void Start()
    {
        InitializeSceneOrder();
        LoadNextScene();
    }

    private void InitializeSceneOrder()
    {
        ShuffleScenes();
        colorSequenceIndices = new List<int>();
        for (int i = 0; i < scenes.Count; i++)
        {
            colorSequenceIndices.Add(i * scenesPerSet);
            colorSequenceIndices.Add(i * scenesPerSet + 1);
            colorSequenceIndices.Add(i * scenesPerSet + 2);
        }

        sceneQueue = new Queue<(string scene, int colorSequenceIndex)>();

        for (int i = 0; i < scenes.Count; i++)
        {
            for (int j = 0; j < scenesPerSet; j++)
            {
                sceneQueue.Enqueue((scenes[i], colorSequenceIndices[i * scenesPerSet + j]));
            }
        }
    }

    private void ShuffleScenes()
    {
        for (int i = 0; i < scenes.Count; i++)
        {
            string temp = scenes[i];
            int randomIndex = Random.Range(i, scenes.Count);
            scenes[i] = scenes[randomIndex];
            scenes[randomIndex] = temp;
        }
    }

    public void LoadNextScene()
    {
        if (sceneQueue.Count > 0)
        {
            var nextSceneInfo = sceneQueue.Dequeue();
            Debug.Log($"Loading Scene: {nextSceneInfo.scene} with Color Sequence Index: {nextSceneInfo.colorSequenceIndex}");
            PlayerPrefs.SetInt("CurrentColorSequenceIndex", nextSceneInfo.colorSequenceIndex);
            SceneManager.LoadScene(nextSceneInfo.scene);
        }
        else
        {
            Debug.Log("All scenes have been played.");
        }
    }
}
