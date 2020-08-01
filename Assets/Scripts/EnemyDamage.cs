using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    [SerializeField] Collider collisionMesh;
    [SerializeField] int hitPoints = 10;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    private void OnParticleCollision(GameObject other)
    {
        print("I'm hit!");
        ProcessHit();
    }

    void ProcessHit()
    {
        hitPoints = hitPoints - 1;
        print("current hitpoints are " + hitPoints);
    }

}
