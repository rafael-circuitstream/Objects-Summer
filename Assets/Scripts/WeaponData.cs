using UnityEngine;

[CreateAssetMenu(menuName = "New Weapon")]
public class WeaponData : ScriptableObject
{
    public string weaponName;
    public string description;
    public int damage;
    public float bulletSpeed;
    public Bullet bulletReference;

    //OPTION 2 FOR WEAPON SOUND:
    //public AudioClip shootSound;

    public void ShootWeapon(Transform weaponTip)
    {
        Bullet clonedBullet = GameObject.Instantiate(bulletReference, weaponTip.position, weaponTip.rotation);
        
        clonedBullet.speed = bulletSpeed;
        clonedBullet.damage = damage;
    }

    //public WeaponData(Bullet bullet, Transform weaponTip)
    //{
    //    weaponName = "Pistol";
    //    damage = 100;
    //    bulletSpeed = 10;
    //    bulletReference = bullet;
    //    shootingOrigin = weaponTip;

    //}
}
