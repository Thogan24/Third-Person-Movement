using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class PlayerStats : MonoBehaviour
{
    public GameObject player;
    public GameObject mushroom;
    public GameObject sword;
    public PostProcessVolume volume;
    public LensDistortion lensDistortion;
    public Grain grain;
    public Vignette vignette;
    public ChromaticAberration chromaticAberration;
    public int playerHealth = 50;
    public GameObject swordHitParticle;


    private void Start()
    {
        volume.profile.TryGetSettings(out lensDistortion);
        volume.profile.TryGetSettings(out grain);
        volume.profile.TryGetSettings(out vignette);
        volume.profile.TryGetSettings(out chromaticAberration);
        lensDistortion.active = false;
        grain.active = false;
        vignette.active = false;
        chromaticAberration.active = false;
    }
    void Update()
    {
        if (mushroom != null)
        {
            if (player.transform.GetComponent<Collider>().bounds.Intersects(mushroom.GetComponent<Collider>().bounds))
            {
                Destroy(mushroom);

                // Effects
                lensDistortion.active = true;
                grain.active = true;
                vignette.active = true;
                chromaticAberration.active = true;
                player.GetComponent<ThirdPersonMovement>().speed = 100f;
                player.GetComponent<ThirdPersonMovement>().gravity = -50f;
                player.GetComponent<ThirdPersonMovement>().jumpHeight = 10f;

            }
        }

        if (player.transform.GetComponent<Collider>().bounds.Intersects(sword.GetComponent<Collider>().bounds)){
            Debug.Log(playerHealth);
            playerHealth -= 10;
            swordHitParticle.SetActive(true);
        }
        else
        {
            swordHitParticle.SetActive(false);
        }
    }
}
