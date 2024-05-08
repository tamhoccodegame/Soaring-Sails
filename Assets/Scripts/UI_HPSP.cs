using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UI_HPSP : MonoBehaviour
{
    private Slider healthBar;
    private Slider cdBar;
	[SerializeField] private PlayerController1 playerController1;

	private void Start()
	{
		
		healthBar = transform.Find("HealthBar").GetComponent<Slider>();

		if(transform.Find("CDBar"))
		{
			cdBar = transform.Find("CDBar").GetComponent<Slider>();
		}

		
	}

	private void FixedUpdate()
	{
		healthBar.value = (float) playerController1.health / 100;
		if(cdBar != null)
		{
			cdBar.value = (float)Mathf.Clamp((Mathf.Abs(playerController1.dashTime2)), 0f, 1f);
		}
		
	}
}
