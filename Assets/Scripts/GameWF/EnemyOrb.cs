using System;
using System.Collections;
using System.Collections.Generic;
using System.Runtime.InteropServices.WindowsRuntime;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemyOrb : MonoBehaviour
{
    [SerializeField] private Vector2 startSizeValues;
    [SerializeField] private float gravityStrength;
    [SerializeField] private CircleCollider2D circleCollider2D;
    public CircleCollider2D CircleCollider2D => circleCollider2D;
    private List<Projectile> projectiles;
    
    private void Start()
    {
        projectiles = new List<Projectile>();
        var randomValue = Random.Range(startSizeValues.x, startSizeValues.y);
        transform.localScale = new Vector3(randomValue, randomValue, randomValue);
    }

    private void Update()
    {
        foreach (var proj in projectiles)
        {
            if (proj == null)
            {
                projectiles.Remove(proj);
                continue;
            }
            NavigateProjectile(proj);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.TryGetComponent<Projectile>(out Projectile projectile))
        {
            projectile.Destroyed += ProjectileDestroyed;
            projectiles.Add(projectile);
        }

        if (other.transform.parent == null) return;
        if (other.transform.parent.TryGetComponent<GameEdge>(out GameEdge zone))
        {
            Destroy(gameObject);
        }
    }

    private void ProjectileDestroyed(Projectile projectile)
    {
        projectile.Destroyed -= ProjectileDestroyed;
        projectiles.Remove(projectile);
    }

    private void NavigateProjectile(Projectile projectile)
    {
        var difference = transform.position - projectile.transform.position;
        float distance = difference.magnitude;

        var direction = difference.normalized;
        var force = direction * gravityStrength / distance;
        projectile.RB.AddForce(force);
    }
}
