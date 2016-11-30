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
    private PolygonCollider2D myPolygonCollider2D;
    private CircleCollider2D myCircleCollider2D;
    private BoxCollider2D myBoxcollider2D;
    private GameObject groundCheck;
   

    void Start()
    {
        anim = GetComponent<Animator>();

        spriteRenderer = GetComponent<SpriteRenderer>();
        myPolygonCollider2D = GetComponent<PolygonCollider2D>();
        myCircleCollider2D = GetComponent<CircleCollider2D>();
        myBoxcollider2D = GetComponent<BoxCollider2D>();
        groundCheck = GameObject.Find("groundCheck");
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
                
                break;
            case PlayerState.MarioBig:
                print("mario is big");
                myPolygonCollider2D.offset = new Vector2(myPolygonCollider2D.offset.x, myPolygonCollider2D.offset.y + .08F);
                myCircleCollider2D.offset = new Vector2(myCircleCollider2D.offset.x, myCircleCollider2D.offset.y - .1F);
                myBoxcollider2D.size = new Vector2(myBoxcollider2D.size.x, myBoxcollider2D.size.y + .2F);
                groundCheck.transform.position = new Vector2(groundCheck.transform.position.x, groundCheck.transform.position.y - .09F);

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
