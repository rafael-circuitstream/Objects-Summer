using UnityEngine;

public abstract class Animal
{
    protected int health;
    protected float strength;

    public abstract void MakeNoise();

    public abstract void Move();


}


public class Bird : Animal, IFly
{
    public override void MakeNoise()
    {
        Debug.Log("Chirp Chirp");   
    }

    public override void Move()
    {
       
    }

    public virtual void FlapWings()
    {
        
    }
}

public class Mammal : Animal
{
    public override void MakeNoise()
    {
        Debug.Log("Mooow");
    }

    public override void Move()
    {
       
    }

    public virtual void GiveBirth()
    {

    }
}

public class Fish : Animal
{
    public override void MakeNoise()
    {
        Debug.Log("Blub Blub");
    }

    public override void Move()
    {
        
    }
}

public class Eagle : Bird
{
    public void Attack()
    {

    }


}

public class Dog : Mammal
{
    public override void MakeNoise()
    {
        Debug.Log("Woof Woof");
    }
}

public class Penguin : Bird
{
    public override void FlapWings()
    {
        Debug.Log("I'll fall to my d3ath");
       
        
    }
}
public class Chicken : Bird
{

}

public class Platypus : Mammal, ILayEgg
{
    public void LayEgg()
    {
        
    }
}

public class Bat : Mammal, IFly
{
    public void FlapWings()
    {
        
    }
}




