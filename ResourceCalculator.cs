using UnityEngine;
using TMPro;

public class ResourceCalculator : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI woodCountText;
    [SerializeField] private TextMeshProUGUI plankCountText;
    [SerializeField] private TextMeshProUGUI stounCountText;
    [SerializeField] private TextMeshProUGUI ironCountText;

    private int woodCount = 0;
    private int plankCount = 0;
    private int stounCount = 0;
    private int ironCount = 0;
    private void Awake()
    {
        ResourceEventManager.StounMining.AddListener(StounMinig);
        ResourceEventManager.TreeCutting.AddListener(WoodCut);
        ResourceEventManager.StounPay.AddListener(StounRecycling);
        ResourceEventManager.WoodPay.AddListener(WoodRecycling);
        ResourceEventManager.CraftPlank.AddListener(CrafPlanks);
        ResourceEventManager.CraftIron.AddListener(CraftIron);
    }
    void Start()
    {
        woodCountText.text = woodCount.ToString();
        plankCountText.text = plankCount.ToString();
        stounCountText.text = stounCount.ToString();
        ironCountText.text = ironCount.ToString();
    }
    public void WoodCut(int wood)
    {
        woodCount += wood;
        woodCountText.text = woodCount.ToString();
    }
    public void StounMinig(int stoun)
    {
        stounCount += stoun;
        stounCountText.text = stounCount.ToString();
    }
    public void WoodRecycling(int wood)
    {
        if (woodCount >= wood)
        {
            woodCount -= wood;
            woodCountText.text = woodCount.ToString();
            ResourceEventManager.SendDecreaseWood(wood);
        }
    }
    public void StounRecycling(int stoun)
    {
        if (stounCount >= stoun)
        {
            stounCount -= stoun;
            stounCountText.text = stounCount.ToString();
            ResourceEventManager.SendDecreaseStoun(stoun);
        }
    }
    public void CrafPlanks(int wood)
    {
        plankCount += wood;
        plankCountText.text = plankCount.ToString();
    }
    public void CraftIron(int stoun)
    {
        ironCount += stoun;
        ironCountText.text = ironCount.ToString();
    }
}
