using UnityEngine;
using UnityEngine.AI;

public class Enemy1 : MonoBehaviour
{

    public GameObject player;

    // Attacking Variables
    public int bossHealth = 100;
    public int damageAmount;
    public int attackCooldown;
    
    //public Collider collider;

    // AI Variables
    public float lookRadius = 10f;
    public float stoppingDistance = 5f;
    public NavMeshAgent agent;
    Transform target;
    public float rayDistance = 12f;

    void OnEnable()
    {
        target = PlayerManager.instance.player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    void Update()
    {
        
       /* RaycastHit hit;
        Ray groundRay = new Ray(transform.position, Vector3.down);
        Debug.Log(groundRay);
        if (Physics.Raycast(groundRay, out hit, rayDistance))
        {
            Debug.Log("Hitting something just not tagged ground");
            if (hit.collider.tag == "Ground")

            {
                //Debug.Log("it should work");
                Debug.Log(hit.distance);
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - hit.distance + 0.5f);
            }
        }
        else
        {
            //Debug.Log("Not hitting anything");
        }*/



        // Follows player
        float distance = Vector3.Distance(target.position, transform.position);

        if (distance <= lookRadius)
        {
            agent.SetDestination(target.position);
            agent.updateRotation = true;
            //Debug.Log(distance);
            if (distance <= stoppingDistance)
            {
                agent.updatePosition = false;

                if (attackCooldown <= 0f) // If the attack cooldown is finished
                {
                    Attack();
                }
                // TODO Look at the target
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
    public void TakeDamage()
    {
        Debug.Log(bossHealth);
        bossHealth--;
    }
    void Attack()
    {
        //TODO Play animation
    }
    
    void OnDrawGizmosSelected()
    {
        // Draws look radius
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, lookRadius);
    }
}
