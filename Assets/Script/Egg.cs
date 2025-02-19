using UnityEngine;

public class Egg : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    [SerializeField]
    private GameObject player;

    void HideEgg()
    {
        audio_manager.instance.PlayCrackEgg();
        gameObject.SetActive(false);
        player.SetActive(true);
    }
}
