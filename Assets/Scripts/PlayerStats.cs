using UnityEngine;
using UnityEngine.Rendering.PostProcessing;


public class PlayerStats : MonoBehaviour
{
    public GameObject player;
    public GameObject mushroom;
    public PostProcessVolume volume;
    public LensDistortion lensDistortion;
    public Grain grain;
    public Vignette vignette;
    public ChromaticAberration chromaticAberration;


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
                Debug.Log("A");
                Destroy(mushroom);
                lensDistortion.active = true;
                grain.active = true;
                vignette.active = true;
                chromaticAberration.active = true;
                player.GetComponent<ThirdPersonMovement>().speed = 100f;
                player.GetComponent<ThirdPersonMovement>().gravity = -50f;
                player.GetComponent<ThirdPersonMovement>().jumpHeight = 10f;

            }
        }
    }
}
