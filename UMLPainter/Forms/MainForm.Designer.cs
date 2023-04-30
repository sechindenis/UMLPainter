namespace UMLPainter
{
    partial class MainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.buttonInheritance = new System.Windows.Forms.Button();
            this.buttonImplemetation = new System.Windows.Forms.Button();
            this.buttonAssociation = new System.Windows.Forms.Button();
            this.buttonComposition = new System.Windows.Forms.Button();
            this.buttonAggregation = new System.Windows.Forms.Button();
            this.buttonClass = new System.Windows.Forms.Button();
            this.buttonClearAll = new System.Windows.Forms.Button();
            this.trackBarLineWidth = new System.Windows.Forms.TrackBar();
            this.buttonColor = new System.Windows.Forms.Button();
            this.colorDialog1 = new System.Windows.Forms.ColorDialog();
            this.pictureBoxMain = new System.Windows.Forms.PictureBox();
            this.labelLineWidth = new System.Windows.Forms.Label();
            this.textBoxAddToClass = new System.Windows.Forms.TextBox();
            this.groupBoxAddingInfoToClass = new System.Windows.Forms.GroupBox();
            this.colorIndicator = new System.Windows.Forms.PictureBox();
            this.buttonMovingMode = new System.Windows.Forms.Button();
            this.buttonSelectionMode = new System.Windows.Forms.Button();
            this.buttonDeleteFromClass = new System.Windows.Forms.Button();
            this.buttonAddToClass = new System.Windows.Forms.Button();
            this.labelTest = new System.Windows.Forms.Label();
            this.buttonHelp = new System.Windows.Forms.Button();
            this.buttonSave = new System.Windows.Forms.Button();
            this.saveFileDialog = new System.Windows.Forms.SaveFileDialog();
            this.buttonOpen = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.buttonEnum = new System.Windows.Forms.Button();
            this.buttonInterface = new System.Windows.Forms.Button();
            this.labelType = new System.Windows.Forms.Label();
            this.labelConnection = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLineWidth)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).BeginInit();
            this.groupBoxAddingInfoToClass.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorIndicator)).BeginInit();
            this.SuspendLayout();
            // 
            // buttonInheritance
            // 
            this.buttonInheritance.Location = new System.Drawing.Point(21, 264);
            this.buttonInheritance.Margin = new System.Windows.Forms.Padding(5);
            this.buttonInheritance.Name = "buttonInheritance";
            this.buttonInheritance.Size = new System.Drawing.Size(150, 40);
            this.buttonInheritance.TabIndex = 1;
            this.buttonInheritance.Text = "Inheritance";
            this.buttonInheritance.UseVisualStyleBackColor = true;
            this.buttonInheritance.Click += new System.EventHandler(this.buttonInheritance_Click);
            // 
            // buttonImplemetation
            // 
            this.buttonImplemetation.Location = new System.Drawing.Point(21, 214);
            this.buttonImplemetation.Margin = new System.Windows.Forms.Padding(5);
            this.buttonImplemetation.Name = "buttonImplemetation";
            this.buttonImplemetation.Size = new System.Drawing.Size(150, 40);
            this.buttonImplemetation.TabIndex = 2;
            this.buttonImplemetation.Text = "Implemetation";
            this.buttonImplemetation.UseVisualStyleBackColor = true;
            this.buttonImplemetation.Click += new System.EventHandler(this.buttonImplemetation_Click);
            // 
            // buttonAssociation
            // 
            this.buttonAssociation.Location = new System.Drawing.Point(21, 114);
            this.buttonAssociation.Margin = new System.Windows.Forms.Padding(5);
            this.buttonAssociation.Name = "buttonAssociation";
            this.buttonAssociation.Size = new System.Drawing.Size(150, 40);
            this.buttonAssociation.TabIndex = 3;
            this.buttonAssociation.Text = "Association";
            this.buttonAssociation.UseVisualStyleBackColor = true;
            this.buttonAssociation.Click += new System.EventHandler(this.buttonAssociation_Click);
            // 
            // buttonComposition
            // 
            this.buttonComposition.Location = new System.Drawing.Point(21, 164);
            this.buttonComposition.Margin = new System.Windows.Forms.Padding(5);
            this.buttonComposition.Name = "buttonComposition";
            this.buttonComposition.Size = new System.Drawing.Size(150, 40);
            this.buttonComposition.TabIndex = 4;
            this.buttonComposition.Text = "Composition";
            this.buttonComposition.UseVisualStyleBackColor = true;
            this.buttonComposition.Click += new System.EventHandler(this.buttonComposition_Click);
            // 
            // buttonAggregation
            // 
            this.buttonAggregation.Location = new System.Drawing.Point(21, 64);
            this.buttonAggregation.Margin = new System.Windows.Forms.Padding(5);
            this.buttonAggregation.Name = "buttonAggregation";
            this.buttonAggregation.Size = new System.Drawing.Size(150, 40);
            this.buttonAggregation.TabIndex = 5;
            this.buttonAggregation.Text = "Aggregation";
            this.buttonAggregation.UseVisualStyleBackColor = true;
            this.buttonAggregation.Click += new System.EventHandler(this.buttonAggregation_Click);
            // 
            // buttonClass
            // 
            this.buttonClass.Location = new System.Drawing.Point(21, 362);
            this.buttonClass.Margin = new System.Windows.Forms.Padding(5);
            this.buttonClass.Name = "buttonClass";
            this.buttonClass.Size = new System.Drawing.Size(150, 40);
            this.buttonClass.TabIndex = 6;
            this.buttonClass.Text = "Class";
            this.buttonClass.UseVisualStyleBackColor = true;
            this.buttonClass.Click += new System.EventHandler(this.buttonClass_Click);
            // 
            // buttonClearAll
            // 
            this.buttonClearAll.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.buttonClearAll.Location = new System.Drawing.Point(23, 857);
            this.buttonClearAll.Margin = new System.Windows.Forms.Padding(10);
            this.buttonClearAll.Name = "buttonClearAll";
            this.buttonClearAll.Size = new System.Drawing.Size(150, 40);
            this.buttonClearAll.TabIndex = 7;
            this.buttonClearAll.Text = "Clear All";
            this.buttonClearAll.UseVisualStyleBackColor = true;
            this.buttonClearAll.Click += new System.EventHandler(this.buttonClearAll_Click);
            // 
            // trackBarLineWidth
            // 
            this.trackBarLineWidth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.trackBarLineWidth.LargeChange = 1;
            this.trackBarLineWidth.Location = new System.Drawing.Point(23, 640);
            this.trackBarLineWidth.Maximum = 5;
            this.trackBarLineWidth.Minimum = 1;
            this.trackBarLineWidth.Name = "trackBarLineWidth";
            this.trackBarLineWidth.Size = new System.Drawing.Size(148, 56);
            this.trackBarLineWidth.TabIndex = 8;
            this.trackBarLineWidth.Tag = "";
            this.trackBarLineWidth.Value = 1;
            this.trackBarLineWidth.Scroll += new System.EventHandler(this.trackBarLineWidth_Scroll);
            // 
            // buttonColor
            // 
            this.buttonColor.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.buttonColor.Location = new System.Drawing.Point(23, 696);
            this.buttonColor.Name = "buttonColor";
            this.buttonColor.Size = new System.Drawing.Size(108, 40);
            this.buttonColor.TabIndex = 13;
            this.buttonColor.Text = "Color";
            this.buttonColor.UseVisualStyleBackColor = true;
            this.buttonColor.Click += new System.EventHandler(this.buttonColor_Click);
            // 
            // pictureBoxMain
            // 
            this.pictureBoxMain.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBoxMain.Location = new System.Drawing.Point(179, 54);
            this.pictureBoxMain.MaximumSize = new System.Drawing.Size(10000, 10000);
            this.pictureBoxMain.Name = "pictureBoxMain";
            this.pictureBoxMain.Size = new System.Drawing.Size(1184, 843);
            this.pictureBoxMain.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBoxMain.TabIndex = 0;
            this.pictureBoxMain.TabStop = false;
            this.pictureBoxMain.SizeChanged += new System.EventHandler(this.pictureBoxMain_SizeChanged);
            this.pictureBoxMain.MouseClick += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseClick);
            this.pictureBoxMain.MouseMove += new System.Windows.Forms.MouseEventHandler(this.pictureBoxMain_MouseMove);
            // 
            // labelLineWidth
            // 
            this.labelLineWidth.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.labelLineWidth.AutoSize = true;
            this.labelLineWidth.Font = new System.Drawing.Font("Segoe UI", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelLineWidth.Location = new System.Drawing.Point(45, 612);
            this.labelLineWidth.Name = "labelLineWidth";
            this.labelLineWidth.Size = new System.Drawing.Size(100, 25);
            this.labelLineWidth.TabIndex = 15;
            this.labelLineWidth.Text = "Line width";
            // 
            // textBoxAddToClass
            // 
            this.textBoxAddToClass.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.textBoxAddToClass.Location = new System.Drawing.Point(6, 18);
            this.textBoxAddToClass.Name = "textBoxAddToClass";
            this.textBoxAddToClass.Size = new System.Drawing.Size(288, 27);
            this.textBoxAddToClass.TabIndex = 16;
            this.textBoxAddToClass.TextChanged += new System.EventHandler(this.textBoxAddToClass_TextChanged);
            // 
            // groupBoxAddingInfoToClass
            // 
            this.groupBoxAddingInfoToClass.BackColor = System.Drawing.SystemColors.Control;
            this.groupBoxAddingInfoToClass.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.groupBoxAddingInfoToClass.Controls.Add(this.textBoxAddToClass);
            this.groupBoxAddingInfoToClass.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.groupBoxAddingInfoToClass.Location = new System.Drawing.Point(191, 202);
            this.groupBoxAddingInfoToClass.Name = "groupBoxAddingInfoToClass";
            this.groupBoxAddingInfoToClass.Size = new System.Drawing.Size(302, 52);
            this.groupBoxAddingInfoToClass.TabIndex = 17;
            this.groupBoxAddingInfoToClass.TabStop = false;
            this.groupBoxAddingInfoToClass.Visible = false;
            // 
            // colorIndicator
            // 
            this.colorIndicator.Anchor = System.Windows.Forms.AnchorStyles.Left;
            this.colorIndicator.BackColor = System.Drawing.SystemColors.Control;
            this.colorIndicator.Location = new System.Drawing.Point(137, 698);
            this.colorIndicator.Name = "colorIndicator";
            this.colorIndicator.Size = new System.Drawing.Size(34, 36);
            this.colorIndicator.TabIndex = 21;
            this.colorIndicator.TabStop = false;
            // 
            // buttonMovingMode
            // 
            this.buttonMovingMode.Location = new System.Drawing.Point(732, 6);
            this.buttonMovingMode.Name = "buttonMovingMode";
            this.buttonMovingMode.Size = new System.Drawing.Size(150, 40);
            this.buttonMovingMode.TabIndex = 22;
            this.buttonMovingMode.Text = "Moving Mode";
            this.buttonMovingMode.UseVisualStyleBackColor = true;
            this.buttonMovingMode.Click += new System.EventHandler(this.buttonMovingMode_Click);
            // 
            // buttonSelectionMode
            // 
            this.buttonSelectionMode.BackColor = System.Drawing.Color.Red;
            this.buttonSelectionMode.FlatAppearance.BorderColor = System.Drawing.SystemColors.HotTrack;
            this.buttonSelectionMode.FlatStyle = System.Windows.Forms.FlatStyle.System;
            this.buttonSelectionMode.ForeColor = System.Drawing.SystemColors.Window;
            this.buttonSelectionMode.Location = new System.Drawing.Point(566, 6);
            this.buttonSelectionMode.Name = "buttonSelectionMode";
            this.buttonSelectionMode.Size = new System.Drawing.Size(150, 40);
            this.buttonSelectionMode.TabIndex = 23;
            this.buttonSelectionMode.Text = "Selection Mode";
            this.buttonSelectionMode.UseVisualStyleBackColor = false;
            this.buttonSelectionMode.Click += new System.EventHandler(this.buttonSelectionMode_Click);
            // 
            // buttonDeleteFromClass
            // 
            this.buttonDeleteFromClass.Font = new System.Drawing.Font("Segoe UI", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonDeleteFromClass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonDeleteFromClass.Location = new System.Drawing.Point(191, 64);
            this.buttonDeleteFromClass.Name = "buttonDeleteFromClass";
            this.buttonDeleteFromClass.Size = new System.Drawing.Size(247, 57);
            this.buttonDeleteFromClass.TabIndex = 25;
            this.buttonDeleteFromClass.Text = "Delete";
            this.buttonDeleteFromClass.UseMnemonic = false;
            this.buttonDeleteFromClass.UseVisualStyleBackColor = true;
            this.buttonDeleteFromClass.Visible = false;
            this.buttonDeleteFromClass.Click += new System.EventHandler(this.buttonDeleteFromClass_Click);
            // 
            // buttonAddToClass
            // 
            this.buttonAddToClass.Font = new System.Drawing.Font("Segoe UI", 7.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point);
            this.buttonAddToClass.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonAddToClass.Location = new System.Drawing.Point(191, 127);
            this.buttonAddToClass.Name = "buttonAddToClass";
            this.buttonAddToClass.Size = new System.Drawing.Size(247, 57);
            this.buttonAddToClass.TabIndex = 26;
            this.buttonAddToClass.Text = "Add";
            this.buttonAddToClass.UseVisualStyleBackColor = true;
            this.buttonAddToClass.Visible = false;
            this.buttonAddToClass.Click += new System.EventHandler(this.buttonAddToClass_Click);
            // 
            // labelTest
            // 
            this.labelTest.AutoSize = true;
            this.labelTest.Location = new System.Drawing.Point(422, 6);
            this.labelTest.Name = "labelTest";
            this.labelTest.Size = new System.Drawing.Size(0, 20);
            this.labelTest.TabIndex = 28;
            // 
            // buttonHelp
            // 
            this.buttonHelp.Location = new System.Drawing.Point(393, 6);
            this.buttonHelp.Name = "buttonHelp";
            this.buttonHelp.Size = new System.Drawing.Size(100, 40);
            this.buttonHelp.TabIndex = 29;
            this.buttonHelp.Text = "Help";
            this.buttonHelp.Click += new System.EventHandler(this.buttonHelp_Click);
            // 
            // buttonSave
            // 
            this.buttonSave.Location = new System.Drawing.Point(285, 6);
            this.buttonSave.Name = "buttonSave";
            this.buttonSave.Size = new System.Drawing.Size(100, 40);
            this.buttonSave.TabIndex = 30;
            this.buttonSave.Text = "Save";
            this.buttonSave.Click += new System.EventHandler(this.buttonSave_Click);
            // 
            // saveFileDialog
            // 
            this.saveFileDialog.Filter = "UML-Project (*.up)|*.up|Text files (*.txt)|*.txt|All files (*.*)|*.*\" ";
            // 
            // buttonOpen
            // 
            this.buttonOpen.Location = new System.Drawing.Point(179, 6);
            this.buttonOpen.Name = "buttonOpen";
            this.buttonOpen.Size = new System.Drawing.Size(100, 40);
            this.buttonOpen.TabIndex = 31;
            this.buttonOpen.Text = "Open";
            this.buttonOpen.Click += new System.EventHandler(this.buttonOpen_Click);
            // 
            // buttonEnum
            // 
            this.buttonEnum.Location = new System.Drawing.Point(21, 462);
            this.buttonEnum.Margin = new System.Windows.Forms.Padding(5);
            this.buttonEnum.Name = "buttonEnum";
            this.buttonEnum.Size = new System.Drawing.Size(150, 40);
            this.buttonEnum.TabIndex = 32;
            this.buttonEnum.Text = "Enum";
            this.buttonEnum.UseVisualStyleBackColor = true;
            this.buttonEnum.Click += new System.EventHandler(this.buttonEnum_Click);
            // 
            // buttonInterface
            // 
            this.buttonInterface.Location = new System.Drawing.Point(21, 412);
            this.buttonInterface.Margin = new System.Windows.Forms.Padding(5);
            this.buttonInterface.Name = "buttonInterface";
            this.buttonInterface.Size = new System.Drawing.Size(150, 40);
            this.buttonInterface.TabIndex = 33;
            this.buttonInterface.Text = "Interface";
            this.buttonInterface.UseVisualStyleBackColor = true;
            this.buttonInterface.Click += new System.EventHandler(this.buttonInterface_Click);
            // 
            // labelType
            // 
            this.labelType.AutoSize = true;
            this.labelType.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelType.Location = new System.Drawing.Point(23, 329);
            this.labelType.Name = "labelType";
            this.labelType.Size = new System.Drawing.Size(122, 28);
            this.labelType.TabIndex = 34;
            this.labelType.Text = "Data model";
            // 
            // labelConnection
            // 
            this.labelConnection.AutoSize = true;
            this.labelConnection.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.labelConnection.Location = new System.Drawing.Point(23, 31);
            this.labelConnection.Name = "labelConnection";
            this.labelConnection.Size = new System.Drawing.Size(119, 28);
            this.labelConnection.TabIndex = 35;
            this.labelConnection.Text = "Connection";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1388, 923);
            this.Controls.Add(this.labelConnection);
            this.Controls.Add(this.labelType);
            this.Controls.Add(this.buttonInterface);
            this.Controls.Add(this.buttonEnum);
            this.Controls.Add(this.buttonOpen);
            this.Controls.Add(this.buttonSave);
            this.Controls.Add(this.labelTest);
            this.Controls.Add(this.buttonAddToClass);
            this.Controls.Add(this.buttonDeleteFromClass);
            this.Controls.Add(this.buttonSelectionMode);
            this.Controls.Add(this.buttonMovingMode);
            this.Controls.Add(this.colorIndicator);
            this.Controls.Add(this.groupBoxAddingInfoToClass);
            this.Controls.Add(this.labelLineWidth);
            this.Controls.Add(this.buttonColor);
            this.Controls.Add(this.trackBarLineWidth);
            this.Controls.Add(this.buttonClearAll);
            this.Controls.Add(this.buttonClass);
            this.Controls.Add(this.buttonAggregation);
            this.Controls.Add(this.buttonComposition);
            this.Controls.Add(this.buttonAssociation);
            this.Controls.Add(this.buttonImplemetation);
            this.Controls.Add(this.buttonInheritance);
            this.Controls.Add(this.pictureBoxMain);
            this.Controls.Add(this.buttonHelp);
            this.KeyPreview = true;
            this.MinimumSize = new System.Drawing.Size(1406, 970);
            this.Name = "MainForm";
            this.Text = "UML-Painter";
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.KeyDown += new System.Windows.Forms.KeyEventHandler(this.KeyDown_Control);
            ((System.ComponentModel.ISupportInitialize)(this.trackBarLineWidth)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBoxMain)).EndInit();
            this.groupBoxAddingInfoToClass.ResumeLayout(false);
            this.groupBoxAddingInfoToClass.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.colorIndicator)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        public Button buttonInheritance;
        public Button buttonImplemetation;
        public Button buttonAssociation;
        public Button buttonComposition;
        public Button buttonAggregation;
        public Button buttonClass;
        public Button buttonClearAll;
        public TrackBar trackBarLineWidth;
        public Button buttonColor;
        public ColorDialog colorDialog1;
        public PictureBox pictureBoxMain;
        public Label labelLineWidth;
        public TextBox textBoxAddToClass;
        public GroupBox groupBoxAddingInfoToClass;
        public PictureBox colorIndicator;
        public Button buttonMovingMode;
        public Button buttonSelectionMode;
        public Button buttonDeleteFromClass;
        public Button buttonAddToClass;
        public Label labelTest;
        public Button buttonHelp;
        public Button buttonSave;
        public SaveFileDialog saveFileDialog;
        public Button buttonOpen;
        public OpenFileDialog openFileDialog;
        public Button buttonEnum;
        public Button buttonInterface;
        public Label labelType;
        public Label labelConnection;
    }
}