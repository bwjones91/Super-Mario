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

    public PlayerState myPlayerState { get; private set; }
   


    public int lives = 3;
    public int coins = 0;
    public GameObject projectileFire;
    public Transform projectileSocketRight;
    public Transform projectileSocketLeft;


    private bool changeMario = false;
    private bool hasFire = false;

    private int numFireBallsOnScreen = 2;
    private int coinLife = 100;
    private bool canShoot = false;
    private SpriteRenderer spriteRenderer;
    private PolygonCollider2D myPolygonCollider2D;
    private CircleCollider2D myCircleCollider2D;
    private BoxCollider2D myBoxcollider2D;
    private GameObject groundCheck;
    private GameObject fireball;
    private PlayerController playerController;
   

    void Start()
    {
        changeMario = false;
        myPlayerState = PlayerState.MarioSmall;
        anim = GetComponent<Animator>();
        playerController = gameObject.GetComponent<PlayerController>();

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

        if (Input.GetKeyDown(KeyCode.RightShift))
        {
            if (hasFire)
            {
                ShootFireball();
            }
        }
    }

    void AddCoin(int numCoin)
    {
        coins += numCoin;
    }

    public void GrowPlayerState()
    {
        if ((int)myPlayerState < 3)
        {
            myPlayerState++;
            changeMario = true;
        }
    }

    public void ShrinkPlayerState()
    {
        myPlayerState--;
        changeMario = true;
    }

    public void ShootFireball()
    {
        if(GameObject.FindGameObjectsWithTag("Fireball").Length < 2)
        {
            fireball = (GameObject)Instantiate(projectileFire, new Vector3(projectileSocketLeft.position.x, projectileSocketLeft.position.y, 0), Quaternion.identity);
            if (playerController.facingRight)
            {
                //spawn fireball right
                fireball.GetComponent<fireballController>().moveSpeed = -3;
              }
            else
            {
                //spawn fireball left
                fireball.GetComponent<fireballController>().moveSpeed = 3;
            }
        }
    }

    void SetPlayerState()
    {
        switch (myPlayerState)
        {
            case PlayerState.MarioSmall:
                print("mario is small");
                myPolygonCollider2D.offset = new Vector2(myPolygonCollider2D.offset.x, myPolygonCollider2D.offset.y - .08F);
                myCircleCollider2D.offset = new Vector2(myCircleCollider2D.offset.x, myCircleCollider2D.offset.y + .1F);
                myBoxcollider2D.size = new Vector2(myBoxcollider2D.size.x, myBoxcollider2D.size.y - .2F);
                groundCheck.transform.position = new Vector2(groundCheck.transform.position.x, groundCheck.transform.position.y + .09F);
                hasFire = false;
                break;
            case PlayerState.MarioBig:
                print("mario is big");
                myPolygonCollider2D.offset = new Vector2(myPolygonCollider2D.offset.x, myPolygonCollider2D.offset.y + .08F);
                myCircleCollider2D.offset = new Vector2(myCircleCollider2D.offset.x, myCircleCollider2D.offset.y - .1F);
                myBoxcollider2D.size = new Vector2(myBoxcollider2D.size.x, myBoxcollider2D.size.y + .2F);
                groundCheck.transform.position = new Vector2(groundCheck.transform.position.x, groundCheck.transform.position.y - .09F);
                hasFire = false;
                break;
            case PlayerState.MarioFire:
                hasFire = true;
                print("mario is fire");
     
                break;
            case PlayerState.MarioDead:
                print("mario is dead");

                break;
        }
    }

    




}
