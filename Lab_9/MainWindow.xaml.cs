using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Mime;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace Lab_9
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();

            int pageNumber = 1;
            int pageSize = 5;
            string snippetsType = "cs"; // C#

            PageReposne reponse = FetchSnippets(pageNumber, pageSize, snippetsType);

            Console.WriteLine($"PageNumber: {reponse.PageNumber}");
            Console.WriteLine($"PagesCount: {reponse.PagesCount}");
            Console.WriteLine($"PageSize:   {reponse.PageSize}  ");
            Console.WriteLine($"TotalCount: {reponse.TotalCount}");

            Console.WriteLine();
            Console.WriteLine("Snippets:");

            foreach (SnippetReponse snippet in reponse.Batches)
                Console.WriteLine("    (" + snippet.Size + ")    " + snippet.Name + "    [" + snippet.Type + "]    " + snippet.CreationTime + "    " + snippet.UpdateTime);
        }
        public static string FetchData(string url)
        {
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);

            using (HttpWebResponse response = (HttpWebResponse)request.GetResponse())
            {
                ContentType type = new ContentType(response.ContentType ?? "text/plain;charset=" + Encoding.UTF8.WebName);
                Encoding encoding = Encoding.GetEncoding(type.CharSet ?? Encoding.UTF8.WebName);

                using (Stream stream = response.GetResponseStream())
                using (StreamReader reader = new StreamReader(stream, encoding))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static PageReposne FetchSnippets(int pageNumber, int pageSize, string snippetsType)
        {
            string url = $"https://dirask.com/api/snippets?pageNumber={pageNumber}&pageSize={pageSize}&dataOrder=newest&dataGroup=batches&snippetsType={Uri.EscapeUriString(snippetsType)}";
            string data = FetchData(url);

            return JsonSerializer.Deserialize<PageReposne>(data);
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            
        }
    }
    public class PageReposne
    {
        [JsonPropertyName("pageNumber")]
        public int PageNumber { get; set; }

        [JsonPropertyName("pagesCount")]
        public int PagesCount { get; set; }

        [JsonPropertyName("pageSize")]
        public int PageSize { get; set; }

        [JsonPropertyName("totalCount")]
        public int TotalCount { get; set; }

        [JsonPropertyName("batches")]
        public List<SnippetReponse> Batches { get; set; }
    }

    public class SnippetReponse
    {
        [JsonPropertyName("size")]
        public int Size { get; set; }

        [JsonPropertyName("type")]
        public string Type { get; set; }

        [JsonPropertyName("name")]
        public string Name { get; set; }

        [JsonPropertyName("creationTime")]
        public DateTime? CreationTime { get; set; }

        [JsonPropertyName("updateTime")]
        public DateTime? UpdateTime { get; set; }
    }
}
