using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class UI_StatPlayerTest : MonoBehaviour
{
	public Player player;
	public PlayerController1 playerController1;
	TextMeshProUGUI healthText;
	TextMeshProUGUI speedText;
	TextMeshProUGUI damageText;

	private void Awake()
	{
		healthText = transform.Find("HealthText").GetComponent<TextMeshProUGUI>();
		speedText = transform.Find("SpeedText").GetComponent<TextMeshProUGUI>();
		damageText = transform.Find("DamageText").GetComponent<TextMeshProUGUI>();
		UpdateStatText();
	}

	public void UpdateStatText()
	{
		healthText.SetText(playerController1.health.ToString());
		speedText.SetText(playerController1.moveSpeed.ToString());
		damageText.SetText(playerController1.damage.ToString());
	}
}
