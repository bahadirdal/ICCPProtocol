using System;
using IEC60870;
using IEC60870.IE.CS101;
using IEC60870.IE.CS104;
using IEC60870.Client;
using IEC60870.Common;

namespace ICCPConnectionExample
{
    class Program
    {
         
        static void Main(string[] args)
        {
                  
            while (true)
            {
                Console.WriteLine("Sisteme hoşgeldiniz. \n \n");
                Console.WriteLine("IP ve Port girip bağlanmak için 1'e basınız. \n \n");
                Console.WriteLine("Bağlantıyı kapatmak için 2'ye basınız. \n \n");
                Console.WriteLine("Veri okumak için 3'e basınız.");

                char secim = Console.ReadKey().KeyChar;
                Console.WriteLine();

                string ipAddress;
                int port;

                ClientConnectionParameters parameters = new ClientConnectionParameters();
                parameters.Address = new ASDUAddress(1); // ASDU (Application Service Data Unit) Adresi
                parameters.LinkParameters = new LinkParameters("168.754.521.1", 2514); // Bağlantı adresi ve portu

                Client client = new Client(parameters);

                switch (secim)
                {
                    case '1':
                        Console.Write("IP Adresini Giriniz: ");
                        ipAddress = Console.ReadLine();
                        Console.Write("Port Numarasını Giriniz: ");
                        port = Convert.ToInt32(Console.ReadLine());
                        Console.WriteLine("Girdiğiniz IP Adresi: " + ipAddress);
                        Console.WriteLine("Girdiğiniz Port Numarası: " + port);         
                        
                        break;

                    case '2':
                        Console.WriteLine("Bağlantı kesildi.");
                        break;

                    case '3':
                        Console.WriteLine("Veriler okundu.");
                        break;

                    default: 
                        Console.WriteLine("Geçersiz Seçim!");
                        break;
                }

                try
                {
                    // Cihaza bağlan
                    client.Connect();

                    // Bağlantı başarılıysa buraya gelir
                    Console.WriteLine("Bağlantı başarılı! Cihaza bağlandınız.");

                    // Veri alışverişi yapmak, komut göndermek vb. işlemleri burada gerçekleştirebilirsiniz.

                    // Bağlantıyı kapat
                    client.Disconnect();
                    Console.WriteLine("Bağlantı kesildi.");
                }
                catch (Exception ex)
                {
                    // Bağlantı sırasında veya işlem yaparken hata oluştuğunda buraya gelir
                    Console.WriteLine("Hata oluştu: " + ex.Message);
                }
            }

           
        }
    }
}

