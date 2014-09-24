

using System;
using System.Drawing;
using System.Collections;
using System.ComponentModel;
using System.Windows.Forms;
using System.Data;

//using AForge.Imaging;

using AForge.Imaging.Filters;
namespace FFTBoxes
{
    /// <summary>
    /// This program takes a picture and modifies it by adding a blurry or sharper filter.
    /// </summary>
    public class PictureBoxDemo : System.Windows.Forms.Form
    {   
        /// <summary>
        /// Create buttons and the picture box
        /// Import a picture and convert it to a Bitmap
        /// Create filters using the AForge library.
        /// </summary>
        private System.Windows.Forms.Button restoreButton;
        private System.Windows.Forms.Button sharpenButton;
        private System.Windows.Forms.Button fuzzyButton;
        private System.Windows.Forms.PictureBox pictureHolder;
        static string path = @"C:\Users\matt\Desktop\Space.jpg";  // Change the path if needed.
        Bitmap bm = new Bitmap(Image.FromFile(path));
        IFilter sharper = new Sharpen();
        IFilter fuzzier = new GaussianBlur(2.0, 7);

        private System.ComponentModel.Container components = null;
      

        public PictureBoxDemo()
        {
            InitializeComponent();
            this.Text = "FFT Test";
            pictureHolder.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureHolder.Image = Image.FromFile(path);
        }

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        protected override void Dispose(bool disposing)
        {
            if (disposing)
            {
                if (components != null)
                {
                    components.Dispose();
                }
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code
        /// <summary>
        /// Create all the buttons and put them where they need to go.
        /// </summary>
        private void InitializeComponent()
        {   
            this.sharpenButton = new System.Windows.Forms.Button();
            this.fuzzyButton = new System.Windows.Forms.Button();
            this.restoreButton = new System.Windows.Forms.Button();
            this.pictureHolder = new System.Windows.Forms.PictureBox();

            ((System.ComponentModel.ISupportInitialize)(this.pictureHolder)).BeginInit();
            pictureHolder.SizeMode = PictureBoxSizeMode.StretchImage;
            this.SuspendLayout();

            // 
            // sharpenButton
            // 
            this.sharpenButton.Location = new System.Drawing.Point(0, 558);
            this.sharpenButton.Name = "sharpenButton";
            this.sharpenButton.Size = new System.Drawing.Size(56, 23);
            this.sharpenButton.TabIndex = 1;
            this.sharpenButton.Text = "Sharper";
            this.sharpenButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // fuzzyButton
            // 
            this.fuzzyButton.Location = new System.Drawing.Point(0, 600);
            this.fuzzyButton.Name = "fuzzyButton";
            this.fuzzyButton.Size = new System.Drawing.Size(56, 23);
            this.fuzzyButton.TabIndex = 2;
            this.fuzzyButton.Text = "Fuzzier";
            this.fuzzyButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // restoreButton
            // 
            this.restoreButton.Location = new System.Drawing.Point(100, 600);
            this.restoreButton.Name = "fuzzyButton";
            this.restoreButton.Size = new System.Drawing.Size(56, 23);
            this.restoreButton.TabIndex = 3;
            this.restoreButton.Text = "Restore";
            this.restoreButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // pictureBox
            // 
            this.pictureHolder.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.pictureHolder.Location = new System.Drawing.Point(0, 0);
            this.pictureHolder.Name = "pictureBox2";
            this.pictureHolder.Size = new System.Drawing.Size(500, 500);
            this.pictureHolder.TabIndex = 0;
            this.pictureHolder.TabStop = false;
            // 
            // PictureBoxDemo
            // 
            this.Location = new System.Drawing.Point(0, 0);
            this.AutoScaleBaseSize = new System.Drawing.Size(5, 13);
            this.ClientSize = new System.Drawing.Size(500,650);
            this.Controls.Add(this.sharpenButton);
            this.Controls.Add(this.fuzzyButton);
            this.Controls.Add(this.restoreButton);
            this.Controls.Add(this.pictureHolder);
            this.Name = "PictureBoxDemo";
            this.Text = "PictureBoxDemo";
            ((System.ComponentModel.ISupportInitialize)(this.pictureHolder)).EndInit();
            this.ResumeLayout(false);

        }
        #endregion

        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.Run(new PictureBoxDemo());
        }
        /// <summary>
        /// Standard button events.
        /// Apply filter based on button pressed and update the new picture.
        /// </summary>

        private void button1_Click(object sender, System.EventArgs e)
        {
            bm = sharper.Apply(bm);
            pictureHolder.Image = bm;
        }
        private void button2_Click(object sender, System.EventArgs E)
        {

            bm = fuzzier.Apply(bm);
            pictureHolder.Image = bm;
        }
        private void button3_Click(object sender, System.EventArgs E)
        {

            bm = new Bitmap(Image.FromFile(path));
            pictureHolder.Image = bm;
        }
    }
}