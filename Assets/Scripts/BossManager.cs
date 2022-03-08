using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class BossManager : MonoBehaviour
{
    public GameObject bloodEffect;

    [SerializeField] GameObject bossSmiling;
    [SerializeField] GameObject bossCrying;
    [SerializeField] AudioSource bossHurt;

    public Animator transitionEffect;
    public Animator cameraAnimator;

    public Slider playerHealthBar;
    public Slider bossHealthBar;

    private float playerHealth = 100f;
    private float bossHealth = 100f;

    private void Start()
    {
        playerHealthBar.value = playerHealth;
    }

    private void Update()
    {
        if(playerHealth <= 0)
        {
            StartCoroutine(LoadGameLose());
        }
        
        if(bossHealth <= 0)
        {
            StartCoroutine(LoadGameWin());
        }
    }

    public void FindTarget()
    {
        float damage = Random.Range(10, 20);

        if(Random.Range(0, 2) == 0)
        {
            //Hurt Player
            playerHealth -= damage;

            playerHealthBar.value = playerHealth;

            StartCoroutine(CameraShake());
        }
        else
        {
            //Hurt Devil
            bossHealth -= damage;

            bossHurt.Play();

            bossHealthBar.value = bossHealth;

            StartCoroutine(CameraShake());

            Instantiate(bloodEffect, transform.position, Quaternion.identity);
        }
    }

    IEnumerator CameraShake()
    {
        cameraAnimator.SetBool("Shake", true);
        yield return new WaitForSeconds(.5f);
        cameraAnimator.SetBool("Shake", false);
    }

    IEnumerator LoadGameWin()
    {
        PlayerPrefs.SetInt("Balance", PlayerPrefs.GetInt("Balance") - (PlayerPrefs.GetInt("Betvalue") * 3));
        transitionEffect.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }

    IEnumerator LoadGameLose()
    {
        PlayerPrefs.SetInt("Balance", PlayerPrefs.GetInt("Balance") - (PlayerPrefs.GetInt("Betvalue") * 3));
        transitionEffect.SetTrigger("Start");
        yield return new WaitForSeconds(1f);
        SceneManager.LoadScene(0);
    }
}
