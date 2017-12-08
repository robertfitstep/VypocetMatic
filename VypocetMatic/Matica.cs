using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VypocetMatic
{
    class Matica
    {
        int n; //počet riadkov
        int m; //počet stĺpcov
        public int[,] hodnotyMatice;
        static string msg_ine_strany = "Matica nemá rovnaký počet sĺpcov a riakov";
        static string msg_riadky_a_stlpce = "Počet stĺpcov prvej matice se musí rovnat počtu riadkov druhej.";

        public Matica(int n, int m)
        {
            this.n = n;
            this.m = m;
            hodnotyMatice = new int[n, m];
        }

        public Matica(int n, int m, bool vygenerujHodnoty):this(n,m)
        {
            Random NahodneCislo = new Random();
            for (int i1 = 0; i1 < n; i1++)
            {
                for (int i2 = 0; i2 < m; i2++)
                {
                    hodnotyMatice[i1, i2] = NahodneCislo.Next(0, 9);
                }
            }
        }

        public Matica(int n, int m, int[,] hodnotyMatice):this(n,m)
        {
            this.hodnotyMatice = hodnotyMatice;   
        }

        public static Matica operator +(Matica m1, Matica m2)
        {
            if (OverRovnostStran(m1, m2))
            {
                Matica m3 = new Matica(m1.n, m1.m, true);

                for (int i1 = 0; i1 < m1.n; i1++)
                {
                    for (int i2 = 0; i2 < m1.m; i2++)
                    {
                        m3.hodnotyMatice[i1, i2] = m1.hodnotyMatice[i1, i2] + m2.hodnotyMatice[i1, i2];
                    }
                }
                return m3;
            }
            else
            {
                Console.WriteLine(msg_ine_strany);
                return new Matica(0, 0, true);

            }
        }

        public static Matica operator ++(Matica m)
        {
            Matica m3 = new Matica(m.n, m.m, true);
            
            for (int i1 = 0; i1 < m.n; i1++)
            {
                for (int i2 = 0; i2 < m.m; i2++)
                {
                    m3.hodnotyMatice[i1, i2] = m.hodnotyMatice[i1, i2] + 1;
                }
            }
            return m3;
        }

        public static Matica operator -(Matica m1, Matica m2)
        {
            if (OverRovnostStran(m1, m2))
            {
                Matica m3 = new Matica(m1.n, m1.m, true);

                for (int i1 = 0; i1 < m1.n; i1++)
                {
                    for (int i2 = 0; i2 < m1.m; i2++)
                    {
                        m3.hodnotyMatice[i1, i2] = m1.hodnotyMatice[i1, i2] - m2.hodnotyMatice[i1, i2];
                    }
                }
                return m3;
            }
            else
            {
                Console.WriteLine(msg_ine_strany);
                return new Matica(0, 0, true);
            }
        }

        public static Matica operator *(Matica m1, Matica m2) 
        {
            if (OverRovnostStlpcovARiadkov(m1, m2))
            {
                Matica m3 = new Matica(m1.n, m2.m, true);

                for (int i1 = 0; i1 < m3.n; i1++) //počet riadkov
                {
                    for (int i2 = 0; i2 < m3.m; i2++) //počet stĺpcov
                    {
                        
                        for (int i3 = 0; i3 < m3.m; i3++)
                        {
                            if (i3 == 0)
                            {
                                m3.hodnotyMatice[i1, i2] = m1.hodnotyMatice[i1,i3] * m2.hodnotyMatice[i3,i2];
        
                            }
                            else
                            {
                                m3.hodnotyMatice[i1, i2] = m3.hodnotyMatice[i1, i2] + (m1.hodnotyMatice[i1, i3] * m2.hodnotyMatice[i3, i2]);
                            }
                        }
                    }
                }
                return m3;
            }
            else
            {
                Console.WriteLine(msg_riadky_a_stlpce);
                return new Matica(0, 0, true);
            }
        }

        public void VypisHodnoty()
            //Vypíše akutálne uložené hodnoty v matici
        {
            for (int i1 = 0; i1 < n; i1++)
            {
                string riadok = "";

                for (int i2 = 0; i2 < m; i2++)
                {
                    riadok = riadok + hodnotyMatice[i1, i2] + "[" + i1 + "," + i2 + "] ";
                    if (i2 == m - 1)
                    {
                        Console.WriteLine(riadok);
                    }
                }
            }
        }

        public static bool OverRovnostStran(Matica m1, Matica m2)
        {
            //overí rovnosť strán (potrebné pri sčítaní a odčítaní)
            if(m1.n == m2.n && m1.m == m2.m)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static bool OverRovnostStlpcovARiadkov(Matica m1, Matica m2)
        {
            //potrebné pri násobení (počet stĺpcov m1 sa musí rovnať počtu riadkov m2)
         if (m1.m == m2.n)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public static Matica VratKopiuMatice(Matica m)
        {
            return m;
        }

        public int this[int x, int y]
        {
            get
            {
                return hodnotyMatice[x, y];
            }

            set
            {
                hodnotyMatice[x, y] = value;
            }
        }
    }
}
