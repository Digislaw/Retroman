using System.Collections;
using UnityEngine;

public class SpawnController : MonoBehaviour
{
    private static SpawnController _instance;
    public static SpawnController Instance
    {
        // zwroc globalna instancje
        get { return _instance; }
    }

    public Vector3 CurrentSpawn { get; set; }   // aktualny spawn

    [SerializeField] 
    private float respawnDelay = 2f; // czas potrzebny do zrespawnowania gracza

    [SerializeField]
    private FadeEffect fade;

    private void Awake()
    {
        _instance = this;
    }

    private void Start()
    {
        PlayerHealth.Instance.onPlayerDeath += RespawnPlayer;
        CurrentSpawn = PlayerMovement.Instance.gameObject.transform.position;
    }

    public void RespawnPlayer()
    {
        StartCoroutine(RespawnCoroutine());
    }

    private IEnumerator RespawnCoroutine()
    {
        PlayerMovement.Instance.gameObject.SetActive(false);

        yield return new WaitForSeconds(respawnDelay);

        fade.FadeIn();
        yield return new WaitForSeconds(fade.Duration);

        PlayerMovement.Instance.gameObject.SetActive(true);
        fade.FadeOut();

        PlayerMovement.Instance.gameObject.transform.position = CurrentSpawn;
        PlayerHealth.Instance.ChangeHP(PlayerHealth.Instance.maxHealth);
    }
}
