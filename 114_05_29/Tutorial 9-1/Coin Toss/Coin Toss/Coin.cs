using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Coin_Toss
{
    internal class Coin
    {
        private string sideUp;
        Random rand = new Random();

        public Coin()
        {
            sideUp = "正面";
        }
        public void Toss()
        {
            if (rand.Next(2) == 0) 

            {
                sideUp = "正面";
            }
            else
            {
                sideUp = "反面";
            }
        }
        public string GetSideUp()
        {

            return sideUp;
        }
    } 
}

