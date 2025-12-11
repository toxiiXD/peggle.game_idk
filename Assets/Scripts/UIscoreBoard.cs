using TMPro;
using UnityEngine;

public class UIscoreBoard : MonoBehaviour
{
    public TMP_Text scoreField;
    [SerializeField] private TMP_Text multipliererfield;
    
    private void Start()
    {
        combosystem.OnScoreChange += UpdateUI;                  
    }

    
    private void OnDisable ()
    {
        combosystem.OnScoreChange -= UpdateUI;                 
    }
    private void UpdateUI(int score, int multiplier)    
    {
        scoreField.text = $"Score: {score}";
        multipliererfield.text = $"multiplier: {multiplier}";
    }
}
