using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Statue : MonoBehaviour
{
    public float total_health = 100;
    public float current_health;
    private float health_scale_total;
    public GameObject health_bar;

    // Start is called before the first frame update
    void Start()
    {
        current_health = total_health;
        health_bar = this.transform.GetChild(1).gameObject;
        health_scale_total = health_bar.transform.localScale.x;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void TakeDamage(float _damage)
    {
        if (current_health <= 0) return;
        current_health -= _damage;
        health_bar.transform.localScale -= new Vector3(_damage, 0, 0);
    }
}
