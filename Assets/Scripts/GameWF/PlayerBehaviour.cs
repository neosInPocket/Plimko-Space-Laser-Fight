using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;

public class PlayerBehaviour : MonoBehaviour
{
    [SerializeField] private ProjectileShooter projectileShooter;
    [SerializeField] private Rigidbody2D rigidB;
    [SerializeField] private SpriteRenderer spriteRenderer;
    [SerializeField] private GameObject dieEffect;
    [SerializeField] private float alphaSpeed;
    [SerializeField] private Transform start; 
    private int currentLifes;
    private int currentPoints;
    public Action<int> PlayerDamage;
    public Action<int> GoldCollected;
    private PlayerData playerData;
    public Rigidbody2D Rigid => rigidB;
    public int CurrentPoints => currentPoints;
    
    private void Start()
    {
        EnhancedTouchSupport.Enable();
        TouchSimulation.Enable();
        
        playerData = new PlayerData(false);
        ResetPlayer();
    }

    public void ResetPlayer()
    {
        transform.position = start.position;
        rigidB.constraints = RigidbodyConstraints2D.None;
        spriteRenderer.enabled = true;
        currentLifes = playerData.CurrentLifePoints;
        currentPoints = 0;
    }

    public void Enable()
    {
        projectileShooter.EnableShooter();
    }

    public void Disable()
    {
        projectileShooter.DisableShooter();
        rigidB.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.TryGetComponent<EnemyOrb>(out EnemyOrb enemyOrb))
        {
            Damage();
        }
            
        if (other.transform.parent is null) return;
        
        if (other.transform.parent.TryGetComponent<ScreenEdgesZone>(out ScreenEdgesZone edges))
        {
            Damage();
        }
    }

    public void InvokeGoldCollected(int reward)
    {
        currentPoints += reward;
        GoldCollected?.Invoke(currentPoints);
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
        Disable();
        spriteRenderer.enabled = false;
        
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
