using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private ProjectileShooter projectileShooter;
    [SerializeField] private Rigidbody2D rigidB;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject dieEffect;
    [SerializeField] private float alphaSpeed;
    private int currentLifes;
    public Action<int> PlayerDamage;
    public Action<int> GoldCollected;
    private PlayerData playerData;
    
    private void Start()
    {
        EnhancedTouchSupport.Enable();
        TouchSimulation.Enable();
        
        playerData = new PlayerData(false);
        ResetPlayer();
    }

    public void ResetPlayer()
    {
        rigidB.constraints = RigidbodyConstraints2D.None;
        spriteRenderer.enabled = true;
        currentLifes = playerData.CurrentLifePoints;
        Disable();
    }

    public void Enable()
    {
        projectileShooter.EnableShooter();
    }

    public void Disable()
    {
        projectileShooter.DisableShooter();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.transform.parent.TryGetComponent<ScreenEdgesZone>(out ScreenEdgesZone edges))
        {
            
        }
    }

    public void Damage()
    {
        bool isDead = currentLifes - 1 <= 0;
        if (isDead)
        {
            currentLifes = 0;
            StartCoroutine(Die());
        }
        else
        {
            currentLifes--;
            StartCoroutine(TakeDamageCor());
        }
        
        currentLifes -= 1;
        PlayerDamage?.Invoke(currentLifes);
    }

    private IEnumerator Die()
    {
        spriteRenderer.enabled = false;
        rigidB.constraints = RigidbodyConstraints2D.FreezeAll;
        var dieEffectInstance = Instantiate(dieEffect, transform.position, transform.rotation);
        yield return new WaitForSeconds(1);
        Destroy(dieEffectInstance.gameObject);
    }

    private IEnumerator TakeDamageCor()
    {
        for (int i = 0; i < 5; i++)
        {
            while (spriteRenderer.color.a > 0)
            {
                var color = spriteRenderer.color;
                color.a -= alphaSpeed;
                spriteRenderer.color = color;
                yield return new WaitForFixedUpdate();
            }

            var alphaColor = new Color(1, 1, 1, 0);
            spriteRenderer.color = alphaColor;
            
            while (spriteRenderer.color.a < 1)
            {
                var color = spriteRenderer.color;
                color.a += alphaSpeed;
                spriteRenderer.color = color;
                yield return new WaitForFixedUpdate();
            }
            
            var defaultColor = new Color(1, 1, 1, 1);
            spriteRenderer.color = defaultColor;
        }
    }
}
