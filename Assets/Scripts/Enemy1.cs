using UnityEngine;
using UnityEngine.AI;

public class Enemy1 : MonoBehaviour
{

    public GameObject player;

    // Attacking Variables
    public int bossHealth = 100;
    public int damageAmount;
    public int damageCooldown;
    //public Collider collider;

    // AI Variables
    public float lookRadius = 10f;
    public float stoppingDistance = 5f;
    public NavMeshAgent agent;
    Transform target;


    // Start is called before the first frame update
    void Start()
    {
        target = PlayerManager.instance.player.transform;
        //Debug.Log(target);
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        // look at player
        //transform.LookAt(player.transform);
        //transform.rotation = new Vector3(transform.eulerAngles.x, transform.eulerAngles.y, 0);

        //follow the player
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            agent.updateRotation = true;
            //Debug.Log(distance);
            if (distance <= stoppingDistance)
            {
                //agent.SetDestination(transform.position);
                agent.updatePosition = false;

                //Attack the target
                //Look at the target potentially needed
            }
            else
            {
                agent.updatePosition = true;
            }
        }

        //If the player hits the boss, take damage
        /*if (player.transform.GetChild(3).GetComponent<Collider>().bounds.Intersects(GetComponent<Collider>().bounds))
        {
            Debug.Log(bossHealth);
            TakeDamage();
        }*/
    }

    void Die()
    {
        // dissapear and animation
        Destroy(gameObject);
    }
    void TakeDamage()
    {
        bossHealth--;
    }

    void Attack()
    {

    }

    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
