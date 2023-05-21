using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public GameObject Player;
    public GameObject bars;
    public GameObject FireAlertHolder;

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

    public void PlaySound(string name)
    {
        audio.PlayOneShot(Resources.Load<AudioClip>($"Sounds/{name}"));
    }

    public void SetFireAlert(bool state)
    {
        FireAlertHolder.SetActive(state);
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
            { TreeType.Oak, new TreeProperties(30, 2500) },
            { TreeType.Pine, new TreeProperties(35, 3000) },
            { TreeType.Maple, new TreeProperties(40, 3500) },
            { TreeType.Birch, new TreeProperties(45, 4000) },
            { TreeType.Cedar, new TreeProperties(50, 4500) },
            { TreeType.Ash, new TreeProperties(55, 5000) },
            { TreeType.Beech, new TreeProperties(60, 5500) },
            { TreeType.Willow, new TreeProperties(65, 6000) },
            { TreeType.Elm, new TreeProperties(70, 6500) },
            { TreeType.Spruce, new TreeProperties(75, 7000) },
            { TreeType.Poplar, new TreeProperties(80, 7500) },
            { TreeType.Fir, new TreeProperties(85, 8000) },
            { TreeType.Sycamore, new TreeProperties(90, 8500) },
            { TreeType.Cherry, new TreeProperties(95, 9000) },
            { TreeType.Magnolia, new TreeProperties(100, 9500) },
            { TreeType.Redwood, new TreeProperties(105, 10000) },
            { TreeType.Sequoia, new TreeProperties(110, 10500) },
            { TreeType.Cypress, new TreeProperties(115, 11000) },
            { TreeType.Hemlock, new TreeProperties(120, 11500) },
            { TreeType.Walnut, new TreeProperties(125, 12000) },
            { TreeType.Mahogany, new TreeProperties(130, 12500) },
            { TreeType.Palm, new TreeProperties(135, 13000) },
            { TreeType.Ginkgo, new TreeProperties(140, 13500) },
            { TreeType.Dogwood, new TreeProperties(145, 14000) },
            { TreeType.Olive, new TreeProperties(150, 14500) },
            { TreeType.Apple, new TreeProperties(155, 15000) },
            { TreeType.Pear, new TreeProperties(160, 15500) },
            { TreeType.Lemon, new TreeProperties(165, 16000) },
            { TreeType.Orange, new TreeProperties(170, 16500) },
            { TreeType.Banana, new TreeProperties(175, 17000) },
            { TreeType.Eucalyptus, new TreeProperties(180, 17500) },
            { TreeType.WillowOak, new TreeProperties(185, 18000) },
            { TreeType.Alder, new TreeProperties(190, 18500) },
            { TreeType.BlackCherry, new TreeProperties(195, 19000) },
            { TreeType.BlackWalnut, new TreeProperties(200, 19500) },
            { TreeType.DouglasFir, new TreeProperties(205, 20000) },
            { TreeType.EasternHemlock, new TreeProperties(210, 20500) },
            { TreeType.Hickory, new TreeProperties(215, 21000) },
            { TreeType.Juniper, new TreeProperties(220, 21500) },
            { TreeType.Linden, new TreeProperties(225, 22000) },
            { TreeType.Pecan, new TreeProperties(230, 22500) },
            { TreeType.RedMaple, new TreeProperties(235, 23000) },
            { TreeType.SilverBirch, new TreeProperties(240, 23500) },
            { TreeType.WhitePine, new TreeProperties(245, 24000) },
            { TreeType.Yew, new TreeProperties(250, 24500) },
            { TreeType.Sassafras, new TreeProperties(255, 25000) },
            { TreeType.SugarMaple, new TreeProperties(260, 25500) },
            { TreeType.WhiteOak, new TreeProperties(265, 26000) },
            { TreeType.YellowPoplar, new TreeProperties(270, 26500) }
        };
    }
}

public enum TreeType
{
    Oak,
    Pine,
    Maple,
    Birch,
    Cedar,
    Ash,
    Beech,
    Willow,
    Elm,
    Spruce,
    Poplar,
    Fir,
    Sycamore,
    Cherry,
    Magnolia,
    Redwood,
    Sequoia,
    Cypress,
    Hemlock,
    Walnut,
    Mahogany,
    Palm,
    Ginkgo,
    Dogwood,
    Olive,
    Apple,
    Pear,
    Lemon,
    Orange,
    Banana,
    Eucalyptus,
    WillowOak,
    Alder,
    BlackCherry,
    BlackWalnut,
    DouglasFir,
    EasternHemlock,
    Hickory,
    Juniper,
    Linden,
    Pecan,
    RedMaple,
    SilverBirch,
    WhitePine,
    Yew,
    Sassafras,
    SugarMaple,
    WhiteOak,
    YellowPoplar
}
