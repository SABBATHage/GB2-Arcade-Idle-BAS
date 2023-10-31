using TMPro;
using UnityEngine;

public class WorkBanch : MonoBehaviour
{
    private bool isWorkBanchReady = false;
    private bool isWoodEnough = false;
    private bool isStounEnough = false;
    private bool isItMyWood = false;
    private bool isItMyStoun = false;
    [SerializeField] private GameObject contructionPlace;
    [SerializeField] private GameObject banch;
    [SerializeField] private GameObject helpMessageToCraftBanch;
    [SerializeField] private GameObject helpMessageToCraftPlanks;
    [SerializeField] private GameObject resourceCostPanel;
    [SerializeField] private TextMeshProUGUI woodText;
    [SerializeField] private TextMeshProUGUI stounText;
    [SerializeField] private int woodNecessary = 2;
    [SerializeField] private int stounNecessary = 2;
    private void Awake()
    {
        ResourceEventManager.DecreaseWood.AddListener(WoodToBanch);
        ResourceEventManager.DecreaseWood.AddListener(CraftPlanks);
        ResourceEventManager.DecreaseStoun.AddListener(StounToBanch);
    }
    void Start()
    {
        woodText.text = woodNecessary.ToString();
        stounText.text = stounNecessary.ToString();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && isWorkBanchReady)
        {
            if (Input.GetKey(KeyCode.E)) 
            {
                isItMyWood = true;
                ResourceEventManager.SendPayWood(1);
            }
        }

        if (other.CompareTag("Player") &&  !isWorkBanchReady) 
        {
            if (Input.GetKey(KeyCode.E) && woodNecessary > 0)
            {
                isItMyWood = true;
                ResourceEventManager.SendPayWood(1);
            }
            if (Input.GetKey(KeyCode.E) && stounNecessary > 0) 
            {
                isItMyStoun = true;
                ResourceEventManager.SendPayStouns(1);                
            }
        }
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player") && isWorkBanchReady)
        {
            helpMessageToCraftPlanks.SetActive(true);
        }
        if (other.CompareTag("Player") && !isWorkBanchReady)
        {
            helpMessageToCraftBanch.SetActive(true);
            resourceCostPanel.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            helpMessageToCraftPlanks.SetActive(false);
            helpMessageToCraftBanch.SetActive(false);
            resourceCostPanel.SetActive(false);
        }
    }
    private void CraftBanch()
    {
        if (isWoodEnough && isStounEnough)
        {
            contructionPlace.SetActive(false);
            banch.SetActive(true);
            resourceCostPanel.SetActive(false);
            isWorkBanchReady = true;
            QuestEventManager.SendBranchComplete(true);
        }
    }
    private void WoodToBanch(int wood) 
    {
        if (!isWoodEnough && !isWorkBanchReady && isItMyWood)
        {
            woodNecessary -= wood;
            isItMyWood = false;
            if (woodNecessary <= 0)
            {
                isWoodEnough = true;
                CraftBanch();
            }
            woodText.text = woodNecessary.ToString();
        }
    }
    private void StounToBanch(int stoun)
    {
        if (!isStounEnough && !isWorkBanchReady && isItMyStoun)
        {
            stounNecessary -= stoun;
            isItMyStoun = false;
            if(stounNecessary <= 0)
            {
                isStounEnough = true;
                CraftBanch();
            }
            stounText.text = stounNecessary.ToString();
        }
    }
    private void CraftPlanks(int planks)
    {
        if (isWorkBanchReady && isItMyWood) 
        {
            isItMyWood = false;
            ResourceEventManager.SendCraftPlank(planks);
        }
    }
}
