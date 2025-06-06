using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Cainos.PixelArtTopDown_Basic
{
    public enum Direction
    {
        Left, Right, Up, Down
    }

    public class TopDownCharacterController : MonoBehaviour
    {
        public float speed;
        private Direction direction;
        private Animator animator;
        [SerializeField]
        private GameObject projectilePrefab;

        [SerializeField]
        private float shootCooldown = 1.0f;
        private bool isOnCooldown = false;

        private void Start()
        {
            animator = GetComponent<Animator>();
        }


        private void Update()
        {
            Vector2 dir = Vector2.zero;
            if (Input.GetKey(KeyCode.A))
            {
                dir.x = -1;
                animator.SetInteger("Direction", 3);
                direction = Direction.Left;
            }
            else if (Input.GetKey(KeyCode.D))
            {
                dir.x = 1;
                animator.SetInteger("Direction", 2);
                direction = Direction.Right;
            }

            if (Input.GetKey(KeyCode.W))
            {
                dir.y = 1;
                animator.SetInteger("Direction", 1);
                direction = Direction.Up;
            }
            else if (Input.GetKey(KeyCode.S))
            {
                dir.y = -1;
                animator.SetInteger("Direction", 0);
                direction = Direction.Down;
            }

            if (Input.GetKey(KeyCode.Space))
            {
                if (!isOnCooldown)
                {
                    ShootProjectile();
                    isOnCooldown = true;
                    StartCoroutine(ShootCooldownCoroutine());
                }
            }

            dir.Normalize();
            animator.SetBool("IsMoving", dir.magnitude > 0);

            GetComponent<Rigidbody2D>().velocity = speed * dir;
        }

        public void ShootProjectile()
        {
            if (direction == Direction.Left)
            {
                GameObject projectile = Instantiate(projectilePrefab, transform.position - new Vector3(0.5f, -0.25f), Quaternion.identity);
                projectile.GetComponent<Projectile>().SetDirection(new Vector2(-1, 0));
            }
            else if (direction == Direction.Right)
            {
                GameObject projectile = Instantiate(projectilePrefab, transform.position + new Vector3(0.5f, 0.25f), Quaternion.identity);
                projectile.GetComponent<Projectile>().SetDirection(new Vector2(1, 0));
            }
            else if (direction == Direction.Up)
            {
                GameObject projectile = Instantiate(projectilePrefab, transform.position + new Vector3(0.0f, 0.5f), Quaternion.identity);
                projectile.GetComponent<Projectile>().SetDirection(new Vector2(0, 1));
            }
            else if (direction == Direction.Down)
            {
                GameObject projectile = Instantiate(projectilePrefab, transform.position - new Vector3(0.0f, 0.10f), Quaternion.identity);
                projectile.GetComponent<Projectile>().SetDirection(new Vector2(0, -1));
            }
        }

        public IEnumerator ShootCooldownCoroutine()
        {
            yield return new WaitForSeconds(shootCooldown);
            isOnCooldown = false;
        }
    }
}
