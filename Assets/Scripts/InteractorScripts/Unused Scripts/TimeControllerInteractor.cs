using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class TimeControllerInteractor : MonoBehaviour
{
    public GameObject picture1;
    public GameObject picture2;
    public GameObject picture3;
    public GameObject picture4;
    public GameObject picture5;
    public ColorChanger colorChanger_1;
    public ColorChanger colorChanger_2;
    public ColorChanger colorChanger_3;
    public ColorChanger colorChanger_4;
    public ColorChanger colorChanger_5;
    public float animationDuration = 5.0f;
    public float timePoint1 = 1.0f;
    public float timePoint2 = 2.0f;
    public float timePoint3 = 3.0f;
    public float timePoint4 = 4.0f;
    public float timePoint5 = 5.0f;

    void Start()
    {
        AddEventTrigger(picture1, timePoint1);
        AddEventTrigger(picture2, timePoint2);
        AddEventTrigger(picture3, timePoint3);
        AddEventTrigger(picture4, timePoint4);
        AddEventTrigger(picture5, timePoint5);
    }

    void AddEventTrigger(GameObject picture, float timePoint)
    {
        EventTrigger trigger = picture.AddComponent<EventTrigger>();

        EventTrigger.Entry entry = new EventTrigger.Entry();
        entry.eventID = EventTriggerType.PointerClick;
        entry.callback.AddListener((eventData) => { OnPictureClicked(timePoint); });
        trigger.triggers.Add(entry);
    }

    void OnPictureClicked(float timePoint)
    {
        Debug.Log($"Picture clicked, moving to time point: {timePoint}");
        SetAnimationTime(timePoint);
    }

    void SetAnimationTime(float timePoint)
    {
        float normalizedTime = timePoint / animationDuration;
        Debug.Log($"Setting animation time to: {normalizedTime * animationDuration} (normalized: {normalizedTime})");
        /**colorChanger_1.SetColor(normalizedTime);
        colorChanger_2.SetColor(normalizedTime);
        colorChanger_3.SetColor(normalizedTime);
        colorChanger_4.SetColor(normalizedTime);
        colorChanger_5.SetColor(normalizedTime);*/
    }

    

    
}
