using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using CloudinaryDotNet;
using CloudinaryDotNet.Actions;
using System.Net.Http;
using System.Net.Http.Formatting;
using System.Net;

namespace Secure_file_storage_system__RSA_
{
    public partial class Main : Form
    {
        private List<Image> LoadedImages { get; set; }
        private List<string> ImageUrl { get; set; }
        private bool CheckAll { get; set; }

        public Main()
        {
            InitializeComponent();
            bool CheckedAll = false;
        }

        private void main_Load(object sender, EventArgs e)
        {

            // load images from Clound
            LoadImage();

            if (LoadedImages.Count==0)
            {
                return;
            }

            Image firstImg = LoadedImages[0];
            selectedImage.Image = firstImg;

            // initializing images list
            ImageList images = new ImageList();
            images.ImageSize = new System.Drawing.Size(210, 90);

            foreach (var image in LoadedImages)
            {
                images.Images.Add(image);
            }

            // setting listview with imagelist
            imageList.SmallImageList = images;

            // Clear all item in listview in case reload form when upload
            imageList.Items.Clear();

            // add image to listview (imageList)
            for (int itemIndex = 0; itemIndex < LoadedImages.Count; itemIndex++)
            {
                imageList.Items.Add(new ListViewItem($"{itemIndex + 1}.png", itemIndex));
            }
        }

        private void LoadImage()
        {
            LoadedImages = new List<Image>();
            string jsonData = "";

            //Read image from clound 
            HttpClient client = new HttpClient();
            var responseTask = client.GetAsync("https://slave-of-deadlines.herokuapp.com/photos/" + "61d82fd286a4206de43fefef");
            responseTask.Wait();

            if (responseTask.IsCompleted)
            {
                var result = responseTask.Result;
                if (result.IsSuccessStatusCode)
                {
                    var messageTask = result.Content.ReadAsStringAsync();
                    messageTask.Wait();

                    // take json data
                    jsonData = messageTask.Result;
                }
            }

            // parse json -> string[] which contain image's url
            jsonData = jsonData.Replace("\"", "");
            string[] imgUrl = jsonData.Split('[')[1].Split(']')[0].Split(',');

            // convert string[] to List<string>
            ImageUrl = new List<string>();
            ImageUrl = imgUrl.ToList();

            // Load image
            for (int i = 0; i < ImageUrl.Count; i++)
            {
                if (imgUrl[i] == "")
                {
                    break;
                }
                WebClient w = new WebClient();
                byte[] imageByte = w.DownloadData(ImageUrl[i]);
                MemoryStream stream = new MemoryStream(imageByte);

                Image im = Image.FromStream(stream);
                LoadedImages.Add(im);
            }
        }

        // action when selecte 1 item
        private void imageList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (imageList.SelectedIndices.Count > 0)
            {
                var selectedIndex = imageList.SelectedIndices[0];
                Image selectedImg = LoadedImages[selectedIndex];
                selectedImage.Image = selectedImg;
            }
        }

        // action when check 1 item
        private void imageList_ItemChecked(object sender, ItemCheckedEventArgs e)
        {
            var numSelectedImg = imageList.CheckedIndices.Count;

            if (numSelectedImg > 0)
            {
                var selectedIndex = imageList.CheckedIndices[numSelectedImg - 1];

                Image selectedImg = LoadedImages[selectedIndex];
                selectedImage.Image = selectedImg;
            }
        }

        // upload image
        private void btnUpload_Click(object sender, EventArgs e)
        {
            string imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";

                if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                {
                    imageLocation = dialog.FileName;

                    selectedImage.ImageLocation = imageLocation;
                }

                Account account = new Account(
                "cryption",
                "731936666387127",
                "INiU8DQHajhzDIZQmBWAFl4_HFk");

                Cloudinary cloudinary = new Cloudinary(account);

                var uploadParams = new ImageUploadParams()
                {
                    File = new FileDescription(@imageLocation),
                };

                var uploadResult = cloudinary.Upload(uploadParams);

                string url = cloudinary.Api.UrlImgUp.BuildUrl(String.Format("{0}.{1}", uploadResult.PublicId, uploadResult.Format));

                HttpClient client = new HttpClient();
                PhotoModel photo = new PhotoModel()
                {
                    urlImage = url,
                    idUser = "61d82fd286a4206de43fefef"
                };
                var responseTask = client.PostAsJsonAsync("https://slave-of-deadlines.herokuapp.com/photos/one", photo);
                responseTask.Wait();

                this.main_Load(sender, e);
            }
            catch (Exception)
            {
                MessageBox.Show("An Error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        // dowload checked image
        private void btnDownload_Click(object sender, EventArgs e)
        {
            var numSelectedImg = imageList.CheckedIndices.Count;

            FolderBrowserDialog sf = new FolderBrowserDialog();

            if (sf.ShowDialog() == DialogResult.OK)
            {
                string path = sf.SelectedPath;

                for (int i = 0; i < numSelectedImg; i++)
                {
                    try
                    {
                        // "name of the file"
                        Bitmap b = new Bitmap(LoadedImages[imageList.CheckedIndices[i]]);
                        // "path of the folder to save"
                        string SavePath = path + "\\" + imageList.CheckedItems[i].Text;
                        b.Save(SavePath);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message);
                    }
                }

                MessageBox.Show("Download complete!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        // check all image in image list
        private void btnAll_Click(object sender, EventArgs e)
        {
            var index = 0;
            bool state = true;
            if (CheckAll == true)
                state = false;

            while (true)
            {
                try
                {
                    imageList.Items[index].Checked = state;
                }
                catch (Exception)
                {
                    break;
                }

                index++;
            }
            CheckAll = state;
        }

        // action when click close button
        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            Sign_In.instance.Close();
        }

        private void btnDecrypt_MouseHover(object sender, EventArgs e)
        {
            btnDecrypt.Cursor = Cursors.Hand;
        }

        private void btnShare_MouseHover(object sender, EventArgs e)
        {
            btnShare.Cursor = Cursors.Hand;
        }

        private void btnAll_MouseHover(object sender, EventArgs e)
        {
            btnAll.Cursor = Cursors.Hand;
        }

        private void btnUpload_MouseHover(object sender, EventArgs e)
        {
            btnUpload.Cursor = Cursors.Hand;
        }

        private void btnDownload_MouseHover(object sender, EventArgs e)
        {
            btnDownload.Cursor = Cursors.Hand;
        }

        private void tabControl1_MouseHover(object sender, EventArgs e)
        {
            tabControl1.Cursor = Cursors.Hand;
        }

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            PrivateKey privateKey_form = new PrivateKey();
            privateKey_form.ShowDialog();
        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            // open form
            UserID userID_form = new UserID();
            userID_form.ShowDialog();

            //----------- QUAN --------------------------
            // get path
            string exeFile = (new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
            string exeDir = Path.GetDirectoryName(exeFile);
            string TempPath = Path.Combine(exeDir, @"..\..\..\..\..\pic\Temp");
            var numSelectedImg = imageList.CheckedIndices.Count;

            // Download checked Image to Temp folder
            for (int i = 0; i < numSelectedImg; i++)
            {
                int imgIndex = imageList.CheckedIndices[i];
                try
                {
                    string url = ImageUrl[imgIndex];

                    // "name of the file"
                    Bitmap b = new Bitmap(LoadedImages[imgIndex]);

                    // "path of the folder to save"
                    string SavePath = TempPath + "\\" + imageList.Items[imgIndex].Text;
                    b.Save(SavePath);

                    Account account = new Account(
                   "cryption",
                   "731936666387127",
                   "INiU8DQHajhzDIZQmBWAFl4_HFk");

                    Cloudinary cloudinary = new Cloudinary(account);

                    var uploadParams = new ImageUploadParams()
                    {
                        File = new FileDescription(@SavePath),
                    };

                    var uploadResult = cloudinary.Upload(uploadParams);

                    string url2 = cloudinary.Api.UrlImgUp.BuildUrl(String.Format("{0}.{1}", uploadResult.PublicId, uploadResult.Format));

                    HttpClient client = new HttpClient();
                    PhotoModel photo = new PhotoModel()
                    {
                        urlImage = url,
                        idUser = userID_form.idUser.Text
                    };
                    var responseTask = client.PostAsJsonAsync("https://slave-of-deadlines.herokuapp.com/photos/one", photo);
                    responseTask.Wait();
                    
                    this.main_Load(sender, e);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }
        }
    }
}
