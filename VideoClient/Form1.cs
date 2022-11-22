using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using VideoClient.Models;



namespace VideoClient
{
    public partial class Form1 : Form
    {
        private readonly string _listVideo = "https://localhost:7217/api/Video";
        private ICollection<VideoDescription> list;

        public Form1()
        {
            InitializeComponent();
        }

        private void Start(object sender, EventArgs e)
        {
            list = GetList(_listVideo).Result;
            listBox1.DataSource = list;
            listBox1.DisplayMember = "Name";
            listBox1.ValueMember = "Id";
        }

        private void NewSelect(Guid id)
        {
            var selectedVideo = list.FirstOrDefault(item => item.Id == id);
            if (selectedVideo != null)
            {
                label1.Text = selectedVideo.Description;
                axWindowsMediaPlayer1.URL = _listVideo + id;
            }
        }

        private async Task<ICollection<VideoDescription>> GetList(string path)
        {
            var client = new HttpClient();
            HttpResponseMessage response = client.GetAsync(path).Result;
            var video = await response.Content.ReadFromJsonAsync<List<VideoDescription>>();
            return video;
        }

        private void NewSelect(object sender, EventArgs e)
        {
            var i = listBox1.SelectedItem;
            if (i != null)
            {
                NewSelect(((VideoDescription)i).Id);
            }
        }
    }
}
