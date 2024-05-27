using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HTTPClient
{
    public partial class SourceForm : Form
    {
        public SourceForm(string htmlSource, HttpRequestHeaders requestHeaders, HttpResponseHeaders responseHeaders)
        {
            InitializeComponent();
            txtSource.Text = htmlSource;
            LoadHeaders(requestHeaders, dvRequest);
            LoadHeaders(responseHeaders, dvResponse);
        }

        private void LoadHeaders(HttpHeaders headers, DataGridView dataGridView)
        {
            dataGridView.Rows.Clear();

            if (headers == null)
            {
                return;
            }

            int stt = 1; // Khởi tạo số thứ tự
            foreach (var header in headers)
            {
                string values = string.Join(", ", header.Value);
                dataGridView.Rows.Add(stt++, header.Key, values); // Thêm số thứ tự vào mỗi hàng
            }
        }
    }
}
