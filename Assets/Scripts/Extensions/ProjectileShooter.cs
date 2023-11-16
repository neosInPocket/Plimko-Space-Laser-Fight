using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class ProjectileShooter : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    private Projectile lastProjectile;
    private float[] projectileSpeeds = { 10, 2, 15, 4 };
    private float projectileSpeed;
    
    private void Awake()
    {
        

        var playerdata = new PlayerData(false);
        projectileSpeed = projectileSpeeds[playerdata.CurrentProjectileSpeedPoints];
        Debug.Log(playerdata.CurrentProjectileSpeedPoints);
    }

    public void EnableShooter()
    {
        Touch.onFingerDown += OnFingerDown;
    }

    public void DisableShooter()
    {
        Touch.onFingerDown -= OnFingerDown;
    }

    private void OnFingerDown(Finger obj)
    {
        if (lastProjectile != null)
        {
            if (!lastProjectile.IsDestroyed) return;
            lastProjectile.FoundPortal -= OnProjectileFoundOrb;
        }
        
        var fingerTouchPosition = obj.screenPosition.ScreenToWorldPoint3();
        var shootDirection = (fingerTouchPosition - transform.position).normalized;
        var zeroZShootDirection = new Vector3(shootDirection.x, shootDirection.y, 0);
        
        transform.up = zeroZShootDirection;
        lastProjectile = Instantiate(projectilePrefab, transform.position, Quaternion.identity);
        lastProjectile.FoundPortal += OnProjectileFoundOrb;
        
        lastProjectile.transform.up = zeroZShootDirection;
        lastProjectile.SetProjectileSpeed(projectileSpeed);
    }

    private void OnProjectileFoundOrb(Vector2 position)
    {
        transform.parent.position = position;
    }
    
    private void OnDestroy()
    {
        Touch.onFingerDown -= OnFingerDown;
        if (lastProjectile != null)
        {
            lastProjectile.FoundPortal -= OnProjectileFoundOrb;
        }
    }
}
