using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ItemAssets : MonoBehaviour
{
	public static ItemAssets Instance { get; private set; }

	private void Awake()
	{
		Instance = this;
	}

	public Transform pfItemWorld;

	public Sprite weaponSprite;
	public Sprite coinSprite;
	public Sprite stickSprite;

	public Sprite sHealthPotionSprite;
	public Sprite mHealthPotionSprite;
	public Sprite lHealthPotionSprite;

	public Sprite sManaPotionSprite;
	public Sprite mManaPotionSprite;
	public Sprite lManaPotionSprite;

}
