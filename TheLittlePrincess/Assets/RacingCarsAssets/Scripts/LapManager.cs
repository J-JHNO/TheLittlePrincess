<<<<<<< Updated upstream
using System;
=======
>>>>>>> Stashed changes
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class LapManager : MonoBehaviour
{
<<<<<<< Updated upstream
    public GameManager gameManager;
    public List<Checkpoint> checkpoints;
    public int totalLaps = 1;

    private List<PlayerRank> playerRanks = new List<PlayerRank>();
    private PlayerRank redPlayerRank;
    private PlayerRank greenPlayerRank;
    private PlayerRank winner;
    public UnityEvent onPlayerFinished = new UnityEvent();
=======
    public List<Checkpoint> checkpoints;
    public int totalLaps = 3;

    private List<PlayerRank> playerRanks = new List<PlayerRank>();
    private PlayerRank mainPlayerRank;
    public UnityEvent onPlayerFinished = new UnityEvent();

>>>>>>> Stashed changes
    void Start()
    {
        // Get players in the scene
        foreach(CarIdentity carIdentity in GameObject.FindObjectsOfType<CarIdentity>())
        {
<<<<<<< Updated upstream
            Debug.Log("Found car " + carIdentity.gameObject.tag);
            playerRanks.Add(new PlayerRank(carIdentity));
        }
        ListenCheckpoints(true);
        redPlayerRank = playerRanks.Find(player => player.identity.gameObject.tag == "Red");
        greenPlayerRank = playerRanks.Find(player => player.identity.gameObject.tag == "Green");
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.R) || Input.GetKeyDown(KeyCode.G))
        {
            ResetCheckpoints();
        }
    }
    
    private void ResetCheckpoints()
    {
        redPlayerRank.lapNumber = 0;
        greenPlayerRank.lapNumber = 0;
        redPlayerRank.lastCheckpoint = -1;
        greenPlayerRank.lastCheckpoint = -1;
        redPlayerRank.hasFinished = false;
        greenPlayerRank.hasFinished = false;
        
=======
            playerRanks.Add(new PlayerRank(carIdentity));
        }
        ListenCheckpoints(true);
        mainPlayerRank = playerRanks.Find(player => player.identity.gameObject.tag == "Player");
>>>>>>> Stashed changes
    }

    private void ListenCheckpoints(bool subscribe)
    {
        foreach(Checkpoint checkpoint in checkpoints) {
            //TODO : refacctor onChekpointEnter event
            if(subscribe) checkpoint.onCheckpointEnter.AddListener(CheckpointActivated);
            else checkpoint.onCheckpointEnter.RemoveListener(CheckpointActivated);
        }
    }

    public void CheckpointActivated(GameObject car, Checkpoint checkpoint)
    {
        PlayerRank player = playerRanks.Find((rank) => rank.identity == car.GetComponent<CarIdentity>());
        if (checkpoints.Contains(checkpoint) && player!=null)
        {
            // if player has already finished don't do anything
            if (player.hasFinished) return;

            int checkpointNumber = checkpoints.IndexOf(checkpoint);
            // first time ever the car reach the first checkpoint
            bool startingFirstLap = checkpointNumber == 0 && player.lastCheckpoint == -1;
            // finish line checkpoint is triggered & last checkpoint was reached
            bool lapIsFinished = checkpointNumber == 0 && player.lastCheckpoint >= checkpoints.Count - 1;
            if (startingFirstLap || lapIsFinished) 
            { 
                player.lapNumber += 1;
                player.lastCheckpoint = 0;

                // if this was the final lap
                if (player.lapNumber > totalLaps)
                {
                    player.hasFinished = true;
                    // getting final rank, by finding number of finished players
                    player.rank = playerRanks.FindAll(player => player.hasFinished).Count;

                    // if first winner, display its name
<<<<<<< Updated upstream
                    if (player == redPlayerRank && !greenPlayerRank.hasFinished) // display player rank if not winner
                    {
                        Debug.Log("Red player finished first");
                        winner = redPlayerRank;
                    }
                    else if (player == greenPlayerRank && !redPlayerRank.hasFinished)
                    {
                        Debug.Log("Green player finished first");
                        winner = greenPlayerRank;
                    }
                    
                    gameManager.CheckBetResult(winner);

                    if (player == redPlayerRank)
                    {
                        onPlayerFinished.Invoke();
                        //sceneLoader.LoadMenu(); 
                        //SceneManager.LoadScene(0);
                    }
                }
=======
                    if (player.rank == 1)
                    {

                        // TODO : create attribute divername in CarIdentity 
                        //Debug.Log(player.identity.driverName + " won");
                    }
                    else if (player == mainPlayerRank) // display player rank if not winner
                    {
                    }

                    if (player == mainPlayerRank)
                    {
                        onPlayerFinished.Invoke();
                        //sceneLoader.LoadMenu(); 
                        SceneManager.LoadScene(0);
                    }
                }
                else {
                    // TODO : create attribute divername in CarIdentity 
                    //Debug.Log(player.identity.driverName + ": lap " + player.lapNumber);
                }
>>>>>>> Stashed changes
            }
            // next checkpoint reached
            else if (checkpointNumber == player.lastCheckpoint + 1)
            {
                player.lastCheckpoint += 1;
            }
        }
    }
<<<<<<< Updated upstream
    
    
=======
>>>>>>> Stashed changes
}
