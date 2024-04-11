using Microsoft.VisualBasic.ApplicationServices;
using Newtonsoft.Json;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.Dynamic;
using System.IO;
using System.Net;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Text.Json.Serialization;
using System.Web;
using System.Windows.Forms;
using MySql.Data.MySqlClient;
public class Server : Form
{

    public Server()
    {
        InitializeComponent();
    }
    private void InitializeComponent()
    {
        textBox1 = new TextBox();
        Request_label = new System.Windows.Forms.Label();
        Listen_btn = new Button();
        button1 = new Button();
        SuspendLayout();
        // 
        // textBox1
        // 
        textBox1.Location = new Point(38, 65);
        textBox1.Multiline = true;
        textBox1.Name = "textBox1";
        textBox1.Size = new Size(635, 273);
        textBox1.TabIndex = 0;
        // 
        // Request_label
        // 
        Request_label.AutoSize = true;
        Request_label.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        Request_label.Location = new Point(38, 22);
        Request_label.Name = "Request_label";
        Request_label.Size = new Size(153, 32);
        Request_label.TabIndex = 1;
        Request_label.Text = "Request List: ";
        // 
        // Listen_btn
        // 
        Listen_btn.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        Listen_btn.Location = new Point(566, 360);
        Listen_btn.Name = "Listen_btn";
        Listen_btn.Size = new Size(107, 47);
        Listen_btn.TabIndex = 2;
        Listen_btn.Text = "Listen";
        Listen_btn.UseVisualStyleBackColor = true;
        Listen_btn.Click += Listen_btn_Click;
        // 
        // button1
        // 
        button1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
        button1.Location = new Point(418, 360);
        button1.Name = "button1";
        button1.Size = new Size(116, 47);
        button1.TabIndex = 3;
        button1.Text = "Stop";
        button1.UseVisualStyleBackColor = true;
        button1.Click += button1_Click;
        // 
        // Server
        // 
        ClientSize = new Size(713, 444);
        Controls.Add(button1);
        Controls.Add(Listen_btn);
        Controls.Add(Request_label);
        Controls.Add(textBox1);
        Name = "Server";
        Load += Server_Load;
        ResumeLayout(false);
        PerformLayout();
    }

    private HttpListener serverlis;
    private Button button1;
    private bool check;

    private async void startlis()
    {
        HttpListener serverlis = new HttpListener();
        serverlis.Prefixes.Add("http://*:5050/");
        serverlis.Start();
        Display("Listening...");
        try
        {
            while (true)
            {
                HttpListenerContext context = serverlis.GetContext();
                HttpListenerRequest request = context.Request;
                Display($"{request.HttpMethod} {request.RawUrl} HTTP/1.1");
                // Lấy tất cả các key của tiêu đề
                string[] headerKeys = request.Headers.AllKeys;

                // Duyệt qua các key từ sau ra trước
                for (int i = headerKeys.Length - 1; i >= 0; i--)
                {
                    string key = headerKeys[i];
                    Display($"{key}: {request.Headers[key]}");
                }
                HttpListenerResponse response = context.Response;

                switch (request.Url.AbsolutePath)
                {
                    case "/":
                    {
                            if (request.HttpMethod == "GET")
                            {
                                string formHtml = "<HTML><BODY>" +
                                                  "<form method=\"POST\">" +
                                                  "<input type=\"text\" name=\"name\" />" +
                                                  "<input type=\"submit\" value=\"Submit\" />" +
                                                  "</form>" +
                                                  "</BODY></HTML>";
                                byte[] formBuffer = System.Text.Encoding.UTF8.GetBytes(formHtml);
                                response.ContentLength64 = formBuffer.Length;
                                Stream output = response.OutputStream;
                                output.Write(formBuffer, 0, formBuffer.Length);
                                output.Close();
                            }
                            else if (request.HttpMethod == "POST")
                            {
                                if (request.HasEntityBody)
                                {
                                    var body = request.InputStream;
                                    var encoding = request.ContentEncoding;
                                    var reader = new StreamReader(body, encoding);

                                    Display("Start of data:");
                                    string s = reader.ReadToEnd();
                                    Display(s);
                                    Display("End of data:");
                                    reader.Close();
                                    body.Close();
                                    string responseString = $"<HTML><BODY>Hello {s.Split('=')[1]}!</BODY></HTML>";
                                    byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                                    response.ContentLength64 = buffer.Length;
                                    Stream output = response.OutputStream;
                                    output.Write(buffer, 0, buffer.Length);
                                    output.Close();
                                }
                            }
                            break;
                        }
                    case "/login":
                        if (request.HttpMethod == "GET")
                        {
                            string loginFormHtml = "<HTML><BODY>" +
                                                   "<h2>Login</h2>" +
                                                   "<form method=\"POST\">" +
                                                   "<label for=\"username\">Username:</label>" +
                                                   "<input type=\"text\" id=\"username\" name=\"username\" /><br><br>" +
                                                   "<label for=\"password\">Password:</label>" +
                                                   "<input type=\"password\" id=\"password\" name=\"password\" /><br><br>" +
                                                   "<input type=\"submit\" value=\"Login\" />" +
                                                   "</form>" +
                                                   "</BODY></HTML>";
                            byte[] loginFormBuffer = System.Text.Encoding.UTF8.GetBytes(loginFormHtml);
                            response.ContentLength64 = loginFormBuffer.Length;
                            Stream output = response.OutputStream;
                            output.Write(loginFormBuffer, 0, loginFormBuffer.Length);
                            output.Close();
                        }
                        else if (request.HttpMethod == "POST")
                        {
                            if (request.HasEntityBody)
                            {
                                var body = request.InputStream;
                                var encoding = request.ContentEncoding;
                                var reader = new StreamReader(body, encoding);
                                string postData = reader.ReadToEnd();
                                postData = HttpUtility.UrlDecode(postData);

                                var parameters = postData.Split('&').Select(param => param.Split('=')).ToDictionary(pair => pair[0], pair => pair[1]);
                                string username = parameters["username"];
                                string password = parameters["password"];
                                bool loginSuccess = CheckLogin(username, password);
                                string responseString;
                                if (loginSuccess)
                                {
                                    responseString = "<HTML><BODY>Login successful!</BODY></HTML>";
                                }
                                else
                                {
                                    responseString = "<HTML><BODY>Login failed. Please try again.</BODY></HTML>";
                                }

                                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                                response.ContentLength64 = buffer.Length;
                                Stream output = response.OutputStream;
                                output.Write(buffer, 0, buffer.Length);
                                output.Close();

                                reader.Close();
                                body.Close();
                            }
                        }
                        break;

                    case "/register":
                        if (request.HttpMethod == "GET")
                        {
                            string registerFormHtml = "<HTML><BODY>" +
                                                      "<h2>Register</h2>" +
                                                      "<form method=\"POST\">" +
                                                      "<label for=\"username\">Username:</label>" +
                                                      "<input type=\"text\" id=\"username\" name=\"username\" /><br><br>" +
                                                      "<label for=\"password\">Password:</label>" +
                                                      "<input type=\"password\" id=\"password\" name=\"password\" /><br><br>" +
                                                      "<label for=\"name\">name:</label>" +
                                                      "<input type=\"name\" id=\"name\" name=\"name\" /><br><br>" +
                                                      "<input type=\"submit\" value=\"Register\" />" +
                                                      "</form>" +
                                                      "</BODY></HTML>";
                            byte[] registerFormBuffer = System.Text.Encoding.UTF8.GetBytes(registerFormHtml);
                            response.ContentLength64 = registerFormBuffer.Length;
                            Stream output = response.OutputStream;
                            output.Write(registerFormBuffer, 0, registerFormBuffer.Length);
                            output.Close();
                        }
                        else if (request.HttpMethod == "POST")
                        {
                            if (request.HasEntityBody)
                            {
                                var body = request.InputStream;
                                var encoding = request.ContentEncoding;
                                var reader = new StreamReader(body, encoding);
                                string postData = reader.ReadToEnd();
                                postData = HttpUtility.UrlDecode(postData);
                                var parameters = postData.Split('&').Select(param => param.Split('=')).ToDictionary(pair => pair[0], pair => pair[1]);
                                string username = parameters["username"];
                                string password = parameters["password"];
                                string name = parameters["name"];
                                bool registerSuccess = ProcessRegistration(username,password,name);
                                string responseString;
                                if (registerSuccess)
                                {
                                    responseString = "<HTML><BODY>Registration successful!</BODY></HTML>";
                                }
                                else
                                {
                                    responseString = "<HTML><BODY>Registration failed. Please try again.</BODY></HTML>";
                                }

                                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                                response.ContentLength64 = buffer.Length;
                                Stream output = response.OutputStream;
                                output.Write(buffer, 0, buffer.Length);
                                output.Close();

                                reader.Close();
                                body.Close();
                            }
                        }
                        break;
                    case "/json":
                    case string path when path.StartsWith("/json/"):
                        {
                            // Lấy id từ URL
                            string id = path.Substring("/json/".Length);


                            if (request.HttpMethod == "GET")
                            {
                                // Đọc dữ liệu từ tệp JSON
                                var jsonFilePath = $"{id}.json";

                                if (File.Exists(jsonFilePath))
                                {
                                    string jsonData = File.ReadAllText(jsonFilePath);

                                    // Trả về dữ liệu JSON như một phản hồi HTTP
                                    response.Headers.Add("Content-Type", "application/json");
                                    byte[] buffer = Encoding.UTF8.GetBytes(jsonData);
                                    response.ContentLength64 = buffer.Length;
                                    Stream output = response.OutputStream;
                                    output.Write(buffer, 0, buffer.Length);
                                    output.Close();
                                }
                                else
                                {
                                    // Trả về lỗi 404 nếu tệp không tồn tại
                                    response.StatusCode = (int)HttpStatusCode.NotFound;
                                    var buffer = Encoding.UTF8.GetBytes("File Not Found");
                                    response.ContentLength64 = buffer.Length;
                                    Stream output = response.OutputStream;
                                    output.Write(buffer, 0, buffer.Length);
                                    output.Close();
                                }
                            }
                            else if (request.HttpMethod == "POST")
                            {
                                // Kiểm tra xem tệp JSON đã tồn tại chưa
                                var jsonFilePath = $"{id}.json";

                                if (!File.Exists(jsonFilePath))
                                {
                                    // Tạo một mảng rỗng nếu tệp không tồn tại
                                    File.WriteAllText(jsonFilePath, "[]");

                                    // Lấy dữ liệu từ yêu cầu POST
                                    if (request.HasEntityBody)
                                    {
                                        var body = request.InputStream;
                                        var encoding = request.ContentEncoding;
                                        var reader = new StreamReader(body, encoding);
                                        string postData = reader.ReadToEnd();
                                        Display("\n" + postData);
                                        reader.Close();
                                        body.Close();

                                        // Phân tích dữ liệu POST
                                        var postParams = System.Web.HttpUtility.ParseQueryString(postData);
                                        var firstName = postParams["firstName"];
                                        var lastName = postParams["lastName"];

                                        // Đọc dữ liệu hiện tại từ tệp JSON
                                        string jsonData = File.ReadAllText(jsonFilePath);

                                        // Phân tích dữ liệu JSON hiện tại thành danh sách đối tượng
                                        List<dynamic> jsonObject = JsonConvert.DeserializeObject<List<dynamic>>(jsonData);

                                        // Thêm dữ liệu mới vào danh sách
                                        dynamic newData = new ExpandoObject();
                                        newData.firstName = firstName;
                                        newData.lastName = lastName;
                                        jsonObject.Add(newData);

                                        // Ghi lại dữ liệu vào tệp JSON
                                        File.WriteAllText(jsonFilePath, JsonConvert.SerializeObject(jsonObject));

                                        // Trả về phản hồi thành công
                                        string responseString = $"Added firstName:{firstName}, lastName:{lastName} to JSON database at {jsonFilePath}.";
                                        byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                                        response.ContentLength64 = buffer.Length;
                                        Stream output = response.OutputStream;
                                        output.Write(buffer, 0, buffer.Length);
                                        output.Close();
                                    }
                                }
                                else
                                {
                                    // Trả về lỗi 409 nếu tệp đã tồn tại
                                    response.StatusCode = (int)HttpStatusCode.Conflict;
                                    var buffer = Encoding.UTF8.GetBytes("File Already Exists");
                                    response.ContentLength64 = buffer.Length;
                                    Stream output = response.OutputStream;
                                    output.Write(buffer, 0, buffer.Length);
                                    output.Close();
                                }
                            }
                            else if (request.HttpMethod == "DELETE")
                            {
                                // Xóa tệp JSON nếu tồn tại
                                var jsonFilePath = $"{id}.json";

                                if (File.Exists(jsonFilePath))
                                {
                                    File.Delete(jsonFilePath);

                                    // Trả về phản hồi thành công
                                    string responseString = $"Deleted JSON file {jsonFilePath}.";
                                    byte[] buffer = Encoding.UTF8.GetBytes(responseString);
                                    response.ContentLength64 = buffer.Length;
                                    Stream output = response.OutputStream;
                                    output.Write(buffer, 0, buffer.Length);
                                    output.Close();
                                }
                                else
                                {
                                    // Trả về lỗi 404 nếu tệp không tồn tại
                                    response.StatusCode = (int)HttpStatusCode.NotFound;
                                    var buffer = Encoding.UTF8.GetBytes("File Not Found");
                                    response.ContentLength64 = buffer.Length;
                                    Stream output = response.OutputStream;
                                    output.Write(buffer, 0, buffer.Length);
                                    output.Close();
                                }
                            }
                            else
                            {
                                // Trường hợp không hỗ trợ phương thức HTTP khác
                                response.StatusCode = (int)HttpStatusCode.MethodNotAllowed;
                                var buffer = Encoding.UTF8.GetBytes("Method Not Allowed");
                                response.ContentLength64 = buffer.Length;
                                Stream output = response.OutputStream;
                                output.Write(buffer, 0, buffer.Length);
                                output.Close();
                            }
                            break;
                        }
              
                    case "/anhmeo.png":
                        {
                            response.Headers.Add("Content-Type", "image/png");
                            var buffer = await File.ReadAllBytesAsync("meongusay.png");
                            response.ContentLength64 = buffer.Length;
                            Stream output = response.OutputStream;
                            output.Write(buffer, 0, buffer.Length);
                            output.Close();
                            break;
                        }
                    default:
                        {
                            response.StatusCode = (int)HttpStatusCode.NotFound;
                            var buffer = Encoding.UTF8.GetBytes("NOT FOUND");
                            response.ContentLength64 = buffer.Length;
                            Stream output = response.OutputStream;
                            output.Write(buffer, 0, buffer.Length);
                            output.Close();
                            break;
                        }
                }    

                
            }
        }
        catch (Exception ex)
        {
            MessageBox.Show($"Error: {ex.Message}");
        }
        finally
        {
            serverlis.Stop();
        }
    }
    public bool CheckLogin(string username, string password)
    {
        bool result = false;
        string connectionString = "Server=localhost;Database=myDatabase;Uid=myUsername;Pwd=myPassword;";
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "SELECT COUNT(1) FROM Users WHERE Username=@username AND Password=SHA2(@password, 256)";
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@password", password); // Mật khẩu nên được mã hóa trước khi so sánh
                result = Convert.ToInt32(command.ExecuteScalar()) == 1;
            }
        }
        return result;
    }

    public bool ProcessRegistration(string username, string password, string name)
    {
        bool result = false;
        string connectionString = "Server=localhost;Port=3306;Uid=root;Pwd=;";
        using (var connection = new MySqlConnection(connectionString))
        {
            connection.Open();
            string query = "INSERT INTO Users (Username, name, Password) VALUES (@username, @name, SHA2(@password, 256))"; // Sửa thứ tự và thêm mã hóa mật khẩu
            using (var command = new MySqlCommand(query, connection))
            {
                command.Parameters.AddWithValue("@username", username);
                command.Parameters.AddWithValue("@name", name);
                command.Parameters.AddWithValue("@password", password); // Mật khẩu nên được mã hóa trước khi lưu
                result = command.ExecuteNonQuery() == 1;
            }
        }
        return result;
    }



    private void Display(string message)
    {
        if (textBox1.InvokeRequired)
        {
            textBox1.Invoke(new MethodInvoker(delegate
            {
                Display(message);
            }));
        }
        else
        {
            textBox1.AppendText(message + Environment.NewLine);
        }
    }

    private void Listen_btn_Click(object sender, EventArgs e)
    {
        Thread threadserver = new Thread(() => startlis());
        threadserver.Start();
    }

    private TextBox textBox1;
    private System.Windows.Forms.Label Request_label;
    private Button Listen_btn;

    private void button1_Click(object sender, EventArgs e)
    {
        check = false;
    }

    private void Server_Load(object sender, EventArgs e)
    {

    }
}

