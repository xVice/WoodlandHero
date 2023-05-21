using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
public class DebugUI : MonoBehaviour
{
    private bool isWindowOpen = false;
    private Rect windowRect = new Rect(10, 10, 500, 400); // Initial position and size of the window
    private Vector2 scrollPosition = Vector2.zero;

    GameManager GameManager;

    int addamount = 1;
    int usesLeft = 64;

    private void Awake()
    {
        GameManager = FindObjectOfType<GameManager>();
    }

    private void OnGUI()
    {
        if (isWindowOpen)
        {
            GUI.Window(0, windowRect, DrawInventoryWindow, "Inventory Adder");
        }
    }

    private void DrawInventoryWindow(int windowID)
    {
        scrollPosition = GUILayout.BeginScrollView(scrollPosition, GUILayout.Width(480), GUILayout.Height(400));

        foreach (Item item in GameManager.ItemManager.items)
        {
            GUILayout.BeginHorizontal();
            GUILayout.Box(item.previewImage.texture, GUILayout.Width(50), GUILayout.Height(50));
            GUILayout.BeginVertical();

            if (GUILayout.Button(item.name))
            {
                GameManager.Inventory.AddItemsWithID(item.id, addamount, usesLeft);
            }

            GUILayout.Label(item.description);

            GUILayout.BeginHorizontal();
            GUILayout.Label("Id:");
            GUILayout.Label(item.id.ToString());

            GUILayout.Label("Amount:");
            addamount = int.Parse(GUILayout.TextField(addamount.ToString()));

            GUILayout.Label("Uses Left:");
            usesLeft = int.Parse(GUILayout.TextField(usesLeft.ToString()));

            GUILayout.EndHorizontal();

            GUILayout.EndVertical();
            GUILayout.EndHorizontal();

            GUILayout.Space(10);
        }

        GUILayout.EndScrollView();

        GUI.DragWindow();
    }


    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.F8))
        {
            isWindowOpen = !isWindowOpen;
        }
    }

    private void AddItemToPlayerInventory(int itemID)
    {
        GameManager.Inventory.AddItemsWithID(itemID, addamount, usesLeft);
        Debug.Log("Adding item to player's inventory: " + itemID);
    }
}
