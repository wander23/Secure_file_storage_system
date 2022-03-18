﻿using System;
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
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
using System.Diagnostics;
using Newtonsoft.Json;

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
            create_Temp_folder();

            bool CheckedAll = false;
            lb_name.Text = Sign_In.instance.full_name;
            lb_id.Text = Sign_In.instance.id_;
            lb_e.Text = Sign_In.instance.pub_e.ToString();
            lb_n.Text = Sign_In.instance.pub_n.ToString();
        }

        static Image ScaleByPercent(Image imgPhoto, int Percent)
        {
            float nPercent = ((float)Percent / 100);

            int sourceWidth = imgPhoto.Width;
            int sourceHeight = imgPhoto.Height;
            int sourceX = 0;
            int sourceY = 0;

            int destX = 0;
            int destY = 0;
            int destWidth = (int)(sourceWidth * nPercent);
            int destHeight = (int)(sourceHeight * nPercent);

            Bitmap bmPhoto = new Bitmap(destWidth, destHeight,
                                     PixelFormat.Format24bppRgb);
            bmPhoto.SetResolution(imgPhoto.HorizontalResolution,
                                    imgPhoto.VerticalResolution);

            Graphics grPhoto = Graphics.FromImage(bmPhoto);
            grPhoto.InterpolationMode = InterpolationMode.HighQualityBilinear;

            grPhoto.DrawImage(imgPhoto,
                new Rectangle(destX, destY, destWidth, destHeight),
                new Rectangle(sourceX, sourceY, sourceWidth, sourceHeight),
                GraphicsUnit.Pixel);

            grPhoto.Dispose();
            return bmPhoto;
        }

        private void create_Temp_folder()
        {
            string exeFile = (new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
            string exeDir = Path.GetDirectoryName(exeFile);
            string TempFolder_path = Path.Combine(exeDir, @"..\..\..\..\..\pic\Temp");

            // check if Temp folder exist
            if (Directory.Exists(TempFolder_path) == false) // if not 
            {
                //create Temp folder
                System.IO.Directory.CreateDirectory(TempFolder_path);
            }
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
            images.ImageSize = new System.Drawing.Size(150, 90);

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
                imageList.Items.Add(new ListViewItem($"{itemIndex + 1}.bmp", itemIndex));
            }
        }

        private void LoadImage()
        {
            LoadedImages = new List<Image>();
            string jsonData = "";

            //Read image from clound 
            HttpClient client = new HttpClient();
            var responseTask = client.GetAsync("https://slave-of-deadlines.herokuapp.com/photos/" + Sign_In.instance.id_);
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
                try
                {
                    WebClient w = new WebClient();
                    byte[] imageByte = w.DownloadData(ImageUrl[i]);
                    MemoryStream stream = new MemoryStream(imageByte);

                    Image im = Image.FromStream(stream);

                    LoadedImages.Add(im);
                }
                catch
                {
                    continue;
                }
                
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
        private void SetPicturBoxImg(Image img)
        {
            selectedImage.Image = img;
        }

        // upload image
        private void btnUpload_Click(object sender, EventArgs e)
        {
            string imageLocation = "";
            try
            {
                OpenFileDialog dialog = new OpenFileDialog();
                dialog.Filter = "Image Files(*.jpeg;*.bmp;*.png;*.jpg)|*.jpeg;*.bmp;*.png;*.jpg";
              
                // find relative path of "loading image"
                string exeFile = (new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
                string exeDir = Path.GetDirectoryName(exeFile);
                string uploadingPath = Path.Combine(exeDir, @"..\..\..\..\..\pic\uploading.png");
                selectedImage.ImageLocation = uploadingPath;
                 
                // just show loading image
                try
                {
                    if (dialog.ShowDialog() == System.Windows.Forms.DialogResult.OK)
                    {
                        string TempFolder_path = Path.Combine(exeDir, @"..\..\..\..\..\pic\Temp");
                        string[] file_path_arr = dialog.FileName.Split('\\');
                        string tempImg_path = Path.Combine(TempFolder_path, dialog.FileName.Split('\\')[file_path_arr.Length - 1]);
                        string imgName = file_path_arr[file_path_arr.Length - 1];
                        string imgName_png = imgName.Split('.')[0] + ".png";
                        string tempImg_png_path = Path.Combine(TempFolder_path, imgName_png);

                        Image tempImg = Image.FromFile(dialog.FileName);

                        //resize image
                        if (tempImg.Width > 3000)
                            tempImg = ScaleByPercent(tempImg, 90);

                        // resize image in Temp folder (95%);
                        tempImg = ScaleByPercent(tempImg, 95);


                        //Download image in Temp folder
                        DownloadImage(tempImg, tempImg_path, "jpeg");

                        //dang..................
                        GFG g = new GFG();
                        g.encryptImage(Sign_In.instance.pub_n, Sign_In.instance.pub_e, Path.Combine(TempFolder_path, imgName), imgName_png);
                        
                        //imageLocation = tempImg_path;
                        imageLocation = tempImg_png_path;

                        selectedImage.ImageLocation = imageLocation;
                    }
                }
                catch
                {
                    try
                    {
                        Image firstImg = LoadedImages[0];
                        selectedImage.Image = firstImg;
                    }
                    catch
                    {
                        string TempPath = Path.Combine(exeDir, @"..\..\..\..\..\pic\gray.png");
                        selectedImage.ImageLocation = TempPath;
                    }
                    
                }
                if (dialog.FileName == "")
                    return;

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
                    idUser = Sign_In.instance.id_
                };
                var responseTask = client.PostAsJsonAsync("https://slave-of-deadlines.herokuapp.com/photos/one", photo);
                responseTask.Wait();

                // Delete temp image in Temp folder
                DeleteFile(imageLocation);
                main_Load(sender, e);
            }
            catch (Exception err)
            {
                MessageBox.Show("An Error occured"+err.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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
                    Image img = LoadedImages[imageList.CheckedIndices[i]];
                    string SavePath = path + "\\" + imageList.CheckedItems[i].Text;

                    DownloadImage(img, SavePath, "bmp");
                }

                MessageBox.Show("Download complete!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteFile(string filePath)
        {
            File.Delete(filePath);
        }

        private void DownloadImage(Image img, string path, string type)
        {
            try
            {
                // set 24 bit image
                Bitmap bmp = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                //set 96 dpi
                bmp.SetResolution(96.0f, 96.0f);

                using (var gr = Graphics.FromImage(bmp))
                    gr.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));

                if (type == "bmp")
                    // save image with format JPEG
                    bmp.Save(path, ImageFormat.Bmp);
                else if (type == "jpeg")
                    bmp.Save(path, ImageFormat.Jpeg);
                else if (type == "png")
                    bmp.Save(path, ImageFormat.Png);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
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

        private void btnDecrypt_Click(object sender, EventArgs e)
        {
            PrivateKey privateKey_form = new PrivateKey();
            privateKey_form.ShowDialog();

            string exeFile = (new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
            string exeDir = Path.GetDirectoryName(exeFile);
            string path = Path.Combine(exeDir, @"..\..\..\..\..\pic\Temp");
            string decryptingPath = Path.Combine(exeDir, @"..\..\..\..\..\pic\decrypting.png");
            selectedImage.ImageLocation = decryptingPath;

            GFG g = new GFG();

            List<Image> LImages = new List<Image>();


            for (int i = 0; i < LoadedImages.Count; i++)
            {
                string saveName = imageList.Items[i].Text.Split('.')[0] + ".png";
                string savePath = path + "\\" + saveName;
                DownloadImage(LoadedImages[i], savePath, "png");

                //key
                try
                {
                    g.decryptImage(Sign_In.instance.pub_n, int.Parse(PrivateKey.instance.private_key.Text), savePath, saveName);
                }
                catch
                {
                    //selectedImage.Image = LoadedImages[0];
                    SetPicturBoxImg(LoadedImages[0]);
                    return;
                }

                Image im = Image.FromFile(savePath);
                LImages.Add(im);
            }

            LoadedImages = LImages;

            Image firstImg;

            // case close form Private Key
            try
            {
                firstImg = LoadedImages[0];
            }
            catch
            {
                return;
            }

            selectedImage.Image = firstImg;

            // initializing images list
            ImageList images = new ImageList();
            images.ImageSize = new System.Drawing.Size(150, 90);
            
            images.Images.Clear();
            imageList.Items.Clear();

            foreach (var image in LoadedImages)
            {
                images.Images.Add(image);
            }

            // setting listview with imagelist
            imageList.SmallImageList = images;

            // add image to listview (imageList)
            for (int itemIndex = 0; itemIndex < LoadedImages.Count; itemIndex++)
            {
                imageList.Items.Add(new ListViewItem($"{itemIndex + 1}.png", itemIndex));
            }
        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            int numSelectedImg = imageList.CheckedIndices.Count;

            if (numSelectedImg == 0)
            {
                MessageBox.Show("Nothing to share", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            HttpClient client = new HttpClient();
            // open form
            UserID userID_form = new UserID();
            userID_form.ShowDialog();
            if (userID_form.idUser.Text == "ID")
            {
                return;
            }

            int my_private_d = int.Parse(UserID.instance.privkey.Text);
            int my_pub_n = Sign_In.instance.pub_n;

            int pub_n = 0;
            int pub_e = 0;

            // get path
            string exeFile = (new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
            string exeDir = Path.GetDirectoryName(exeFile);
            string TempPath = Path.Combine(exeDir, @"..\..\..\..\..\pic\Temp");
            string sendingPath = Path.Combine(exeDir, @"..\..\..\..\..\pic\sending.png");

            // Kiem tra va nhan khoa
            var responseTask2 = client.GetAsync("https://slave-of-deadlines.herokuapp.com/customers/pubkey/" + userID_form.idUser.Text);
            responseTask2.Wait();
            if (responseTask2.IsCompleted)
            {
                var result = responseTask2.Result;
                if (!result.IsSuccessStatusCode)
                {
                    MessageBox.Show("ID user dont exists", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }
                else
                {
                    var messageTask = result.Content.ReadAsStringAsync();
                    messageTask.Wait();

                    // get shared User public key
                    dynamic json = JsonConvert.DeserializeObject(messageTask.Result);
                    pub_e = Convert.ToInt32(json.data.e);
                    pub_n = Convert.ToInt32(json.data.n);
                    
                    Image im = Image.FromFile(sendingPath);
                    selectedImage.Image = im;
                }
            }

            // Send each image
            for (int i = 0; i < numSelectedImg; i++)
            {
                int imgIndex = imageList.CheckedIndices[i];
                try
                {

                    // Download image
                    Image img = LoadedImages[imageList.CheckedIndices[i]];
                    string SaveName = imageList.CheckedItems[i].Text.Split('.')[0] + ".png";
                    string SavePath = TempPath + "\\" + SaveName;

                    DownloadImage(img, SavePath, "png");

                    // Decrypt image by key of Sender
                    GFG g = new GFG();
                    g.decryptImage(my_pub_n, my_private_d, SavePath, SaveName);

                    // Encrypt image by Key of Receiver
                    g.encryptImage(pub_n, pub_e, SavePath, SaveName);


                    // Send Encrypt image to server
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


                    PhotoModel photo = new PhotoModel()
                    {
                        urlImage = url2,
                        idUser = userID_form.idUser.Text
                    };
                    var responseTask = client.PostAsJsonAsync("https://slave-of-deadlines.herokuapp.com/photos/one", photo);
                    responseTask.Wait();

                    DeleteFile(SavePath);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
            }

            selectedImage.Image = LoadedImages[0];

            MessageBox.Show("Share complete", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
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

       
        private void btn_reload_Click(object sender, EventArgs e)
        {
            this.main_Load(sender, e);
        }

        private void btn_copy_Click(object sender, EventArgs e)
        {
            // copy ID into clipboard
            Clipboard.SetText(lb_id.Text);

            lb_copy.Visible = true;
        }

        private void Main_Click(object sender, EventArgs e)
        {
            lb_copy.Visible = false;
        }

        private void lb_name_Click(object sender, EventArgs e)
        {
            lb_copy.Visible = false;
        }

        private void lb_id_Click(object sender, EventArgs e)
        {
            lb_copy.Visible = false;
        }

        private void lb_n_Click(object sender, EventArgs e)
        {
            lb_copy.Visible = false;
        }

        private void lb_e_Click(object sender, EventArgs e)
        {
            lb_copy.Visible = false;
        }

        private void tabPage2_Click(object sender, EventArgs e)
        {
            lb_copy.Visible = false;
        }

        private void btn_reload_MouseHover(object sender, EventArgs e)
        {
            btn_reload.Cursor = Cursors.Hand;
        }

        private void splitContainer1_SplitterMoved(object sender, SplitterEventArgs e)
        {

        }
    }
}
