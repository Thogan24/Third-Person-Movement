using UnityEngine;

public class MonkeyGun : MonoBehaviour
{
    public GameObject player;
    public GameObject banana;
    public ParticleSystem shootParticles;

    public Vector3 Offset;

    [SerializeField] private float startingAttackCooldown = 0.1f;
    [SerializeField] private float attackCooldown;
    private bool CanAttack;
    public GameObject bananaReference;

    private void Start()
    {
        attackCooldown = 0.1f;
        CanAttack = true;
    }

    void Update()
    {
        shootParticles.startSize = 0;
        if (CanAttack == false)
        {
            attackCooldown -= Time.deltaTime;
        }

        transform.position = player.transform.position + Offset;
        //transform.rotation = player.transform.rotation;
        if (Input.GetMouseButtonDown(0))
        {
            if (CanAttack)
            {
                monkeyShoot();
            }
        }
        if (attackCooldown <= 0)
        {
            
            CanAttack = true;
            attackCooldown = startingAttackCooldown;

        }
    }

    public void monkeyShoot()
    {
        CanAttack = false;
        // Maybe use an array because there are multiple objects??
        bananaReference = Instantiate(banana, transform.position, transform.rotation);
        shootParticles.startSize = 1;
        //Instantiate(banana, transform);
        //Animator anim = monkeyGun.GetComponent<Animator>();
        //anim.SetTrigger("Attack");
    }

    public GameObject bananaGetter()
    {
        return bananaReference;
    }

}
