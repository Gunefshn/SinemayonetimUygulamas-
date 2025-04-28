namespace SinemaUygulaması
{
    internal class Program
    {

        static Sinema snm;

        static void Main(string[] args)
        {
            Uygulama();

            //Test();
        }

        static void Test()
        {
            while (true)
            {
                Console.Write("Sayı girin: ");
                string giris = Console.ReadLine();

                int sayi;

                bool sonuc = int.TryParse(giris, out sayi);

                if (sonuc == true)
                {

                    Console.WriteLine("Girilenen sayının 2 katı : " + (sayi * 2));

                }
                else
                {
                    Console.WriteLine("Hatalı giriş yapıldı.");
                }
            }
        }

        static int SayiAl(string mesaj)
        {
            int sayi;
            while (true)
            {
                Console.Write(mesaj);
                string giris = Console.ReadLine();

                if (int.TryParse(giris, out sayi))
                {
                    return sayi;
                }
                Console.WriteLine("Hatalı giriş yapıldı.");
            }

        }

        static void Uygulama()
        {
            Kurulum();
            Menu();

            while (true)
            {
                string secim = SecimAl();
                switch (secim)
                {
                    case "S":
                    case "1":
                        BiletSat();
                        break;
                    case "R":
                    case "2":
                        Biletİade();
                        break;
                    case "D":
                    case "3":
                        DurumBilgisi();
                        break;
                    case "X":
                    case "4":
                        Environment.Exit(0);
                        break;
                }
                Console.WriteLine();
            }
        }
        static void BiletSat()
        {
            Console.WriteLine("Bilet Sat:");

            //Console.Write("Tam Bilet Adedi: ");
            //int tam = int.Parse(Console.ReadLine());
            int tam = SayiAl("Tam Bilet Adedi: ");

            //Console.Write("Yarım Bilet Adedi: ");
            //int yarim = int.Parse(Console.ReadLine());
            int yarim = SayiAl("Yarım Bilet Adedi: ");

            snm.BiletSatisi(tam, yarim);
        }

        static void Biletİade()
        {
            Console.WriteLine("Bilet İade:");

            //Console.Write("Tam Bilet Adedi: ");
            //int tam = int.Parse(Console.ReadLine());
            int tam = SayiAl("Tam Bilet Adedi: ");

            //Console.Write("Yarım Bilet Adedi: ");
            //int yarim = int.Parse(Console.ReadLine());
            int yarim = SayiAl("Yarım Bilet Adedi: ");

            snm.BiletIade(tam, yarim);
        }

        static void DurumBilgisi()
        {
            Console.WriteLine("Durum Bilgisi");
            Console.WriteLine("Film: " + snm.FilmAdi);
            Console.WriteLine("Kapasite : " + snm.Kapasite);
            Console.WriteLine("Tam Bilet Fiyatı : " + snm.TamBiletFiyati);
            Console.WriteLine("Yarım Bilet Fiyatı : " + snm.YarimBiletFiyati);
            Console.WriteLine("Toplam Tam Bilet Adedi: " + snm.ToplamTamBiletAdeti);
            Console.WriteLine("Toplam Yarım Bilet Adedi: " + snm.ToplamYarimBiletAdeti);
            Console.WriteLine("Ciro: " + snm.Ciro);
            Console.WriteLine("Boş Koltuk Adedi: " + snm.BosKoltukAdetiGetir());
        }


        static string SecimAl()
        {
            string karakterler = "1234SRDX";
            int sayac = 0;

            while (true)
            {
                sayac++;
                Console.Write("Seçiminiz: ");
                string giris = Console.ReadLine().ToUpper();
                int index = karakterler.IndexOf(giris);

                Console.WriteLine();

                if (giris.Length == 1 && index >= 0)
                {
                    return giris;
                }
                else
                {
                    if (sayac == 10)
                    {
                        Console.WriteLine("Üzgünüm sizi anlayamıyorum. Program sonlandırılıyor.");
                        Environment.Exit(0);
                    }
                    Console.WriteLine("Hatalı giriş yapıldı.");
                }
                Console.WriteLine();
            }


        }



        static void Kurulum()
        {
            Console.WriteLine("-------Butik Sinema Salonu-------");
            Console.Write("Film adı: ");
            string film = Console.ReadLine();

            //Console.Write("Kapasite: ");
            //int kapasite = int.Parse(Console.ReadLine());
            int kapasite = SayiAl("Kapasite: ");

            //Console.Write("Tam Bilet Fiyatı: ");
            //int tam = int.Parse(Console.ReadLine());
            int tam = SayiAl("Tam Bilet Fiyatı: ");

            //Console.Write("Yarım Bilet Fiyatı: ");
            //int yarim = int.Parse(Console.ReadLine());
            int yarim = SayiAl("Yarım Bilet Fiyatı: ");

            snm = new Sinema(film, kapasite, tam, yarim);

            Console.WriteLine();
        }


        static void Menu()
        {
            Console.WriteLine("1 - Bilet Sat(S)     ");
            Console.WriteLine("2 - Bilet İade(R)    ");
            Console.WriteLine("3 - Durum Bilgisi(D) ");
            Console.WriteLine("4 - Çıkış(X)         ");

        }
    }
}
