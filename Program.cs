using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using static System.Net.WebRequestMethods;

namespace Club_tagsag_nyilvantartas
{
    internal class Program
    {

        static async Task Main(string[] args)
        {
            try
            {
                HttpClient client = new HttpClient();
                string apiUrl = "https://retoolapi.dev/OEDUXm/member";

                HttpResponseMessage response = await client.GetAsync(apiUrl);
                response.EnsureSuccessStatusCode();

                string responseBody = await response.Content.ReadAsStringAsync();

                List<Tagok> tagokLista = JsonConvert.DeserializeObject<List<Tagok>>(responseBody);

                //kiíratás
                Console.WriteLine("Tagok listája: ");
                foreach (var tagok in tagokLista)
                {
                    Console.WriteLine($" Id:{tagok.Id}\n Entry: {tagok.Entry}\n Rating: {tagok.Rating}\n Fullname: {tagok.Fullname}\n Interest: {tagok.Interest}\n");
                    Console.WriteLine();
                }
                UtolsoBelepo(tagokLista);
                TagokSzamaÖsszesen(tagokLista);

            }
            catch (Exception ex)
            {

                Console.WriteLine($"Hiba történt: {ex.Message}");
            }
        }

        private static void UtolsoBelepo(List<Tagok> tagokLista)
        {
            var utolsobelepo = tagokLista.OrderByDescending(tagok => tagok.Entry).FirstOrDefault();
            if (utolsobelepo != null)
            {
                Console.WriteLine($"Az utolsó belépő: a{utolsobelepo.Fullname}");
            }
            else
            {
                Console.WriteLine("Nincs adat a listában");
            }
        }

        static void TagokSzamaÖsszesen(List<Tagok> tagokLista)
        {
            int osszeg = tagokLista.GroupBy(tagok => tagok.Id).Count();
            Console.WriteLine($"Összesen: {osszeg} tag van a listában");
            Console.WriteLine("Nyomj Entert a kilépéshez");
            Console.ReadLine();
        }


    }
}
