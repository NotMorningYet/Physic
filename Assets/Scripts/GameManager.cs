using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TimeCounter _timeCounter;
    [SerializeField] private UI _ui;
    [SerializeField] private Player _player;
    [SerializeField] private int _levelTime;
    [SerializeField] private CoinManager _coinManager;

    private string _restartButton = "R";
    private bool _isPlaying;

    private void Awake()
    {
        ResetGame();
    }

    private void Update()
    {
        int coinsToCollect = _coinManager.CoinsToCollect;
        _ui.RefreshData(coinsToCollect, _timeCounter.TimeToLoose);

        if (_isPlaying == false)
        {
            if (Input.GetKeyDown(KeyCode.R))
            {
                ResetGame();
            }
            return;
        }
        
        if (_timeCounter.IsOutOfTime)
        {
            GameOver();
            return;
        }

        if (coinsToCollect == 0)
        {
            GameWin();
            return;
        }                
    }

    private void GameWin()
    {
        _ui.GameWinShow(_restartButton);
        _timeCounter.CountStop();
        _isPlaying = false;
        _player.Freeze();
    }

    private void GameOver()
    {
        _ui.GameOverShow(_restartButton);
        _isPlaying = false;
        _player.Freeze();
    }

    private void ResetGame()
    {
        _coinManager.Initialize();
        _player.Initialize();
        _timeCounter.CountStart(_levelTime);
        _ui.RefreshData(_coinManager.CoinsToCollect, _timeCounter.TimeToLoose);
        _ui.ResetGame();
        _isPlaying = true;
    }
}