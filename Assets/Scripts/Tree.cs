using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(TickSubscriber))]
public class Tree : MonoBehaviour, ITickable
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Tick()
    {
        Debug.Log("Sex");
    }
}
