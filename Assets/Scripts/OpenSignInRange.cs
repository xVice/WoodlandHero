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

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green;
        Gizmos.DrawWireSphere(transform.position, range);
        Gizmos.DrawWireSphere(transform.position, range + 10f);
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
        else if(sign != null && sign.isActiveAndEnabled && distance <= range + 10f)
        {
            sign.DisableSign();
        }
    }
}
