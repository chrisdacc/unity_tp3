using UnityEngine;

public class KillOnClick : MonoBehaviour
{
    [SerializeField] private GameObject spawnMummy;
    [SerializeField] private GameObject spawnBoss;
    private GameObject respawnPosition;
    private Animator animator;
    private static int enemyHealth = 20;
    private static int counter = 4;

    void Start()
    {
        respawnPosition = GameObject.FindWithTag("Respawn");
        animator = GetComponent<Animator>();
        animator.SetBool("isDead", false);
    }

    void Update()
    {
        // Use Time.deltaTime to make the movement independent of the frame rate
        transform.Translate(Vector3.forward * Time.deltaTime * (SaveSystem.PlayerLevel + 2)*0.6f);
    }

    private void OnMouseDown()
    {
        RaycastHit hitInfo;
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);

        if (Physics.Raycast(ray, out hitInfo))
        {
            if (hitInfo.collider.gameObject == gameObject)
            {
                //Debug.Log("Enemy Clicked!");
                if (enemyHealth <= 0)
                {
                    Die();
                }
                else
                {
                    TakeDamage(SaveSystem.skill);
                }
            }
        }
    }

    private void Die()
    {
        animator.SetBool("isDead", true);

        // Reset enemyHealth and re-enable the collider
        enemyHealth = 20 + (SaveSystem.PlayerLevel * 5);
        GetComponent<Collider>().enabled = true;

        InstantiateEnemy();

        UpdateScoreAndLevel();

        Invoke(nameof(Kill), 2);
    }

    private void TakeDamage(int damage)
    {
        enemyHealth = Mathf.Max(0, enemyHealth - damage);
    }

    private void InstantiateEnemy()
    {
        if (counter > 1)
        {
            counter--;
            GameObject newMummy = Instantiate(spawnMummy);
            newMummy.transform.position = respawnPosition.transform.position;
        }
        else if (counter == 1)
        {
            counter = 5; // Reset the counter for the next cycle
            GameObject boss = Instantiate(spawnBoss);
            boss.transform.position = respawnPosition.transform.position;
        }
    }

    private void UpdateScoreAndLevel()
    {
        if (gameObject.name.StartsWith("B"))
        {
            SaveSystem.IncrementScore(4f);
            SaveSystem.IncrementLevel(1);
        }
        else
        {
            SaveSystem.IncrementScore(2f);
        }
    }

    private void Kill()
    {
        // Disable the collider when the enemy is killed
        //GetComponent<Collider>().enabled = false;
        Destroy(gameObject);
    }
}
