using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class GameEvents
{
    //minigame 3
    static public UnityEvent GenericEvent = new UnityEvent();

    static public UnityEvent OnWateringStart = new UnityEvent();

    static public UnityEvent OnWateringStop = new UnityEvent();

    //minigame 4
    public static UnityEvent<Sprite> OnEmojiSelected = new UnityEvent<Sprite>();

    public static UnityEvent OnMiniGameStepCompleted = new UnityEvent();

}
