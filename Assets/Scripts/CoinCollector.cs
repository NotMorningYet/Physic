using UnityEngine;

public class CoinCollector : MonoBehaviour
{
    [SerializeField] private Player _player;

    private void OnTriggerEnter(Collider other)
    {
        Coin coin = other.GetComponent<Coin>();

        if (coin != null)
        {
            coin.gameObject.SetActive(false);
            _player.AddCoin();
        }
    }
}
