using System.Collections;
using System.Collections.Generic;
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

        //Debug.Log(Vector2.Distance(this.transform.position, target.position));
        if (Vector2.Distance(this.transform.position, target.position) >= 1f) return;
        StartCoroutine(ExecuteDamage());
    }

    private IEnumerator ExecuteDamage()
    {
        float time = Random.Range(minSpawnTime, maxSpawnTime);
        yield return new WaitForSeconds(time);
        target.gameObject.GetComponent<Statue>().TakeDamage(10f);
    }
}
