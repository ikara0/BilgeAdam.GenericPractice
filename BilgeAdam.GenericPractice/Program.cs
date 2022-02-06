using System.Text;
using System.Text.Json;

namespace BilgeAdam.GenericPractice
{
    internal class Program
    {
        public static void Main(string[] arg)
        {
            #region swap

            //int a = 5;
            //int b = 10;

            //Console.WriteLine($"a-->{a}, b-->{b}");
            //Swap(ref a,ref b);
            //Console.WriteLine($"a-->{a}, b-->{b}");

            //char char1 = 'k';
            //char char2 = 'l';

            //Console.WriteLine($"char1-->{char1}, char2-->{char2}");
            //Swap(ref char1, ref char2);
            //Console.WriteLine($"char1-->{char1}, char2-->{char2}");

            #endregion swap

            //File.WriteAllText("Product", "sadasd");
            //File.Delete("Product");

            var repository = new Repository();
            var products = repository.GetData<Product>();
            products.Add(new Product { Name = "Sergen" });
            repository.WriteData<Product>(products);
            products.Add(new Product { Name = "Metehan" });
            repository.WriteData<Product>(products);
            var products2 = repository.GetData<Product>();
            var products3 = repository.GetData<Product>();

            products3.Add(new Product { Name = "En yenisi" });
            var products4 = repository.GetData<Product>();


        }

        private class Repository
        {
            //static Repository()
            //{
            //    Data = new Dictionary<string, object>();
            //}
            private static Dictionary<string, object> Data { get; set; } = new Dictionary<string, object>(); // tekrar tekrar dosyadan çekmesin !
            public List<T> GetData<T>()
            {
                var list = new List<T>();
                if (Data.ContainsKey(typeof(T).Name))
                {
                    list = (List<T>)Data[typeof(T).Name];
                }
                else if (File.Exists(typeof(T).Name))
                {
                    var jsonData = File.ReadAllText(typeof(T).Name, Encoding.UTF8);
                    list = JsonSerializer.Deserialize<List<T>>(jsonData);
                    Data.Add(typeof(T).Name, list);
                }
                return list;
            }

            public void WriteData<T>(List<T> data)
            {
                var jsonData = JsonSerializer.Serialize(data);
                File.WriteAllText(typeof(T).Name, jsonData);
            }
        }

        private class Product
        {
            public string Name { get; set; }
        }

        private class Category
        {
            public string Name { get; set; }
        }

        private static void Swap<T>(ref T a, ref T b)
        {
            T temp = a;
            a = b;
            b = temp;
        }
    }

    //TODO: Swap methodu için unit test yazınız !!!!
}