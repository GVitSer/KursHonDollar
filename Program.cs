using System;
using System.IO;
using System.Net;
using System.Text;

class Program
{
    static void Main(string[] args)
    {       
        string line;
        WebClient client = new WebClient();
        client.Encoding = Encoding.GetEncoding("windows-1251");
        client.Headers.Add("user-agent", "Mozilla/85.0.2");
        line = client.DownloadString("http://www.cbr.ru/scripts/XML_daily.asp");
        string[] words = line.Split('<', '>');
        for (int i=0; i<words.Length; i++)
        {
            if (words[i]=="Гонконгских долларов")
            {
                double hongkongDollar = Convert.ToDouble(words[i - 4]);
                double rubl = Convert.ToDouble(words[i + 4]);
                double n = rubl / hongkongDollar;
                Console.WriteLine("1 гонконгский доллар = {0} российских рублей", n);
                break;
            }
        }
        Console.ReadKey();
    }
}