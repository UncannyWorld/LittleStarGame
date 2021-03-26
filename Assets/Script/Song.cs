using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Song : MonoBehaviour
{
    // Start is called before the first frame update
    public AudioClip[] chords;
    public AudioClip gameOverSong;
    public Text score;
    public Image[] btnsImage;
    float timer = 0.0f;
    int currentChord = 0;
    bool gameOver = false;
    float gameOverScreen = 0;
    bool finish = false;
    float finishScreen = 0;
    public int[] songSheet = new int[] {0,0,1,1,2,2,1,
                                 3,3,4,4,5,5,0,
                                 1,1,3,3,4,4,5,
                                 1,1,3,3,4,4,5,
                                 0,0,1,1,2,2,1,
                                 3,3,4,4,5,5,0
                                };

    AudioSource audioSource;
    StarGenerator starGenerator;

    void Start()
    {
        starGenerator = FindObjectOfType<StarGenerator>();
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(gameOver){
            if(gameOverScreen == 0){
                gameOverScreen = Time.time + 2;
            }
            else if(gameOverScreen < Time.time){
                SceneManager.LoadScene(2);
            }
            Debug.Log("GAME OVER!!!");
            score.color = Color.red;
            return;
        }
        if(finish){
            if(finishScreen == 0){
                finishScreen = Time.time + 2;
            }
            else if(finishScreen < Time.time){
                SceneManager.LoadScene(3);
            }
            Debug.Log("Finish!!!");
            if(timer > 20)
                score.color = Color.red;
            else
                score.color = Color.green;
            return;
        }
        if(currentChord > 0 && currentChord < songSheet.Length){
            timer += Time.deltaTime;
            score.text = timer.ToString("00.00");
        }
        if(currentChord >= songSheet.Length){
            finish = true;
            Saving.Instance.SetScore(timer);
            Debug.Log("You Won");
        }
    }
    public void Play(int px){
        if(gameOver) return;
        if(starGenerator.currentStarSlotPosition(currentChord) == px){
            audioSource.Stop();
            audioSource.clip = chords[songSheet[currentChord]];
            audioSource.Play();
            currentChord++;
            starGenerator.SetPosition(currentChord);
        }
        else{
            gameOver = true;
            audioSource.Stop();
            audioSource.clip = gameOverSong;
            audioSource.Play();
            btnsImage[px+1].color = new Color32(150,20,20,150);
            //starGenerator.SetPosition(currentChord+1);
        }
    }
}
