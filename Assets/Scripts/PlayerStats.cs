using UnityEngine;
using UnityEngine.Rendering.PostProcessing;
using UnityEngine.SceneManagement;


public class PlayerStats : MonoBehaviour
{
    public GameObject player;
    public GameObject mushroom;
    public GameObject rock;
    public GameObject sword;
    public GameObject enemy;
    public GameObject mainUI;
    public PostProcessVolume volume;
    public LensDistortion lensDistortion;
    //public Grain grain;
    public Vignette vignette;
    public ChromaticAberration chromaticAberration;
    public int maxPlayerHealth = 500;
    public float maxPlayerSprint = 50;
    public float playerSprint;
    public int playerHealth;
    public ParticleSystem swordHitParticle;
    public bool isDead = false;
    public bool isSprinting = false;

    private void Start()
    {
        playerHealth = maxPlayerHealth;
        playerSprint = maxPlayerSprint;
        volume.profile.TryGetSettings(out lensDistortion);
        //volume.profile.TryGetSettings(out grain);
        volume.profile.TryGetSettings(out vignette);
        volume.profile.TryGetSettings(out chromaticAberration);
        lensDistortion.active = false;
        //grain.active = false;
        vignette.active = false;
        chromaticAberration.active = false;
        swordHitParticle.startSize = 0;
    }
    void Update()
    {

        playerSprint = playerSprint < maxPlayerSprint ? playerSprint + 0.5f : playerSprint;

        if (!mainUI.GetComponent<MainUI>().GameIsPaused)
        {
            if (mushroom != null)
            {
                if (player.transform.GetComponent<Collider>().bounds.Intersects(mushroom.GetComponent<Collider>().bounds))
                {
                    Destroy(mushroom);

                    // Effects
                    lensDistortion.active = true;
                    //grain.active = true;
                    vignette.active = true;
                    chromaticAberration.active = true;
                    player.GetComponent<ThirdPersonMovement>().speed += 100f;
                    player.GetComponent<ThirdPersonMovement>().gravity = -50f;
                    player.GetComponent<ThirdPersonMovement>().jumpHeight = 10f;

                }
            }

            if (rock != null)
            {
                //Debug.Log("NONE");
                if (player.transform.GetComponent<Collider>().bounds.Intersects(rock.GetComponent<Collider>().bounds))
                {

                    Destroy(rock);
                    enemy.SetActive(true);

                }
            }
            else
            {
                if (player.transform.GetComponent<Collider>().bounds.Intersects(sword.GetComponent<Collider>().bounds))
                {

                    //Debug.Log(playerHealth);
                    playerHealth = playerHealth > 0 ? playerHealth - 1 : playerHealth; // If health above 0 then health - 1 otherwise stay as playerhealth

                    swordHitParticle.startSize = 1;
                }
                else
                {

                    swordHitParticle.startSize = 0;
                }
            }
            //Debug.Log(player.GetComponent<ThirdPersonMovement>().speed);
            //Debug.Log(playerSprint);
            if (((Input.GetKeyDown(KeyCode.RightShift) || Input.GetKeyDown(KeyCode.LeftShift))) && playerSprint > 0)
            {
                player.GetComponent<ThirdPersonMovement>().applySprint();
            }
            if ((Input.GetKey(KeyCode.RightShift) || Input.GetKey(KeyCode.LeftShift)) && playerSprint > 0)
            {
                isSprinting = true;
                playerSprint = playerSprint > 0 ? playerSprint - 1 : playerSprint;
                
                //Debug.Log(playerSprint);
            }
            else if (isSprinting == true && ((Input.GetKeyUp(KeyCode.RightShift) || Input.GetKeyUp(KeyCode.LeftShift)) || playerSprint <= 0)) {
                //Debug.Log(player.GetComponent<ThirdPersonMovement>().speed);
                //Debug.Log(isSprinting);
                player.GetComponent<ThirdPersonMovement>().removeSprint();
                //Debug.Log(player.GetComponent<ThirdPersonMovement>().speed);
                isSprinting = false;
                
                
            }
           
            if (playerHealth == 0)
            {
                Die();
            }
        }

    }
    public void Die()
    {
        // play an animation
        isDead = true;
        Cursor.lockState = CursorLockMode.None;
        Cursor.visible = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        
    }
}
