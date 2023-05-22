using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class GotoOtherArea : MonoBehaviour
{
    public GameObject player;
    public Transform target;
    public float interactionDistance = 5f;
    public Animator barsAnimator;
    public CinemachineVirtualCamera cinemachineCamera;
    public string notifyText = "Press E to goto ";

    GameManager gameManager;

    private bool isTransitioning = false;

    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, interactionDistance);
    }

    private void Start()
    {

    }

    void Update()
    {
        float distance = Vector2.Distance(transform.position, player.transform.position);

        if (distance <= interactionDistance && !isTransitioning)
        {

            gameManager.Notify(true, notifyText);
            if (Input.GetKeyDown(KeyCode.E))
            {
                gameManager.Notify(false);
                StartCoroutine(TransitionToTarget());
            }
        }
        else if (distance <= interactionDistance + 0.5f)
        {
            gameManager.Notify(false);
        }
    }

    IEnumerator TransitionToTarget()
    {
        isTransitioning = true;
        

        // Trigger the closing animation
        barsAnimator.SetTrigger("Close");

        yield return new WaitForSeconds(1f); // Adjust the duration to match your animation length

        player.transform.position = target.position;

        // Trigger the opening animation
        barsAnimator.SetTrigger("Open");

        yield return new WaitForSeconds(1f); // Adjust the duration to match your animation length

        isTransitioning = false;
    }

}