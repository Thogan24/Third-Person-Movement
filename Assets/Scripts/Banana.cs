using UnityEngine;

public class Banana : MonoBehaviour
{
    // change power dependant on speed??
    public GameObject player;
    
    [SerializeField] private float power = 1500f;
    [SerializeField] private float lifetime = 5f;
    public GameObject monkey;
    void Start()
    {
        lifetime = 5f;
        transform.SetParent(null);
        GetComponent<Rigidbody>().AddForce(power * -transform.up);

    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Enemy"))
        {
            other.transform.GetComponent<Enemy1>().TakeDamage();
        }
    }

    private void Update()
    {
        Debug.Log(lifetime);
        lifetime -= Time.deltaTime;

        if (lifetime <= 0)
        {
            //Destroy(monkey.GetComponent<MonkeyGun>().bananaGetter());
        }
    }


}
