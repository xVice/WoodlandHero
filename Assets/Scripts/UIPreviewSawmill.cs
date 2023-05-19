using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIPreviewSawmill : MonoBehaviour
{
    public Item item;

    public Image displayImage;
    public TextMeshProUGUI ItemNameLabel;
    public TextMeshProUGUI ItemAmountLabel;

    public void SetItem(Item item)
    {
        this.item = item;
        ItemNameLabel.text = item.name;
        ItemAmountLabel.text = item.amount.ToString();
        displayImage.sprite = item.previewImage;
    }

    public void ReDraw()
    {
        ItemNameLabel.text = item.name;
        ItemAmountLabel.text = item.amount.ToString();
        displayImage.sprite = item.previewImage;
    }
}
