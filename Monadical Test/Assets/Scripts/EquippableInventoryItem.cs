public class EquippableInventoryItem : InventoryItem
{
    private EquippableItemData data;

    public EquippableInventoryItem(EquippableItemData _data) : base(_data)
    {
        data = _data;
    }

    public Stats GetStats()
    {
        return data.modifiers;
    }
}