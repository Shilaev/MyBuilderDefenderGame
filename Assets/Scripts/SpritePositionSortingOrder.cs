using System;
using UnityEngine;

public class SpritePositionSortingOrder : MonoBehaviour
{
    [SerializeField] private bool _runOnce = true;
    private SpriteRenderer _spriteRenderer;

    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void LateUpdate()
    {
        _spriteRenderer.sortingOrder = Convert.ToInt32(-transform.position.y * 10);

        // destroy after run once
        // you can chose this option in inspector
        if (_runOnce)
        {
            Destroy(this);
        }

    }
}