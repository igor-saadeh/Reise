using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class EmojiManager : MonoBehaviour
{
    [SerializeField] private List<Sprite> emojis; // Lista com os 9 sprites de emojis
    [SerializeField] private Button[] emojiButtons;  // Array de Bot�es onde os emojis ser�o exibidos (UI)
    private List<Sprite> selectedEmojis = new List<Sprite>(); // Lista de sele��es do jogador
    private int currentStage = 0; // Etapa atual
    private int emojisPerStage = 3; // N�mero de emojis por etapa
    private int startIndex = 0; // �ndice inicial dos emojis da etapa

    private void Awake()
    {
        LoadEmojis();
        //FindEmojiButtons
        SetupEmojiButtons();
    }

    //private void FindEmojiButtons()
    //{
    //    // Obt�m todos os objetos raiz da cena ativa
    //    GameObject[] rootObjects = SceneManager.GetActiveScene().GetRootGameObjects();

    //    foreach (GameObject rootObject in rootObjects)
    //    {
    //        // Procura por Canvas entre os objetos raiz
    //        if (rootObject.name == "Canvas")
    //        {
    //            // Se Canvas for encontrado, encontra todos os bot�es filhos dele
    //            emojiButtons = rootObject.GetComponentsInChildren<Button>();
    //            return; // Sai do loop, pois encontrou Canvas
    //        }
    //    }

    //    // Se Canvas n�o for encontrado, exibe um erro
    //    Debug.LogError("Canvas n�o encontrado na hierarquia.");
    //}


    private void SetupEmojiButtons()
    {
        for (int i = 0; i < emojiButtons.Length; i++)
        {
            int index = i; // Captura o valor de i para cada bot�o
            emojiButtons[i].onClick.AddListener(() => OnEmojiButtonClicked(index)); // Desnecess�rio?
        }
    }

    private void LoadEmojis()
    {
        emojis = new List<Sprite>(Resources.LoadAll<Sprite>("Minigame4"));
    }

    private void ShowEmojis()
    {
        ClearEmojiButtons();

        for (int i = 0; i < emojisPerStage; i++)
        {
            emojiButtons[i].image.sprite = emojis[startIndex + i];
        }
    }

    private void OnEmojiButtonClicked(int buttonIndex)
    {
        Sprite emoji = emojis[startIndex + buttonIndex];
        selectedEmojis.Add(emoji);

        if (selectedEmojis.Count == 3)
        {
            GameEvents.OnMiniGameStepCompleted.Invoke();
            NextStage();
        }
    }

    private void NextStage()
    {
        currentStage++;
        startIndex = currentStage * emojisPerStage;

        if (currentStage < 3)
        {
            ShowEmojis();
            selectedEmojis.Clear();
        }
    }

    private void ClearEmojiButtons()
    {
        foreach (Button button in emojiButtons)
        {
            button.image.sprite = null;
            button.onClick.RemoveAllListeners(); // Limpa os listeners anteriores
        }
    }
}