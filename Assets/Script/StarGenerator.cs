using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarGenerator : MonoBehaviour
{
    // Start is called before the first frame update
    GameObject starSlot, starParticle;
    Song song;
    GameObject[] allStars;
    public Sprite aStar;
    int amountToInstantiate;
    bool particlePlayed = true;

    void Start()
    {
        Saving.Instance.SetScore(0);
        song = FindObjectOfType<Song>();
        amountToInstantiate = song.songSheet.Length;
        allStars = new GameObject[amountToInstantiate];
        starSlot = Resources.Load<GameObject>("Prefab/StarSlot");
        starParticle = Resources.Load<GameObject>("Prefab/StarParticle");
        CreateStars();
    }
    void Update(){
        foreach (GameObject star in allStars)
        {
            if(star.transform.position.y < -4){
                star.SetActive(false);
            }
            if(star.transform.position.y == -4){
                star.GetComponent<SpriteRenderer>().sprite = aStar;
                if(!particlePlayed) 
                {
                    Instantiate(starParticle,star.transform.position,transform.rotation);
                    particlePlayed = true;
                }
            }
        }
    }

    // Update is called once per frame
    void CreateStars(){
        for (int i = 0; i < amountToInstantiate; i++)
        {
            Vector2 position = new Vector2(Random.Range(-1,2)*2f,-4+(i*2));
            GameObject s = Instantiate(starSlot,position,transform.rotation);
            s.transform.SetParent(transform);
            allStars[i] = s;
        }
    }

    public void SetPosition(int playedChords){
        particlePlayed = false;
        Vector2 pos = transform.position;
        pos.y = -2*playedChords;
        transform.position = pos;
    }
    public int currentStarSlotPosition(int cchord){
        float cposx = allStars[cchord].transform.position.x;
        if(cposx == 2f){
            return 1;
        }
        else if(cposx == 0){
            return 0;
        }
        else{
            return -1;
        }
    }
}
