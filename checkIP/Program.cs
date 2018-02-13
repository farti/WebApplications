using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;

namespace checkIP
{
    class Program
    {
        static void Main(string[] args)
        {
            string NazwaHosta = Dns.GetHostName();
            IPHostEntry AdresyIP = Dns.GetHostEntry(NazwaHosta);
            Console.WriteLine("nazwa komputera: "+ NazwaHosta);
            int licznik = 0;
            foreach (IPAddress AdresIP in AdresyIP.AddressList)
            {
                if (AdresIP.ToString()== "127.0.0.1")
                {
                    Console.WriteLine("Komputer nie jest podłączony do sieci. Adres IP: "+AdresIP.ToString());
                }
                else
                {
                    Console.WriteLine(" adres IP#"+ ++licznik+": "+AdresIP.ToString());
                }
                Console.ReadLine();
            }
        }
    }
}
