using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Slot : MonoBehaviour
{
    public Image iconImage;
    public Text countText;
    public int count;
    public Item item;

    public void increaseItem()
    {
        if (count + 1 <= item.StackAmount)
        {
            count++;
            countText.text = count.ToString();
        }
    }
}
