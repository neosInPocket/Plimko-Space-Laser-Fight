using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject blowEffect;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private CircleCollider2D circleCollider2D;
    public Rigidbody2D RB => rb;
    public bool IsDestroyed { get; set; }
    public Action<Vector2> FoundPortal;
    public Action<Projectile> Destroyed;
    
    private float[] projectileSpeeds = { 10, 2, 15, 4 };
    private float projectileSpeed;
    public PlayerBehaviour Player { get; set; }
    
    private void Start()
    {
        var playerdata = new PlayerData(false);
        projectileSpeed = projectileSpeeds[playerdata.CurrentProjectileSpeedPoints];
        rb.velocity = transform.up * projectileSpeed;
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        var portalOrb = collider2D.GetComponent<PortalOrb>();
        if (portalOrb)
        {
            FoundPortal?.Invoke(portalOrb.transform.position);
            Player.InvokeGoldCollected(3);
            portalOrb.TakeDamage();
            Blow();
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<Projectile>(out Projectile projectile))
        {
            return;
        }
        
        Blow();
    }

    public void Blow()
    {
        if (IsDestroyed) return;
        Destroyed?.Invoke(this);
        IsDestroyed = true;
        StartCoroutine(PlayBlowEffect());
    }

    private IEnumerator PlayBlowEffect()
    {
        spriteRenderer.enabled = false;
        circleCollider2D.enabled = false;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
        var blowEffectInstance = Instantiate(blowEffect, transform.position, transform.rotation, transform);
        yield return new WaitForSeconds(1);
        Destroy(gameObject);
    }
}
