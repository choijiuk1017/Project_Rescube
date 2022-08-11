using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Item", menuName = "New Item/item")]
public class Item : ScriptableObject
{
    public enum ItemType
    {   
        Weapon,
        Used,
        Food,
    }
    public string itemName;
    public ItemType itemtype;
    public Sprite itemImage;
    public GameObject itemPrefab;

    public string weaponType;

}
