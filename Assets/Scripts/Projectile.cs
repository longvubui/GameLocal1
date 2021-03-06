using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public float speed;
    public float lifeTime;
    public GameObject destroyEffect;
    public float distance;
    public int damage;
    public LayerMask whatIsSolid;
    // Start is called before the first frame update
    private  void Start()
    {
        Invoke("DestroyProjectile", lifeTime);
    }

    // Update is called once per frame
   private void Update()
    {
        RaycastHit2D hitInfo = Physics2D.Raycast(transform.position, transform.up, distance, whatIsSolid);
        if (hitInfo.collider != null)
        {
            if (hitInfo.collider.CompareTag("Enemy"))
            {
                hitInfo.collider.GetComponent<EnemyScript>().TakeDamage(damage);
            }
            DestroyProjectile();
        }
        transform.Translate(Vector2.up * speed * Time.deltaTime);
    }
    void DestroyProjectile()
    {
        Instantiate(destroyEffect, transform.position, Quaternion.identity);
        Destroy(gameObject); 
    }
}
