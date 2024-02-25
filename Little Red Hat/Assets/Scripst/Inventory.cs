using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class Inventory : MonoBehaviour
{
    public DataBase date;
    public List<ItemInventory> items = new List<ItemInventory>();
    public GameObject gameObjectShow;
    public GameObject inventoryMainObject;
    public int maxCount;
    public Camera cam;
    public EventSystem es;
    public int currentID;
    public ItemInventory currentItem;
    public RectTransform movingObject;
    public Vector3 offset;
    public GameObject backGroung;
    public Button InventoryButton;
    public void Start()
    {
        InventoryButton.onClick.AddListener(delegate {
            backGroung.SetActive(!backGroung.activeSelf);
            if (backGroung.activeSelf)
            {
                UpdateInventory();
            }
        });
        if (items.Count == 0) {
            AddGraphics();
        }
        for (int i = 0; i < maxCount;++i) {
            AddItem(i, date.Items[Random.Range(0, date.Items.Count)], Random.Range(1, 99));
        }
        UpdateInventory();
    }
    public void Update()
    {
        if (currentID == -1) {
            MoveObject();
        }
        if(InventoryButton.GetComponent<EventTrigger>())
       /////stugel if(backGroung)
        {
            UpdateInventory();
        }
    }
    public void SearchForSameItems(Item itm, int count) {
        for (int i = 0; i < maxCount; ++i) {
            if (items[i].id == itm.id) {
                if (items[i].count < 128) {
                    items[i].count += count;
                    if (items[i].count > 128)
                    {
                        count = items[i].count - 128;
                        items[i].count = 64;
                    }
                    else {
                        count = 0;
                    }
                }
            }
        }
        if (count > 0) {
            for (int i = 0; i < maxCount; ++i)
            {
                if (items[i].id == 0) {
                    AddItem(i, itm, count);
                    i = maxCount;
                }
            }
        }
    }
    public void AddItem(int id, Item item, int count) {
        items[id].id = item.id;
        items[id].count = count;
        items[id].itemGameObj.GetComponent<Image>().sprite = item.img;////ste ushadir
        if (count > 1 && item.id != 0)
        {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = count.ToString();
        }
        else {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = "";
        }
    }
    public void AddInventoryItem(int id, ItemInventory InvItem)
    {
        items[id].id = InvItem.id;
        items[id].count = InvItem.count;
        items[id].itemGameObj.GetComponent<Image>().sprite = date.Items[InvItem.id].img;
        if (InvItem.count > 1 && InvItem.id != 0)
        {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = InvItem.count.ToString();
        }
        else
        {
            items[id].itemGameObj.GetComponentInChildren<Text>().text = "";
        }
    }
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
            tempButton.onClick.AddListener(delegate { SelectObject(); });
            items.Add(ii);
        }
    }
    public void UpdateInventory()
    {
        for(int i = 0; i < maxCount; i++)
        {
            if (items[i].id != 0 && items[i].count > 1)
            {
                items[i].itemGameObj.GetComponentInChildren<Text>().text = items[i].count.ToString();
            }
            else {
                items[i].itemGameObj.GetComponentInChildren<Text>().text = "";
            }
            items[i].itemGameObj.GetComponent<Image>().sprite = date.Items[items[i].id].img;
        }
            
                
     }
    public void SelectObject() {
        if (currentID == -1)
        {
            currentID = int.Parse(es.currentSelectedGameObject.name);
            currentItem = CopyInventoryItem(items[currentID]);
            movingObject.gameObject.SetActive(true);
            movingObject.GetComponent<Image>().sprite = date.Items[currentItem.id].img;
            AddItem(currentID,date.Items[0],0);
        }
        else {
            ItemInventory II = items[int.Parse(es.currentSelectedGameObject.name)];
            if (currentItem.id != II.id)
            {
                AddInventoryItem(currentID, II);
                AddInventoryItem(int.Parse(es.currentSelectedGameObject.name), currentItem);
            }
            else {
                if (II.count + currentItem.count <= 128)
                {
                    II.count += currentItem.count;
                }
                else
                {
                    AddItem(currentID, date.Items[II.id], II.count + currentItem.count - 128);
                    II.count = 128;
                }
                II.itemGameObj.GetComponentInChildren<Text>().text = II.count.ToString();
            }
            currentID = -1;
            movingObject.gameObject.SetActive(false);
        }
    }
    public void MoveObject() {
        Vector3 pos = Input.mousePosition + offset;
        pos.z = inventoryMainObject.GetComponent<RectTransform>().position.z;
        movingObject.position = cam.ScreenToWorldPoint(pos);
    }
    public ItemInventory CopyInventoryItem(ItemInventory old)
    {
        ItemInventory New = new ItemInventory();
        New.id = old.id;
        New.itemGameObj = old.itemGameObj;
        New.count = old.count;
        return New;
    }

}
[System.Serializable]
public class ItemInventory
{
    public int id;
    public GameObject itemGameObj;
    public int count;
}
