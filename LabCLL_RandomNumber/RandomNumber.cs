using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LabCLL_RandomNumber
{
    public class RandomNumber
    {
        public string Random() { 
        
            Random random = new Random();
            string result = "";

            for (int i = 0; i < 13; i++) { 
                result += random.Next(0, 10);  // สุ่ม 0 ถึง 9 
            }

            return result;
            
        }
    }
}
