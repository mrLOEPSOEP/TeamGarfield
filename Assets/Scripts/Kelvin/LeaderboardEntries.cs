using UnityEngine;

[System.Serializable]
public class LeaderboardEntries
{
    public string playerName;
    public float score;

    public LeaderboardEntries(string name, float receiveScore)
    {
        playerName = name;
        score = receiveScore;
    }

}
