using System.Collections.Generic;
using UnityEngine;

public class Manage : MonoBehaviour
{
    [SerializeField] TimeCounter _timeCounter;
    [SerializeField] UI _ui;
    [SerializeField] Player _player;
    [SerializeField] private int _levelTime;
    [SerializeField] List<Coin> _coins;

    private int _coinsToCollect;
    private string _restartButton = "R";
    private bool _isPlaying;

    public void DecreaseCoinsToCollect()
    {
        _coinsToCollect--;
    }

    private void Awake()
    {
        ResetGame();
    }

    private void Update()
    {
        _ui.RefreshData(_coinsToCollect, _timeCounter.TimeToLoose);

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

        if (_coinsToCollect == 0)
        {
            GameWin();
            return;
        }                
    }

    private void GameWin()
    {
        _ui.GameWinShow(_restartButton);
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
        foreach (Coin coin in _coins)
        {
            coin.gameObject.SetActive(true);
        }

        _coinsToCollect = _coins.Count;
        _timeCounter.CountStart(_levelTime);
        _player.Initialize();
        _ui.RefreshData(_coinsToCollect, _timeCounter.TimeToLoose);
        _ui.ResetGame();
        _isPlaying = true;
    }
}