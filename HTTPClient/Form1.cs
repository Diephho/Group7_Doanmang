using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Security.Policy;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net.Http;
using System.Diagnostics;
using System.Net.Http.Headers;
using Microsoft.Web.WebView2.Core;
using System.Xml;
using HtmlAgilityPack;
namespace HTTPClient
{
    public partial class Form1 : Form
    {
        private bool useHttp2 = false; // Biến để lưu trạng thái sử dụng HTTP/2
        public Form1()
        {
            InitializeComponent();
            InitializeWebView();
            radioButtonHttp11.Checked = true; // Thiết lập HTTP/1.1 là tùy chọn mặc định
        }
        HttpResponseHeaders headersResponse = null;
        HttpRequestHeaders headersRequest = null;
        private HtmlAgilityPack.HtmlDocument htmlDocument;
        private void InitializeWebView()
        {
            webView.CoreWebView2InitializationCompleted += webView_CoreWebView2InitializationCompleted;
        }
        private async void WebView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            htmlDocument = new HtmlAgilityPack.HtmlDocument();
            string htmlContent = await webView.CoreWebView2.ExecuteScriptAsync("document.documentElement.outerHTML");
            htmlDocument.LoadHtml(htmlContent);
        }
        private void webView_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            var webView = (Microsoft.Web.WebView2.WinForms.WebView2)sender;
            webView.NavigationCompleted += WebView_NavigationCompleted;
            webView.CoreWebView2.NavigationStarting += webView_CoreWebView2NavigationStarting;
        }
       
        private void webView_CoreWebView2NavigationStarting(object sender, CoreWebView2NavigationStartingEventArgs e)
        {
            txtUrl.Text = e.Uri;
        }
        public class Http2CustomHandler : WinHttpHandler
        {
            protected override Task<HttpResponseMessage> SendAsync(HttpRequestMessage request, System.Threading.CancellationToken cancellationToken)
            {
                request.Version = new Version("2.0");
                return base.SendAsync(request, cancellationToken);
            }
        }

        private HttpClient CreateHttpClient()
        {
            if (useHttp2)
            {
                // Sử dụng HTTP/2
                var handler = new Http2CustomHandler();
                return new HttpClient(handler);
            }
            else
            {
                // Sử dụng HTTP/1.1
                return new HttpClient();
            }
        }

        private async Task<string> GetHTMLAsync(string url)
        {
            using (HttpClient client = CreateHttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);
                request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/123.0.0.0 Safari/537.36");
                // Gửi yêu cầu và nhận phản hồi
                HttpResponseMessage response = await client.SendAsync(request);

                headersRequest = request.Headers;
                headersResponse = response.Headers;

                statusCode.Text = ((decimal)response.StatusCode) + " " + response.StatusCode.ToString();
                if (response.IsSuccessStatusCode)
                {
                    // Đọc nội dung với Encoding.UTF8 để đảm bảo đọc đúng bộ mã.
                    string responseData = await response.Content.ReadAsStringAsync();
                    string protocolVersion = response.Version.ToString();
                    MessageBox.Show("HTTP Protocol Version: " + protocolVersion);
                    return responseData;
                }
                else
                {
                    return "Error: " + response.StatusCode;
                }
            }
        }


        private async Task<string> GetDataWithCookieAsync(string url, string cookie)
        {
            using (HttpClient client = CreateHttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Get, url);

                // Thêm tiêu đề User-Agent vào yêu cầu để định danh trình duyệt khi gửi yêu cầu.
                request.Headers.Add("User-Agent", "Mozilla/5.0 (Windows NT 10.0; Win64; x64) AppleWebKit/537.36 (KHTML, like Gecko) Chrome/123.0.0.0 Safari/537.36");

                // Phân tách cookie thành các cặp key-value và thêm chúng vào CookieContainer.
                var cookiePairs = cookie.Split(';');
                foreach (var pair in cookiePairs)
                {
                    var cookieKeyValue = pair.Split('=');
                    if (cookieKeyValue.Length == 2)
                    {
                        request.Headers.Add("Cookie", $"{cookieKeyValue[0].Trim()}={cookieKeyValue[1].Trim()}");
                    }
                }

                HttpResponseMessage response = await client.SendAsync(request);

                headersRequest = request.Headers;
                headersResponse = response.Headers;

                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    return responseData;
                }
                else
                {
                    return "Error: " + response.StatusCode;
                }
            }
        }


        private async Task<string> PostDataAsync(string szUrl, string postData)
        {
            using (HttpClient client = CreateHttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, szUrl);
                // Tạo nội dung POST từ dữ liệu đã cung cấp
                HttpContent content = new StringContent(postData, Encoding.UTF8, "application/x-www-form-urlencoded");
                // Gán nội dung POST vào yêu cầu
                request.Content = content;
                // Gửi yêu cầu POST đến URL đã chỉ định và nhận phản hồi
                HttpResponseMessage response = await client.PostAsync(szUrl, content);
                headersRequest = request.Headers;
                headersResponse = response.Headers;
                statusCode.Text = ((decimal)response.StatusCode) + " " + response.StatusCode.ToString();
                // Đảm bảo yêu cầu thành công
                if (response.IsSuccessStatusCode)
                {
                    // Đọc nội dung phản hồi và trả về dưới dạng chuỗi
                    string responseData = await response.Content.ReadAsStringAsync();
                    return responseData;
                }
                else
                {
                    // Xử lý trường hợp lỗi nếu cần thiết
                    return "Error: " + response.StatusCode;
                }
            }
        }
        private async Task<string> DeleteDataAsync(string url)
        {
            using (HttpClient client = CreateHttpClient())
            {
                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Delete, url);
                HttpResponseMessage response = await client.DeleteAsync(url);
                statusCode.Text = ((decimal)response.StatusCode) + " " + response.StatusCode.ToString();
                headersRequest = request.Headers;
                headersResponse = response.Headers;
                if (response.IsSuccessStatusCode)
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    return responseData;
                }
                else
                {
                    return $"Error: {response.StatusCode}";
                }
            }
        }
        private async Task<string> PutDataAsync(string url, string data)
        {
            using (HttpClient client = CreateHttpClient())
            {
                StringContent content = new StringContent(data, Encoding.UTF8, "application/json");

                HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Put, url);
                HttpResponseMessage response = await client.PutAsync(url, content);
                headersRequest = request.Headers;
                headersResponse = response.Headers;
                statusCode.Text = ((decimal)response.StatusCode) + " " + response.StatusCode.ToString();
                if (response.IsSuccessStatusCode)
                {
                    // Đọc nội dung phản hồi và trả về dưới dạng chuỗi
                    string responseData = await response.Content.ReadAsStringAsync();
                    return responseData;
                }
                else
                {
                    return $"Error: {response.StatusCode}";
                }
            }
        }
        
        private async void button1_Click(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "GET":
                {
                    if (cookieBox.Text == "")
                    {
                        string responseData = await GetHTMLAsync(txtUrl.Text);
                    }
                    else
                    {
                        string responseData = await GetDataWithCookieAsync(txtUrl.Text, cookieBox.Text);
                    }
                    break;
                }
                    
                case "POST":
                {
                    string responseData = await PostDataAsync(txtUrl.Text, postData.Text);
                    break;
                }
                case "DELETE":
                {
                    string noti = await DeleteDataAsync(txtUrl.Text);
                    break;
                }
                case "PUT":
                {
                    string noti = await PutDataAsync(txtUrl.Text, postData.Text);
                    break;
                }
                default:
                {
                    MessageBox.Show("Invalid method");
                    break;
                }
            }
            if (!string.IsNullOrWhiteSpace(txtUrl.Text))
            {
                webView.Source = new Uri(txtUrl.Text);
            }

        }
        

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {
            webView.EnsureCoreWebView2Async();
        }

        private void btnBack_Click(object sender, EventArgs e)
        {
            if (webView.CanGoBack)
            {
                webView.GoBack();
            }
        }

        private void btnForward_Click(object sender, EventArgs e)
        {
            if (webView.CanGoForward)
            {
                webView.GoForward();
            }
        }

        private void btnReload_Click(object sender, EventArgs e)
        {
            webView.Reload();
        }
        private async Task<string> GetHtmlSourceAsync(string url)
        {
            using (HttpClient client = new HttpClient())
            {
                return await client.GetStringAsync(url);
            }
        }

        private async void btnViewSource_Click(object sender, EventArgs e)
        {
            string url = webView.Source.ToString();
            string htmlSource = await GetHtmlSourceAsync(url);

            var sourceForm = new SourceForm(htmlSource, headersRequest, headersResponse);
            sourceForm.Show();
        }

        private void radioButtonHttp11_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonHttp11.Checked)
            {
                useHttp2 = false; // Đặt biến useHttp2 về false để sử dụng HTTP/1.1
            }
        }

        private void radioButtonHttp2_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButtonHttp2.Checked)
            {
                useHttp2 = true; // Đặt biến useHttp2 về true để sử dụng HTTP/2
            }
        }
    }
    
}
