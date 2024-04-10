using Microsoft.VisualBasic.ApplicationServices;
using System;
using System.ComponentModel;
using System.Diagnostics;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Net;
using System.Reflection.Emit;
using System.Runtime.InteropServices;
using System.Runtime.Intrinsics.X86;
using System.Text;
using System.Windows.Forms;

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
        Request_label.Size = new Size(124, 28);
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
        ResumeLayout(false);
        PerformLayout();
    }

    private HttpListener serverlis;
    private Button button1;
    private bool check;

    private void startlis()
    {
        HttpListener serverlis = new HttpListener();
        serverlis.Prefixes.Add("http://*:5050/");
        serverlis.Start();
        Display("Listening...");
        try { 
            while (true)
            {
                HttpListenerContext context = serverlis.GetContext();
                HttpListenerRequest request = context.Request;
                Display($"{request.HttpMethod} {request.Url}");
                if (request.HasEntityBody)
                {
                    var body = request.InputStream;
                    var encoding = request.ContentEncoding;
                    var reader = new StreamReader(body, encoding);
                    if (request.ContentType != null)
                    {
                        Display($"Client data content type {request.ContentType}");
                    }
                    Display($"Client data content length {request.ContentLength64}");

                    Display("Start of data:");
                    string s = reader.ReadToEnd();
                    Display(s);
                    Display("End of data:");
                    reader.Close();
                    body.Close();
                }
                HttpListenerResponse response = context.Response;
                string responseString = "<HTML><BODY>Hello Diep!</BODY></HTML>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                output.Close();
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
}

