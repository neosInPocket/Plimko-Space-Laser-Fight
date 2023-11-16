using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Serialization;

public class Projectile : MonoBehaviour
{
    [SerializeField] private Rigidbody2D rb;
    [SerializeField] private GameObject blowEffect;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private CircleCollider2D circleCollider2D;
    public bool IsDestroyed { get; set; }
    private Vector2 screenSize;
    public Action<Vector2> FoundPortal;
    
    private void Start()
    {
        screenSize = GameExtensions.screenSize;
    }

    public void SetProjectileSpeed(float speed)
    {
        rb.velocity = transform.up * speed;
    }

    private void Update()
    {
        if (Mathf.Abs(transform.position.x) > screenSize.x)
        {
            Blow();
        }
    }

    private void OnTriggerEnter2D(Collider2D collider2D)
    {
        var portalOrb = collider2D.GetComponent<PortalOrb>();
        if (portalOrb)
        {
            FoundPortal?.Invoke(portalOrb.transform.position);
            Destroy(portalOrb.gameObject);
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
