﻿using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    [SerializeField] float movementPeriod = 0.5f;
    [SerializeField] ParticleSystem goalParticle;

	// Start is called before the first frame update
	void Start()
    {
        Pathfinder pathfinder = FindObjectOfType<Pathfinder>();
        var path = pathfinder.GetPath();
        StartCoroutine(FollowPath(path));
    }

   IEnumerator FollowPath(List<Waypoint2> path)
	{
		print("Starting patrol...");
        foreach (Waypoint2 waypoint in path)
		{
			transform.position = waypoint.transform.position;
			yield return new WaitForSeconds(movementPeriod);
		}
		SelfDestruct();
	}

    private void SelfDestruct()
    {
        var vfx = Instantiate(goalParticle, transform.position, Quaternion.identity);
        vfx.Play();
        Destroy(vfx.gameObject, vfx.main.duration);

        Destroy(gameObject); // the enemy
    }

}

