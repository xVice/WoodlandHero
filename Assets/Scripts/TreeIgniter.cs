using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

[RequireComponent(typeof(TickSubscriber))]
public class TreeIgniter : MonoBehaviour, ITickable
{
    public GameObject Player;
    public float ignitionRange = 100f;
    public int currentTick = 0;
    public int ignitionRate = 5000;

    GameManager gameManager;

    public void Tick()
    {
        currentTick++;
        if(currentTick > ignitionRate)
        {
            currentTick = 0;
            float distance = Vector2.Distance(transform.position, Player.transform.position);

            // Check if the distance is within the specified range
            if (distance <= ignitionRange)
            {
                Tree[] allTrees = FindObjectsOfType<Tree>();

                // Check if any trees exist in the scene
                if (allTrees.Length > 0)
                {
                    Tree[] nonBurningTrees = allTrees.Where(x => x.GetBurning() == false).ToArray();
                    // Select a random tree from the array
                    Tree randomTree = nonBurningTrees[Random.Range(0, nonBurningTrees.Length)];

                    // Call the Ignite function on the random tree
                    randomTree.Ignite();
                    ignitionRate = Random.Range(1000, 10000);
                }
                else
                {
                    Debug.Log("No trees found in the scene.");
                }
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.blue;
        Gizmos.DrawWireSphere(transform.position, ignitionRange);
    }


    private void Awake()
    {
        gameManager = FindObjectOfType<GameManager>();
    }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }
}
