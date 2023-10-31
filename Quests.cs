using UnityEngine;

public class Quests : MonoBehaviour
{
    [SerializeField] private GameObject firstQuestText;
    [SerializeField] private GameObject secondQuestText;
    [SerializeField] private GameObject completeGamePanel;
    [SerializeField] private int planksToSecondQ;
    [SerializeField] private int ironsToSecondQ;
    private bool woodBranchChek = false;
    private bool furnaceChek = false;
    private bool isPlanksEnought = false;
    private bool isIronEnought = false;
    private int planks = 0;
    private int irons = 0;

    private void Awake()
    {
        QuestEventManager.WoodBranchComplete.AddListener(WoodBranchChek);
        QuestEventManager.FurnaceComplete.AddListener(FurnaceChek);
        ResourceEventManager.CraftPlank.AddListener(PlanksCounter);
        ResourceEventManager.CraftIron.AddListener(IronCounter);
    }
    private void WoodBranchChek(bool chek)
    {
        woodBranchChek = chek;
        FirstQuestComplete();
    }
    private void FurnaceChek(bool chek)
    {
        furnaceChek = chek;
        FirstQuestComplete();
    }
    private void FirstQuestComplete()
    {
        if (woodBranchChek && furnaceChek) 
        {
            firstQuestText.SetActive(false);
            secondQuestText.SetActive(true);            
        }
    }
    private void PlanksCounter(int plank)
    {
        planks += plank;
        if (planks >= planksToSecondQ)
        {
            isPlanksEnought = true;
            SecondQuestComplete();
        }
    }
    private void IronCounter(int iron)
    {
        irons += iron;
        if (irons >= ironsToSecondQ)
        {
            isIronEnought = true;
            SecondQuestComplete();
        }
    }
    private void SecondQuestComplete()
    {
        if (isPlanksEnought && isIronEnought)
        {
            secondQuestText.SetActive(false);
            completeGamePanel.SetActive(true);
        }
    }
}
