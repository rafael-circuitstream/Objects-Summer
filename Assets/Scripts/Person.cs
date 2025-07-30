using UnityEngine;

public class Person
{
    public string name;
    public int age;
    public float heigth;
    public Health health;

    public void IntroduceYourself()
    {
        Debug.Log("Hello! My Name is " + name);
    }

    public Person()
    {
        
    }
}
