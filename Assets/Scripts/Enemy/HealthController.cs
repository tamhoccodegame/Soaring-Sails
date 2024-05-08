using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    private Slider healthSlider;
    private BossThungRac bossThungRac;

    private void Start()
    {
        healthSlider = GetComponent<Slider>();
        bossThungRac = GameObject.FindObjectOfType<BossThungRac>();
        if (healthSlider != null)
        {
            healthSlider.maxValue = bossThungRac.health;
            healthSlider.value = bossThungRac.health;
        }
        Debug.Log(healthSlider.name);
		bossThungRac.OnBossDamaged += BossThungRac_OnBossDamaged;
		bossThungRac.OnBossDie += BossThungRac_OnBossDie;
    }

	private void BossThungRac_OnBossDie(object sender, System.EventArgs e)
	{
		this.gameObject.SetActive(false);
	}

	private void BossThungRac_OnBossDamaged(object sender, BossThungRac.OnBossDamagedEventArgs e)
	{
        healthSlider.value = e.health;
	}

}
