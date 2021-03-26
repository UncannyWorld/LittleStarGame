using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class Saving : MonoBehaviour
{
    public static Saving Instance{get;set;}
    
    void Awake()
    {
        if(Instance == null || Saving.Instance == null)
            Instance = this;
        else
            Destroy(this);
        PlayerPrefs.SetFloat("score",0);
        if(!PlayerPrefs.HasKey("highscore")) PlayerPrefs.SetFloat("highscore",0);
        DontDestroyOnLoad(this);
    }
    
    // Update is called once per frame
    public float GetScore(){
        return PlayerPrefs.GetFloat("score");
    }
    public void SetScore(float score){
        PlayerPrefs.SetFloat("score",score);
        if(score !=0 && (score < GetHighScore() || GetHighScore() == 0)){
            SetHighScore(score);
        }
    }
    public float GetHighScore(){
        return PlayerPrefs.GetFloat("highscore");
    }
    public void SetHighScore(float hscore){
        PlayerPrefs.SetFloat("highscore",hscore);
    }
}
