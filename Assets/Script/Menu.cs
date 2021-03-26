using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Menu : MonoBehaviour
{
    // Start is called before the first frame update
    public Text hscore;
    public Text score;
    void Start()
    {
        float hs = Saving.Instance.GetHighScore();
        if(hs > 0)
            hscore.text = hs.ToString("00.00");
        else
            hscore.text = "--.--";
        if(score != null){
        float sc = Saving.Instance.GetScore();
            if(sc > 0)
                score.text = sc.ToString("00.00");
            else
                score.text = "--.--";
        }
    }

    public void Play(){
        SceneManager.LoadScene(1);
    }
}
