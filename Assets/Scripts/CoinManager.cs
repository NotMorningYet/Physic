using System.Collections.Generic;
using UnityEngine;

public class CoinManager : MonoBehaviour
{
    [SerializeField] private List<Coin> _coins;

    public void Initialize()
    {
        foreach (Coin coin in _coins)        
            coin.gameObject.SetActive(true);
    }

    public int GetInitialNumberOfCoins()
    {
        return _coins.Count;
    }
}
