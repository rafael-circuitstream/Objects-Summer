using UnityEngine;
using System;
public class Enemy : Character
{
    [SerializeField] protected float distanceToAttack;

    private Player target;
    protected override void Start()
    {
        base.Start();
        target = FindAnyObjectByType<Player>();
        ChangeSpriteColor(Color.red);
    }

    private void FixedUpdate()
    {
        if(target != null)
        {
            Vector2 direction = target.transform.position - transform.position;
            
            if(Vector2.Distance(transform.position, target.transform.position) > distanceToAttack)
            {
                Move(direction.normalized, direction);
            }
            else
            {
                Attack();
            }
            
        }
    }

    public override void Attack()
    {
        Debug.Log("Pow Pow");
    }

    public override void Explode()
    {
        base.Explode();
    }
}
