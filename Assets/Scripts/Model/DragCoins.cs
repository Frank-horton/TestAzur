using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class DragCoins : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI _TextCoin;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Coin"))
        {
            Destroy(other.gameObject);
            CointsCount.RenderCoinCount(ref _TextCoin);
        }
    }
}