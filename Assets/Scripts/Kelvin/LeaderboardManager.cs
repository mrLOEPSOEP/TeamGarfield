using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;


public class LeaderboardManager : MonoBehaviour, IAmObserver<ButtonType>
{
    [Header("UI references")]
    [SerializeField] private TextMeshPro scoreText;
    [SerializeField] private TextMeshPro titleText;

    [Header("Settings")]
    [SerializeField] private int maxPlayers;

    private ButtonType currentActiveMode;

    private void Start()
    {
        UpdateDisplay();

    }

    public void OnNotify(ButtonType buttonType)
    {
        currentActiveMode = buttonType;
        if(titleText != null)
        {
            titleText.text = buttonType.ToString() + " HighScores";
        }
        UpdateDisplay();
    }

    public void SaveNewScore(string playerName, float score)
    {
        string gameModeType = currentActiveMode.ToString();
        List<LeaderboardEntries> scores = LoadScores(gameModeType);

        scores.Add(new LeaderboardEntries(playerName, score));
        var sortedScores = scores.OrderByDescending(recivedScore => recivedScore.score).Take(maxPlayers).ToList();

        // Savings as a json string
        string json = JsonUtility.ToJson(new SerializationWrapper { entries = sortedScores, });
        PlayerPrefs.SetString("leaderboard_" + gameModeType, json);
        PlayerPrefs.Save();
        UpdateDisplay();
    }

    public void UpdateDisplay()
    {
        List<LeaderboardEntries> scores = LoadScores(currentActiveMode.ToString());
        string displayString = "";

        for (int i = 0; i < scores.Count; i++)
        {
            displayString += $"{i + 1}. {scores[i].playerName} - {scores[i].score:F1}";
        }

        if (scores.Count == 0)
        {
            displayString = "No Scores";
        }

        scoreText.text = displayString;
    }

    private List<LeaderboardEntries> LoadScores(string gameModeType)
    {
        string modeType = "leaderboard_" + gameModeType;

        if (!PlayerPrefs.HasKey(modeType))
        {
            return new List<LeaderboardEntries>();
        }
        string json = PlayerPrefs.GetString(modeType);
        return JsonUtility.FromJson<SerializationWrapper>(json).entries;
    }

    [System.Serializable]
    private class SerializationWrapper { public List<LeaderboardEntries> entries; }


}
