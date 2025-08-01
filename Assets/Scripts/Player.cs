using UnityEngine;
using System;
using System.Collections;
using System.Collections.Generic;
public class Player : Character
{

    public string[] LoadedWeaponData;

    //[SerializeField] private Bullet bulletPrefab;
    [SerializeField] private Transform weaponTip;
    [SerializeField] private WeaponData currentWeapon;
    
    #region VARIABLES

    private Vector2 mousePosition;
    private Vector2 worldPositionOfMouse;

    public Vector2 moveDirection;
    private Vector2 lookDirection;

    #endregion

    #region METHODS


    #region Behaviour


    protected override void Start()
    {
        //currentWeapon = new WeaponData(bulletPrefab, shootOrigin);
        ChangeSpriteColor(Color.blue);
        
        
    }
    
    void Update()
    {
        moveDirection.x = Input.GetAxisRaw("Horizontal");
        moveDirection.y = Input.GetAxisRaw("Vertical");


        mousePosition = Input.mousePosition;
        worldPositionOfMouse = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        lookDirection = worldPositionOfMouse - myRigidbody.position;


        //Debug.Log(Vector2.SignedAngle(myRigidbody.transform.up, worldPositionOfMouse));

        //One way of testing:
        //transform.position = worldPositionOfMouse;

        ChangeSpriteColor(  Color.Lerp(Color.red, Color.green, (float) health.GetHealth() / maxHealth )    );

        if (Input.GetKeyDown( KeyCode.Space ))
        {
            health.Damage(UnityEngine.Random.Range(1, 4));
        }

        if(Input.GetKeyDown( KeyCode.P ))
        {

        }


        if(Input.GetMouseButtonDown(0))
        {
            Attack();
        }
    }

    public Rigidbody2D GetPlayerRigidbody()
    {
        return myRigidbody;
    }

    public override void Attack()
    {
        base.Attack();

        //OPTION 2 FOR WEAPON SOUND:
        //characterAudio.PlayOneShot(currentWeapon.shootSound);

        if(currentWeapon != null)
        {
            currentWeapon.ShootWeapon(weaponTip);
        }
        else
        {

        }
        
    }

    private void FixedUpdate()
    {
        Move(moveDirection.normalized, lookDirection);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        IPickable pickableFeature = collision.gameObject.GetComponent<IPickable>();

        //NULL IS EQUAL TO AN EMPTY SPACE (MEANING THE SEARCH WAS NOT SUCCESFUL)
        if (pickableFeature != null)
        {
            pickableFeature.PickUp();
        }
    }

    #endregion

    /// <summary>
    /// This method is for when the player ship explodes
    /// It can be used to spawn explosion effects, sounds, and tell the game manager the game is over
    /// </summary>
    public override void Explode()
    {
        base.Explode();
    }

    /*
    private void SwitchWeapon()
    {

    }

    private void Dash()
    {
        
    }

    private void UseUltimatum()
    {

    }
    */


    #endregion
}
