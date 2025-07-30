using UnityEngine;
using UnityEngine.Events;

public class Character : MonoBehaviour
{
    public Health health;
    [SerializeField] protected int maxHealth;
    [SerializeField] protected float moveSpeed;
    [SerializeField] protected Rigidbody2D myRigidbody;
    [SerializeField] protected SpriteRenderer sprite;

    //OPTION 2 FOR WEAPON SOUND:
    //[SerializeField] protected AudioSource characterAudio;

    [SerializeField] protected GameObject destroyEffect;

    private void Awake()
    {
        health = new Health(maxHealth);
    }

    protected virtual void Start()
    {
        ChangeSpriteColor(Random.value, Random.value, Random.value);
    }

    void Update()
    {

    }

    protected void ChangeSpriteColor(Color newColor)
    {
        sprite.color = newColor;
    }

    protected void ChangeSpriteColor(float red, float blue, float green)
    {
        Color newColor = new Color(red, green, blue);
        ChangeSpriteColor(newColor);
    }

    public virtual void Move(Vector2 direction)
    {
        myRigidbody.AddForce(direction * moveSpeed);
    }

    public virtual void Move(Vector2 directionToMove, Vector2 directionToLook)
    {
        Move(directionToMove);
        transform.up = directionToLook;
    }

    public virtual void Explode()
    { 
        if(destroyEffect)
        {
            Instantiate(destroyEffect, transform.position, transform.rotation);
        }

        Destroy(gameObject);
    }

    public virtual void Attack()
    {
        Debug.Log("Pew Pew");
    }
}
