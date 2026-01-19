using System;
using System.Collections.Generic;
using System.Linq;
using TMPro;
using UnityEngine;
using UnityEngine.Android;


public class LeaderboardManager : MonoBehaviour, IAmObserver<ButtonType>, IAmObserver<AccuracyData>
{
    [Header("UI references")]
    [SerializeField] private TextMeshPro scoreText;
    [SerializeField] private TextMeshPro titleText;
    [SerializeField] GameObject gamemodeSelectScreen;
    [SerializeField] TextMeshPro lastScoreText;

    [Header("Settings")]
    [SerializeField] private int maxPlayers;

    private ButtonType currentActiveMode;
    bool isDutch;

    private void OnEnable()
    {
        // Find your subjects and attach this script to them
        FindObjectOfType<Subject<ButtonType>>()?.AddObserver(this);
        FindObjectOfType<Subject<AccuracyData>>()?.AddObserver(this); 
    }

    private void OnDisable()
    {
        // Always detach to prevent memory leaks/errors when reloading scenes
        FindObjectOfType<Subject<ButtonType>>()?.RemoveObserver(this);
        FindObjectOfType<Subject<AccuracyData>>()?.RemoveObserver(this);
    }
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
        //Thygo added from this point
        if (buttonType == ButtonType.Dutch) isDutch = true;
    }

    public void OnNotify(AccuracyData data)
    {
        string rankTitle;

        if (isDutch) rankTitle = GetDutchTitle(data.accuracyScore);
        else rankTitle = GetEnglishTitle(data.accuracyScore);

        SaveNewScore(rankTitle, data.accuracyScore);
        UpdateResult(rankTitle, data.accuracyScore);
    }

    void UpdateResult(string title, float score)
    {
        if (lastScoreText != null) lastScoreText.text = "Last Result: " + title + " " + score;
    }

    string GetDutchTitle(float score)
    {
        if (score >= 90f) return "Meester";
        if (score >= 75f) return "Vakman";
        if (score >= 50f) return "Leerling";
        return "Amateur";
    }

    string GetEnglishTitle(float score)
    {
        if (score >= 90f) return "Master";
        if (score >= 75f) return "Expert";
        if (score >= 50f) return "Apprentice";
        return "Novice";
    }
    //Thygo end
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
