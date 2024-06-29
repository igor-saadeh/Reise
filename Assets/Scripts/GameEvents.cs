using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public static class GameEvents
{
    //minigame 2
    static public UnityEvent GenericEvent = new UnityEvent();

    static public UnityEvent OnWateringStart = new UnityEvent();

    static public UnityEvent OnWateringStop = new UnityEvent();

    static public UnityEvent OnMinigame2Finished = new UnityEvent();

    //minigame 3
    public static UnityEvent<Sprite> OnEmojiSelected = new UnityEvent<Sprite>();

    public static UnityEvent OnMiniGameStepCompleted = new UnityEvent();

    static public UnityEvent OnMinigame3Finished = new UnityEvent();

}
