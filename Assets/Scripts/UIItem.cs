using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class UIItem : MonoBehaviour
{
    public Item item;

    public Image displayImage;
    public TextMeshProUGUI ItemNameLabel;

    public void SetItem(Item item)
    {
        this.item = item;
        ItemNameLabel.text = item.name;
        displayImage.sprite = item.previewImage;
    }
}
