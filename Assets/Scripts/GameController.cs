using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameController : MonoBehaviour
{
    
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            SceneManager.LoadScene("Slider_NoChoices");
            
        } 
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            SceneManager.LoadScene("Slider_FewChoices");
        } 
        if(Input.GetKeyDown(KeyCode.Alpha3))
        {
            SceneManager.LoadScene("Slider_ManyChoices");
        }
        if (Input.GetKeyDown(KeyCode.Alpha4))
        {
            SceneManager.LoadScene("Interactor_NoChoices");
        }
        if (Input.GetKeyDown(KeyCode.Alpha5))
        {
            SceneManager.LoadScene("Interactor_FewChoices");
        }
        if (Input.GetKeyDown(KeyCode.Alpha6))
        {
            SceneManager.LoadScene("Interactor_ManyChoices");
        }
        if (Input.GetKeyDown(KeyCode.Alpha7))
        {
            SceneManager.LoadScene("Movement_NoChoices");
        }
        if (Input.GetKeyDown(KeyCode.Alpha8))
        {
            SceneManager.LoadScene("Movement_FewChoices");
        }
        if (Input.GetKeyDown(KeyCode.Alpha9))
        {
            SceneManager.LoadScene("Movement_ManyChoices");
        }
    }
}