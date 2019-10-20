using System;
using System.Drawing;
using System.Windows.Forms;

namespace path_finding_cs.initGUI {
    class InitGUI
    {
        const int BUTTONSIZEX = 10, BUTTONSIZEY = 10, TEN = 10, ZERO = 0, MAXX = 40, MAXY = 30;
        private Color white = Color.White;
        private MainForm mainForm;
        private Panel mainPanel;
        public InitGUI(MainForm p_mainForm) {
            this.mainForm = p_mainForm;

            setMainPanel();

            addAllButtons();
        }
        private void setMainPanel() {
            this.mainPanel = this.mainForm.panelMain;
        }
        private void addAllButtons() {
            for (int indexX = ZERO; indexX < MAXX; indexX++) {
                for (int indexY = ZERO; indexY < MAXY; indexY++) {
                    addButton(indexX * TEN, indexY * TEN);
                }
            }
        }
        private void addButton(int x, int y) {
            Button button = new Button() {
                Name = "buttonPanel" + (x / 10) + "_" + (y / 10),
                Location = new System.Drawing.Point(x, y),
                Size = new System.Drawing.Size(BUTTONSIZEX, BUTTONSIZEY),
                Margin = System.Windows.Forms.Padding.Empty,
                FlatStyle = FlatStyle.Popup,
                BackColor = white
            };
            addButtonToPanel(button);
        }
        private void addButtonToPanel(Button button) {
            this.mainPanel.Controls.Add(button);
        }
    }
}