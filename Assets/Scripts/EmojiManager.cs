using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmojiManager : MonoBehaviour
{
    [SerializeField] private List<Sprite> emojis; // Lista com os 9 sprites de emojis
    [SerializeField] private Button[] emojiButtons;  // Array de Botões onde os emojis serão exibidos (UI)
    private List<Sprite> selectedEmojis = new List<Sprite>(); // Lista de seleções do jogador
    private int currentStage = 0; // Etapa atual
    private int emojisPerStage = 3; // Número de emojis por etapa
    private int startIndex = 0; // Índice inicial dos emojis da etapa

    private void Awake()
    {
        LoadEmojis();
    }

    void Start()
    {
        ShowEmojis();
    }

    // Exibe os emojis da etapa atual
    void ShowEmojis()
    {
        ClearEmojiButtons();

        for (int i = 0; i < emojisPerStage; i++)
        {
            emojiButtons[i].image.sprite = emojis[startIndex + i];
        }
    }

    void LoadEmojis()
    {
        emojis = new List<Sprite>(Resources.LoadAll<Sprite>("Minigame4"));
    }

    // Método chamado quando um emoji é clicado
    void OnEmojiClicked(Sprite emoji)
    {
        selectedEmojis.Add(emoji);

        if (selectedEmojis.Count == 3)
        {
            GameEvents.OnMiniGameStepCompleted.Invoke();
            NextStage();
        }
    }

    // Avança para a próxima etapa ou finaliza o minigame
    void NextStage()
    {
        currentStage++;
        startIndex = currentStage * emojisPerStage;

        if (currentStage < 3)
        {
            ShowEmojis();
            selectedEmojis.Clear();
        }
        //else
        //{
        //    EndGame();
        //}
    }

    // Limpa os botões de emojis
    void ClearEmojiButtons()
    {
        for (int i = 0; i < emojiButtons.Length; i++)
        {
            emojiButtons[i].onClick.RemoveAllListeners();
            emojiButtons[i].image.sprite = null;
        }
    }

    // Finaliza o minigame (aqui você pode adicionar o que deve acontecer no final)
    //void EndGame()
    //{
    //    Debug.Log("Fim do minigame!");
    //    GameEvents.OnMiniGameComplete.Invoke(selectedEmojis);
    //}

    //void OnEnable()
    //{
    //    GameEvents.OnEmojiSelected.AddListener(OnEmojiSelectedHandler);
    //    GameEvents.OnMiniGameComplete.AddListener(OnMiniGameCompleteHandler);
    //}

    //void OnDisable()
    //{
    //    GameEvents.OnEmojiSelected.RemoveListener(OnEmojiSelectedHandler);
    //    GameEvents.OnMiniGameComplete.RemoveListener(OnMiniGameCompleteHandler);
    //}

    //void OnEmojiSelectedHandler(Sprite emoji)
    //{
    //    // Código a ser executado quando um emoji é selecionado
    //    Debug.Log("Emoji selecionado: " + emoji.name);
    //}

    //void OnMiniGameCompleteHandler(List<Sprite> selectedEmojis)
    //{
    //    // Código a ser executado quando o minigame é concluído
    //    Debug.Log("Minigame concluído com os seguintes emojis:");
    //    foreach (var emoji in selectedEmojis)
    //    {
    //        Debug.Log(emoji.name);
    //    }
    //}
}
