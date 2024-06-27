using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EmojiManager : MonoBehaviour
{
    private List<Sprite> emojis; // Lista com os 9 sprites de emojis
    private Button[] emojiButtons;  // Array de Botões onde os emojis serão exibidos (UI)
    private Balloon[] balloons; // Array de Balloons para exibir os emojis selecionados

    private List<Sprite> selectedEmojis = new List<Sprite>(); // Lista de seleções do jogador
    private int currentStage = 0; // Etapa atual
    private int emojisPerStage = 3; // Número de emojis por etapa
    private int totalEmojis = 9; // Total de emojis no minigame
    private int startIndex = 0; // Índice inicial dos emojis da etapa

    private void Awake()
    {
        LoadEmojis();
        FindEmojiButtons();
        FindBalloons();
        SetupEmojiButtons();
        ShowEmojis();
    }

    private void FindEmojiButtons()
    {
        // Encontra todos os botões na cena ou no objeto que contém o script
        emojiButtons = GetComponentsInChildren<Button>();
    }

    private void FindBalloons()
    {
        // Encontra todos os Balloons na cena ou no objeto que contém o script
        balloons = GetComponentsInChildren<Balloon>();
    }

    private void SetupEmojiButtons()
    {
        foreach (Button button in emojiButtons)
        {
            int index = System.Array.IndexOf(emojiButtons, button); // Captura o índice do botão
            button.onClick.AddListener(() => OnEmojiButtonClicked(index));
        }
    }

    private void LoadEmojis()
    {
        emojis = new List<Sprite>(Resources.LoadAll<Sprite>("Minigame4"));
        Debug.Log("Emojis carregados: " + emojis.Count);
    }

    private void ShowEmojis()
    {
        ClearEmojiButtons();

        // Calcula o índice final para esta etapa
        int endIndex = Mathf.Min(startIndex + emojisPerStage, totalEmojis);

        for (int i = startIndex; i < endIndex; i++)
        {
            emojiButtons[i - startIndex].image.sprite = emojis[i];
            emojiButtons[i - startIndex].interactable = true;
        }
    }

    private void OnEmojiButtonClicked(int buttonIndex)
    {
        int emojiIndex = startIndex + buttonIndex;

        if (emojiIndex < emojis.Count)
        {
            Sprite emoji = emojis[emojiIndex];
            selectedEmojis.Add(emoji);

            Debug.Log("Emoji selecionado: " + emoji.name);
            Debug.Log("Total de emojis selecionados: " + selectedEmojis.Count);

            if (selectedEmojis.Count % emojisPerStage == 0)
            {
                int balloonIndex = selectedEmojis.Count / emojisPerStage - 1;
                balloons[balloonIndex].AddEmoji(emoji); // Adiciona o emoji ao Balloon correspondente
                GameEvents.OnMiniGameStepCompleted.Invoke();
                NextStage();
            }
        }
        else
        {
            Debug.LogError("Índice de emoji fora dos limites: " + emojiIndex);
        }
    }

    private void NextStage()
    {
        currentStage++;
        startIndex = currentStage * emojisPerStage;

        if (currentStage < balloons.Length)
        {
            ShowEmojis();
        }
        else
        {
            EndMiniGame();
        }

        Debug.Log("Etapa atual: " + currentStage);
    }

    private void EndMiniGame()
    {
        foreach (Button button in emojiButtons)
        {
            button.interactable = false;
        }

        Debug.Log("Minigame finalizado.");
        // Adicione aqui qualquer lógica adicional para o fim do minigame
    }

    private void ClearEmojiButtons()
    {
        foreach (Button button in emojiButtons)
        {
            button.image.sprite = null;
            button.onClick.RemoveAllListeners(); // Limpa os listeners anteriores
        }

        SetupEmojiButtons(); // Reconfigura os listeners
    }
}
