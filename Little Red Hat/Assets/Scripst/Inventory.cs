using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    public List<ItemInventory> items = new List<ItemInventory>();
    public GameObject gameObjectShow;
    public GameObject inventoryMainObject;
    public int maxCount;
    public void AddGraphics() {
        for (int i = 0; i < maxCount; i++) {
            GameObject newItem = Instantiate(gameObjectShow, inventoryMainObject.transform) as GameObject;

            newItem.name = i.ToString();
            ItemInventory ii = new ItemInventory();
            ii.itemGameObj = newItem;
            RectTransform rt = newItem.GetComponent<RectTransform>();
            rt.localPosition = new Vector3(0, 0, 0);
            rt.localScale = new Vector3(1, 1, 1);
            newItem.GetComponentInChildren<Transform>().localScale = new Vector3(1, 1, 1);
            Button tempButton =  newItem.GetComponent<Button>();
        }
    }
}
[System.Serializable]
public class ItemInventory
{
    public int id;
    public GameObject itemGameObj;
    public int count;
}
