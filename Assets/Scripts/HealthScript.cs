using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour {
    public Image currentHealthbar;
    public Text ratioText;
    private float hitpoint = 100;
    private float maxHitpoint = 100;

    private void Start()
    {
        UpdateHealthbar();
    }

    private void UpdateHealthbar()
    {
        float ratio = hitpoint / maxHitpoint;
        currentHealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio * 100).ToString() + '%';
    }

    private void TakeDamage(float damage)
    {

    }

    private void HealDamage(float heal)
    {

    }
}
