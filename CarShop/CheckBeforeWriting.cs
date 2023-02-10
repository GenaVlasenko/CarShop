using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Threading.Tasks;

namespace CarShop
{
    public class CheckBeforeWriting
    {
        
        
        public bool Special_Characters(dynamic word)
        {
            string special_characters = @"~`!@#$%^&*/()_+Ё!\,<.>/?';][}{|=-";
            foreach (var item in word)
            {
                foreach (var chars in special_characters)
                {
                    if (item == chars)
                    {
                        return false;
                    }
                }

            }
            return true;

        }

       
    }
}
