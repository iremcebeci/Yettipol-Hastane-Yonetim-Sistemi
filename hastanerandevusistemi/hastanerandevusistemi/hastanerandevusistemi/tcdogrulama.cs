using System;
using System.Windows.Forms;

namespace hastaneRandevuSistemi
{
    public class tcdogrulama
    {
        public static bool Dogrula(string girilen)
        {
            bool donustu_mu = long.TryParse(girilen, out long tckn);

            if (!donustu_mu || tckn.ToString().Length != 11)
            {
                MessageBox.Show("Girilen değer 11 basamaklı sayısal ifade olmalıdır.", "Hatalı TC", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return false;
            }

            long ilk9 = tckn / 100;
            long son2 = tckn % 100;
            long tekler = 0, ciftler = 0;
            int i = 1;

            while (ilk9 > 0)
            {
                long basamak = ilk9 % 10;
                if (i % 2 == 0)
                    ciftler += basamak;
                else
                    tekler += basamak;

                ilk9 /= 10;
                i++;
            }

            long b10 = (tekler * 7 - ciftler) % 10;
            long b11 = (tekler + ciftler + b10) % 10;

            bool dogruMu = son2 == (b10 * 10 + b11);

            if (!dogruMu)
                MessageBox.Show("TC Kimlik numarası geçersizdir.", "Hatalı TC", MessageBoxButtons.OK, MessageBoxIcon.Warning);

            return dogruMu;
        }
    }
}

