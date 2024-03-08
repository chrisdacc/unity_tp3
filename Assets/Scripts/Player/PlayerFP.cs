using TMPro;
using UnityEngine;

public class PlayerFP : MonoBehaviour
{
     public GameObject spawnMummy;
    public  GameObject spawnBoss;
    private GameObject respawnPosition;
    public TMP_Text gameover;

    private void Start()
    {
        respawnPosition = GameObject.FindWithTag("Respawn");
    }

    private void Update()
    {
        if (BarManager.health <= 0)
        {
            gameover.text = "GAME OVER";
        }
        else
        {
            gameover.text = "";
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Enemy"))
        {
            Destroy(other.gameObject);
            BarManager.TakeDamage(2f);

            // Optionally, respawn enemies from the PlayerFP script
            Invoke(nameof(RespawnEnemy), 2f);
        }
    }

    private void RespawnEnemy()
    {
        // Respawn the enemy at the respawn position
        GameObject newMummy = Instantiate(spawnMummy);
        newMummy.transform.position = respawnPosition.transform.position;
    }
}