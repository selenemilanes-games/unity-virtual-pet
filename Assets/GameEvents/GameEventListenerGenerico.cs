using UnityEngine.Events;
using UnityEngine;


public abstract class GameEventListenerGenerico<T> : MonoBehaviour
{
    [Tooltip("Event to register with.")]
    public GameEventGenerico<T> Event;

    [Tooltip("Response to invoke when Event is raised.")]
    public UnityEvent<T> Response;

    private void OnEnable()
    {
        Event.RegisterListener(this);
    }

    private void OnDisable()
    {
        Event.UnregisterListener(this);
    }

    public void OnEventRaised(T parameter)
    {
        Response.Invoke(parameter);
    }
}


