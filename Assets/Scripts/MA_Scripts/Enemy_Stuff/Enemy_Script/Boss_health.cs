using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;

public class Boss_health : MonoBehaviour
{
    public int BossHealth = 100;
    public int BossDmg = 25;
    private int currentHealth;

    [SerializeField]
    private string sceneToLoad;

    public TextMeshProUGUI Healtext;


    // Start is called before the first frame update
    void Start()
    {
        currentHealth = BossHealth;
        UpdateText();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void DamageOnEnemy(int damage)
    {
        BossHealth -= damage;
        UpdateText();
        if (BossHealth <= 0)
        {
            defeat();
            SceneManager.LoadScene(sceneToLoad);
        }
    }

    public void defeat()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player")) // More efficient tag comparison
        {
            Player_Health playerHealth = other.GetComponent<Player_Health>();
            if (playerHealth != null)
            {
                playerHealth.TakeDamage(BossDmg);
            }
        }
    }

    void UpdateText()
    {
        if (Healtext != null)
        {
            Healtext.text = "Boss " + BossHealth + " / " + currentHealth;
        }
    }
}

