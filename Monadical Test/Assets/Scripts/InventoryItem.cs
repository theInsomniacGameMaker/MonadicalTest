public class InventoryItem
{
    private ItemData data;
    
    public ItemData Data
    {
        get => data;
        set => data = value;
    }
    public int stackCount = 0;

    public InventoryItem(ItemData _data)
    {
        Data = _data;
    }
    
    public void AddToStack()
    {
        stackCount++;
    }

    public void RemoveFromStack()
    {
        stackCount--;
    }
}