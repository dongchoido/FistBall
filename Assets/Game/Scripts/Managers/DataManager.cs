using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataManager : MonoBehaviour
{
    public static DataManager instance;
    private float timeLeft = 100f;
    public float TimeLeft() => timeLeft;
    private Vector2Int matchScore;
    public Vector2Int MatchScore() => matchScore;
    private Vector2 punchCooldown;
    public Vector2 PunchCooldown() => punchCooldown;
    private Vector2 dashCooldown;
    public Vector2 DashCooldown() => dashCooldown;
    void Awake()
    {
        if (instance == null)
        {
            instance = this;
           // DontDestroyOnLoad(this);
        }
    }
    void Start()
    {
        matchScore = new Vector2Int(0, 0);
    }
    public void Goal(bool isTeam1)
    {
        if (isTeam1) matchScore += new Vector2Int(1, 0);
        else matchScore += new Vector2Int(0, 1);
    }
}