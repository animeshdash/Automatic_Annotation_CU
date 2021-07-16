using Automatic_Annotation_CU;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Net.Http;
using Newtonsoft.Json;
using System.Threading.Tasks;

namespace Automatic_Annotation_CU.Forms
{
    public partial class Login : Form
    {
        public string strWelcomeMessage = "";
        public Login()
        {
            InitializeComponent();
        }

        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string username = "";
            string password = "";
            
            username = txtUsername.Text;
            password = txtPassword.Text;
            if (validateValues(username, password) == true)
            {
                var isUserValid = checkUserCredentials(username, password);
                if (isUserValid == true)
                {
                    this.Hide();
                    strWelcomeMessage = "Welcome, " + username + "!!";
                    ParentForm pf = new ParentForm();
                    pf.ShowDialog();
                }
               else
                {
                    MessageBox.Show("Invalid credentials!!");
                }
            }
            
        }

        //private static async Task<string> PostURI(Uri u, HttpContent c)
        //{
        //    var response = string.Empty;
        //    using (var client = new HttpClient())
        //    {
        //        HttpResponseMessage result = await client.PostAsync(u, c);
        //        if (result.IsSuccessStatusCode)
        //        {
        //            response = result.StatusCode.ToString();
        //        }
        //    }
        //    return response;
        //}

        private bool validateValues(string username,string password)
        {
            if (string.IsNullOrWhiteSpace(username))
            {
                MessageBox.Show("Username can't be blank!!");
                return false;
            }
            if (username.Length < 5)
            {
                MessageBox.Show("Username can't be less than 5 characters!!");
                return false;
            }
            if (string.IsNullOrWhiteSpace(password))
            {
                MessageBox.Show("Password can't be blank!!");
                return false;
            }
            if (password.Length < 5)
            {
                MessageBox.Show("Password can't be less than 5 characters!!");
                return false;
            }
            return true;
        }

        private bool checkUserCredentials(string username, string password)
        {
            bool correctCredentials = false;
            string inputParams = "{ \"firstName\":\"" + username + "\",\"password\":\"" + password + "\"}";
            var json = JsonConvert.SerializeObject(inputParams);
            var data = new StringContent(json, Encoding.UTF8, "application/json");

            var url = "http://localhost:8000/loginuser/";
            using var client = new HttpClient();
            var webRequest = new HttpRequestMessage(HttpMethod.Post, url)
            {
                Content = new StringContent(inputParams, Encoding.UTF8, "application/json")
            };

            var response =  client.Send(webRequest);

            //string result = response.Content.ReadAsStringAsync().Result;

            //using (var httpClient = new HttpClient())
            //using (var request = new HttpRequestMessage(HttpMethod.Post, "http://localhost:8000/loginuser/")
            //{

            //    var json = JsonConvert.SerializeObject(inputParams);

            //    using (var stringContent = new StringContent(json, Encoding.UTF8, "application/json"))
            //    {
            //        request.Content = stringContent;

            //        using (var response = httpClient.SendAsync(request, HttpCompletionOption.ResponseHeadersRead, cancellationToken).ConfigureAwait(false))
            //        {
            //            response.EnsureSuccessStatusCode();
            //        }
            //    }
            //return correctCredentials;
            //}
            //{

            //    httpClient.DefaultRequestHeaders.Add("X-Version", "1");
            //    var response = httpClient.PostAsync( (new Uri("http://localhost:8000/loginuser/")).Result;

            //}

            //return correctCredentials;
            if (response.StatusCode.ToString() == "Unauthorized")
            {
                return false; 
            }
            else
            {
                return true;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
