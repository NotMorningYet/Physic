using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private CoinManager _coinManager;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            _coinManager.CoinCollected();
            gameObject.SetActive(false);
        }
    }
}
