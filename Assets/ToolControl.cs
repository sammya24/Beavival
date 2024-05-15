using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToolControl : MonoBehaviour
{
    Beaver_Behavior beaverMov;
    Rigidbody2D rb;

    [SerializeField] float offsetDistance = 1f;
    [SerializeField] float pickupZone = 1.5f;

    private void Awake()
    {
        beaverMov = GetComponent<Beaver_Behavior>();
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            UseTool();
        }
    }

    private void UseTool()
    {
        Vector2 pos = rb.position + beaverMov.lastPos * offsetDistance;
        Collider2D[] colliders = Physics2D.OverlapCircleAll(pos, pickupZone);

        foreach(Collider2D c in colliders)
        {
            Tool hit = c.GetComponent<Tool>();
            if(hit != null)
            {
                hit.Hit();
                break;
            }
        }
    }


}
