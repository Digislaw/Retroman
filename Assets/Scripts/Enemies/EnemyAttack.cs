﻿using UnityEngine;

public class EnemyAttack : MonoBehaviour
{
    [SerializeField]
    private PlayerHealth healthController;
    [SerializeField]
    private LayerMask playerLayer;

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (playerLayer != (playerLayer | 1 << col.gameObject.layer)) return;

        Vector2 vec = new Vector2(transform.position.x - col.gameObject.transform.position.x, 0f);
        healthController.DamagePlayer((int) vec.normalized.x);
    }
}