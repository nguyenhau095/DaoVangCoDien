using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Anchor : MonoBehaviour
{
    private float m_speedAngle = 2;
    private float m_angleMax = 90;
    private float m_speed = 100;
    private Vector3 m_pos = new Vector3(-0.3f, 2.25f, 0);

    private Rigidbody2D ri;
    private LineRenderer lr;

    public GameObject m_anchorGoldBig;
    public GameObject m_anchorGoldNormal;
    public GameObject m_anchorGoldSmall;
    public GameObject m_anchorStoneNormal;
    public GameObject m_anchorStoneSmall;
    public GameObject m_anchorDiamond;
    public GameObject m_anchorMouse;
    public GameObject m_anchorMouseDiamond;
    public GameObject m_anchorTNT;
    public GameObject m_anchorGift;

    public GameObject m_anchorImg;
    private Animator m_anchorImgAnimator;

    public static Anchor Instance { get; set; }
    private void Awake()
    {
        if(Instance == null)
        {
            Instance = this;
        }
    }
    void Start()
    {
        ri = GetComponent<Rigidbody2D>();
        lr = GetComponent<LineRenderer>();
        lr.SetPosition(0, m_pos);
        m_anchorImgAnimator = m_anchorImg.GetComponent<Animator>();
        _Init();
    }
    public void _Init()
    {
        if(ri != null)
        {
            ri.velocity = new Vector2(0, 0);
        }
        transform.position = m_pos;
        GameManager.instance.IsAttack = false;
        GameManager.instance.SetAniOldManIDE();
        GameManager.instance.m_sTagPull = "";
        GameManager.instance.SetDefaultPosMine();
        GameManager.instance.SetActiveExplod(false);
        if(m_anchorImgAnimator != null)
        {
            m_anchorImgAnimator.SetBool("Pull", false);
        }        
    }
    // Update is called once per frame
    void Update()
    {
        lr.SetPosition(1, transform.position);
        if (Input.GetKeyDown(KeyCode.DownArrow))
        {
            GameManager.instance.IsAttack = true;
            float rotationZ = Mathf.Sin(Time.time * m_speedAngle) * m_angleMax;
            float x = Mathf.Sin(rotationZ * Mathf.Deg2Rad) * m_speed;
            float y = Mathf.Cos(rotationZ * Mathf.Deg2Rad) * m_speed;
            GameManager.instance.m_VecAttack = new Vector2(x, -y);
            GameManager.instance.m_QuaAttack = transform.rotation;
            ri.AddForce(GameManager.instance.m_VecAttack);
            GameManager.instance.SetAniOldManPull();
            SoundManager.Instansce._ThrowAnchor();
        }
        if (Input.GetKeyDown(KeyCode.UpArrow))
        {
            if (GameManager.instance.IsAttack && GameManager.instance.m_sTagPull != "")
            {
                GameManager.instance.ThrowMine();
            }
        }
    }
    private void FixedUpdate()
    {
        if (!GameManager.instance.IsAttack)
        {
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Sin(Time.time * m_speedAngle) * m_angleMax);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //Debug.Log("AnchorImg " + collision.gameObject.tag);
        if (collision.gameObject.tag == "Gift")
        {
            //Debug.Log("Gift");
            ri.velocity = new Vector2(-ri.velocity.x * Gift.speed * GameManager.instance.m_Strength, -ri.velocity.y * Gift.speed * GameManager.instance.m_Strength);

            m_anchorGift.SetActive(true);
            collision.gameObject.SetActive(false);
            m_anchorImgAnimator.SetBool("Pull", true);
            GameManager.instance.m_sTagPull = "Gift";
            SoundManager.Instansce._GoldSmall();
            SoundManager.Instansce._PullAnchor();
        }
        if (collision.gameObject.tag == "golgBig")
        {
            //Debug.Log("golgBig");
            ri.velocity = new Vector2(-ri.velocity.x * GoldBig.speed * GameManager.instance.m_Strength, -ri.velocity.y * GoldBig.speed * GameManager.instance.m_Strength);

            m_anchorGoldBig.SetActive(true);
            collision.gameObject.SetActive(false);
            m_anchorImgAnimator.SetBool("Pull", true);
            GameManager.instance.m_sTagPull = "goldBig";
            SoundManager.Instansce._GoldBig();
            SoundManager.Instansce._PullAnchor();
        }
        if (collision.gameObject.tag == "GoldNormal")
        {
            //Debug.Log("GoldNormal");
            ri.velocity = new Vector2(-ri.velocity.x * GoldNormal.speed * GameManager.instance.m_Strength, -ri.velocity.y * GoldNormal.speed * GameManager.instance.m_Strength);
            m_anchorGoldNormal.SetActive(true);
            collision.gameObject.SetActive(false);
            m_anchorImgAnimator.SetBool("Pull", true);
            GameManager.instance.m_sTagPull = "GoldNormal";
            SoundManager.Instansce._GoldSmall();
            SoundManager.Instansce._PullAnchor();
        }
        if (collision.gameObject.tag == "GoldSmall")
        {
            //Debug.Log("GoldSmall"); 
            ri.velocity = new Vector2(-ri.velocity.x * GoldSmall.speed * GameManager.instance.m_Strength, -ri.velocity.y * GoldSmall.speed * GameManager.instance.m_Strength);
            m_anchorGoldSmall.SetActive(true);
            collision.gameObject.SetActive(false);
            m_anchorImgAnimator.SetBool("Pull", true);
            GameManager.instance.m_sTagPull = "GoldSmall";
            SoundManager.Instansce._GoldSmall();
            SoundManager.Instansce._PullAnchor();
        }
        if (collision.gameObject.tag == "StoneNormal")
        {
            //Debug.Log("StoneNormal");
            ri.velocity = new Vector2(-ri.velocity.x * StoneNormal.speed * GameManager.instance.m_Strength, -ri.velocity.y * StoneNormal.speed * GameManager.instance.m_Strength);
            m_anchorStoneNormal.SetActive(true);
            collision.gameObject.SetActive(false);
            m_anchorImgAnimator.SetBool("Pull", true);
            GameManager.instance.m_sTagPull = "StoneNormal";
            SoundManager.Instansce._Stone();
            SoundManager.Instansce._PullAnchor();
        }
        if (collision.gameObject.tag == "StoneSmall")
        {
            //Debug.Log("StoneSmall");
            ri.velocity = new Vector2(-ri.velocity.x * StoneSmall.speed * GameManager.instance.m_Strength, -ri.velocity.y * StoneSmall.speed * GameManager.instance.m_Strength);
            m_anchorStoneSmall.SetActive(true);
            collision.gameObject.SetActive(false);
            m_anchorImgAnimator.SetBool("Pull", true);
            GameManager.instance.m_sTagPull = "StoneSmall";
            SoundManager.Instansce._Stone();
            SoundManager.Instansce._PullAnchor();
        }
        if (collision.gameObject.tag == "Diamond")
        {
            //Debug.Log("Diamond");
            ri.velocity = new Vector2(-ri.velocity.x * Diamond.speed * GameManager.instance.m_Strength, -ri.velocity.y * Diamond.speed * GameManager.instance.m_Strength);
            m_anchorDiamond.SetActive(true);
            collision.gameObject.SetActive(false);
            m_anchorImgAnimator.SetBool("Pull", true);
            GameManager.instance.m_sTagPull = "Diamond";
            SoundManager.Instansce._Diamond();
            SoundManager.Instansce._PullAnchor();
        }
        if (collision.gameObject.tag == "Mouse" && !_IsPullArchor())
        {
            //Debug.Log("Mouse");
            ri.velocity = new Vector2(-ri.velocity.x * Mouse.speed * GameManager.instance.m_Strength, -ri.velocity.y * Mouse.speed * GameManager.instance.m_Strength);
            m_anchorMouse.SetActive(true);
            collision.gameObject.SetActive(false);
            m_anchorImgAnimator.SetBool("Pull", true);
            GameManager.instance.m_sTagPull = "Mouse";
            SoundManager.Instansce._Stone();
            SoundManager.Instansce._PullAnchor();
        }
        if (collision.gameObject.tag == "MouseDiamond" && !_IsPullArchor())
        {
            //Debug.Log("MouseDiamond");
            ri.velocity = new Vector2(-ri.velocity.x * MouseDiamond.speed * GameManager.instance.m_Strength, -ri.velocity.y * MouseDiamond.speed * GameManager.instance.m_Strength);
            m_anchorMouseDiamond.SetActive(true);
            collision.gameObject.SetActive(false);
            m_anchorImgAnimator.SetBool("Pull", true);
            GameManager.instance.m_sTagPull = "MouseDiamond";
            SoundManager.Instansce._Diamond();
            SoundManager.Instansce._PullAnchor();
        }
        if (collision.gameObject.tag == "TNT")
        {
            //Debug.Log("TNT");
            ri.velocity = new Vector2(-ri.velocity.x * MouseDiamond.speed * GameManager.instance.m_Strength, -ri.velocity.y * MouseDiamond.speed * GameManager.instance.m_Strength);
            m_anchorTNT.SetActive(true);
            m_anchorImgAnimator.SetBool("Pull", true);
            GameManager.instance.m_sTagPull = "TNT";
            collision.gameObject.GetComponent<Animator>().SetBool("Explod", true);
            GameManager.instance.CreateTNTExplod(collision.gameObject.transform.position);
            collision.gameObject.SetActive(false);
            SoundManager.Instansce._Explod();
            SoundManager.Instansce._PullAnchor();
        }
        if (collision.gameObject.tag == "Wall")
        {
            //Debug.Log("wall");
            Vector2 v2 = new Vector2(-ri.velocity.x * 2 * GameManager.instance.m_Strength, -ri.velocity.y * 2 * GameManager.instance.m_Strength);
            ri.velocity = v2;
        }
        if (collision.gameObject.tag == "OldMan")
        {
            _OnTriggerEnter2DOldMan();
        }
        if(collision.tag == "Mine")
        {
            if (m_anchorGoldBig.activeSelf)
            {
                m_anchorGoldBig.SetActive(false);
                ri.velocity = new Vector2(ri.velocity.x / GoldBig.speed * GameManager.instance.m_Strength, ri.velocity.y / GoldBig.speed * GameManager.instance.m_Strength);
            }
            if (m_anchorGoldNormal.activeSelf)
            {
                m_anchorGoldNormal.SetActive(false);
                ri.velocity = new Vector2(ri.velocity.x / GoldNormal.speed * GameManager.instance.m_Strength, ri.velocity.y / GoldNormal.speed * GameManager.instance.m_Strength);
            }
            if (m_anchorGoldSmall.activeSelf)
            {
                m_anchorGoldSmall.SetActive(false);
                ri.velocity = new Vector2(ri.velocity.x / GoldSmall.speed * GameManager.instance.m_Strength, ri.velocity.y / GoldSmall.speed * GameManager.instance.m_Strength);
            }
            if (m_anchorStoneNormal.activeSelf)
            {
                m_anchorStoneNormal.SetActive(false);
                ri.velocity = new Vector2(ri.velocity.x / StoneNormal.speed * GameManager.instance.m_Strength, ri.velocity.y / StoneNormal.speed * GameManager.instance.m_Strength);
            }
            if (m_anchorStoneSmall.activeSelf)
            {
                m_anchorStoneSmall.SetActive(false);
                ri.velocity = new Vector2(ri.velocity.x / StoneSmall.speed * GameManager.instance.m_Strength, ri.velocity.y / StoneSmall.speed * GameManager.instance.m_Strength);
            }
            if (m_anchorDiamond.activeSelf)
            {
                m_anchorDiamond.SetActive(false);
                ri.velocity = new Vector2(ri.velocity.x / Diamond.speed * GameManager.instance.m_Strength, ri.velocity.y / Diamond.speed * GameManager.instance.m_Strength);
            }
            if (m_anchorMouse.activeSelf)
            {
                m_anchorMouse.SetActive(false);
                ri.velocity = new Vector2(ri.velocity.x / Mouse.speed * GameManager.instance.m_Strength, ri.velocity.y / Mouse.speed * GameManager.instance.m_Strength);
            }
            if (m_anchorMouseDiamond.activeSelf)
            {
                m_anchorMouseDiamond.SetActive(false);
                ri.velocity = new Vector2(ri.velocity.x / MouseDiamond.speed * GameManager.instance.m_Strength, ri.velocity.y / MouseDiamond.speed * GameManager.instance.m_Strength);
            }
            if (m_anchorTNT.activeSelf)
            {
                m_anchorTNT.SetActive(false);
                ri.velocity = new Vector2(ri.velocity.x / TNT.speed * GameManager.instance.m_Strength, ri.velocity.y / TNT.speed * GameManager.instance.m_Strength);
            }
            if (m_anchorDiamond.activeSelf)
            {
                m_anchorDiamond.SetActive(false);
                ri.velocity = new Vector2(ri.velocity.x / Diamond.speed * GameManager.instance.m_Strength, ri.velocity.y / Diamond.speed * GameManager.instance.m_Strength);
            }
            if (m_anchorGift.activeSelf)
            {
                m_anchorGift.SetActive(false);
                ri.velocity = new Vector2(ri.velocity.x / Gift.speed * GameManager.instance.m_Strength, ri.velocity.y / Gift.speed * GameManager.instance.m_Strength);
            }
            ri.velocity = new Vector2(ri.velocity.x * 2, ri.velocity.y * 2);

            collision.gameObject.SetActive(false);
            GameManager.instance.SetActiveExplod(true);
            m_anchorImgAnimator.SetBool("Pull", false);
            GameManager.instance.SetDefaultPosMine();
        }
    }
    bool _IsPullArchor()
    {
        return (ri.velocity.y > 0);
    }
    void _OnTriggerEnter2DOldMan()
    {
	    _Init();
        if (m_anchorGoldBig.activeSelf)
        {
            m_anchorGoldBig.SetActive(false);
            GameManager.instance.AddScoreAnimator(GoldBig.value);
        }
        if (m_anchorGoldNormal.activeSelf)
        {
            m_anchorGoldNormal.SetActive(false);
            GameManager.instance.AddScoreAnimator(GoldNormal.value);
        }
        if (m_anchorGoldSmall.activeSelf)
        {
            m_anchorGoldSmall.SetActive(false);
            GameManager.instance.AddScoreAnimator(GoldSmall.value);
        }
        if (m_anchorStoneNormal.activeSelf)
        {
            m_anchorStoneNormal.SetActive(false);
            if (GameManager.instance.m_IncreateDiamond)
            {
                GameManager.instance.AddScoreAnimator(StoneNormal.valueIncreate);
            }
            else
            {
                GameManager.instance.AddScoreAnimator(StoneNormal.value);
            }
        }
        if (m_anchorStoneSmall.activeSelf)
        {
            m_anchorStoneSmall.SetActive(false);
            if (GameManager.instance.m_IncreateDiamond)
            {
                GameManager.instance.AddScoreAnimator(StoneSmall.valueIncreate);
            }
            else
            {
                GameManager.instance.AddScoreAnimator(StoneSmall.value);
            }
        }
        if (m_anchorDiamond.activeSelf)
        {
            m_anchorDiamond.SetActive(false);
            if (GameManager.instance.m_IncreateDiamond)
            {
                GameManager.instance.AddScoreAnimator(Diamond.valueIncreate);
            }
            else
            {
                GameManager.instance.AddScoreAnimator(Diamond.value);
            }                
        }
        if (m_anchorMouse.activeSelf)
        {
            m_anchorMouse.SetActive(false);
            GameManager.instance.AddScoreAnimator(Mouse.value);
        }
        if (m_anchorMouseDiamond.activeSelf)
        {
            m_anchorMouseDiamond.SetActive(false);
            if (GameManager.instance.m_IncreateDiamond)
            {
                GameManager.instance.AddScoreAnimator(MouseDiamond.valueIncreate);
            }
            else
            {
                GameManager.instance.AddScoreAnimator(MouseDiamond.value);
            }
        }
        if (m_anchorTNT.activeSelf)
        {
            m_anchorTNT.SetActive(false);
            GameManager.instance.AddScoreAnimator(TNT.value);
        }
        if (m_anchorGift.activeSelf)
        {
            m_anchorGift.SetActive(false);
            GameManager.instance._AddValueGift();
        }
    }
}
