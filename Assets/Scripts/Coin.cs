using UnityEngine;

public class Coin : MonoBehaviour
{
    [SerializeField] Animator _animator;

    private void OnTriggerEnter(Collider other)
    {
        Player player = other.GetComponent<Player>();

        if (player != null)
        {
            gameObject.GetComponentInParent<Manage>().DecreaseCoinsToCollect();
            gameObject.SetActive(false);
        }
    }
}
