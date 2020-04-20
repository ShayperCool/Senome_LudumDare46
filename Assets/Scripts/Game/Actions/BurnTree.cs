using System;
using System.Collections;
using Game.Models;
using UnityEngine;
using Game;
using Game.ActonsOnEvents;

public class BurnTree : MonoBehaviour
{
    [SerializeField] private Sprite _treeBurnted;
    [SerializeField] private Sprite _treeNormal;

    private void Start()
    {
        FireEventController.Singleton.OnEndFire += TreeAfterFire;
    }
    public void TreeAfterFire()
    {
        ChangeSpriteHouse(_treeBurnted);
        StartCoroutine(TreeRepaired());
    }

    public IEnumerator TreeRepaired()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(4.5f, 6.5f));
        ChangeSpriteHouse(_treeNormal);
    }
    public void ChangeSpriteHouse(Sprite _currentSprite)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite = _currentSprite;
    }
}
