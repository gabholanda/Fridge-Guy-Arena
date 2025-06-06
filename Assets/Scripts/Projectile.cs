using System.Collections;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    private Vector2 direction = new(1, 0);
    [SerializeField]
    private float speed = 3.0f;
    [SerializeField]
    protected int damage = 1;

    [SerializeField]
    private float lifeTime = 3.0f;

    private void Awake()
    {
        StartCoroutine(DestroyProjectileCoroutine());
    }

    public IEnumerator DestroyProjectileCoroutine()
    {
        yield return new WaitForSeconds(lifeTime);

        Destroy(gameObject);
    }

    public void SetDirection(Vector2 direction)
    {
        this.direction = direction;
    }

    private void Update()
    {
        transform.position += speed * Time.deltaTime * (Vector3)direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (!collision.gameObject.CompareTag("Enemy")) return;

        Destroy(collision.gameObject);
    }
}
