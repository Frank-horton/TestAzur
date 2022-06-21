using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Finish : MonoBehaviour
{
    [SerializeField] private GameObject _FinishPanel;
    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {
            _FinishPanel.SetActive(true);
            Player.Instance.AnimPlayer.SetBool("Run", false);
            Player.Instance.enabled = false; 
        }
    }
}
