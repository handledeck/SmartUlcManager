namespace ZtpManager
{
  partial class CatLightPlanForm
  {
    /// <summary>
    /// Required designer variable.
    /// </summary>
    private System.ComponentModel.IContainer components = null;

    /// <summary>
    /// Clean up any resources being used.
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
    /// Required method for Designer support - do not modify
    /// the contents of this method with the code editor.
    /// </summary>
    private void InitializeComponent()
    {
      this.components = new System.ComponentModel.Container();
      System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(CatLightPlanForm));
      Ztp.Configuration.ZtpLight ztpLight1 = new Ztp.Configuration.ZtpLight();
      Ztp.Configuration.ZtpScheduler ztpScheduler1 = new Ztp.Configuration.ZtpScheduler();
      Ztp.Ui.LocationEditorControl.ZtpLocation ztpLocation1 = new Ztp.Ui.LocationEditorControl.ZtpLocation();
      this.ribbon = new System.Windows.Forms.Ribbon();
      this.ribbonTab = new System.Windows.Forms.RibbonTab();
      this.rpPlan = new System.Windows.Forms.RibbonPanel();
      this.rbAddPlan = new System.Windows.Forms.RibbonButton();
      this.rbDeletePlan = new System.Windows.Forms.RibbonButton();
      this.rbEditPlan = new System.Windows.Forms.RibbonButton();
      this.rpSeason = new System.Windows.Forms.RibbonPanel();
      this.rbAddSeason = new System.Windows.Forms.RibbonButton();
      this.rbDeleteSeason = new System.Windows.Forms.RibbonButton();
      this.rbEditSeason = new System.Windows.Forms.RibbonButton();
      this.rpSchedule = new System.Windows.Forms.RibbonPanel();
      this.rbAddSchedule = new System.Windows.Forms.RibbonButton();
      this.rbDeleteSchedule = new System.Windows.Forms.RibbonButton();
      this.rbEditSchedule = new System.Windows.Forms.RibbonButton();
      this.rpViewScheduler = new System.Windows.Forms.RibbonPanel();
      this.rbViewScheduler = new System.Windows.Forms.RibbonButton();
      this.tableLayoutPanel = new System.Windows.Forms.TableLayoutPanel();
      this.lvPlan = new System.Windows.Forms.ListView();
      this.columnHeader1 = ((System.Windows.Forms.ColumnHeader)(new System.Windows.Forms.ColumnHeader()));
      this.iml = new System.Windows.Forms.ImageList(this.components);
      this.lightPlanEditor = new Ztp.Ui.LightPlanEditorControl();
      this.tableLayoutPanel.SuspendLayout();
      this.SuspendLayout();
      // 
      // ribbon
      // 
      this.ribbon.CaptionBarVisible = false;
      this.ribbon.Font = new System.Drawing.Font("Segoe UI", 9F);
      this.ribbon.Location = new System.Drawing.Point(0, 0);
      this.ribbon.Minimized = false;
      this.ribbon.Name = "ribbon";
      // 
      // 
      // 
      this.ribbon.OrbDropDown.BorderRoundness = 8;
      this.ribbon.OrbDropDown.Location = new System.Drawing.Point(0, 0);
      this.ribbon.OrbDropDown.Name = "";
      this.ribbon.OrbDropDown.Size = new System.Drawing.Size(527, 447);
      this.ribbon.OrbDropDown.TabIndex = 0;
      this.ribbon.OrbDropDown.Visible = false;
      this.ribbon.OrbImage = null;
      this.ribbon.OrbStyle = System.Windows.Forms.RibbonOrbStyle.Office_2013;
      this.ribbon.OrbVisible = false;
      this.ribbon.RibbonTabFont = new System.Drawing.Font("Trebuchet MS", 9F);
      this.ribbon.Size = new System.Drawing.Size(802, 128);
      this.ribbon.TabIndex = 0;
      this.ribbon.Tabs.Add(this.ribbonTab);
      this.ribbon.TabsMargin = new System.Windows.Forms.Padding(12, 2, 20, 0);
      this.ribbon.Text = "ribbon1";
      this.ribbon.ThemeColor = System.Windows.Forms.RibbonTheme.Blue;
      // 
      // ribbonTab
      // 
      this.ribbonTab.Panels.Add(this.rpPlan);
      this.ribbonTab.Panels.Add(this.rpSeason);
      this.ribbonTab.Panels.Add(this.rpSchedule);
      this.ribbonTab.Panels.Add(this.rpViewScheduler);
      this.ribbonTab.Text = "РАСПИСАНИЯ";
      // 
      // rpPlan
      // 
      this.rpPlan.ButtonMoreEnabled = false;
      this.rpPlan.ButtonMoreVisible = false;
      this.rpPlan.Items.Add(this.rbAddPlan);
      this.rpPlan.Items.Add(this.rbDeletePlan);
      this.rpPlan.Items.Add(this.rbEditPlan);
      this.rpPlan.Text = "План";
      // 
      // rbAddPlan
      // 
      this.rbAddPlan.Image = ((System.Drawing.Image)(resources.GetObject("rbAddPlan.Image")));
      this.rbAddPlan.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbAddPlan.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbAddPlan.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbAddPlan.SmallImage")));
      this.rbAddPlan.Text = "Добавить план";
      this.rbAddPlan.Click += new System.EventHandler(this.rbAddPlan_Click);
      // 
      // rbDeletePlan
      // 
      this.rbDeletePlan.Image = ((System.Drawing.Image)(resources.GetObject("rbDeletePlan.Image")));
      this.rbDeletePlan.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbDeletePlan.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbDeletePlan.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbDeletePlan.SmallImage")));
      this.rbDeletePlan.Text = "Удалить план";
      this.rbDeletePlan.Click += new System.EventHandler(this.rbDeletePlan_Click);
      // 
      // rbEditPlan
      // 
      this.rbEditPlan.Image = ((System.Drawing.Image)(resources.GetObject("rbEditPlan.Image")));
      this.rbEditPlan.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbEditPlan.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbEditPlan.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbEditPlan.SmallImage")));
      this.rbEditPlan.Text = "Изменить план";
      this.rbEditPlan.Click += new System.EventHandler(this.rbEditPlan_Click);
      // 
      // rpSeason
      // 
      this.rpSeason.ButtonMoreEnabled = false;
      this.rpSeason.ButtonMoreVisible = false;
      this.rpSeason.Items.Add(this.rbAddSeason);
      this.rpSeason.Items.Add(this.rbDeleteSeason);
      this.rpSeason.Items.Add(this.rbEditSeason);
      this.rpSeason.Text = "Сезон";
      // 
      // rbAddSeason
      // 
      this.rbAddSeason.Image = ((System.Drawing.Image)(resources.GetObject("rbAddSeason.Image")));
      this.rbAddSeason.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbAddSeason.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbAddSeason.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbAddSeason.SmallImage")));
      this.rbAddSeason.Text = "Добавить сезон";
      this.rbAddSeason.Click += new System.EventHandler(this.rbAddSeason_Click);
      // 
      // rbDeleteSeason
      // 
      this.rbDeleteSeason.Image = ((System.Drawing.Image)(resources.GetObject("rbDeleteSeason.Image")));
      this.rbDeleteSeason.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbDeleteSeason.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbDeleteSeason.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbDeleteSeason.SmallImage")));
      this.rbDeleteSeason.Text = "Удалить сезон";
      this.rbDeleteSeason.Click += new System.EventHandler(this.rbDeleteSeason_Click);
      // 
      // rbEditSeason
      // 
      this.rbEditSeason.Image = ((System.Drawing.Image)(resources.GetObject("rbEditSeason.Image")));
      this.rbEditSeason.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbEditSeason.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbEditSeason.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbEditSeason.SmallImage")));
      this.rbEditSeason.Text = "Изменить сезон";
      this.rbEditSeason.Click += new System.EventHandler(this.rbEditSeason_Click);
      // 
      // rpSchedule
      // 
      this.rpSchedule.ButtonMoreEnabled = false;
      this.rpSchedule.ButtonMoreVisible = false;
      this.rpSchedule.Items.Add(this.rbAddSchedule);
      this.rpSchedule.Items.Add(this.rbDeleteSchedule);
      this.rpSchedule.Items.Add(this.rbEditSchedule);
      this.rpSchedule.Text = "Расписание";
      // 
      // rbAddSchedule
      // 
      this.rbAddSchedule.Image = ((System.Drawing.Image)(resources.GetObject("rbAddSchedule.Image")));
      this.rbAddSchedule.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbAddSchedule.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbAddSchedule.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbAddSchedule.SmallImage")));
      this.rbAddSchedule.Text = "Добавить расписание";
      this.rbAddSchedule.Click += new System.EventHandler(this.rbAddSchedule_Click);
      // 
      // rbDeleteSchedule
      // 
      this.rbDeleteSchedule.Image = ((System.Drawing.Image)(resources.GetObject("rbDeleteSchedule.Image")));
      this.rbDeleteSchedule.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbDeleteSchedule.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbDeleteSchedule.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbDeleteSchedule.SmallImage")));
      this.rbDeleteSchedule.Text = "Удалить расписание";
      this.rbDeleteSchedule.Click += new System.EventHandler(this.rbDeleteSchedule_Click);
      // 
      // rbEditSchedule
      // 
      this.rbEditSchedule.Image = ((System.Drawing.Image)(resources.GetObject("rbEditSchedule.Image")));
      this.rbEditSchedule.MaxSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbEditSchedule.MinSizeMode = System.Windows.Forms.RibbonElementSizeMode.Medium;
      this.rbEditSchedule.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbEditSchedule.SmallImage")));
      this.rbEditSchedule.Text = "Изменить расписание";
      this.rbEditSchedule.Click += new System.EventHandler(this.rbEditSchedule_Click);
      // 
      // rpViewScheduler
      // 
      this.rpViewScheduler.ButtonMoreEnabled = false;
      this.rpViewScheduler.ButtonMoreVisible = false;
      this.rpViewScheduler.Items.Add(this.rbViewScheduler);
      this.rpViewScheduler.Text = "";
      // 
      // rbViewScheduler
      // 
      this.rbViewScheduler.Image = ((System.Drawing.Image)(resources.GetObject("rbViewScheduler.Image")));
      this.rbViewScheduler.SmallImage = ((System.Drawing.Image)(resources.GetObject("rbViewScheduler.SmallImage")));
      this.rbViewScheduler.Text = "Просмотр";
      this.rbViewScheduler.Click += new System.EventHandler(this.rbViewScheduler_Click);
      // 
      // tableLayoutPanel
      // 
      this.tableLayoutPanel.ColumnCount = 2;
      this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 40F));
      this.tableLayoutPanel.ColumnStyles.Add(new System.Windows.Forms.ColumnStyle(System.Windows.Forms.SizeType.Percent, 60F));
      this.tableLayoutPanel.Controls.Add(this.lvPlan, 0, 0);
      this.tableLayoutPanel.Controls.Add(this.lightPlanEditor, 1, 0);
      this.tableLayoutPanel.Dock = System.Windows.Forms.DockStyle.Fill;
      this.tableLayoutPanel.Location = new System.Drawing.Point(0, 128);
      this.tableLayoutPanel.Name = "tableLayoutPanel";
      this.tableLayoutPanel.RowCount = 1;
      this.tableLayoutPanel.RowStyles.Add(new System.Windows.Forms.RowStyle(System.Windows.Forms.SizeType.Percent, 100F));
      this.tableLayoutPanel.Size = new System.Drawing.Size(802, 433);
      this.tableLayoutPanel.TabIndex = 1;
      // 
      // lvPlan
      // 
      this.lvPlan.Columns.AddRange(new System.Windows.Forms.ColumnHeader[] {
            this.columnHeader1});
      this.lvPlan.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lvPlan.FullRowSelect = true;
      this.lvPlan.GridLines = true;
      this.lvPlan.HideSelection = false;
      this.lvPlan.Location = new System.Drawing.Point(3, 3);
      this.lvPlan.MultiSelect = false;
      this.lvPlan.Name = "lvPlan";
      this.lvPlan.Size = new System.Drawing.Size(314, 427);
      this.lvPlan.SmallImageList = this.iml;
      this.lvPlan.TabIndex = 0;
      this.lvPlan.UseCompatibleStateImageBehavior = false;
      this.lvPlan.View = System.Windows.Forms.View.Details;
      this.lvPlan.SelectedIndexChanged += new System.EventHandler(this.lvPlan_SelectedIndexChanged);
      // 
      // columnHeader1
      // 
      this.columnHeader1.Text = "План";
      this.columnHeader1.Width = 300;
      // 
      // iml
      // 
      this.iml.ImageStream = ((System.Windows.Forms.ImageListStreamer)(resources.GetObject("iml.ImageStream")));
      this.iml.TransparentColor = System.Drawing.Color.Transparent;
      this.iml.Images.SetKeyName(0, "clock.png");
      // 
      // lightPlanEditor
      // 
      this.lightPlanEditor.Dock = System.Windows.Forms.DockStyle.Fill;
      this.lightPlanEditor.Location = new System.Drawing.Point(323, 3);
      this.lightPlanEditor.Name = "lightPlanEditor";
      this.lightPlanEditor.Size = new System.Drawing.Size(476, 427);
      this.lightPlanEditor.TabIndex = 1;
      this.lightPlanEditor.UseSchedulerVisible = false;
      ztpLight1.Scheduler = ztpScheduler1;
      ztpLight1.UseScheduler = false;
      this.lightPlanEditor.Value = ztpLight1;
      ztpLocation1.Latitude = 0F;
      ztpLocation1.Longitude = 0F;
      ztpLocation1.TimeZone = ((sbyte)(0));
      this.lightPlanEditor.ZtpLocation = ztpLocation1;
      // 
      // CatLightPlanForm
      // 
      this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
      this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
      this.ClientSize = new System.Drawing.Size(802, 561);
      this.Controls.Add(this.tableLayoutPanel);
      this.Controls.Add(this.ribbon);
      this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
      this.MinimizeBox = false;
      this.MinimumSize = new System.Drawing.Size(800, 600);
      this.Name = "CatLightPlanForm";
      this.ShowInTaskbar = false;
      this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
      this.Text = "Справочник планов освещения";
      this.tableLayoutPanel.ResumeLayout(false);
      this.ResumeLayout(false);

    }

    #endregion

    private System.Windows.Forms.Ribbon ribbon;
    private System.Windows.Forms.RibbonTab ribbonTab;
    private System.Windows.Forms.RibbonPanel rpSeason;
    private System.Windows.Forms.RibbonButton rbAddSeason;
    private System.Windows.Forms.RibbonButton rbDeleteSeason;
    private System.Windows.Forms.RibbonButton rbEditSeason;
    private System.Windows.Forms.RibbonPanel rpSchedule;
    private System.Windows.Forms.RibbonButton rbAddSchedule;
    private System.Windows.Forms.RibbonButton rbDeleteSchedule;
    private System.Windows.Forms.RibbonButton rbEditSchedule;
    private System.Windows.Forms.RibbonPanel rpViewScheduler;
    private System.Windows.Forms.RibbonButton rbViewScheduler;
    private System.Windows.Forms.RibbonPanel rpPlan;
    private System.Windows.Forms.TableLayoutPanel tableLayoutPanel;
    private System.Windows.Forms.RibbonButton rbAddPlan;
    private System.Windows.Forms.RibbonButton rbDeletePlan;
    private System.Windows.Forms.RibbonButton rbEditPlan;
    private System.Windows.Forms.ListView lvPlan;
    private Ztp.Ui.LightPlanEditorControl lightPlanEditor;
    private System.Windows.Forms.ColumnHeader columnHeader1;
    private System.Windows.Forms.ImageList iml;
  }
}