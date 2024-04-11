using DG.Tweening;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class Enemy_Healthbar_Script : MonoBehaviour
{
    public float _maxHealth = 100;
    public float _currentHealth;

    [SerializeField] private Image _healthBarfill;
    [SerializeField] public Camera camera;
    [SerializeField] Transform target;
    [SerializeField] public TextMeshProUGUI _healthtext;
    [SerializeField] public float _fillSpeed;
    [SerializeField] public Gradient _ColorGradient;
    void Start()
    {

        _currentHealth = _maxHealth;
        _healthtext.text = _currentHealth.ToString();

    }
    void Update()
    {
        transform.rotation = camera.transform.rotation;

        if (Input.GetKeyDown(KeyCode.Space))
        {
            UpdateHealth(-10);

        }
    }
    public void UpdateHealth(float amount)
    {
        _currentHealth += amount;
        _healthtext.text = _currentHealth.ToString();
        UpdateHealthbar();

    }
    public void UpdateHealthbar()
    {
        float targetFillAmount = _currentHealth / _maxHealth;
        //_healthBarfill.fillAmount = targetFillAmount;
        _healthBarfill.DOFillAmount(targetFillAmount, _fillSpeed);
        _healthBarfill.color = _ColorGradient.Evaluate(targetFillAmount);
    }
}
