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
		sHealthPotionSprite,
		mHealthPotionSprite,
		lHealthPotionSprite,
		sManaPotionSprite,
		mManaPotionSprite,
		lManaPotionSprite,
		Stick,
    }

    public ItemType itemType;
    public int amount;

    public Sprite GetSprite()
    {
        switch(itemType)
        {
            default:
            case ItemType.Weapon:                       return ItemAssets.Instance.weaponSprite;
            case ItemType.Coin:                         return ItemAssets.Instance.coinSprite;
            case ItemType.sHealthPotionSprite:          return ItemAssets.Instance.sHealthPotionSprite;
			case ItemType.mHealthPotionSprite:          return ItemAssets.Instance.mHealthPotionSprite;
			case ItemType.lHealthPotionSprite:          return ItemAssets.Instance.lHealthPotionSprite;
			case ItemType.sManaPotionSprite:            return ItemAssets.Instance.sManaPotionSprite;
			case ItemType.mManaPotionSprite:            return ItemAssets.Instance.mManaPotionSprite;
			case ItemType.lManaPotionSprite:            return ItemAssets.Instance.lManaPotionSprite;
			case ItemType.Stick:                        return ItemAssets.Instance.stickSprite;
        }
    }

    public bool IsStackable()
    {
        switch(itemType)
        {
            default:
            case ItemType.Coin:
            case ItemType.sHealthPotionSprite:
            case ItemType.mHealthPotionSprite:
            case ItemType.lHealthPotionSprite:
			case ItemType.sManaPotionSprite:
			case ItemType.mManaPotionSprite:
			case ItemType.lManaPotionSprite:
			case ItemType.Stick:
                return true;
            case ItemType.Weapon: 
                return false;
        }
    }

    public bool CanUse()
    {
        switch(itemType)
        {
            default:
			case ItemType.sHealthPotionSprite:
			case ItemType.mHealthPotionSprite:
			case ItemType.lHealthPotionSprite:
			case ItemType.sManaPotionSprite:
			case ItemType.mManaPotionSprite:
			case ItemType.lManaPotionSprite:
                return true;
            case ItemType.Stick:
            case ItemType.Coin:
                return false;
		}
    }
 
}
