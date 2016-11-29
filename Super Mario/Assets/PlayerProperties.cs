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

    Animator anim;

    

    public PlayerState myPlayerState = PlayerState.MarioSmall;


    public int lives = 3;
    public int coins = 0;
    public GameObject projectileFire;
    public Transform projectileSocketRight;
    public Transform projectileSocketLeft;
    public Sprite spriteMarioSmall;
    public Sprite spriteMarioBig;
    public Sprite spriteMarioFire;
    public Sprite spriteMarioDead;
  

    public bool changeMario = false;
    public bool hasFire = false;

    private int numFireBalls = 2;
    private int coinLife = 100;
    private bool canShoot = false;
    private SpriteRenderer spriteRenderer;
   

    void Start()
    {
        anim = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    void Update()
    {
        anim.SetInteger("State", (int)myPlayerState);


        if (changeMario)
        {
            SetPlayerState();
            changeMario = false;
        }
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
                spriteRenderer.sprite = spriteMarioSmall;
                break;
            case PlayerState.MarioBig:
                print("mario is big");
                spriteRenderer.sprite = spriteMarioBig;
                break;
            case PlayerState.MarioFire:
                print("mario is fire");
                spriteRenderer.sprite = spriteMarioFire;
                break;
            case PlayerState.MarioDead:
                print("mario is dead");
                spriteRenderer.sprite = spriteMarioDead;
                break;
        }
    }

    




}
