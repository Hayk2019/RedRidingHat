using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthScript : MonoBehaviour
{
    float maxHealth;
    float maxMagicHealth;
    float  health;
    float magicHealth;
    [SerializeField] GameObject Healthbar;
    [SerializeField] GameObject MagicHealthBar;
    void Start()
    {
        Healthbar.GetComponent<Image>().fillAmount = 1;
        MagicHealthBar.GetComponent<Image>().fillAmount = 1;
        maxHealth = GameObject.Find("Player").GetComponent<PlayerParameters>().Health;
        maxMagicHealth = GameObject.Find("Player").GetComponent<PlayerParameters>().MagicManna;

    }
    void UpdatingState() {
            health = GameObject.Find("Player").GetComponent<PlayerParameters>().Health;
            magicHealth = GameObject.Find("Player").GetComponent<PlayerParameters>().MagicManna;
            Healthbar.GetComponent<Image>().fillAmount = health / maxHealth;
            MagicHealthBar.GetComponent<Image>().fillAmount = magicHealth / maxMagicHealth;
    }
    void Update()
    {
        UpdatingState();
    }
}
