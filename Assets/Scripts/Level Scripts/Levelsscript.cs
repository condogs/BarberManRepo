using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Levelsscript : MonoBehaviour {


    //Initialising some variables
 
    public float LevelTimer = 60;           //Level Timer - how much time in the level left
    public int LevelNumber = 1;             //Level Number - What level are we on
    int WaveCount = 2;                      //Wave Count - How many waves left in a level
    public float WaveTimer = 20;            //Wave Timer - How long a wave goes for
    public int CurrentWave = 1;             //CurrentWave - What Wave we are on - displays on user HUD
    public Text WaveGUI;                    //Wave GUI - The specific GUI element for assigning the Current Wave Number
    public Text LevelGUI;                   //Level GUI - The specific GUI element for assigning the Current Level Number
    public bool LevelActive = true;         //Level Active - Is the level in action, or are we in a intermission(break), this determines which.
    public float IntermissionTimer = 30;    //IntermissionTimer - How long a intermission goes for

    public Text IntermissionTimerGUI;
    public GameObject IntermissionGameObjectGUI;

    //wavesystem
    public float SpawnTimer = 4.0f;
    public GameObject Enemy;
    public GameObject EnemySpawn;

	// Use this for initialization
	void Start () {

        IntermissionTimerGUI.GetComponent<Text>().text = " ";

    }
	
	// Update is called once per frame
	void Update () {
	
        
        //After wave 3, level active will becoome false, for a break
        if(LevelActive == true)
        {
            LevelTimer -= Time.deltaTime;
            WaveTimer -= Time.deltaTime;
        }
        
        //So if the Level Timer gets to zero, we need a couple things to happen:
        // 1st - Add 1 to the current number
        // 2nd - Reset the intermission Timer
        // 3rd - Reset the Level Timer
        if (LevelTimer < 0)
        {
            Debug.Log("Level complete: " + LevelNumber);
            LevelNumber++;
            IntermissionTimer = 30;
            LevelTimer = 60;
        }

        //When the Wave Timer gets to zero we need a couple things to happen:
        // 1st - Subtract from the WaveCount - This is to keep track of how many waves per level, it starts at 2 and once it goes below 0 it resets
        // 2nd - Add 1 to the current wave number to let the player know what level he/she is on
        // 3rd - Reset the Wave timer to 20 seconds
        if (WaveTimer < 0)
        {
            Debug.Log("Wave complete: " + WaveCount);
            WaveCount--;
            CurrentWave++;
            WaveTimer = 20;
            
            
        }

        //When the wave count gets to zero, after counting down from 2 (3 waves), Set the level active as false so the intermission begins and Level 2 begins
        if(WaveCount < 0)
        {
            LevelActive = false;
        }

        //If the level is not active, the intermission timer will be enabled and the wave count will be reset
        if(LevelActive == false)
        {
            IntermissionTimer -= Time.deltaTime;
            WaveCount = 2;
            IntermissionGameObjectGUI.SetActive(true);
        }
        else
        {
            IntermissionGameObjectGUI.SetActive(false);
        }

        //If the intermission timer is over, that means the next level will start, therefor Level is now active, and the intermission will stay at -1
        if(IntermissionTimer <= 0)
        {
            LevelActive = true;
            IntermissionTimer = -1;
        }
        if(IntermissionTimer >= 0)
        {
            IntermissionTimerGUI.GetComponent<Text>().text = "BREAK!:  " + IntermissionTimer;
        }


        //Wave GUI
        //Change the wave number on screen as it increases.
        WaveGUI.GetComponent<Text>().text = "Wave: " + CurrentWave;
        LevelGUI.GetComponent<Text>().text = "Level: " + LevelNumber;



        //WaveSystem

        if(LevelActive == true)
        {

            //everytime the enemy spawn timer resets to zero initiate a enemy
            SpawnTimer -= Time.deltaTime;
            if(SpawnTimer <= 0)
            {

                Instantiate(Enemy, EnemySpawn.transform.position, Quaternion.identity);
                SpawnTimer = Random.Range(3,9);                                             //The next enemy will spawn on a time between 3-9 seconds
            }


        }

    }
}
