using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    private int m_score = 10000;
    private int m_taget = 0;
    private int m_level = 0;
    private int m_mine = 0;
    private float m_time = 0;

    [Header("UI in running")]
    public Text txtScore;
    public Text txtTaget;
    public Text txtLevel;
    public Text txtMine;
    public Text txtTime;
    public Text txtCanvasTaget;

    [Header("Game object")]
    public GameObject m_playerOldMan;
    public GameObject m_playerMine;
    public GameObject m_anchorExplod;
    public GameObject m_TNTExplod;
    public GameObject m_GOAddScore;
    public int m_iAddScore;
    private Vector2 m_posMine;

    [Header("Screen")]
    public GameObject m_ScreenTaget;
    public GameObject m_ScreenRunning;
    public GameObject m_ScreenShop;
    public GameObject m_ScreenGameover;

    [Header("Anchor")]
    public Vector2 m_VecAttack;
    public Quaternion m_QuaAttack;
    public bool IsAttack = false;
    public string m_sTagPull;

    [Header("Item")]
    public int m_Strength = 1;
    public bool m_IncreateDiamond = false;
    public bool m_IncreteStone = false;
    public bool m_IncreteClover = false;

    [Header("Other")]
    public AddScore AddScoreManager;

    private MapManager m_mapManager;
    private GameStatus m_gameStatus;
    public static GameManager instance { get; private set; }
    private void Awake()
    {
        if(instance == null)
        {
            instance = this;
        }
    }
    void Start()
    {
        m_gameStatus = GameStatus.TAGET;
        //Debug.Log("Start");
        SetActiveScreen(m_gameStatus);

        m_posMine = m_playerMine.transform.position;
        m_level = 1;
        
    }

    void Update()
    {
        switch (m_gameStatus)
        {
            case GameStatus.TAGET:
                {
                    m_taget = Map.taget[m_level - 1];
                    MapManager.Instance.SetActiveMap(m_level);
                    txtLevel.text = m_level + "";
                    txtTaget.text = "" + m_taget;
                    txtCanvasTaget.text = "Mục tiêu:\n" + m_taget;
                    //txtScore.text = "" + m_score;//test

                    m_gameStatus = GameStatus.RUNNING;
                    StartCoroutine(NextRuning());
                    break;
                }
            case GameStatus.RUNNING:
                {
                    m_time -= Time.deltaTime;
                    txtTime.text = "" + (int)m_time;
                    if(m_time < 0)
                    {
                        //Debug.Log("update m_time < 0");
                        if(m_score >= m_taget)
                        {
                            SetActiveScreen(GameStatus.SHOP);
                        }
                        else
                        {
                            SetActiveScreen(GameStatus.GAMEOVER);
                        }
                    }
                    break;
                }
            case GameStatus.SHOP:
                {
                    break;
                }
            case GameStatus.GAMEOVER:
                {
                    break;
                }
        }        
    }
    IEnumerator NextRuning()
    {
        yield return new WaitForSeconds(2);
        Debug.Log("NextRunning");
        SetActiveScreen(GameStatus.RUNNING);
    }
    public void SetActiveScreen(GameStatus gameStatus)
    {
        m_gameStatus = gameStatus;
        m_ScreenTaget.SetActive(false);
        if(gameStatus != GameStatus.GAMEOVER)
        {
            m_ScreenRunning.SetActive(false);
        }        
        m_ScreenShop.SetActive(false);
        m_ScreenGameover.SetActive(false);
        switch (gameStatus)
        {
            case GameStatus.TAGET:
                {
                    //Debug.Log("gamemanager SetActiveScreen: GameStatus.TAGET");
                    m_time = Map.time;
                    m_level++;
                    m_taget = Map.taget[m_level];
                    m_ScreenTaget.SetActive(true);
                    SoundManager.Instansce._BackgroundTaget();
                    break;
                }
            case GameStatus.RUNNING:
                {
                    //Debug.Log("gamemanager SetActiveScreen: GameStatus.RUNNING");
                    Debug.Log("m_level:" + m_level);
                    m_ScreenRunning.SetActive(true);
                        Anchor.Instance._Init();
                    break;
                }
            case GameStatus.SHOP:
                {
                    m_ScreenShop.SetActive(true);
                    break;
                }
            case GameStatus.GAMEOVER:
                {
                    m_ScreenGameover.SetActive(true);
                    break;
                }
        }
    }
    public void _AddValueGift()
    {
        int value = Random.Range(0, 3);
        if (value == 0)//drink strength
        {
            m_Strength = 2;
        }
        if(value == 1)//add 1 mine
        {
            Add1Mine();
        }
        if(value == 2)//add money
        {
            AddScoreAnimator(Random.Range(3, 546));
        }
        Debug.Log("_AddValueGift:" + value);
    }
    public void CreateTNTExplod(Vector3 pos)
    {
        Instantiate(m_TNTExplod, pos, Quaternion.identity);
        SoundManager.Instansce._Explod();
    }
    public void ThrowMine()
    {
        m_playerMine.SetActive(true);
        m_playerMine.GetComponent<Rigidbody2D>().AddForce(GameManager.instance.m_VecAttack * Mine.SpeedThrow);
        m_playerMine.transform.rotation = GameManager.instance.m_QuaAttack;
        GameManager.instance.SetAniOldManThrowMine();
        SoundManager.Instansce._Explod();
    }
    public void SetActiveExplod(bool isActive)
    {
        m_anchorExplod.SetActive(isActive);
    }
    public void SetDefaultPosMine()
    {
        m_playerMine.transform.position = m_posMine;
        m_playerMine.SetActive(false);
    }
    public void SetAniOldManPull()
    {
        m_playerOldMan.GetComponent<Animator>().SetInteger("OldMan", 1);
    }
    public void SetAniOldManThrowMine()
    {
        m_playerOldMan.GetComponent<Animator>().SetInteger("OldMan", -1);
    }
    public void SetAniOldManIDE()
    {
        m_playerOldMan.GetComponent<Animator>().SetInteger("OldMan", 0);
    }
    
    public void Add1Mine()
    {
        m_mine++;
        txtMine.text = "" + m_mine;
    }
    public void AddScoreAnimator(int score)
    {
        m_iAddScore = score;
        AddScore.Instance._init();
        SoundManager.Instansce._AddScore();
    }
    public void SetScore(int score)
    {
        m_score += score;
        txtScore.text = "" + m_score;
    }
}
