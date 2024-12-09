using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AsyncProgramming
{
    public class Async
    {

        public void Plus(int numb, int numb2)
        {
            Console.WriteLine("Rakam Toplama işlemi başladı");
            for (int i = 0; i < 1000; i++)
            {
                numb++;
            }
            for (int i = 0; i < 600; i++)
            {
                numb2++;
            }
            var total = numb + numb2;
            Console.WriteLine($"Total: {total} ");


        }

        public async Task PlusAsync(int numb, int numb2)
        {
            Console.WriteLine("Async Rakam Toplama işlemi başladı");

            var task1 = Task.Run(() => {
                for (int i = 0; i < 1000; i++)
                {
                    numb++;
                }
                return numb;

            });
            var task2 = Task.Run(() => {

                for (int i = 0; i < 600; i++)
                {
                    numb2++;
                }
                return numb2;
            });

            await Task.WhenAll(task1, task2);
            var asynctotal = task1.Result + task2.Result;
            Console.WriteLine($"numb: {asynctotal}, ");


        }

        // Async Await ile hata yönetimi bölüm 2 2.soru =>

        public void Discount(string message)
        {
            HttpClient client = new HttpClient();

            var tasks = new[]
            {
            client.GetAsync("https://www.google.com"),
        client.GetAsync("https://www.google.com"),
        client.GetAsync("https://www.google.com")
    };

            Task.WhenAll(tasks).ContinueWith(allTasks =>
            {
               if (allTasks.IsFaulted)
               {
                 Console.WriteLine("Hata.");
                }
                else
                {
                    Console.WriteLine("Başarılı Post işlemine geçiliyor.");

                    client.PostAsync("https://www.gleasdasd.com", new StringContent(message)).ContinueWith(
                        responseMessage =>
                    {
                        if (responseMessage.IsFaulted)
                        {
                            Console.WriteLine("PostAsync  hata.");
                        }
                        else
                        {
                            var result = responseMessage.Result;
                            if (!result.IsSuccessStatusCode)
                            {
                                Console.WriteLine("PostAsync  başarısız.");
                            }
                            else
                            {
                                Console.WriteLine("PostAsync  başarılı.");
                            }
                        }
                    });
                }
            });
        }


    }
}