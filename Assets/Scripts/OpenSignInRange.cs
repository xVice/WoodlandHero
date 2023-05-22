using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenSignInRange : MonoBehaviour
{
    public string SignText = "Lorem";

    public GameObject player;

    public float range = 2f;

    GameManager gameManager;
    SignUI sign;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    public void OnDrawGizmos()
    {
        Gizmos.color = Color.cyan;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.color = Color.magenta;
        Gizmos.DrawWireSphere(transform.position, range + 0.5f);
    }

    // Start is called before the first frame update
    void Start()
    {
        sign = gameManager.Sign;
    }

    // Update is called once per frame
    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        // Check if the distance is within the specified range
        if (distance <= range)
        {
            if (Input.GetKey(KeyCode.F))
            {
                gameManager.DisplaySign(SignText);
            }
        }
        else if(sign != null && sign.isActiveAndEnabled && distance <= range + 0.5f)
        {
            sign.DisableSign();
        }
    }
}
