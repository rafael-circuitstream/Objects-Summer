using UnityEngine;

public class ClassTester : MonoBehaviour
{
    GameObject[] randomObjects;
    Animal[] myFarm = new Animal[3];

    IPickable[] allPickables;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        foreach(GameObject randomObject in randomObjects)
        {
            if(randomObject.GetComponent<IPickable>() != null)
            {

            }
        }

        myFarm[0] = new Platypus();
        myFarm[1] = new Chicken();
        myFarm[2] = new Bat();

        foreach(Animal animal in myFarm)
        {
            if(animal is IPickable)
            {
                


                Debug.Log("This animal fly");
            }
        }
    }


    IFly GetRandomAnimalThatFlies()
    {
        if(myFarm[0] is IFly flyAnimal)
        {
            return flyAnimal;
        }
        else
        {
            return null;
        }
    }


    // Update is called once per frame
    void Update()
    {
       
    }
}
