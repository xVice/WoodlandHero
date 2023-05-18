using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

public class Item
{
    public int id = 0;
    public string name = "empty";
    public string description = "empty";
    public Sprite previewImage = Resources.Load<Sprite>("Sprites/Default");
    public int ammount = 1;
    public int usesLeft = 1;


    public Item(Sprite previewImage, int id = 0, string name = "empty", string description = "empty", int ammount = 1, int usesLeft = 64)
    {
        this.id = id;
        this.name = name;
        this.description = description;
        this.ammount = ammount;
        this.usesLeft = usesLeft;
        this.previewImage = previewImage;
    }

    public Item()
    {
        this.id = 0;
        this.name = "empty";
        this.description = "empty";
        this.ammount = 0;
        this.usesLeft = 0;
        this.previewImage = Resources.Load<Sprite>("Sprites/Default");
    }
}

