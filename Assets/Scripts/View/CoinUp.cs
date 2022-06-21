using UnityEngine;

public class CoinUp : MonoBehaviour
{
    [SerializeField] private GameObject _PickupEffect;

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) Pickup();
    }

    void Pickup()
    {
        Instantiate(_PickupEffect, transform.position, transform.rotation);
        Destroy(gameObject);
    }
}