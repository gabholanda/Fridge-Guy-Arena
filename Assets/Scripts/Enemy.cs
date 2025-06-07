using System;
using System.Collections;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public Transform target;
    public float speed = 0.2f;

    [SerializeField]
    private float minSpawnTime = 2.0f;
    [SerializeField]
    private float maxSpawnTime = 12.0f;

    void Start()
    {
        target = GameObject.Find("GodessStatue").transform;
    }

    void Update()
    {
        if (!target) return;
        this.transform.position = Vector2.LerpUnclamped(this.transform.position, target.position, this.speed * Time.deltaTime);
    }


    float trigger_damage = 0;
    void OnCollisionStay2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Target")) return;
        trigger_damage += Time.fixedDeltaTime;
        if (Math.Ceiling(trigger_damage) % 6 == 0)
        {
            trigger_damage = 0.1f;
            target.gameObject.GetComponent<Statue>().TakeDamage(10f);
        }
    }

}
