using System.Collections;
using System.Collections.Generic;
using SP;
using UnityEngine;

public class MoneyObject : MonoBehaviour, IInteractable
{
    public int moneyPerCall = 1;
    public int maxMoney = 10;

    public int currentMoneyAmount = 0;

    void Start()
    {
        currentMoneyAmount = maxMoney;
    }

    public void Interact(StateManager state)
    {
        if(currentMoneyAmount - moneyPerCall < 0)
        {
            int amountToAdd = currentMoneyAmount;
            GameManager.GetMoneyManager().AddMoney(amountToAdd);
            currentMoneyAmount = 0;
        }
        else
        {
            GameManager.GetMoneyManager().AddMoney(moneyPerCall);
            currentMoneyAmount -= moneyPerCall;
        }

        if (currentMoneyAmount <= 0)
            Destroy(gameObject);
    }
}
