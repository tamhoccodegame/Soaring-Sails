using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Item
{
    public enum ItemType
    {
        Weapon,
        Coin,
        Medkit,
        Stick,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch(itemType)
        {
            default:
            case ItemType.Weapon:         return ItemAssets.Instance.weaponSprite;
            case ItemType.Coin:           return ItemAssets.Instance.coinSprite;
            case ItemType.Medkit:         return ItemAssets.Instance.medkitSprite;
            case ItemType.Stick:          return ItemAssets.Instance.stickSprite;
        }
    }

    public bool IsStackable()
    {
        switch(itemType)
        {
            default:
            case ItemType.Coin:
            case ItemType.Medkit: 
            case ItemType.Stick:
                return true;
            case ItemType.Weapon: 
                return false;
        }
    }
 
}
