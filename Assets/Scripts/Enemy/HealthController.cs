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
        healthSlider.maxValue = bossThungRac.health;
        healthSlider.value = bossThungRac.health;
    }

    private void Update()
    {
        healthSlider.value = bossThungRac.health;
    }
}
