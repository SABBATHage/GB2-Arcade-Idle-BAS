using System.Collections;
using UnityEngine;

public class Cutting : MonoBehaviour
{
    private bool isReadyToCutting = true;
    [SerializeField] GameObject tree;
    [SerializeField] GameObject stump;
    [SerializeField] GameObject helpMessage;
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && isReadyToCutting)
        {
            if (Input.GetKey(KeyCode.E))
            {
                tree.SetActive(false);
                stump.SetActive(true);
                helpMessage?.SetActive(false);
                ResourceEventManager.SendCuttingTrees(1);
                isReadyToCutting = false;
                StartCoroutine(RespawnTimer());
            }
        }
    }
    IEnumerator RespawnTimer()
    {
        yield return new WaitForSeconds(5);
        tree.SetActive(true);
        stump.SetActive(false);
        isReadyToCutting = true;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isReadyToCutting)
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
