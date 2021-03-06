using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using MusicShop.Data;
using System;
using System.Linq;

namespace MusicShop.Models
{
    public static class DataImporter
    {
        public static void Initialize(IServiceProvider serviceProvider)
        {
            using (var context = new MusicShopContext(
                serviceProvider.GetRequiredService<DbContextOptions<MusicShopContext>>()))
            {
                if (context.Artist.Any())
                {
                    return;
                }

                context.Artist.AddRange(
                    new Artist
                    {
                        Name = "Barış Manço",
                        Biography = "Mehmet Barış Manço (born Tosun Yusuf Mehmet Barış Manço; 2 January 1943 – 1 February 1999), known by his stage name Barış Manço, was a Turkish rock musician, singer, songwriter, composer, actor, television producer and show host. Beginning his musical career while attending Galatasaray High School, he was a pioneer of rock music in Turkey and one of the founders of the Anatolian rock genre. Manço composed around 200 songs and is among the best-selling and most awarded Turkish artists to date."
                    },
                    new Artist
                    {
                        Name = "Scorpions",
                        Biography = "This German hard rock band was formed at school in 1965 by guitarist Rudolf Schenker (31 August 1948, Savstedt, Germany). 25 May 1948, Hannover, Germany; vocals), Lothar Heimberg (bass) and Wolfgang Dziony (drums), they exploded onto the international heavy rock scene with Lonesome Crow in 1972."
                    },
                    new Artist
                    {
                        Name = "Sezen Aksu",
                        Biography = "Sezen Aksu (born Fatma Sezen Yıldırım; 13 July 1954) is a Turkish pop music singer, songwriter and producer who has sold over 40 million albums worldwide. Her nicknames include the (Queen of Turkish Pop) and Minik Serçe (Little Sparrow)."
                    },
                    new Artist{
                        Name="Sertap Erener",
                        Biography="Sertab Erener (born 4 December 1964) is a Turkish singer, songwriter and composer. With her coloratura soprano voice, she started working as a backing vocalist for Sezen Aksu, and with Aksu's help she released her first studio album in the 1990s. Because of her education in classical music, she initially had difficulties in performing pop music. Although she did experimental works from time to time, she eventually preferred to focus on making pop music instead of making avant-garde works, in order to make her music heard by a larger audience. In some of her works, she combined Western music and Eastern music, and benefited from operas as well as classical Turkish music together with ethnic elements. With her entrance to Europe's market in the early 2000s, many of her works were also sold in Turkey as well as European countries."
                    }
                );
                context.SaveChanges();
            }
        }
    }
}