using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Tree : Tool
{
    [SerializeField] GameObject drop;
    [SerializeField] int dropCount = 15;
    [SerializeField] float spread = 2f;

    public override void Hit()
    {
        while(dropCount > 0)
        {
            dropCount -= 1;
            Vector3 pos = transform.position;
            pos.x += spread * UnityEngine.Random.value - spread / 2;
            pos.y += spread * UnityEngine.Random.value - spread / 2;
            GameObject go = Instantiate(drop);
            go.transform.position = pos;
        }
        Destroy(gameObject);
    }
}
