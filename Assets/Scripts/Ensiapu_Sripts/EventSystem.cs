using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EventSystem : MonoBehaviour
{
    private static EventSystem instance;

    private Dictionary<string, List<Action<object>>> eventCallbacks;

    public static EventSystem Instance
    {
        get
        {
            if (instance == null)
            {
                instance = FindObjectOfType<EventSystem>();

                if (instance == null)
                {
                    Debug.LogError("An instance of EventSystem is needed in the scene, but there is none.");
                }
            }

            return instance;
        }
    }
    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            eventCallbacks = new Dictionary<string, List<Action<object>>>();
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }

    public void TriggerEvent(string eventName, object data)
    {
        if (eventCallbacks.ContainsKey(eventName))
        {
            foreach (var callback in eventCallbacks[eventName])
            {
                callback?.Invoke(data);
            }
        }
    }

    public void RegisterToEvent(string eventName, Action<object> callback)
    {
        if (!eventCallbacks.ContainsKey(eventName))
        {
            eventCallbacks[eventName] = new List<Action<object>>();
        }

        eventCallbacks[eventName].Add(callback);
    }
}
