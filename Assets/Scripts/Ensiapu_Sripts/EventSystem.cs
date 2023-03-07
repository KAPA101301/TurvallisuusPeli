using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class EventSystem : MonoSingleton<EventSystem>
{
    //private static EventSystem instance;

    private Dictionary<string, List<Action<object>>> eventCallbacks;

    //public static EventSystem Instance
    //{
    //    get
    //    {
    //        if (instance == null)
    //        {
    //            instance = FindObjectOfType<EventSystem>();

    //            if (instance == null)
    //            {
    //                instance = new EventSystem();
    //                DontDestroyOnLoad(instance);
    //                Debug.LogError("An instance of EventSystem is needed in the scene, but there is none.");
    //            }
    //        }
    //        return instance;
    //    }
    //}
    //protected override void Awake()
    //{
    //    base.Awake();
    //    if (instance == null)
    //    {
    //        instance = this;
    //        eventCallbacks = new Dictionary<string, List<Action<object>>>();
    //        DontDestroyOnLoad(gameObject);
    //    }
    //    else
    //    {
    //        Destroy(gameObject);
    //    }
    //}

    protected override void Awake()
    {
        base.Awake();
        eventCallbacks = new Dictionary<string, List<Action<object>>>();
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
