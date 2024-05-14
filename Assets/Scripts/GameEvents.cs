using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class GameEvents
{
    static public UnityEvent GenericEvent = new UnityEvent();

    static public UnityEvent OnWateringStart = new UnityEvent();

    static public UnityEvent OnWateringStop = new UnityEvent();

}
