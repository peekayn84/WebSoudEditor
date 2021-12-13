using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Media;

namespace Sound
{

    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            while (true)
            {
                HttpListener listener = new HttpListener();
                // установка адресов прослушки
                listener.Prefixes.Add("http://192.168.0.105:8888/connection/");
                listener.Start();
                Console.WriteLine("Ожидание подключений...");
                // метод GetContext блокирует текущий поток, ожидая получение запроса 
                HttpListenerContext context = listener.GetContext();
                HttpListenerRequest request = context.Request;
                // получаем объект ответа
                string url = request.Url.ToString();
                int volume = Convert.ToInt32(url.Substring(url.IndexOf("value=") + 6));
                //Console.WriteLine(volume.ToString());
                label1.Text = "Volume:" + volume.ToString();
                //var volume = AudioControl.GetMasterVolume();
                AudioControl.SetMasterVolume(Convert.ToSingle(volume*1.0/100));
                HttpListenerResponse response = context.Response;
                // создаем ответ в виде кода html
                string responseStr = "<html><head><meta charset='utf8'></head><body>Привет мир!</body></html>";
                byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseStr);
                // получаем поток ответа и пишем в него ответ
                response.ContentLength64 = buffer.Length;
                Stream output = response.OutputStream;
                output.Write(buffer, 0, buffer.Length);
                // закрываем поток
                output.Close();
                // останавливаем прослушивание подключений
                listener.Stop();
                Console.WriteLine("Обработка подключений завершена");
            }

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            this.BackColor = System.Drawing.Color.FromArgb(73, 51, 111);

            label1.ForeColor = System.Drawing.Color.FromArgb(254, 200, 50);
            button1.BackColor = System.Drawing.Color.FromArgb(174, 93, 28);
            button1.ForeColor = System.Drawing.Color.FromArgb(254, 200, 50);
        }
    }
}
