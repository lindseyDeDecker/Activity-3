/*Lindsey DeDecker
 * CST-150
 * Activity 3
 * 7.18.24
 */


namespace CST_150_Activity_3._1
{
    public partial class FrmMain : Form
    {
        public FrmMain()
        {
            InitializeComponent();
            //Set the properties for the selectFileDialog control
            //Define the initial directory that is hsown
            selectFileDialog.InitialDirectory = Application.StartupPath + @"Data";
            //Set the title of open file dialog
            selectFileDialog.Title = "Browse Txt Files";
            //DefaultExt is only used when "All Files" is selected
            //from the filter box and no extentsion is sepecified by the user
            selectFileDialog.DefaultExt = "Txt";
            selectFileDialog.Filter = "Text Files (*.txt)|*.txt|All Files (*.*)|*.*";

            //When the form is initialized make sure the lblResults and lblSelectedFile are not visible
            lblResults.Visible = false;
            lblSelectedFile.Visible = false;
        }
        private void button1_Click(object sender, EventArgs e)
        {

        }
        private void lblSelectedFile_Click(object sender, EventArgs e)
        {

        }

        private void BtnReadFileClickEvent(object sender, EventArgs e)
        {
            //Declare and initialzie variables
            string txtFile = "";
            string dirLocation = "";
            const int PadSpace = 20;
            string header1 = "Type", header2 = "Color", header3 = "Qty";
            string headerLine1 ="----", headerLine2 = "----", headerLine3 = "----";

            //Once the button is clicked - show file dialog
            if (this.selectFileDialog.ShowDialog() == DialogResult.OK)
            {
                //Read in the text file that was selected
                txtFile = this.selectFileDialog.FileName;
                //Get the path of the file plus the filename
                dirLocation = Path.GetFullPath(selectFileDialog.FileName);
                //show the selcted file and path in the label
                lblSelectedFile.Text = txtFile;
                //Make sure to make this label visible
                lblSelectedFile.Visible = true;

            }

            //Read all the lines into a one dimentional string array
            string[] lines = File.ReadAllLines(txtFile);

            //Populate a lable with the array and make sure the label is cleared out before we start
            lblResults.Text = "";
            foreach(string line in lines)
            {
                //Split each line into an array of elements
                string[] inventoryList = line.Split(", ");
                //Iterate through each element in the array using a for loop
                for(int i = 0; i < inventoryList.Length; i++)
                {
                    //display each element usign proper spacing
                    lblResults.Text += inventoryList[i].PadRight(PadSpace);
                }
                //Meed a new line after each iteration to show next line
                lblResults.Text += "\n";


            }

            //Make sure the label is visible 
            lblResults.Visible = true;
        }
    }
}
