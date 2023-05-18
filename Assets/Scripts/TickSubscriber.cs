// TickSubscriber.cs contents

using UnityEngine;

public class TickSubscriber : MonoBehaviour
{
    private void Start()
    {
        TickSystem ticksystem = FindObjectOfType<TickSystem>();
        if (ticksystem != null)
        {
            ITickable tickable = GetComponent<ITickable>();
            if (tickable != null)
            {
                ticksystem.Register(tickable);
            }
        }
    }

    private void OnDestroy()
    {
        TickSystem ticksystem = FindObjectOfType<TickSystem>();
        if (ticksystem != null)
        {
            ITickable tickable = GetComponent<ITickable>();
            if (tickable != null)
            {
                ticksystem.Unregister(tickable);
            }
        }
    }
}