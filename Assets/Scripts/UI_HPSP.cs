using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HPSP : MonoBehaviour
{
    private Slider healthBar;
    private Slider spBar;
	[SerializeField] private PlayerController1 playerController1;

	private void Start()
	{
		healthBar = transform.Find("HealthBar").GetComponent<Slider>();
		Transform tmp = transform.Find("SPBar");
		if(tmp != null)
		{
			spBar = tmp.GetComponent<Slider>();
		}

	}

	private void FixedUpdate()
	{
		healthBar.value = (float) playerController1.health / 100;
		if(spBar != null) spBar.value = .1f;
	}
}
