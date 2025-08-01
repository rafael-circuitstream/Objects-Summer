using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] private Rigidbody2D myRigidbody;
    [SerializeField] private GameObject destroyEffect;

    public float speed;
    public int damage;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        /*
        foreach(Transform t in transform)
        {
            if(t.gameObject.name.Contains("Audio"))
            {
                t.SetParent(null);
                Destroy(gameObject, 1f);
            }

        }
        */

        Destroy(gameObject, 5f);
        myRigidbody.linearVelocity = transform.up * speed;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {

        Debug.Log("Collided with " + collision.gameObject.name);

        Character characterCheck = collision.gameObject.GetComponent<Character>();

        if (characterCheck)
        {
            characterCheck.health.Damage(damage);
            Debug.Log(characterCheck.health.GetHealth());
        }

        if(destroyEffect)
        {
            Instantiate(destroyEffect, transform.position, transform.rotation);
        }
        

        Destroy(gameObject);
    }
}
