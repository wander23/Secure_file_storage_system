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
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;

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
                MessageBox.Show(dialog.FileName);
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
                        Image tempImg = Image.FromFile(dialog.FileName);

                        //resize image
                        if (tempImg.Width > 3000)
                            tempImg = ScaleByPercent(tempImg, 90);

                        // resize image in Temp folder (95%);
                        tempImg = ScaleByPercent(tempImg, 95);

                        //Download resized image in Temp folder
                        DownloadImage(tempImg, tempImg_path);
                        imageLocation = tempImg_path;

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
            }
            catch (Exception)
            {
                MessageBox.Show("An Error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            // Delete temp image in Temp folder
            DeleteFile(imageLocation);
            main_Load(sender, e);
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

                    DownloadImage(img, SavePath);
                }

                MessageBox.Show("Download complete!", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void DeleteFile(string filePath)
        {
            File.Delete(filePath);
        }

        private void DownloadImage(Image img, string path)
        {
            try
            {
                // set 24 bit image
                Bitmap bmp = new Bitmap(img.Width, img.Height, System.Drawing.Imaging.PixelFormat.Format24bppRgb);

                //set 96 dpi
                bmp.SetResolution(96.0f, 96.0f);

                using (var gr = Graphics.FromImage(bmp))
                    gr.DrawImage(img, new Rectangle(0, 0, img.Width, img.Height));

                // save image with format JPEG
                bmp.Save(path, ImageFormat.Jpeg);
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
            if(userID_form.idUser.Text=="ID")
            {
                return;
            }

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
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                this.main_Load(sender, e);
            }
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
    }
}
