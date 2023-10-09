using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public abstract class GameEventGenerico<T> : ScriptableObject
{
    /// <summary>
    /// The list of listeners that this event will notify if it is raised.
    /// </summary>
    private readonly List<GameEventListenerGenerico<T>> eventListeners =
        new List<GameEventListenerGenerico<T>>();

    public void Raise(T parameter)
    {
        for (int i = eventListeners.Count - 1; i >= 0; i--)
            eventListeners[i].OnEventRaised(parameter);
    }

    public void RegisterListener(GameEventListenerGenerico<T> listener)
    {
        if (!eventListeners.Contains(listener))
            eventListeners.Add(listener);
    }

    public void UnregisterListener(GameEventListenerGenerico<T> listener)
    {
        if (eventListeners.Contains(listener))
            eventListeners.Remove(listener);
    }
}

