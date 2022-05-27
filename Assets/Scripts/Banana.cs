using UnityEngine;

public class Banana : MonoBehaviour
{
    [SerializeField] private float power = 1500;
    [SerializeField] private float lifetime = 5;
    // Start is called before the first frame update
    void Start()
    {
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
            Destroy(this);
        }
    }


}
