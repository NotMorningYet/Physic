using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private List<Coin> _coins;
    [SerializeField] private Player _player;
        
    private int _coinsToCollect;

    public int CoinsToCollect { get => _coinsToCollect; }

    public void Initialize()
    {
        foreach (Coin coin in _coins)        
            coin.gameObject.SetActive(true);
        
        _coinsToCollect = _coins.Count;
    }

    public void CoinCollected()
    {
        DecreaseCoinsToCollect();
        _player.AddCoin();
    }

    public bool IsAllCoinsCollected()
    {
        return _coinsToCollect == 0;
    }

    private void DecreaseCoinsToCollect()
    {
        _coinsToCollect--;
    }
}
