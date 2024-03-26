using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace pract19
{
    internal class Cezar
    {
        
        public string Shifr(string str) 
        {
            int numb = 0, k = 0, j = 0;
            char[] stroka = str.ToCharArray();
            char[] al = {' ','а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
            for(int i = 0; i < stroka.Length; i++) 
            {
                for(j=0; j < al.Length; j++) 
                {
                   if(stroka[i] == al[j]) {break;}
                }
                if (j != 34) 
                {
                    numb = j;
                    k = numb + 3; 
                    if (k > 33) { k -= 34;}
                    stroka[i] = al[k];
                }
            }
            return str = new string(stroka);
        }
        public string Deshifr(string str)
        {
            int numb = 0, k = 3, j = 0;
            char[] stroka = str.ToCharArray();
            char[] al = {' ','а', 'б', 'в', 'г', 'д', 'е', 'ё', 'ж', 'з', 'и', 'й', 'к', 'л', 'м', 'н', 'о', 'п', 'р', 'с', 'т', 'у', 'ф', 'х', 'ц', 'ч', 'ш', 'щ', 'ъ', 'ы', 'ь', 'э', 'ю', 'я' };
            for (int i = 0; i < stroka.Length; i++)
            {
                for (j = 0; j < al.Length; j++)
                {
                    if (stroka[i] == al[j]) { break; }
                }
                if (j != 34) 
                {
                    numb = j;
                    k = numb - 3;
                    if (k < 0) k += 34;
                    stroka[i] = al[k];
                }
            }
            return str = new string(stroka);
        }
    }
}
