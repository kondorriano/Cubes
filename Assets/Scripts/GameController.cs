using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public GameObject playerPrefab;
    public GameObject IAPrefab;

    public Texture[] coolFaces;
    public Texture[] angryFaces;


    private PlayerMovement[] players;
    private IAMovement[] ias;


    // Use this for initialization
    void Start () {
        RunGame();
	}

    void RunGame()
    {
        players = new PlayerMovement[1];
        PlayerMovement newPlayer = ((GameObject)GameObject.Instantiate(
                (UnityEngine.Object)playerPrefab,
                playerPrefab.transform.position, playerPrefab.transform.rotation)).GetComponent<PlayerMovement>();
        newPlayer.SetCoolFace(coolFaces[Random.Range(0, coolFaces.Length)]);
        newPlayer.SetAngryFace(angryFaces[Random.Range(0, angryFaces.Length)]);

        players[0] = newPlayer;

        ias = new IAMovement[5];
        for(int i = 0; i < ias.Length; ++i)
        {
            IAMovement newIA = ((GameObject)GameObject.Instantiate(
                (UnityEngine.Object)IAPrefab,
                IAPrefab.transform.position, IAPrefab.transform.rotation)).GetComponent<IAMovement>();
            newIA.SetCoolFace(coolFaces[Random.Range(0, coolFaces.Length)]);

            ias[i] = newIA;
        }

    }

}
