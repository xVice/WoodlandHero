using Cinemachine;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

[RequireComponent(typeof(TickSubscriber))]
public class Tree : MonoBehaviour, ITickable
{
    public TreeType type = TreeType.Oak;
    public int tickToGrow = 2000;
    public int currentTick = 0;
    public int moneyReward = 25;
    public int burnTick = 250;
    public int currentBurnTick = 0;
    public float fireSpreadRange = 3f;
    public ParticleSystem flameParticles;

    public float growthRate = 0.01f; // The rate at which the tree grows per tick

    private GameObject player;
    private Vector3 initialScale;
    private Vector3 targetScale;
    private bool isGrowing = false;
    private bool isGrown = false;
    private bool isBurning = false;

    CinemachineVirtualCamera vcam;
    GameManager gameManager;
    Item item;
    AudioSource audio;

    private void Awake()
    {
        gameManager = FindAnyObjectByType<GameManager>();
        audio = gameObject.GetComponent<AudioSource>();
        player = gameManager.Player;
        initialScale = transform.localScale;
        targetScale = initialScale * 5f; // Increase the scale to twice the initial size
    }

    public bool GetBurning()
    {
        return isBurning;
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, transform.localScale.x + fireSpreadRange);
    }

    public void SetupTree(TreeType type, Item item)
    {
        this.type = type;
        this.item = item;
        // Retrieve tree properties based on the tree type
        TreeProperties properties = gameManager.TreeProperties[type];
        moneyReward = properties.moneyReward;
        tickToGrow = properties.tickToGrow;
        gameObject.GetComponent<SpriteRenderer>().sprite = item.previewImage;
        Debug.Log($"Tree is now a {type}, and rewards {moneyReward} coins, grow time is {tickToGrow} ticks");

        // Start growing the tree
        StartGrowing();
    }

    public void IgniteSilent()
    {
        isBurning = true;
        flameParticles.Play();
        audio.Play();
    }

    public void Ignite()
    {
        // Move the virtual camera smoothly to the tree
        vcam = FindObjectOfType<CinemachineVirtualCamera>();
        StartCoroutine(MoveCameraToTree());

        IEnumerator MoveCameraToTree()
        {
            gameManager.PlaySound("alarm");
            gameManager.SetFireAlert(true);
            gameManager.ToggleBars(false);
            vcam.Follow = gameObject.transform;
            vcam.LookAt = gameObject.transform;

            // Start the particles and set the bool to true
            isBurning = true;
            flameParticles.Play();
            audio.Play();

            yield return new WaitForSeconds(2);

            gameManager.SetFireAlert(false);
            vcam.Follow = player.gameObject.transform;
            vcam.LookAt = player.gameObject.transform;
            gameManager.ToggleBars(true);
        }
    }

    public void HarvestTree()
    {
        if (isGrown)
        {
            isGrown = false;
            gameManager.Inventory.AddItemsWithID(gameManager.ItemManager.GetWoodTypeTuple(type).Item2.id, 3);
            gameManager.MoneyManager.AddCoins(moneyReward);
            Destroy(gameObject);
        }
    }

    public void Extinguish()
    {
        isBurning = false;
    }

    public void Tick()
    {
        if (isBurning)
        {
            currentBurnTick++;
            if(currentBurnTick > burnTick)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, transform.localScale.x + fireSpreadRange);
                List<Tree> treesInRange = new List<Tree>();

                foreach (Collider2D collider in colliders)
                {
                    if (collider.CompareTag("Tree"))
                    {
                        Tree obj = collider.GetComponent<Tree>();
                        treesInRange.Add(obj);
                    }
                }

                Tree[] nonBurningTrees = treesInRange.Where(x => !x.GetBurning()).ToArray();

                if (nonBurningTrees.Length >0)
                {
                    Tree randomTree = nonBurningTrees[UnityEngine.Random.Range(0, nonBurningTrees.Length)];
                    randomTree.IgniteSilent();
                }

                Destroy(gameObject);
            }
        }
        else
        {
            flameParticles.Stop();
            audio.Stop();
        }

        if (isGrowing)
        {
            if (currentTick < tickToGrow)
            {
                currentTick++;
                // Update the scale of the tree
                float t = (float)currentTick / tickToGrow;
                transform.localScale = Vector3.Lerp(initialScale, targetScale, t);
            }
            else
            {
                Debug.Log("Tree fully grown");
                isGrowing = false;
                isGrown = true;
            }
        }
    }

    private void StartGrowing()
    {
        isGrowing = true;
        currentTick = 0;
    }
}


public class TreeProperties
{
    public int moneyReward;
    public int tickToGrow;

    public TreeProperties(int moneyReward, int tickToGrow)
    {
        this.moneyReward = moneyReward;
        this.tickToGrow = tickToGrow;
    }
}


