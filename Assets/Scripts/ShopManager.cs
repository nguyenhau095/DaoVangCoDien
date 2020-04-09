using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShopManager : MonoBehaviour
{
    public GameObject m_owner;
    public Canvas m_canvasShop;
    public Text m_txtInfo;

    [Header("Item:")]
    public GameObject m_Mine;
    public GameObject m_StrengthDrink;
    public GameObject m_Stone;
    public GameObject m_IncreateDiamond;
    public GameObject m_Clover;

    [Header("Button buy item:")]
    public GameObject m_BuyMine;
    public GameObject m_BuyStrengthDrink;
    public GameObject m_BuyStone;
    public GameObject m_BuyIncreateDiamond;
    public GameObject m_BuyClover;

    [Header("Text show price item:")]
    public Text m_txtBuyMine;
    public Text m_txtBuyStrengthDrink;
    public Text m_txtBuyStone;
    public Text m_txtBuyIncreateDianomd;
    public Text m_txtBuyClover;
    private void Start()
    {
        _Init();
    }
    void _Init()
    {
        SetInactiveAllBuy();
        SetinactiveAllBTN();
        int SumItem = 5;
        int []listItem = new int[SumItem];
        int sumItemActive = 0;
        while(sumItemActive == 0)
        {
            for (int i = 0; i < SumItem; i++)
            {
                int i_radom = Random.Range(0, 2);
                //listItem[i] = i_radom;
                listItem[i] = 1;
                if(i_radom == 1)
                {
                    sumItemActive++;
                }
                //Debug.Log(i + ": " + listItem[i]);
            }
        }        
        if(listItem[0] == 1)
        {
            //Debug.Log("_init m_Mine");
            m_Mine.SetActive(true);
            m_txtBuyMine.text = "" + Random.Range(29, 38);
        }
        if (listItem[1] == 1)
        {
            //Debug.Log("_init m_StrengthDrink");
            m_StrengthDrink.SetActive(true);
            m_txtBuyStrengthDrink.text = "" + Random.Range(102, 396);
        }
        if (listItem[2] == 1)
        {
            //Debug.Log("_init m_BuyStone");
            m_Stone.SetActive(true);
            m_txtBuyStone.text = "" + Random.Range(8, 148);
        }
        if (listItem[3] == 1)
        {
            //Debug.Log("_init m_BuyIncreateDiamond");
            m_IncreateDiamond.SetActive(true);
            m_txtBuyIncreateDianomd.text = "" + Random.Range(293, 682);
        }
        if (listItem[4] == 1)
        {
            //Debug.Log("_init m_txtBuyMine");
            m_Clover.SetActive(true);
            m_txtBuyClover.text = "" + Random.Range(27, 215);
        }
    }
    private int m_sumItemBougth = 0;
    void SetinactiveAllBTN()
    {
        m_Mine.SetActive(false);
        m_StrengthDrink.SetActive(false);
        m_Stone.SetActive(false);
        m_IncreateDiamond.SetActive(false);
        m_Clover.SetActive(false);
    }
    void SetInactiveAllBuy()
    {
        m_BuyMine.SetActive(false);
        m_BuyStrengthDrink.SetActive(false);
        m_BuyStone.SetActive(false);
        m_BuyIncreateDiamond.SetActive(false);
        m_BuyClover.SetActive(false);
    }
    public void btnMine()
    {
        Debug.Log("shop btnMine");
        m_txtInfo.text = "Khi lượm được những thứ mà bạn không muốn kéo lên, nhấn phim mũi tên để ném thỏi thuốc nổ vào nó và làm nó nổ tung";
        SetInactiveAllBuy();
        m_BuyMine.SetActive(true);
    }
    public void btnPower()
    {
        Debug.Log("shop btnPower");
        m_txtInfo.text = "Thuốc tăng lực, người thợ mỏ sẽ kéo vật nặng nhanh hơn. Chỉ có tác dụng trong 1 cửa";
        SetInactiveAllBuy();
        m_BuyStrengthDrink.SetActive(true);
    }
    public void btnIncreateDiamond()
    {
        Debug.Log("shop btnIncreateDiamond");
        m_txtInfo.text = "Đánh bóng kim cương, làm kim cương có giá trị hơn. Chỉ có giá trị trong 1 cửa";
        SetInactiveAllBuy();
        m_BuyIncreateDiamond.SetActive(true);
    }
    public void btnClover()
    {
        Debug.Log("shop btnClover");
        m_txtInfo.text = "Hoa may mắn, sẽ tăng cơ hội nhận được những thứ có giá trị trong túi có dấu hỏi. Chỉ dùng được 1 cửa";
        SetInactiveAllBuy();
        m_BuyClover.SetActive(true);
    }
    public void btnStone()
    {
        Debug.Log("shop btnStone");
        m_txtInfo.text = "Bộ sưu tập đá, đá sẽ tăng giá trị gấp 3 lầm trong cửa kế tiếp. Chỉ có tác dụng trong 1 cửa";
        SetInactiveAllBuy();
        m_BuyStone.SetActive(true);
    }
    public void btnContinues()
    {
        Debug.Log("shop btnContinues");
        m_txtInfo.text = "btnContinues";
        m_owner.GetComponent<Animator>().SetInteger("Owner", 0);
        StartCoroutine(NextLevel());
        SoundManager.Instansce._NextMap();
    }
    public void btnBuyMine()
    {
        Debug.Log("shop btnBuyMine");
        GameManager.instance.Add1Mine();
        m_BuyMine.SetActive(false);
        m_Mine.SetActive(false);
    }
    public void btnBuyPower()
    {
        Debug.Log("shop btnBuyPower");
        GameManager.instance.m_Strength = 2;
        m_BuyStrengthDrink.SetActive(false);
        m_StrengthDrink.SetActive(false);
    }
    public void btnBuyIncreateDiamond()
    {
        Debug.Log("shop btnBuyIncreateDiamond");
        GameManager.instance.m_IncreateDiamond = true;
        m_BuyIncreateDiamond.SetActive(false);
        m_IncreateDiamond.SetActive(false);
    }
    public void btnBuyClover()
    {
        Debug.Log("shop btnBuyClover");
        GameManager.instance.m_IncreteClover = true;
        m_BuyClover.SetActive(false);
        m_Clover.SetActive(false);
    }
    public void btnBuyStone()
    {
        Debug.Log("shop btnBuyStone");
        GameManager.instance.m_IncreteStone = true;
        m_BuyStone.SetActive(false);
        m_Stone.SetActive(false);
    }
    IEnumerator NextLevel()
    {
        Debug.Log("NextLevel");
        yield return new WaitForSeconds(1);
        m_owner.GetComponent<Animator>().SetBool("Angry", false);
        GameManager.instance.SetActiveScreen(GameStatus.TAGET);
    }
}
