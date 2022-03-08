using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameHandler : MonoBehaviour
{
    [SerializeField] GameObject devilHeadButton;
    [SerializeField] GameObject nahButton;

    public GameObject choice;
    public bool enoughMoney;

    public Row1 rowScript1;
    public Row2 rowScript2;
    public Row3 rowScript3;
    public Row4 rowScript4;

    public bool canTurnHandle = true;

    public AudioSource spinSound;
    public Animator transition;

    public int rowHasStoped = 0;
    public bool resultsChecked = true;
    private int startingBalance = 1000;

    public bool spinningHasStarted = false;

    private int betValue;

    private int firstRowResult = 0;
    private int secondRowResult = 0;
    private int thirdRowResult = 0;
    private int forthRowResult = 0;

    public GameObject row1;
    public GameObject row2;
    public GameObject row3;
    public GameObject row4;

    [SerializeField] Animator devilButtonPressed;
    [SerializeField] Text balance;
    [SerializeField] Animator stopButtonPressed;
    [SerializeField] Text prizeText;
    [SerializeField] GameObject inputField;

    public Animator handleAnimator;


    private void Start()
    {
        devilHeadButton.SetActive(false);
        nahButton.SetActive(false);

        balance.enabled = true;
        prizeText.enabled = true;
        inputField.SetActive(true);

        choice.SetActive(false);
        PlayerPrefs.SetInt("Balance", 10000);
    }

    public void GettingInput(string bet)
    {
        betValue = int.Parse(bet);
        PlayerPrefs.SetInt("Betvalue", betValue);
    }

    public void TurnHandle()
    {
        spinningHasStarted = true;

        if (canTurnHandle)
        {
            if(PlayerPrefs.GetInt("Balance") >= 100 + betValue)
            {
                enoughMoney = true;

                if(betValue != 0)
                {
                    //Take comission
                    PlayerPrefs.SetInt("Balance", PlayerPrefs.GetInt("Balance") - 100);
                }
                PlayerPrefs.SetInt("Balance", PlayerPrefs.GetInt("Balance") - betValue);

                //Animation
                StartCoroutine(TurnHandleCorutine());
                resultsChecked = false;
                spinSound.Play();

                prizeText.text = "BET " + betValue.ToString() + "$";

                inputField.SetActive(false);
            }
            else
            {
                enoughMoney = false;
            }
        }
    }

    IEnumerator TurnHandleCorutine()
    {
        handleAnimator.SetBool("TurnHandle", true);
        yield return new WaitForSecondsRealtime(0.5f);
        handleAnimator.SetBool("TurnHandle", false);
        canTurnHandle = false;
    }

    private void Update()
    {
        balance.text = "BALANCE " + PlayerPrefs.GetInt("Balance").ToString();

        if (rowHasStoped == 4)
        {
            spinSound.Stop();
            CheckResults();
        }
    }

    private void CheckResults()
    {
        if(resultsChecked == false)
        {
            // 1 - Dracusor, 2 - Potcoava, 3 - Trident, 4 - Moneda, 5 - Foc, 6 - Sac, 7 - Banconte

            //First Row
            if (row1.transform.position.y < 0.91 && row1.transform.position.y > -0.81)
            {
                firstRowResult = 1;
            }
            else if (row1.transform.position.y < 2.82)
            {
                firstRowResult = 2;
            }
            else if (row1.transform.position.y < 4.49)
            {
                firstRowResult = 3;
            }
            else if (row1.transform.position.y < 6.14)
            {
                firstRowResult = 4;
            }
            else if (row1.transform.position.y < 8.08)
            {
                firstRowResult = 5;
            }
            else if (row1.transform.position.y < 10.5)
            {
                firstRowResult = 6;
            }
            else if (row1.transform.position.y < 12)
            {
                firstRowResult = 7;
            }
            else if (row1.transform.position.y < 14.13)
            {
                firstRowResult = 1;
            }

            //Second Row
            if (row2.transform.position.y < 0.91 && row2.transform.position.y > -0.81)
            {
                secondRowResult = 1;
            }
            else if (row2.transform.position.y < 2.82)
            {
                secondRowResult = 2;
            }
            else if (row2.transform.position.y < 4.49)
            {
                secondRowResult = 3;
            }
            else if (row2.transform.position.y < 6.14)
            {
                secondRowResult = 4;
            }
            else if (row2.transform.position.y < 8.08)
            {
                secondRowResult = 5;
            }
            else if (row2.transform.position.y < 10.5)
            {
                secondRowResult = 6;
            }
            else if (row2.transform.position.y < 12)
            {
                secondRowResult = 7;
            }
            else if (row2.transform.position.y < 14.13)
            {
                secondRowResult = 1;
            }

            //Third Row
            if (row3.transform.position.y < 0.91 && row3.transform.position.y > -0.81)
            {
                thirdRowResult = 1;
            }
            else if (row3.transform.position.y < 2.82)
            {
                thirdRowResult = 2;
            }
            else if (row3.transform.position.y < 4.49)
            {
                thirdRowResult = 3;
            }
            else if (row3.transform.position.y < 6.14)
            {
                thirdRowResult = 4;
            }
            else if (row3.transform.position.y < 8.08)
            {
                thirdRowResult = 5;
            }
            else if (row3.transform.position.y < 10.5)
            {
                thirdRowResult = 6;
            }
            else if (row3.transform.position.y < 12)
            {
                thirdRowResult = 7;
            }
            else if (row3.transform.position.y < 14.13)
            {
                thirdRowResult = 1;
            }

            //Forth Row
            if (row4.transform.position.y < 0.91 && row4.transform.position.y > -0.81)
            {
                forthRowResult = 1;
            }
            else if (row4.transform.position.y < 2.82)
            {
                forthRowResult = 2;
            }
            else if (row4.transform.position.y < 4.49)
            {
                forthRowResult = 3;
            }
            else if (row4.transform.position.y < 6.14)
            {
                forthRowResult = 4;
            }
            else if (row4.transform.position.y < 8.08)
            {
                forthRowResult = 5;
            }
            else if (row4.transform.position.y < 10.5)
            {
                forthRowResult = 6;
            }
            else if (row4.transform.position.y < 12)
            {
                forthRowResult = 7;
            }
            else if (row4.transform.position.y < 14.13)
            {
                forthRowResult = 1;
            }

            canTurnHandle = true;
            spinningHasStarted = false;
            resultsChecked = true;
            rowHasStoped = 0;
            inputField.SetActive(true);

            rowScript1.canRotate1 = true;
            rowScript2.canRotate2 = true;
            rowScript3.canRotate3 = true;
            rowScript4.canRotate4 = true;
        }

        /*//Decide winner
        if((firstRowResult == secondRowResult && secondRowResult == thirdRowResult) || (secondRowResult == thirdRowResult && thirdRowResult == forthRowResult))
        {
            //Loadboss Fight
            Debug.Log("dracusor");
            prizeText.text = "BOSS FIGHT";
            StartCoroutine(LoadFirstBossBattle());
        }*/

        //Decide winner
        if(firstRowResult == secondRowResult)
        {
            if(secondRowResult == thirdRowResult)
            {
                if(thirdRowResult == forthRowResult)
                {
                    switch (forthRowResult)
                    {
                        case 1:
                            //Loadboss Fight
                            Debug.Log("dracusor");
                            prizeText.text = "BOSS FIGHT";
                            if(Random.Range(0, 3) == 2)
                            {
                                StartCoroutine(LoadFirstBossBattle());
                            }
                            else
                            {
                                StartCoroutine(LoadSecondBossBattle());
                            }
                            break;
                        case 2:
                            PlayerPrefs.SetInt("Balance", PlayerPrefs.GetInt("Balance") + (betValue * 2));
                            Debug.Log("potcoava");
                            break;
                        case 3:
                            PlayerPrefs.SetInt("Balance", PlayerPrefs.GetInt("Balance") - (betValue * 2));
                            Debug.Log("trident");
                            break;
                        case 4:
                            PlayerPrefs.SetInt("Balance", PlayerPrefs.GetInt("Balance") + (betValue * 3));
                            Debug.Log("moneda");
                            break;
                        case 5:
                            PlayerPrefs.SetInt("Balance", PlayerPrefs.GetInt("Balance") - (betValue * 3));
                            Debug.Log("foc");
                            break;
                        case 6:
                            PlayerPrefs.SetInt("Balance", PlayerPrefs.GetInt("Balance") + (betValue * 3));
                            Debug.Log("sac");
                            break;
                        case 7:
                            PlayerPrefs.SetInt("Balance", PlayerPrefs.GetInt("Balance") + (betValue * 4));
                            Debug.Log("bancnote");
                            break;
                    }
                }
            }
        }
    }

    IEnumerator LoadSecondBossBattle()
    {
        yield return new WaitForSeconds(1f);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(2);
    }

    IEnumerator LoadFirstBossBattle()
    {
        yield return new WaitForSeconds(1f);
        transition.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(1);
    }

    public void StopButtonPressed()
    {
        StartCoroutine(StopButton());
    }

    IEnumerator StopButton()
    {
        stopButtonPressed.SetBool("Stop", true);
        yield return new WaitForSeconds(2f);
        stopButtonPressed.SetBool("Stop", false);
    }

    public void ExitGame()
    {
        Application.Quit();
    }

    public void SkipToBoss()
    {
        choice.SetActive(true);

        devilHeadButton.SetActive(true);
        nahButton.SetActive(true);

        balance.enabled = false;
        prizeText.enabled = false;
        inputField.SetActive(false);
    }

    public void GoldenAplleButton()
    {
        choice.SetActive(false);

        if (PlayerPrefs.GetInt("Balance") >= 5000)
        {
            PlayerPrefs.SetInt("Balance", PlayerPrefs.GetInt("Balance") - 5000);

            StartCoroutine(DevilButton());

            prizeText.text = "BOSS FIGHT";
            if (Random.Range(0, 3) == 2)
            {
                StartCoroutine(LoadFirstBossBattle());
            }
            else
            {
                StartCoroutine(LoadSecondBossBattle());
            }
        }
    }

    public void NoAppleButton()
    {
        devilHeadButton.SetActive(false);
        nahButton.SetActive(false);

        choice.SetActive(false);
        balance.enabled = true;
        prizeText.enabled = true;
        inputField.SetActive(true);
    }

    IEnumerator DevilButton()
    {
        devilButtonPressed.SetBool("Devil", true);
        yield return new WaitForSeconds(2f);
        devilButtonPressed.SetBool("Devil", false);
    }
}
