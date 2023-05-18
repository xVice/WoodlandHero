// Ticksystem.cs contents

using System;
using UnityEngine;

public class TickSystem : MonoBehaviour
{
    private TickEvent tickEvent;
    public float tickRate = 0.1f;
    private float timer = 0f;

    private void Awake()
    {
        tickEvent = new TickEvent();
    }

    public void Register(ITickable tickable)
    {
        tickEvent.OnTick += tickable.Tick;
    }

    public void Unregister(ITickable tickable)
    {
        tickEvent.OnTick -= tickable.Tick;
    }

    private void Update()
    {
        timer += Time.deltaTime;
        if (timer >= tickRate)
        {
            tickEvent.Invoke();
            timer = 0f;
        }
    }
}

public class TickEvent
{
    public event Action OnTick;

    public void Invoke()
    {
        OnTick?.Invoke();
    }
}

public interface ITickable
{
    void Tick();
}