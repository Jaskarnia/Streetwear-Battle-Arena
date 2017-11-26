using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player1Health : MonoBehaviour
{
    public Image currentHealthbar;
    public Text ratioText;
    public static float hitpoint = 100;
    private float maxHitpoint = 100;

    void Update()
    {
        UpdateHealthbar();
    }

    private void UpdateHealthbar()
    {
        float ratio = hitpoint / maxHitpoint;
        currentHealthbar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        ratioText.text = (ratio * 100).ToString() + '%';
    }

    public void TakeDamage(int damage)
    {
        if (hitpoint > 0)
            hitpoint -= damage;
    }

}
