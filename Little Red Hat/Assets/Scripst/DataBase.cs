using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DataBase : MonoBehaviour
{
    public List<Item> Items = new List<Item>();
}
[System.Serializable]
public class Item {
    public int id;
    public string name;
    public Sprite img;
}
