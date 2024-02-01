using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public event EventHandler OnStateChanged;
    public static GameManager Instance { get; private set; }
    private enum State
    {
        WaitingToStart,
        CountdownToStart,
        GamePlaying,
        GameOver,
    }

    private State _state;
    private float waitingToStartTimer = 1f;
    private float countdownToStartTimer = 3f;
    private float gamePlayingTimer;
    private float gamePlayingTimerMax = 10f;

    private void Awake()
    {
        Instance = this;
        _state = State.WaitingToStart;
    }

    private void Update()
    {
        switch (_state)
        {
            case State.WaitingToStart:
                waitingToStartTimer -= Time.deltaTime;
                if (waitingToStartTimer <= 0f) _state = State.CountdownToStart;
                OnStateChanged?.Invoke(this, EventArgs.Empty);
                break;
            case State.CountdownToStart:
                countdownToStartTimer -= Time.deltaTime;
                if (countdownToStartTimer <= 0f) _state = State.GamePlaying;
                gamePlayingTimer = gamePlayingTimerMax;
                OnStateChanged?.Invoke(this, EventArgs.Empty);
                break;
            case State.GamePlaying:
                gamePlayingTimer -= Time.deltaTime;
                if (gamePlayingTimer <= 0f) _state = State.GameOver;
                OnStateChanged?.Invoke(this, EventArgs.Empty);
                break;
            case State.GameOver:
                break;
        }
        Debug.Log(_state);
    }

    public bool IsGamePlaying()
    {
        return _state == State.GamePlaying;
    }

    public bool IsCountdownToStartActive()
    {
        return _state == State.CountdownToStart;
    }

    public float GetCountdownToStartTimer()
    {
        return countdownToStartTimer;
    }

    public bool IsGameOver()
    {
        return _state == State.GameOver;
    }

    public float GetGamePlayingTimerNormalized()
    {
        return 1 - (gamePlayingTimer / gamePlayingTimerMax);
    }
}
