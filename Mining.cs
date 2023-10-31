using System.Collections;
using UnityEngine;

public class Mining : MonoBehaviour
{
    private bool isReadyToMining = true;
    [SerializeField] private GameObject stoun;
    [SerializeField] private GameObject fragments;
    [SerializeField] private GameObject helpMessage;

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && isReadyToMining)
        {
            if (Input.GetKey(KeyCode.E))
            {
                stoun.SetActive(false);
                fragments.SetActive(true);
                helpMessage.SetActive(false);
                ResourceEventManager.SendMinigStouns(1);
                isReadyToMining = false;
                StartCoroutine(RespawnTimer());
            }
        }
    }

    IEnumerator RespawnTimer()
    {
        yield return new WaitForSeconds(5);
        stoun.SetActive(true);
        fragments.SetActive(false);
        isReadyToMining = true;
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isReadyToMining)
        {
            helpMessage.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            helpMessage.SetActive(false);
        }
    }
}
