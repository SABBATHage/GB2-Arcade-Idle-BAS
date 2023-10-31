using UnityEngine.Events;

public class ResourceEventManager
{
    public static UnityEvent<int>StounMining = new UnityEvent<int>();
    public static UnityEvent<int>TreeCutting = new UnityEvent<int>();
    public static UnityEvent<int>StounPay = new UnityEvent<int>();
    public static UnityEvent<int>WoodPay = new UnityEvent<int>();
    public static UnityEvent<int>DecreaseWood = new UnityEvent<int>();
    public static UnityEvent<int>DecreaseStoun = new UnityEvent<int>();
    public static UnityEvent<int>CraftPlank = new UnityEvent<int>();
    public static UnityEvent<int>CraftIron = new UnityEvent<int>();

    public static void SendMinigStouns(int mining)
    {
        StounMining.Invoke(mining);
    }
    public static void SendCuttingTrees(int tree)
    {
        TreeCutting.Invoke(tree);
    }
    public static void SendPayStouns(int stounCost)
    {
        StounPay.Invoke(stounCost);
    }
    public static void SendPayWood(int woodCost)
    {
        WoodPay.Invoke(woodCost);
    }
    public static void SendDecreaseWood(int decreaseWood) 
    {
        DecreaseWood.Invoke(decreaseWood);
    }
    public static void SendDecreaseStoun(int decreaseStoun)
    {
        DecreaseStoun.Invoke(decreaseStoun);
    }
    public static void SendCraftPlank(int craftPlank)
    {
        CraftPlank.Invoke(craftPlank);
    }
    public static void SendCraftIron(int craftIron)
    {
        CraftIron.Invoke(craftIron);
    }
}
