using System;
using path_finding_cs.map;
using path_finding_cs.initGUI;
using System.Windows.Forms;
using System.Drawing;

namespace path_finding_cs.mapSetter {
        public class MapSetter {
        private const int WALL = 3, EMPTY = 0, STARTPOINT = 1, DESTPOINT = 2;
        private Color black = Color.Black;
        private Color white = Color.White;
        private Color green = Color.Green;
        private Color blue = Color.Blue;
        private Map map = new Map();
        private InitGUI initGUI;
        private MainForm mainForm;
        public MapSetter(MainForm p_mainForm) {
            this.mainForm = p_mainForm;
            this.initGUI = new InitGUI(this.mainForm);
            setAllButtonEvent();
            drawStartDest();
        }
        private void button_click(object sender, EventArgs e) {
            //Debug.WriteLine(((Button)sender).Name);
            Button button = ((Button)sender);

            string values = button.Name.Substring(11, button.Name.Length - 11);
            int x = Convert.ToInt32(values.Split('_')[0]);
            int y = Convert.ToInt32(values.Split('_')[1]);

            if (isEmpty(map.getElement(x, y)))
            {
                map.setElement(x, y, WALL);
                button.BackColor = black;
            }
            else if (isWall(map.getElement(x, y)))
            {
                map.setElement(x, y, EMPTY);
                button.BackColor = white;
            }
        }
        public void resetMap()
        {
            if (MessageBox.Show("Reset", "Reseter la map ?", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                int[] startPoint = this.map.getStartPoint(), destPoint = this.map.getDestPoint();
                Panel mainPanel = this.mainForm.panelMain;
                this.map.reset();
                foreach (Button button in mainPanel.Controls)
                {
                    string values = button.Name.Substring(11, button.Name.Length - 11);
                    int x = Convert.ToInt32(values.Split('_')[0]);
                    int y = Convert.ToInt32(values.Split('_')[1]);

                    if (x == startPoint[0] && y == startPoint[1])
                    {
                        button.BackColor = green;
                    }
                    else if (x == destPoint[0] && y == destPoint[1])
                    {
                        button.BackColor = blue;
                    }
                    else
                    {
                        button.BackColor = white;
                    }
                }
            }
        }
        private void drawStartDest()
        {
            int[] startPoint = this.map.getStartPoint(), destPoint = this.map.getDestPoint();

            Panel mainPanel = this.mainForm.panelMain;
            foreach (Button button in mainPanel.Controls)
            {
                string values = button.Name.Substring(11, button.Name.Length - 11);
                int x = Convert.ToInt32(values.Split('_')[0]);
                int y = Convert.ToInt32(values.Split('_')[1]);

                if (x == startPoint[0] && y == startPoint[1])
                {
                    button.BackColor = green;
                }
                else if (x == destPoint[0] && y == destPoint[1])
                {
                    button.BackColor = blue;
                }
            }
        }
        private void setAllButtonEvent()
        {
            Panel mainPanel = this.mainForm.panelMain;
            foreach (Button button in mainPanel.Controls)
            {
                // TODO :
                // add event on every button on the main panel
                // check what we can do on whatever is setted on the map from the button x y
                button.Click += new EventHandler(button_click);
            }
        }
        private bool isEmpty(int value)
        {
            if (value == EMPTY)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
        private bool isWall(int value)
        {
            if (value == WALL)
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}