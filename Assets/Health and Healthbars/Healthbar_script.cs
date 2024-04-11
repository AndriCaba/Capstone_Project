using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro; 
public class Healthbar_script : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI healthtext;
     [SerializeField] private Image healthBarfill;
    [SerializeField] private float fillSpeed;
    [SerializeField] private Gradient colorGradient;
    [SerializeField] public Camera camera;
    void Update()
     {
         transform.rotation = camera.transform.rotation;
    }
    public void SetMaxHealth(float health)
    {
      float targetFillAmount = health;
      healthtext.text = health.ToString();
     healthBarfill.DOFillAmount(targetFillAmount, fillSpeed);
        healthBarfill.color = colorGradient.Evaluate(targetFillAmount);
    

    
    }
       public void SetHealth(float health, float maxHealth)
    { 
    
        float targetFillAmount = health/ maxHealth;
        healthtext.text = health.ToString();
        healthBarfill.DOFillAmount(targetFillAmount, fillSpeed);
        healthBarfill.color = colorGradient.Evaluate(targetFillAmount);
    
    }
    // public void SetHealth(int health)
    // { 
    // slider.value = health;
    // healthBarfill.DOFillAmount(targetFillAmount, fillSpeed);
    // healthBarfill.color = colorGradient.Evaluate(targetFillAmount);
    
    // }
    // private float maxHealth;
    // private float currentHealth;

    // [SerializeField] private Image healthBarfill;
    // [SerializeField] private Camera camera;
    // [SerializeField] private TextMeshProUGUI healthtext;
    // [SerializeField] private float fillSpeed;
    // [SerializeField] private Gradient colorGradient;

    // void Start()
    // {
    //     // Set initial health values
       
    // }

    // void Update()
    // {
    //     transform.rotation = camera.transform.rotation;
    // }

    // // Method to update health and health bar
    // public void UpdateHealth(float newMaxHealth, float newCurrentHealth)
    // {
    //     maxHealth = newMaxHealth;
    //     currentHealth = newCurrentHealth;

    //     // Update health text
    //     healthtext.text = currentHealth.ToString();

    //     // Update health bar visuals
    //     UpdateHealthbar();
    // }
    // public void Update2 (float amount) {

    //     currentHealth += amount;
    //     healthtext.text = currentHealth.ToString();
    //     UpdateHealthbar();
    // }

    // // Method to update health bar visuals
    // private void UpdateHealthbar()
    // {
    //     float targetFillAmount = currentHealth / maxHealth;
    //     healthBarfill.DOFillAmount(targetFillAmount, fillSpeed);
    //     healthBarfill.color = colorGradient.Evaluate(targetFillAmount);
    // }
}


