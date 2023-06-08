namespace Lab2
{
    public partial class Form1 : Form
    {

        static Form1 form1;
        private delegate void lableUpdate(string Text);
        public Form1()
        {
            InitializeComponent();
            form1 = this;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            ThreadWrite threadWrite = new ThreadWrite();
            ThreadDelete threadDelete = new ThreadDelete();
            Thread write = new Thread(threadWrite.Start);
            Thread delete = new Thread(threadDelete.Start);
            write.Start();
            delete.Start();
        }

        public void changeColor(string box, bool status)
        {
            box = box.Trim();
            switch (box)
            {
                case "File1.txt":
                    if (status)
                    {
                        pictureBox1.BackColor = Color.LightGreen;
                        return;
                    }
                    pictureBox1.BackColor = Color.Red;
                    break;
                case "File2.txt":
                    if (status)
                    {
                        pictureBox2.BackColor = Color.LightGreen;
                        return;
                    }
                    pictureBox2.BackColor = Color.Red;
                    break;
                case "File3.txt":
                    if (status)
                    {
                        pictureBox3.BackColor = Color.LightGreen;
                        return;
                    }
                    pictureBox3.BackColor = Color.Red;
                    break;
            }
        }

        public void Label1(string input)
        {
            if (label3.InvokeRequired)
            {
                var d = new lableUpdate(Label1);
                label3.Invoke(d, input);
            }
            else
            {
                label3.Text = input;
            }

        }

        public void Label2(string input)
        {
            if (label4.InvokeRequired)
            {
                var d = new lableUpdate(Label2);
                label4.Invoke(d, input);
            }
            else
            {
                label4.Text = input;
            }
        }

        static public Form1 getForm()
        {
            if (form1 == null)
                form1 = new Form1();
            return form1;
        }
    }
}