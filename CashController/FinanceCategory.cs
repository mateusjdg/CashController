﻿using System;

namespace CashController
{
    public class FinanceCategory
    {
        public FinanceCategory()
        {
        }

        public string categoryName;
        public double realAmount;
        public double foressenAmount;
        public bool overloadStatus;

        public void SetCategoryName(string name)
        {
            categoryName = name;
        }

        public string GetCategoryName()
        {
            if ( String.IsNullOrEmpty(categoryName) )
                return "\'categoria sem identificacao\'";
            else
                return categoryName;
        }

        public bool Deposit(double amount)
        {
            if (amount > 0)
            {
                realAmount += amount;
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Withdraw(double amount)
        {
            if( (realAmount-amount) >= 0)
            {
                realAmount -= amount;
                overloadStatus = false;
                return true;
            }
            else
            {
                overloadStatus = true;
                return false;
            }
        }

        public double GetRealAmount()
        {
            return realAmount;
        }

        public double GetForeseenAmount()
        {
            return foressenAmount;
        }

        public void SetForeseenAmount(double amount)
        {
            foressenAmount = amount;
        }
    }
}