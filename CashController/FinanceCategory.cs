using System;
using Newtonsoft.Json;

namespace CashController
{
    public class FinanceCategory
    {
        public FinanceCategory()
        {
            //this.realAmount = 50;
        }

        [JsonProperty] private string categoryName;
        [JsonProperty] private double realAmount;
        [JsonProperty] private double foressenAmount;
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

        public bool ExpenseInput(double amount)
        {
            if (amount > 0)
            {
                realAmount += amount;
                if(realAmount > foressenAmount)
                {
                    overloadStatus = true;
                }
                return true;
            }
            else
            {
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