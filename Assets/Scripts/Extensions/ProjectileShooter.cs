using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem.EnhancedTouch;
using Touch = UnityEngine.InputSystem.EnhancedTouch.Touch;

public class ProjectileShooter : MonoBehaviour
{
    [SerializeField] private Projectile projectilePrefab;
    [SerializeField] private PlayerBehaviour player;
    [SerializeField] private float playerPortalSpeed;
    private Projectile lastProjectile;
    public Vector2 LastPortalPosition { get; set; }
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
        lastProjectile.Player = player;
        lastProjectile.FoundPortal += OnProjectileFoundOrb;
        
        lastProjectile.transform.up = zeroZShootDirection;
    }

    private void OnProjectileFoundOrb(Vector2 position)
    {
        LastPortalPosition = position;
        player.transform.position = position;
        player.Rigid.velocity = Vector2.zero;
        player.Rigid.AddForce(Vector2.up * playerPortalSpeed);
    }
    
    private void OnDestroy()
    {
        Touch.onFingerDown -= OnFingerDown;
        if (lastProjectile != null)
        {
            lastProjectile.FoundPortal -= OnProjectileFoundOrb;
        }
    }

    public void Restart()
    {
        if (lastProjectile != null)
        {
            Destroy(lastProjectile.gameObject);
            lastProjectile = null;
        }
    }
}
