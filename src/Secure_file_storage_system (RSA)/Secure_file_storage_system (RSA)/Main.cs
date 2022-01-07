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

namespace Secure_file_storage_system__RSA_
{
    public partial class Main : Form
    {
        private List<Image> LoadedImages { get; set; }
        public Main()
        {
            InitializeComponent();
        }

        private void main_Load(object sender, EventArgs e)
        {
            // load images from folder
            LoadImage();

            // initializing images list
            ImageList images = new ImageList();
            images.ImageSize = new System.Drawing.Size(210, 90);

            foreach (var image in LoadedImages)
            {
                images.Images.Add(image);
            }

            // setting listview with imagelist
            //imageList.LargeImageList = images;
            imageList.SmallImageList = images;

            for (int itemIndex = 1; itemIndex < LoadedImages.Count; itemIndex++)
            {
                imageList.Items.Add(new ListViewItem($"{itemIndex}.png", itemIndex - 1));
            }
        }

        private void LoadImage()
        {
            LoadedImages = new List<Image>();
            string exeFile = (new System.Uri(Assembly.GetEntryAssembly().CodeBase)).AbsolutePath;
            string exeDir = Path.GetDirectoryName(exeFile);

            var index = 1;
            while (index < 10)
            {
                try
                {
                    string tempLocation = Path.Combine(exeDir, $@"..\..\..\..\..\pic\TestImage\{index}.png");

                    var tempImage = Image.FromFile(tempLocation);
                    LoadedImages.Add(tempImage);

                }
                catch (Exception)
                {
                }

                index++;
            }
        }

        private void imageList_ItemSelectionChanged(object sender, ListViewItemSelectionChangedEventArgs e)
        {
            if (imageList.SelectedIndices.Count > 0)
            {
                var selectedIndex = imageList.SelectedIndices[0];
                Image selectedImg = LoadedImages[selectedIndex];
                selectedImage.Image = selectedImg;
            }
        }

        private void pictureBox_Click(object sender, EventArgs e)
        {

        }

        private void lb_Signup_Click(object sender, EventArgs e)
        {

        }

        private void label18_Click(object sender, EventArgs e)
        {

        }

        private void splitContainer1_Panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label20_Click(object sender, EventArgs e)
        {

        }

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
                MessageBox.Show(url);

                //MessageBox.Show("An Error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            catch (Exception)
            {
                MessageBox.Show("An Error occured", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
              

        }

        private void Main_FormClosed(object sender, FormClosedEventArgs e)
        {
            //Sign_In.instance.Close();
        }

    }
}
