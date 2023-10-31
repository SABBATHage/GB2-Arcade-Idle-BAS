using UnityEngine.Events;

public class QuestEventManager
{
    public static UnityEvent<bool> WoodBranchComplete = new UnityEvent<bool>();
    public static UnityEvent<bool> FurnaceComplete = new UnityEvent<bool>();

    public static void SendBranchComplete(bool ready)
    {
        WoodBranchComplete.Invoke(ready);
    }
    public static void SendFurnaceComplete(bool ready)
    {
        FurnaceComplete.Invoke(ready);
    }
}
