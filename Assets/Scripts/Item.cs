using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "Inventory/Item")]
public class Item : ScriptableObject
{
    public string Name;
    public Sprite Icon;
    [Range(1, 999)]
    public int StackAmount;
}
