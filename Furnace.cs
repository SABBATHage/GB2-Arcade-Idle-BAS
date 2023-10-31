using TMPro;
using UnityEngine;

public class Furnace : MonoBehaviour
{
    private bool isFurnaceReady = false;
    private bool isWoodEnough = false;
    private bool isStounEnough = false;
    private bool isItMyWood = false;
    private bool isItMyStoun = false;
    [SerializeField] private GameObject contructionPlace;
    [SerializeField] private GameObject furnace;
    [SerializeField] private GameObject helpMessageToCraftFurnace;
    [SerializeField] private GameObject helpMessageToCraftIron;
    [SerializeField] private GameObject resourceCostPanel;
    [SerializeField] private TextMeshProUGUI woodText;
    [SerializeField] private TextMeshProUGUI stounText;
    [SerializeField] private int woodNecessary = 2;
    [SerializeField] private int stounNecessary = 4;
    private void Awake()
    {
        ResourceEventManager.DecreaseWood.AddListener(WoodToFurnace);
        ResourceEventManager.DecreaseStoun.AddListener(StounToFurnace);
        ResourceEventManager.DecreaseStoun.AddListener(CraftIron);
    }
    void Start()
    {
        woodText.text = woodNecessary.ToString();
        stounText.text = stounNecessary.ToString();
    }
    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && isFurnaceReady)
        {
            if (Input.GetKey(KeyCode.E))
            {
                isItMyStoun = true;
                ResourceEventManager.SendPayStouns(1);
            }
        }

        if (other.CompareTag("Player") && !isFurnaceReady)
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
        if (other.CompareTag("Player") && isFurnaceReady)
        {
            helpMessageToCraftIron.SetActive(true);
        }
        if (other.CompareTag("Player") && !isFurnaceReady)
        {
            helpMessageToCraftFurnace.SetActive(true);
            resourceCostPanel.SetActive(true);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            helpMessageToCraftIron.SetActive(false);
            helpMessageToCraftFurnace.SetActive(false);
            resourceCostPanel.SetActive(false);
        }
    }
    private void CraftFurnace()
    {
        if (isWoodEnough && isStounEnough)
        {
            contructionPlace.SetActive(false);
            furnace.SetActive(true);
            resourceCostPanel.SetActive(false);
            isFurnaceReady = true;
            QuestEventManager.SendFurnaceComplete(true);
        }
    }
    private void WoodToFurnace(int wood)
    {
        if (!isWoodEnough && !isFurnaceReady && isItMyWood)
        {
            woodNecessary -= wood;
            isItMyWood = false;
            if (woodNecessary <= 0)
            {
                isWoodEnough = true;
                CraftFurnace();
            }
            woodText.text = woodNecessary.ToString();
        }
    }
    private void StounToFurnace(int stoun)
    {
        if (!isStounEnough && !isFurnaceReady && isItMyStoun)
        {
            stounNecessary -= stoun;
            isItMyStoun = false;
            if (stounNecessary <= 0)
            {
                isStounEnough = true;
                CraftFurnace();
            }
            stounText.text = stounNecessary.ToString();
        }
    }
    private void CraftIron(int stoun)
    {
        if (isFurnaceReady && isItMyStoun)
        {
            isItMyStoun = false;
            ResourceEventManager.SendCraftIron(stoun);
        }
    }
}
