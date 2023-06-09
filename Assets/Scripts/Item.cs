﻿using System;
using System.Collections.Generic;
using UnityEngine;
public class ItemData
{
    private Dictionary<string, object> data = new Dictionary<string, object>();
    private MonoBehaviour context;

    public ItemData(MonoBehaviour context)
    {
        this.context = context;
    }

    public void SetContext(MonoBehaviour context)
    {
        this.context = context;
    }

    public void AddData(string key, object value)
    {
        if (!data.ContainsKey(key))
            data.Add(key, value);
        else
            data[key] = value;
    }

    public T GetData<T>(string key)
    {
        if (data.ContainsKey(key))
        {
            try
            {
                return (T)data[key];
            }
            catch (InvalidCastException)
            {
                Debug.LogError($"Invalid cast when retrieving data with key '{key}'.");
            }
        }
        else
        {
            Debug.LogError($"Data with key '{key}' does not exist.");
            Debug.LogError($"The type that wasn't found is: {typeof(T)}");
            Debug.LogError($"The file that couldn't find the data is '{context.gameObject.name}'.");
        }

        return default(T);
    }

    public bool ContainsData(string key)
    {
        return data.ContainsKey(key);
    }

    public void RemoveData(string key)
    {
        if (data.ContainsKey(key))
            data.Remove(key);
        else
            Debug.LogError($"Data with key '{key}' does not exist.");
    }
}


public class Item
{
    public int id = 0;
    public string name = "empty";
    public string description = "empty";
    public Sprite previewImage = Resources.Load<Sprite>("Sprites/Default");
    public int amount = 1;
    public int usesLeft = 1;
    public ItemData data;

    public Item(ItemData data, Sprite previewImage, int id = 0, string name = "empty", string description = "empty", int amount = 1, int usesLeft = 64)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.amount = amount;
        this.usesLeft = usesLeft;
        this.previewImage = previewImage;
        this.data = data;
    }

    public Item(ItemData data)
    {
        this.id = 0;
        this.name = "empty";
        this.description = "empty";
        this.amount = 0;
        this.usesLeft = 0;
        this.previewImage = Resources.Load<Sprite>("Sprites/Default");
        this.data = data;
    }
}
