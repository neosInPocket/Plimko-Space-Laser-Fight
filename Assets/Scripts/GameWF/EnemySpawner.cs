using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private EnemyOrb prefab;
    [SerializeField] private PortalOrb portalPrefab;
    [SerializeField] private PlayerBehaviour player;
    [SerializeField] private EnemyOrb firstOrb;
    [SerializeField] private PortalOrb firstPortal;
    [SerializeField] private float spawnDistance;
    [SerializeField] private float portalSpawnDistance;
    private EnemyOrb lastOrb;
    private PortalOrb lastPortal;
    private float offset;
    private float portalOffset;
    private Vector2 screenSize;

    private void Start()
    {
        screenSize = GameExtensions.screenSize;
        lastOrb = firstOrb;
        lastPortal = firstPortal;
        offset = Mathf.Abs(player.transform.position.y - lastOrb.transform.position.y);
        portalOffset = Mathf.Abs(player.transform.position.y - lastPortal.transform.position.y);
    }

    public void Restart()
    {
        lastOrb = firstOrb;
        
        firstPortal.gameObject.SetActive(true);
        firstPortal.isDead = false;
        lastPortal = firstPortal;
    }
    
    private void Update()
    {
        if (player.transform.position.y + offset > lastOrb.transform.position.y)
        {
            var currentPosition = lastOrb.transform.position;
            var radius = prefab.CircleCollider2D.radius;
            
            var randomX = Random.Range(-screenSize.x + radius, screenSize.x - radius);
            var newOrbPosition = new Vector3(randomX, currentPosition.y + spawnDistance, currentPosition.z);
            lastOrb = Instantiate(prefab, newOrbPosition, Quaternion.identity, transform);
        }

        if (player.transform.position.y + portalOffset > lastPortal.transform.position.y)
        {
            var currentEnemyPosition = lastOrb.transform.position;
            var enemyRadius = prefab.CircleCollider2D.radius;
            
            var currentPosition = lastPortal.transform.position;
            var radius = portalPrefab.CircleCollider2D.radius;
            
            var randomX1 = Random.Range(-screenSize.x + 2 * radius + 0.1f, currentEnemyPosition.x - enemyRadius - 0.1f);
            var randomX2 = Random.Range(currentEnemyPosition.x + enemyRadius + 0.1f, screenSize.x - 2 * radius - 0.1f);
            var rnd = Random.Range(0, 2);
            var newOrbPosition = Vector2.one;
            if (rnd == 0)
            {
                newOrbPosition = new Vector3(randomX1, currentPosition.y + portalSpawnDistance, currentPosition.z);
            }
            else
            {
                newOrbPosition = new Vector3(randomX2, currentPosition.y + portalSpawnDistance, currentPosition.z);
            }
            
            lastPortal = Instantiate(portalPrefab, newOrbPosition, Quaternion.identity, transform);
        }
    }

    public void DestroyObjects()
    {
        foreach (Transform child in transform)
        {
            Destroy(child.gameObject);
        }
    }
}
