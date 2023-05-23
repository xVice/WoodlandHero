using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuyOtherIsland : MonoBehaviour
{

    public float interactionDistance = 3f;
    public int price = 150;
    public bool isBougth = false;

    public BoxCollider2D box;

    GameManager gameManager;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, interactionDistance);
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, interactionDistance + 0.5f);
    }


    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, gameManager.Player.transform.position);

        if (distance <= interactionDistance && isBougth == false)
        {
            gameManager.Notify(true, $"Press the F key to buy the island for {price} coins.");
            if (Input.GetKeyDown(KeyCode.F) && gameManager.MoneyManager.HasEnoughCoins(price))
            {
                isBougth = true;
                gameManager.MoneyManager.RemoveCoins(price);
                gameManager.Notify(false);
                box.enabled = false;
            }
        }
        else if (distance <= interactionDistance + 0.5f)
        {
            gameManager.Notify(false);
        }
    }
}
