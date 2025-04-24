using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ResetPlayerPosition : MonoBehaviour
{
    public Transform targetPosition;

    //public Vector3 absoluteTargetEulerRotation; 
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space)) {
            //transform.position = new Vector3(0.14f, 1.28f, 5.47f);
            transform.position = targetPosition.position;
            Debug.Log("Changed player positon to start.");
            //transform.rotation = new Quaternion(0, 0, 0, 1);
            //Quaternion targetRotation = Quaternion.Euler(absoluteTargetEulerRotation);
            transform.rotation = targetPosition.rotation;
        }
        //Debug.Log("Player position after teleport: " + transform.position + "Player rotation: " + transform.rotation);
    }
}
