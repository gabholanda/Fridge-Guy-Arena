using System;
using UnityEngine;
using UnityEngine.UIElements;

public class Statue : MonoBehaviour
{
    public float current_health;
    public float total_health = 100;
    public float current_scale;
    private float health_scale_total;

    public GameObject health_bar;

    void Start()
    {
        current_health = total_health;
        health_bar = this.transform.GetChild(1).gameObject;
        health_scale_total = health_bar.transform.localScale.x;
    }

    public void TakeDamage(float _damage)
    {
        if (current_health <= 0) return;
        current_health -= _damage;
        float current = health_scale_total * current_health / total_health;
        if (health_bar.transform.localScale.x - current <= 0) return;
        health_bar.transform.localScale = new Vector3(current, 1, 1);
    }
}
