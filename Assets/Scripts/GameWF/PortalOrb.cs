using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PortalOrb : MonoBehaviour
{
    [SerializeField] private CircleCollider2D circleCollider2D;
    [SerializeField] private GameObject destroyEffect;
    [SerializeField] private ParticleSystem particleSystem;
    public bool isDead { get; set; }
    
    public CircleCollider2D CircleCollider2D => circleCollider2D;

    public void TakeDamage()
    {
        if (isDead) return;
        isDead = true;
        StartCoroutine(TakeDamageEffect());
    }

    private IEnumerator TakeDamageEffect()
    {
        particleSystem.Stop(true);
        var effect = Instantiate(destroyEffect, transform.position, Quaternion.identity, transform);
        yield return new WaitForSeconds(1);
        gameObject.SetActive(false);
    }
}
