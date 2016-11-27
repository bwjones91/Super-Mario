using UnityEngine;
using System.Collections;

public class PlayerProperties : MonoBehaviour {

    public enum PlayerState
    {
        MarioDead = 0,
        MarioSmall = 1,
        MarioBig = 2,
        MarioFire = 3
    }

    public PlayerState myPlayerState = PlayerState.MarioSmall;


    public int lives = 3;
    public int coins = 0;
    public GameObject projectileFire;
    public Transform projectileSocketRight;
    public Transform projectileSocketLeft;
    public Material materialMarioStandard;
    public Material materialMarioFire;

    public bool changeMario = false;
    public bool hasFire = false;

    private int numFireBalls = 2;
    private int coinLife = 100;
    private bool canShoot = false;

    void Update()
    {
        SetPlayerState();
    }

    void AddCoin(int numCoin)
    {
        coins += numCoin;
    }

    void SetPlayerState()
    {
        switch (myPlayerState)
        {
            case PlayerState.MarioSmall:
                print("mario is small");
                break;
            case PlayerState.MarioBig:
                print("mario is big");
                break;
            case PlayerState.MarioFire:
                print("mario is fire");
                break;
            case PlayerState.MarioDead:
                print("mario is dead");
                break;
        }
    }

    




}
