using UnityEngine;

public class combosystem : MonoBehaviour
{


    public static event Action<int, int> OnScoreChange;

    

    private void CheckForCombo(string tag, int bumperValue) {
        bumperTags.Add(tag);
        if (bumperTags.Count > 1) {
            if (bumperTags[bumperTags.Count - 2] == bumperTags[bumperTags.Count - 1])
            {
                Multiplier++;
            }
            else
            {
                Multiplier = 1;
            }
        }
        ScoreManager.Instance.AddScore(Value * Multiplier);
       
        OnScoreChange?.Invoke(ScoreManager.Instance.score, Multiplier);
        
        

    }
}