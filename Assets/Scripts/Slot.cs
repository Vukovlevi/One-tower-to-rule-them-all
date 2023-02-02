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
            iconImage.sprite = item.Icon;
            var color = iconImage.color;
            color.a = 1f;
            iconImage.color = color;
        }
    }

    public void decreaseItem(int removeCount)
    {
        count -= removeCount;
        countText.text = count.ToString();
        if (count == 0)
        {
            iconImage.sprite = null;
            var color = iconImage.color;
            color.a = 0f;
            iconImage.color = color;
        }
    }
}
