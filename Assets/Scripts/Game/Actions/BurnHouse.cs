using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BurnHouse : MonoBehaviour
{
    [SerializeField] private Sprite _houseBurnted;
    [SerializeField] private Sprite _houseNormal;

    public static event Action HouseAfterFireEvent;

    private void Start()
    {
        HouseAfterFireEvent += HouseAfterFire;
    }
    public void HouseAfterFire()
    {
        ChangeSpriteHouse(_houseBurnted);
        StartCoroutine(HouseRepaired());
    }

    public IEnumerator HouseRepaired()
    {
        yield return new WaitForSeconds(UnityEngine.Random.Range(4.5f, 6.5f));
        ChangeSpriteHouse(_houseNormal);
    }
    public void ChangeSpriteHouse(Sprite _currentSprite)
    {
        gameObject.GetComponent<SpriteRenderer>().sprite =_currentSprite;
    }
}
