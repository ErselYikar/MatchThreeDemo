using System.Collections.Generic;
using UnityEngine;
using System;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;

    public static event Action<GameState> OnGameStatesChanged;

    public GameState State;

    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
        else
        {
            Destroy(gameObject);
            return;
        }
    }

    public void UpdateGameStates(GameState newState)
    {
        State = newState;

        switch (newState)
        {
            case GameState.Ready:
                break;
            case GameState.TileGathering:
                break;
            case GameState.MatchChecking:
                break;
            case GameState.Spawning:
                break;
            case GameState.TileGatheringDone:
                break;
            case GameState.AdjacentsFounding:
                break;
            case GameState.EmptyTilesFounding:
                break;
            case GameState.AttendChildsToTiles:
                break;
        }

        OnGameStatesChanged?.Invoke(newState);
    }
}

public enum GameState
{
    Ready,
    TileGathering,
    TileGatheringDone,
    AttendChildsToTiles,
    AdjacentsFounding,
    MatchChecking,
    CheckMatchingDone,
    EmptyTilesFounding,
    Spawning
}
