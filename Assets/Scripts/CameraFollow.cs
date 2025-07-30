using UnityEngine;

public class CameraFollow : MonoBehaviour
{

    // Find them in the documenation
    // Vector3.Dot() and Vector3.Cross()


    [SerializeField] private Vector3 offset;
    [SerializeField] private float followSpeed;

    private Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Awake()
    {
        player = FindAnyObjectByType<Player>();
    }

    // Update is called once per frame
    void Update()
    {
        if (player)
        {

            Vector3 destination = Vector3.Lerp(transform.position, player.transform.position, Time.deltaTime * followSpeed);
            destination.z = 0;
            transform.position = destination + offset;

        }    
    }

    //transform.position = ((Vector3)Vector2.Lerp(transform.position, player.transform.position, Time.deltaTime * followSpeed)) + offset;
}
