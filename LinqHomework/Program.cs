using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LinqHomework
{
    class Program
    {
        static void Main(string[] args)
        {
            //影片資料集合
            List<Video> videoList = new List<Video>() {
                new Video() { Name = "天竺鼠車車", Country = "日本", Duration = 2.6, Type = "動漫" },
                new Video() { Name = "鬼滅之刃", Country = "日本", Duration = 25, Type = "動漫" },
                new Video() { Name = "鬼滅之刃-無限列車", Country = "日本", Duration = 100, Type = "電影" },
                new Video() { Name = "甜蜜家園SweetHome", Country = "韓國", Duration = 50, Type = "影集" },
                new Video() { Name = "The 100 地球百子", Country = "歐美", Duration = 48, Type = "影集" },
                new Video() { Name = "冰與火之歌Game of thrones", Country = "歐美", Duration = 60, Type = "影集" },
                new Video() { Name = "半澤直樹", Country = "日本", Duration = 40, Type = "影集" },
                new Video() { Name = "古魯家族：新石代", Country = "歐美", Duration = 90, Type = "電影" },
                new Video() { Name = "角落小夥伴電影版：魔法繪本裡的新朋友", Country = "日本", Duration = 77, Type = "電影" },
                new Video() { Name = "TENET天能", Country = "歐美", Duration = 80, Type = "電影" },
                new Video() { Name = "倚天屠龍記2019", Country = "中國", Duration = 58, Type = "影集" },
                new Video() { Name = "下一站是幸福", Country = "中國", Duration = 45, Type = "影集" },
            };

            //人物資料集合
            List<Person> personList = new List<Person>()
            {
                new Person() { Name = "Bill", CountryPrefer = new List<string>() { "中國", "日本" }, TypePrefer = new List<string>() { "影集" } },
                new Person() { Name = "Jimmy", CountryPrefer = new List<string>() { "日本" }, TypePrefer = new List<string>() { "動漫", "電影" } },
                new Person() { Name = "Andy", CountryPrefer = new List<string>() { "歐美", "日本" }, TypePrefer = new List<string>() { "影集", "電影" } },
            };

            // 1. 找出所有日本的影片名稱
            Console.WriteLine($"{Environment.NewLine}Q: 找出所有日本的影片名稱");
            // ===================<Q1作答區>===================

            videoList.Where(x => x.Country == "日本").ToList().ForEach(x => Console.WriteLine(x.Name));

            // ===================</Q1作答區>===================
            // 2. 找出所有歐美的影片且類型為"影集"的影片名稱
            Console.WriteLine($"{Environment.NewLine}Q: 找出所有歐美的影片且類型為'影集'的影片名稱");
            // ===================<Q2作答區>===================

            videoList.Where(x => x.Country == "歐美").Where(x => x.Type == "影集").ToList().ForEach(x => Console.WriteLine(x.Name));

            // ===================</Q2作答區>===================
            // 3. 是否有影片片長超過120分鐘的影片
            Console.WriteLine($"{Environment.NewLine}Q: 是否有影片片長超過120分鐘的影片");
            // ===================<Q3作答區>===================

            int target3 = 120;
            var a3 = videoList.Any(x => x.Duration > target3);
            if (a3)
                Console.WriteLine($"存在片長超過 {target3} 分鐘的影片。");
            else
                Console.WriteLine($"找不到片長超過 {target3} 分鐘的影片。");

            // ===================</Q3作答區>===================
            // 4. 請列出所有人的名稱，並且用大寫英文表示，ex: Bill -> BILL
            Console.WriteLine($"{Environment.NewLine}Q: 請列出所有人的名稱，並且用大寫英文表示");
            // ===================<Q4作答區>===================

            personList.ForEach(x => Console.WriteLine(x.Name.ToUpper()));

            // ===================</Q4作答區>===================
            // 5. 將所有影片用片長排序(最長的在前)，並顯示排序過的排名以及片名，ex: No1: 天竺鼠車車
            Console.WriteLine($"{Environment.NewLine}Q: 將所有影片用片長排序(最長的在前)，並顯示排序過的排名以及片名");
            // ===================<Q5作答區>===================

            var a5 = videoList.OrderByDescending(x => x.Duration).ToList();
            a5.ForEach(x => Console.WriteLine($"No. {a5.FindIndex(y => y == x) + 1:D2}： {x.Name}"));

            // ===================</Q5作答區>===================
            // 6. 將所有影片進行以"類型"分類，並顯示以下樣式(注意縮排)
            /* 
            動漫:
                天竺鼠車車
                鬼滅之刃
            */
            Console.WriteLine($"{Environment.NewLine}Q: 將所有影片進行以'類型'分類");
            // ===================<Q6作答區>===================

            var a6 = videoList.GroupBy(x => x.Type);
            foreach (var items in a6)
            {
                Console.WriteLine($"{items.Key}：");
                items.ToList().ForEach(y => Console.WriteLine($"\t{y.Name}"));
            }

            // ===================</Q6作答區>===================
            // 7. 找到第一個喜歡歐美影片的人
            Console.WriteLine($"{Environment.NewLine}Q: 找到第一個喜歡歐美影片的人");
            // ===================<Q7作答區>===================

            string target7 = "歐美";
            var a7 = personList.FirstOrDefault(x => x.CountryPrefer.Contains(target7));
            if (a7 != null)
                Console.WriteLine($"第一個喜歡 {target7} 影片的人是 {a7.Name}。");
            else
                Console.WriteLine($"找不到喜歡 {target7} 影片的人。");

            // ===================</Q7作答區>===================
            // 8. 找到每個人喜歡的影片(根據國家以及類型)，ex: Bill: 天竺鼠車車, 倚天屠龍記2019
            Console.WriteLine($"{Environment.NewLine}Q: 找到每個人喜歡的影片");
            // ===================<Q8作答區>===================

            Console.WriteLine("\t***** 如果題目指的喜歡是指國家 && 類型 *****");
            foreach (var person in personList)
            {
                // 國家 && 類型
                IEnumerable<Video> favos8 = new List<Video>();
                IEnumerable<string> personalFavos = new List<string>();
                //person.CountryPrefer.ForEach(x => videoList.ForEach(y => Console.WriteLine(string.Join("、", x.Intersect(y.Country).Select(z => y.Name).Distinct()))));

                foreach (var country in person.CountryPrefer)
                {
                    foreach (var type in person.TypePrefer)
                    {
                        favos8 = favos8.Union(videoList.Where(x => x.Country == country && x.Type == type));
                        personalFavos = favos8.Select(x => x.Name);
                    }
                }

                var ans8 = string.Join("、", personalFavos.Distinct());

                Console.WriteLine($"{person.Name} 喜歡的影片有：{ans8}。");
            }

            Console.WriteLine("\t***** 如果題目指的喜歡是指國家 || 類型 *****");
            foreach (var person in personList)
            { 
                // 國家 || 類型
                var favo8 = person.CountryPrefer.Union(person.TypePrefer);
                IEnumerable<Video> personalFavo = new List<Video>();
                foreach (var item in favo8)
                    personalFavo = personalFavo.Union(videoList.Where(x => x.Country.Contains(item)).Union(videoList.Where(x => x.Type.Contains(item))));
                
                var a8 = string.Join("、", personalFavo.Select(x => x.Name));

                Console.WriteLine($"{person.Name} 喜歡的影片有：{a8}。");
            }

            // ===================</Q8作答區>===================
            // 9. 列出所有類型的影片總時長，ex: 動漫: 100min
            Console.WriteLine($"{Environment.NewLine}Q: 列出所有類型的影片總時長");
            // ===================<Q9作答區>===================

            videoList.GroupBy(x => x.Type).ToList().ForEach(x => Console.WriteLine($"{x.Key}：總時長 {x.Sum(y => y.Duration):N1} 分鐘"));

            // ===================</Q9作答區>===================
            // 10. 列出所有國家出產的影片數量，ex: 日本: 3部
            Console.WriteLine($"{Environment.NewLine}Q: 列出所有國家出產的影片數量");
            // ===================<Q10作答區>===================

            videoList.GroupBy(x => x.Country).ToList().ForEach(x => Console.WriteLine($"{x.Key}：總共有 {x.Count()} 部影片"));

            // ===================</Q10作答區>===================
            Console.ReadLine();
        }
    }
}
