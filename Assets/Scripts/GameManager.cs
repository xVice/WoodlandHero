using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject bars;
    public GameObject FireAlertHolder;
    public GameObject SellModeHolder;


    public ItemManager ItemManager;
    public Inventory Inventory;
    public MoneyManager MoneyManager;
    public Shop Shop;
    public SignUI Sign;
    public Dictionary<TreeType, TreeProperties> TreeProperties;
    public AudioSource audio;
    // Start is called before the first frame update
    void Awake()
    {
        audio = FindObjectOfType<AudioSource>();
        ItemManager = FindObjectOfType<ItemManager>();
        Inventory = FindObjectOfType<Inventory>();
        MoneyManager = FindObjectOfType<MoneyManager>();
        Shop = FindObjectOfType<Shop>();
        Sign = FindObjectOfType<SignUI>();
        WarmTreeTypes();

    }

    public void PlaySound(string name, float vol = .25f)
    {
        audio.PlayOneShot(Resources.Load<AudioClip>($"Sounds/{name}"), vol);
    }

    public void SetFireAlert(bool state)
    {
        FireAlertHolder.SetActive(state);
    }

    public void SetSellModeAlert(bool state)
    {
        SellModeHolder.SetActive(state);
    }


    public void ToggleBars(bool state)
    {
        bars.SetActive(state);
    }

    public void DisplaySign(string text)
    {
        Sign.gameObject.SetActive(true);
        Sign.DisplaySign(text);
    }

    private void WarmTreeTypes()
    {
        TreeProperties = new Dictionary<TreeType, TreeProperties>()
        {
            { TreeType.Oak, new TreeProperties(30, 750) },
            { TreeType.Pine, new TreeProperties(35, 1500) },
            { TreeType.Birch, new TreeProperties(45, 2000) },
            { TreeType.Cedar, new TreeProperties(50, 2300) },
            { TreeType.Ash, new TreeProperties(55, 5000) },
            { TreeType.Spruce, new TreeProperties(75, 7000) },
            { TreeType.Sycamore, new TreeProperties(90, 8500) },
            { TreeType.Cherry, new TreeProperties(95, 9000) },
            { TreeType.Magnolia, new TreeProperties(100, 9500) },
            { TreeType.Redwood, new TreeProperties(105, 10000) },
            { TreeType.Cypress, new TreeProperties(115, 11000) },
            { TreeType.Walnut, new TreeProperties(125, 12000) },
            { TreeType.Palm, new TreeProperties(135, 13000) },
            { TreeType.Eucalyptus, new TreeProperties(180, 17500) },
        };
    }
}

public enum TreeType
{
    Oak,
    Birch,
    Ash,
    Bamboo,
    Cedar,
    Cherry,
    Cypress,
    Eucalyptus,
    Magnolia,
    Palm,
    Pine,
    Redwood,
    Spruce,
    Sycamore,
    Walnut
}
