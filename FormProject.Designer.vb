<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class FormProject
    Inherits System.Windows.Forms.Form

    'Форма переопределяет dispose для очистки списка компонентов.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Является обязательной для конструктора форм Windows Forms
    Private components As System.ComponentModel.IContainer

    'Примечание: следующая процедура является обязательной для конструктора форм Windows Forms
    'Для ее изменения используйте конструктор форм Windows Form.  
    'Не изменяйте ее в редакторе исходного кода.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(FormProject))
        Me.Panel1 = New System.Windows.Forms.Panel()
        Me.Panel2 = New System.Windows.Forms.Panel()
        Me.LinkLabel1 = New System.Windows.Forms.LinkLabel()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.Panel3 = New System.Windows.Forms.Panel()
        Me.Panel4 = New System.Windows.Forms.Panel()
        Me.ButtonCancel = New System.Windows.Forms.Button()
        Me.ButtonSave = New System.Windows.Forms.Button()
        Me.Panel5 = New System.Windows.Forms.Panel()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.Panel7 = New System.Windows.Forms.Panel()
        Me.TextBoxЧасть = New System.Windows.Forms.TextBox()
        Me.TextBoxПодраздел = New System.Windows.Forms.TextBox()
        Me.TextBoxРаздел = New System.Windows.Forms.TextBox()
        Me.TextBoxОбъект = New System.Windows.Forms.TextBox()
        Me.TextBoxШифрПроекта = New System.Windows.Forms.TextBox()
        Me.Panel6 = New System.Windows.Forms.Panel()
        Me.Label6 = New System.Windows.Forms.Label()
        Me.ComboBoxЧастьНомер = New System.Windows.Forms.ComboBox()
        Me.ComboBoxСтадия = New System.Windows.Forms.ComboBox()
        Me.ComboBoxРазделНомер = New System.Windows.Forms.ComboBox()
        Me.ComboBoxПодразделНомер = New System.Windows.Forms.ComboBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.Panel9 = New System.Windows.Forms.Panel()
        Me.PictureBox4 = New System.Windows.Forms.PictureBox()
        Me.PictureBox3 = New System.Windows.Forms.PictureBox()
        Me.ComboBoxРасчетыЛистов = New System.Windows.Forms.ComboBox()
        Me.ComboBoxСпецификацияЛистов = New System.Windows.Forms.ComboBox()
        Me.Panel8 = New System.Windows.Forms.Panel()
        Me.ButtonCreateTop = New System.Windows.Forms.Button()
        Me.ButtonCreateBottom = New System.Windows.Forms.Button()
        Me.Label15 = New System.Windows.Forms.Label()
        Me.Label11 = New System.Windows.Forms.Label()
        Me.Label12 = New System.Windows.Forms.Label()
        Me.TabPage3 = New System.Windows.Forms.TabPage()
        Me.Panel11 = New System.Windows.Forms.Panel()
        Me.PictureBox2 = New System.Windows.Forms.PictureBox()
        Me.DateTimePickerНормоконтроль = New System.Windows.Forms.DateTimePicker()
        Me.TextBoxНормоконтроль = New System.Windows.Forms.TextBox()
        Me.DateTimePickerГАП = New System.Windows.Forms.DateTimePicker()
        Me.TextBoxГАП = New System.Windows.Forms.TextBox()
        Me.DateTimePickerГИП = New System.Windows.Forms.DateTimePicker()
        Me.TextBoxГИП = New System.Windows.Forms.TextBox()
        Me.DateTimePickerПроверил = New System.Windows.Forms.DateTimePicker()
        Me.TextBoxПроверил = New System.Windows.Forms.TextBox()
        Me.DateTimePickerРазработал = New System.Windows.Forms.DateTimePicker()
        Me.TextBoxРазработал = New System.Windows.Forms.TextBox()
        Me.TextBoxПроектнаяОрганизация = New System.Windows.Forms.TextBox()
        Me.Panel10 = New System.Windows.Forms.Panel()
        Me.ButtonCreateLogo = New System.Windows.Forms.Button()
        Me.Label16 = New System.Windows.Forms.Label()
        Me.Label14 = New System.Windows.Forms.Label()
        Me.Label13 = New System.Windows.Forms.Label()
        Me.Label10 = New System.Windows.Forms.Label()
        Me.Label9 = New System.Windows.Forms.Label()
        Me.Label7 = New System.Windows.Forms.Label()
        Me.Label8 = New System.Windows.Forms.Label()
        Me.Panel2.SuspendLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel3.SuspendLayout()
        Me.Panel4.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.Panel7.SuspendLayout()
        Me.Panel6.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.Panel9.SuspendLayout()
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel8.SuspendLayout()
        Me.TabPage3.SuspendLayout()
        Me.Panel11.SuspendLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.Panel10.SuspendLayout()
        Me.SuspendLayout()
        '
        'Panel1
        '
        Me.Panel1.Dock = System.Windows.Forms.DockStyle.Top
        Me.Panel1.Location = New System.Drawing.Point(0, 0)
        Me.Panel1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Panel1.Name = "Panel1"
        Me.Panel1.Size = New System.Drawing.Size(756, 15)
        Me.Panel1.TabIndex = 0
        '
        'Panel2
        '
        Me.Panel2.Controls.Add(Me.LinkLabel1)
        Me.Panel2.Controls.Add(Me.PictureBox1)
        Me.Panel2.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel2.Location = New System.Drawing.Point(0, 15)
        Me.Panel2.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Panel2.Name = "Panel2"
        Me.Panel2.Size = New System.Drawing.Size(240, 453)
        Me.Panel2.TabIndex = 1
        '
        'LinkLabel1
        '
        Me.LinkLabel1.AutoSize = True
        Me.LinkLabel1.Location = New System.Drawing.Point(21, 422)
        Me.LinkLabel1.Name = "LinkLabel1"
        Me.LinkLabel1.Size = New System.Drawing.Size(194, 18)
        Me.LinkLabel1.TabIndex = 1
        Me.LinkLabel1.TabStop = True
        Me.LinkLabel1.Text = "Copyright ©  2026 K&B studio"
        '
        'PictureBox1
        '
        Me.PictureBox1.BackgroundImage = CType(resources.GetObject("PictureBox1.BackgroundImage"), System.Drawing.Image)
        Me.PictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom
        Me.PictureBox1.Dock = System.Windows.Forms.DockStyle.Top
        Me.PictureBox1.Location = New System.Drawing.Point(0, 0)
        Me.PictureBox1.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(240, 240)
        Me.PictureBox1.TabIndex = 0
        Me.PictureBox1.TabStop = False
        '
        'Panel3
        '
        Me.Panel3.Controls.Add(Me.Panel4)
        Me.Panel3.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Panel3.Location = New System.Drawing.Point(240, 429)
        Me.Panel3.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Panel3.Name = "Panel3"
        Me.Panel3.Size = New System.Drawing.Size(516, 39)
        Me.Panel3.TabIndex = 2
        '
        'Panel4
        '
        Me.Panel4.Controls.Add(Me.ButtonCancel)
        Me.Panel4.Controls.Add(Me.ButtonSave)
        Me.Panel4.Dock = System.Windows.Forms.DockStyle.Right
        Me.Panel4.Location = New System.Drawing.Point(254, 0)
        Me.Panel4.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Panel4.Name = "Panel4"
        Me.Panel4.Size = New System.Drawing.Size(262, 39)
        Me.Panel4.TabIndex = 0
        '
        'ButtonCancel
        '
        Me.ButtonCancel.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.ButtonCancel.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ButtonCancel.Location = New System.Drawing.Point(132, 3)
        Me.ButtonCancel.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(120, 30)
        Me.ButtonCancel.TabIndex = 1
        Me.ButtonCancel.Text = "Отмена"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonSave
        '
        Me.ButtonSave.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.ButtonSave.Location = New System.Drawing.Point(4, 3)
        Me.ButtonSave.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.ButtonSave.Name = "ButtonSave"
        Me.ButtonSave.Size = New System.Drawing.Size(120, 30)
        Me.ButtonSave.TabIndex = 0
        Me.ButtonSave.Text = "ОК"
        Me.ButtonSave.UseVisualStyleBackColor = True
        '
        'Panel5
        '
        Me.Panel5.Dock = System.Windows.Forms.DockStyle.Bottom
        Me.Panel5.Location = New System.Drawing.Point(240, 414)
        Me.Panel5.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.Panel5.Name = "Panel5"
        Me.Panel5.Size = New System.Drawing.Size(516, 15)
        Me.Panel5.TabIndex = 3
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Controls.Add(Me.TabPage3)
        Me.TabControl1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.TabControl1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TabControl1.Location = New System.Drawing.Point(240, 15)
        Me.TabControl1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(516, 399)
        Me.TabControl1.TabIndex = 4
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Panel7)
        Me.TabPage1.Controls.Add(Me.Panel6)
        Me.TabPage1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.TabPage1.Location = New System.Drawing.Point(4, 27)
        Me.TabPage1.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage1.Size = New System.Drawing.Size(508, 368)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Документ"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'Panel7
        '
        Me.Panel7.Controls.Add(Me.TextBoxЧасть)
        Me.Panel7.Controls.Add(Me.TextBoxПодраздел)
        Me.Panel7.Controls.Add(Me.TextBoxРаздел)
        Me.Panel7.Controls.Add(Me.TextBoxОбъект)
        Me.Panel7.Controls.Add(Me.TextBoxШифрПроекта)
        Me.Panel7.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel7.Location = New System.Drawing.Point(189, 2)
        Me.Panel7.Name = "Panel7"
        Me.Panel7.Size = New System.Drawing.Size(316, 364)
        Me.Panel7.TabIndex = 5
        '
        'TextBoxЧасть
        '
        Me.TextBoxЧасть.Location = New System.Drawing.Point(7, 276)
        Me.TextBoxЧасть.Multiline = True
        Me.TextBoxЧасть.Name = "TextBoxЧасть"
        Me.TextBoxЧасть.Size = New System.Drawing.Size(304, 72)
        Me.TextBoxЧасть.TabIndex = 4
        '
        'TextBoxПодраздел
        '
        Me.TextBoxПодраздел.Location = New System.Drawing.Point(7, 222)
        Me.TextBoxПодраздел.Multiline = True
        Me.TextBoxПодраздел.Name = "TextBoxПодраздел"
        Me.TextBoxПодраздел.Size = New System.Drawing.Size(304, 48)
        Me.TextBoxПодраздел.TabIndex = 3
        '
        'TextBoxРаздел
        '
        Me.TextBoxРаздел.Location = New System.Drawing.Point(7, 144)
        Me.TextBoxРаздел.Multiline = True
        Me.TextBoxРаздел.Name = "TextBoxРаздел"
        Me.TextBoxРаздел.Size = New System.Drawing.Size(304, 72)
        Me.TextBoxРаздел.TabIndex = 2
        Me.TextBoxРаздел.Text = "Сведения об инженерном оборудовании, о сетях и системах инженерно-технического об" &
    "еспечения."
        '
        'TextBoxОбъект
        '
        Me.TextBoxОбъект.Location = New System.Drawing.Point(7, 42)
        Me.TextBoxОбъект.Multiline = True
        Me.TextBoxОбъект.Name = "TextBoxОбъект"
        Me.TextBoxОбъект.Size = New System.Drawing.Size(304, 96)
        Me.TextBoxОбъект.TabIndex = 1
        '
        'TextBoxШифрПроекта
        '
        Me.TextBoxШифрПроекта.Location = New System.Drawing.Point(7, 12)
        Me.TextBoxШифрПроекта.Name = "TextBoxШифрПроекта"
        Me.TextBoxШифрПроекта.Size = New System.Drawing.Size(304, 24)
        Me.TextBoxШифрПроекта.TabIndex = 0
        '
        'Panel6
        '
        Me.Panel6.Controls.Add(Me.Label6)
        Me.Panel6.Controls.Add(Me.ComboBoxЧастьНомер)
        Me.Panel6.Controls.Add(Me.ComboBoxСтадия)
        Me.Panel6.Controls.Add(Me.ComboBoxРазделНомер)
        Me.Panel6.Controls.Add(Me.ComboBoxПодразделНомер)
        Me.Panel6.Controls.Add(Me.Label1)
        Me.Panel6.Controls.Add(Me.Label5)
        Me.Panel6.Controls.Add(Me.Label4)
        Me.Panel6.Controls.Add(Me.Label3)
        Me.Panel6.Controls.Add(Me.Label2)
        Me.Panel6.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel6.Location = New System.Drawing.Point(3, 2)
        Me.Panel6.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Panel6.Name = "Panel6"
        Me.Panel6.Size = New System.Drawing.Size(186, 364)
        Me.Panel6.TabIndex = 4
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label6.Location = New System.Drawing.Point(5, 79)
        Me.Label6.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(59, 18)
        Me.Label6.TabIndex = 9
        Me.Label6.Text = "Стадия"
        '
        'ComboBoxЧастьНомер
        '
        Me.ComboBoxЧастьНомер.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxЧастьНомер.FormattingEnabled = True
        Me.ComboBoxЧастьНомер.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9"})
        Me.ComboBoxЧастьНомер.Location = New System.Drawing.Point(108, 276)
        Me.ComboBoxЧастьНомер.Name = "ComboBoxЧастьНомер"
        Me.ComboBoxЧастьНомер.Size = New System.Drawing.Size(72, 26)
        Me.ComboBoxЧастьНомер.TabIndex = 8
        '
        'ComboBoxСтадия
        '
        Me.ComboBoxСтадия.FormattingEnabled = True
        Me.ComboBoxСтадия.Items.AddRange(New Object() {"П", "РД"})
        Me.ComboBoxСтадия.Location = New System.Drawing.Point(108, 76)
        Me.ComboBoxСтадия.Name = "ComboBoxСтадия"
        Me.ComboBoxСтадия.Size = New System.Drawing.Size(72, 26)
        Me.ComboBoxСтадия.TabIndex = 7
        '
        'ComboBoxРазделНомер
        '
        Me.ComboBoxРазделНомер.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxРазделНомер.FormattingEnabled = True
        Me.ComboBoxРазделНомер.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9"})
        Me.ComboBoxРазделНомер.Location = New System.Drawing.Point(108, 144)
        Me.ComboBoxРазделНомер.Name = "ComboBoxРазделНомер"
        Me.ComboBoxРазделНомер.Size = New System.Drawing.Size(72, 26)
        Me.ComboBoxРазделНомер.TabIndex = 6
        '
        'ComboBoxПодразделНомер
        '
        Me.ComboBoxПодразделНомер.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList
        Me.ComboBoxПодразделНомер.FormattingEnabled = True
        Me.ComboBoxПодразделНомер.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9"})
        Me.ComboBoxПодразделНомер.Location = New System.Drawing.Point(108, 222)
        Me.ComboBoxПодразделНомер.Name = "ComboBoxПодразделНомер"
        Me.ComboBoxПодразделНомер.Size = New System.Drawing.Size(72, 26)
        Me.ComboBoxПодразделНомер.TabIndex = 5
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label1.Location = New System.Drawing.Point(5, 279)
        Me.Label1.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(49, 18)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Часть"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label5.Location = New System.Drawing.Point(4, 225)
        Me.Label5.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(87, 18)
        Me.Label5.TabIndex = 3
        Me.Label5.Text = "Подраздел"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label4.Location = New System.Drawing.Point(5, 147)
        Me.Label4.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(60, 18)
        Me.Label4.TabIndex = 2
        Me.Label4.Text = "Раздел"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label3.Location = New System.Drawing.Point(4, 42)
        Me.Label3.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(178, 18)
        Me.Label3.TabIndex = 1
        Me.Label3.Text = "Объект проектирования"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label2.Location = New System.Drawing.Point(4, 12)
        Me.Label2.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(110, 18)
        Me.Label2.TabIndex = 0
        Me.Label2.Text = "Шифр проекта"
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Panel9)
        Me.TabPage2.Controls.Add(Me.Panel8)
        Me.TabPage2.Location = New System.Drawing.Point(4, 27)
        Me.TabPage2.Margin = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3, 2, 3, 2)
        Me.TabPage2.Size = New System.Drawing.Size(508, 368)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Приложения"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'Panel9
        '
        Me.Panel9.Controls.Add(Me.PictureBox4)
        Me.Panel9.Controls.Add(Me.PictureBox3)
        Me.Panel9.Controls.Add(Me.ComboBoxРасчетыЛистов)
        Me.Panel9.Controls.Add(Me.ComboBoxСпецификацияЛистов)
        Me.Panel9.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel9.Location = New System.Drawing.Point(189, 2)
        Me.Panel9.Name = "Panel9"
        Me.Panel9.Size = New System.Drawing.Size(316, 364)
        Me.Panel9.TabIndex = 6
        '
        'PictureBox4
        '
        Me.PictureBox4.Location = New System.Drawing.Point(7, 162)
        Me.PictureBox4.Name = "PictureBox4"
        Me.PictureBox4.Size = New System.Drawing.Size(300, 32)
        Me.PictureBox4.TabIndex = 16
        Me.PictureBox4.TabStop = False
        '
        'PictureBox3
        '
        Me.PictureBox3.Location = New System.Drawing.Point(7, 76)
        Me.PictureBox3.Name = "PictureBox3"
        Me.PictureBox3.Size = New System.Drawing.Size(300, 80)
        Me.PictureBox3.TabIndex = 15
        Me.PictureBox3.TabStop = False
        '
        'ComboBoxРасчетыЛистов
        '
        Me.ComboBoxРасчетыЛистов.FormattingEnabled = True
        Me.ComboBoxРасчетыЛистов.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9"})
        Me.ComboBoxРасчетыЛистов.Location = New System.Drawing.Point(7, 44)
        Me.ComboBoxРасчетыЛистов.Name = "ComboBoxРасчетыЛистов"
        Me.ComboBoxРасчетыЛистов.Size = New System.Drawing.Size(72, 26)
        Me.ComboBoxРасчетыЛистов.TabIndex = 8
        '
        'ComboBoxСпецификацияЛистов
        '
        Me.ComboBoxСпецификацияЛистов.FormattingEnabled = True
        Me.ComboBoxСпецификацияЛистов.Items.AddRange(New Object() {"1", "2", "3", "4", "5", "6", "7", "8", "9"})
        Me.ComboBoxСпецификацияЛистов.Location = New System.Drawing.Point(7, 12)
        Me.ComboBoxСпецификацияЛистов.Name = "ComboBoxСпецификацияЛистов"
        Me.ComboBoxСпецификацияЛистов.Size = New System.Drawing.Size(72, 26)
        Me.ComboBoxСпецификацияЛистов.TabIndex = 7
        '
        'Panel8
        '
        Me.Panel8.Controls.Add(Me.ButtonCreateTop)
        Me.Panel8.Controls.Add(Me.ButtonCreateBottom)
        Me.Panel8.Controls.Add(Me.Label15)
        Me.Panel8.Controls.Add(Me.Label11)
        Me.Panel8.Controls.Add(Me.Label12)
        Me.Panel8.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel8.Location = New System.Drawing.Point(3, 2)
        Me.Panel8.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Panel8.Name = "Panel8"
        Me.Panel8.Size = New System.Drawing.Size(186, 364)
        Me.Panel8.TabIndex = 5
        '
        'ButtonCreateTop
        '
        Me.ButtonCreateTop.Image = CType(resources.GetObject("ButtonCreateTop.Image"), System.Drawing.Image)
        Me.ButtonCreateTop.Location = New System.Drawing.Point(153, 132)
        Me.ButtonCreateTop.Name = "ButtonCreateTop"
        Me.ButtonCreateTop.Size = New System.Drawing.Size(24, 24)
        Me.ButtonCreateTop.TabIndex = 15
        Me.ButtonCreateTop.UseVisualStyleBackColor = True
        '
        'ButtonCreateBottom
        '
        Me.ButtonCreateBottom.Image = CType(resources.GetObject("ButtonCreateBottom.Image"), System.Drawing.Image)
        Me.ButtonCreateBottom.Location = New System.Drawing.Point(153, 170)
        Me.ButtonCreateBottom.Name = "ButtonCreateBottom"
        Me.ButtonCreateBottom.Size = New System.Drawing.Size(24, 24)
        Me.ButtonCreateBottom.TabIndex = 14
        Me.ButtonCreateBottom.UseVisualStyleBackColor = True
        '
        'Label15
        '
        Me.Label15.AutoSize = True
        Me.Label15.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label15.Location = New System.Drawing.Point(4, 76)
        Me.Label15.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label15.Name = "Label15"
        Me.Label15.Size = New System.Drawing.Size(59, 18)
        Me.Label15.TabIndex = 2
        Me.Label15.Text = "Титулы"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label11.Location = New System.Drawing.Point(4, 44)
        Me.Label11.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(129, 18)
        Me.Label11.TabIndex = 1
        Me.Label11.Text = "Расчеты, листов:"
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label12.Location = New System.Drawing.Point(4, 12)
        Me.Label12.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(173, 18)
        Me.Label12.TabIndex = 0
        Me.Label12.Text = "Спецификация, листов:"
        '
        'TabPage3
        '
        Me.TabPage3.Controls.Add(Me.Panel11)
        Me.TabPage3.Controls.Add(Me.Panel10)
        Me.TabPage3.Location = New System.Drawing.Point(4, 27)
        Me.TabPage3.Name = "TabPage3"
        Me.TabPage3.Size = New System.Drawing.Size(508, 368)
        Me.TabPage3.TabIndex = 2
        Me.TabPage3.Text = "Организация"
        Me.TabPage3.UseVisualStyleBackColor = True
        '
        'Panel11
        '
        Me.Panel11.Controls.Add(Me.PictureBox2)
        Me.Panel11.Controls.Add(Me.DateTimePickerНормоконтроль)
        Me.Panel11.Controls.Add(Me.TextBoxНормоконтроль)
        Me.Panel11.Controls.Add(Me.DateTimePickerГАП)
        Me.Panel11.Controls.Add(Me.TextBoxГАП)
        Me.Panel11.Controls.Add(Me.DateTimePickerГИП)
        Me.Panel11.Controls.Add(Me.TextBoxГИП)
        Me.Panel11.Controls.Add(Me.DateTimePickerПроверил)
        Me.Panel11.Controls.Add(Me.TextBoxПроверил)
        Me.Panel11.Controls.Add(Me.DateTimePickerРазработал)
        Me.Panel11.Controls.Add(Me.TextBoxРазработал)
        Me.Panel11.Controls.Add(Me.TextBoxПроектнаяОрганизация)
        Me.Panel11.Dock = System.Windows.Forms.DockStyle.Fill
        Me.Panel11.Location = New System.Drawing.Point(186, 0)
        Me.Panel11.Name = "Panel11"
        Me.Panel11.Size = New System.Drawing.Size(322, 368)
        Me.Panel11.TabIndex = 7
        '
        'PictureBox2
        '
        Me.PictureBox2.Location = New System.Drawing.Point(7, 194)
        Me.PictureBox2.Name = "PictureBox2"
        Me.PictureBox2.Size = New System.Drawing.Size(300, 90)
        Me.PictureBox2.TabIndex = 13
        Me.PictureBox2.TabStop = False
        '
        'DateTimePickerНормоконтроль
        '
        Me.DateTimePickerНормоконтроль.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerНормоконтроль.Location = New System.Drawing.Point(210, 164)
        Me.DateTimePickerНормоконтроль.Name = "DateTimePickerНормоконтроль"
        Me.DateTimePickerНормоконтроль.Size = New System.Drawing.Size(101, 24)
        Me.DateTimePickerНормоконтроль.TabIndex = 10
        '
        'TextBoxНормоконтроль
        '
        Me.TextBoxНормоконтроль.Location = New System.Drawing.Point(7, 164)
        Me.TextBoxНормоконтроль.Name = "TextBoxНормоконтроль"
        Me.TextBoxНормоконтроль.Size = New System.Drawing.Size(197, 24)
        Me.TextBoxНормоконтроль.TabIndex = 9
        '
        'DateTimePickerГАП
        '
        Me.DateTimePickerГАП.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerГАП.Location = New System.Drawing.Point(210, 134)
        Me.DateTimePickerГАП.Name = "DateTimePickerГАП"
        Me.DateTimePickerГАП.Size = New System.Drawing.Size(101, 24)
        Me.DateTimePickerГАП.TabIndex = 8
        '
        'TextBoxГАП
        '
        Me.TextBoxГАП.Location = New System.Drawing.Point(7, 134)
        Me.TextBoxГАП.Name = "TextBoxГАП"
        Me.TextBoxГАП.Size = New System.Drawing.Size(197, 24)
        Me.TextBoxГАП.TabIndex = 7
        '
        'DateTimePickerГИП
        '
        Me.DateTimePickerГИП.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerГИП.Location = New System.Drawing.Point(210, 104)
        Me.DateTimePickerГИП.Name = "DateTimePickerГИП"
        Me.DateTimePickerГИП.Size = New System.Drawing.Size(101, 24)
        Me.DateTimePickerГИП.TabIndex = 6
        '
        'TextBoxГИП
        '
        Me.TextBoxГИП.Location = New System.Drawing.Point(7, 104)
        Me.TextBoxГИП.Name = "TextBoxГИП"
        Me.TextBoxГИП.Size = New System.Drawing.Size(197, 24)
        Me.TextBoxГИП.TabIndex = 5
        '
        'DateTimePickerПроверил
        '
        Me.DateTimePickerПроверил.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerПроверил.Location = New System.Drawing.Point(210, 74)
        Me.DateTimePickerПроверил.Name = "DateTimePickerПроверил"
        Me.DateTimePickerПроверил.Size = New System.Drawing.Size(101, 24)
        Me.DateTimePickerПроверил.TabIndex = 4
        '
        'TextBoxПроверил
        '
        Me.TextBoxПроверил.Location = New System.Drawing.Point(7, 74)
        Me.TextBoxПроверил.Name = "TextBoxПроверил"
        Me.TextBoxПроверил.Size = New System.Drawing.Size(197, 24)
        Me.TextBoxПроверил.TabIndex = 3
        '
        'DateTimePickerРазработал
        '
        Me.DateTimePickerРазработал.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePickerРазработал.Location = New System.Drawing.Point(210, 44)
        Me.DateTimePickerРазработал.Name = "DateTimePickerРазработал"
        Me.DateTimePickerРазработал.Size = New System.Drawing.Size(101, 24)
        Me.DateTimePickerРазработал.TabIndex = 2
        '
        'TextBoxРазработал
        '
        Me.TextBoxРазработал.Location = New System.Drawing.Point(7, 44)
        Me.TextBoxРазработал.Name = "TextBoxРазработал"
        Me.TextBoxРазработал.Size = New System.Drawing.Size(197, 24)
        Me.TextBoxРазработал.TabIndex = 1
        '
        'TextBoxПроектнаяОрганизация
        '
        Me.TextBoxПроектнаяОрганизация.Location = New System.Drawing.Point(7, 12)
        Me.TextBoxПроектнаяОрганизация.Name = "TextBoxПроектнаяОрганизация"
        Me.TextBoxПроектнаяОрганизация.Size = New System.Drawing.Size(304, 24)
        Me.TextBoxПроектнаяОрганизация.TabIndex = 0
        '
        'Panel10
        '
        Me.Panel10.Controls.Add(Me.ButtonCreateLogo)
        Me.Panel10.Controls.Add(Me.Label16)
        Me.Panel10.Controls.Add(Me.Label14)
        Me.Panel10.Controls.Add(Me.Label13)
        Me.Panel10.Controls.Add(Me.Label10)
        Me.Panel10.Controls.Add(Me.Label9)
        Me.Panel10.Controls.Add(Me.Label7)
        Me.Panel10.Controls.Add(Me.Label8)
        Me.Panel10.Dock = System.Windows.Forms.DockStyle.Left
        Me.Panel10.Location = New System.Drawing.Point(0, 0)
        Me.Panel10.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.Panel10.Name = "Panel10"
        Me.Panel10.Size = New System.Drawing.Size(186, 368)
        Me.Panel10.TabIndex = 6
        '
        'ButtonCreateLogo
        '
        Me.ButtonCreateLogo.Image = CType(resources.GetObject("ButtonCreateLogo.Image"), System.Drawing.Image)
        Me.ButtonCreateLogo.Location = New System.Drawing.Point(152, 194)
        Me.ButtonCreateLogo.Name = "ButtonCreateLogo"
        Me.ButtonCreateLogo.Size = New System.Drawing.Size(24, 24)
        Me.ButtonCreateLogo.TabIndex = 13
        Me.ButtonCreateLogo.UseVisualStyleBackColor = True
        '
        'Label16
        '
        Me.Label16.AutoSize = True
        Me.Label16.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label16.Location = New System.Drawing.Point(4, 194)
        Me.Label16.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label16.Name = "Label16"
        Me.Label16.Size = New System.Drawing.Size(66, 18)
        Me.Label16.TabIndex = 7
        Me.Label16.Text = "Логотип"
        '
        'Label14
        '
        Me.Label14.AutoSize = True
        Me.Label14.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label14.Location = New System.Drawing.Point(4, 164)
        Me.Label14.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label14.Name = "Label14"
        Me.Label14.Size = New System.Drawing.Size(122, 18)
        Me.Label14.TabIndex = 5
        Me.Label14.Text = "Нормоконтроль"
        '
        'Label13
        '
        Me.Label13.AutoSize = True
        Me.Label13.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label13.Location = New System.Drawing.Point(4, 134)
        Me.Label13.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label13.Name = "Label13"
        Me.Label13.Size = New System.Drawing.Size(172, 18)
        Me.Label13.TabIndex = 4
        Me.Label13.Text = "Гл. архитектор проекта"
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label10.Location = New System.Drawing.Point(4, 104)
        Me.Label10.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(153, 18)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "Гл. инженер проекта"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label9.Location = New System.Drawing.Point(4, 74)
        Me.Label9.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(77, 18)
        Me.Label9.TabIndex = 2
        Me.Label9.Text = "Проверил"
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label7.Location = New System.Drawing.Point(4, 44)
        Me.Label7.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(92, 18)
        Me.Label7.TabIndex = 1
        Me.Label7.Text = "Разработал"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Label8.Location = New System.Drawing.Point(4, 12)
        Me.Label8.Margin = New System.Windows.Forms.Padding(4, 0, 4, 0)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(174, 18)
        Me.Label8.TabIndex = 0
        Me.Label8.Text = "Проектная организация"
        '
        'FormProject
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 18.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.CancelButton = Me.ButtonCancel
        Me.ClientSize = New System.Drawing.Size(756, 468)
        Me.ControlBox = False
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.Panel5)
        Me.Controls.Add(Me.Panel3)
        Me.Controls.Add(Me.Panel2)
        Me.Controls.Add(Me.Panel1)
        Me.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(204, Byte))
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Margin = New System.Windows.Forms.Padding(4, 3, 4, 3)
        Me.MaximizeBox = False
        Me.MinimizeBox = False
        Me.Name = "FormProject"
        Me.ShowInTaskbar = False
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "ПРОЕКТ:"
        Me.Panel2.ResumeLayout(False)
        Me.Panel2.PerformLayout()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel3.ResumeLayout(False)
        Me.Panel4.ResumeLayout(False)
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.Panel7.ResumeLayout(False)
        Me.Panel7.PerformLayout()
        Me.Panel6.ResumeLayout(False)
        Me.Panel6.PerformLayout()
        Me.TabPage2.ResumeLayout(False)
        Me.Panel9.ResumeLayout(False)
        CType(Me.PictureBox4, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel8.ResumeLayout(False)
        Me.Panel8.PerformLayout()
        Me.TabPage3.ResumeLayout(False)
        Me.Panel11.ResumeLayout(False)
        Me.Panel11.PerformLayout()
        CType(Me.PictureBox2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.Panel10.ResumeLayout(False)
        Me.Panel10.PerformLayout()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Panel1 As Windows.Forms.Panel
    Friend WithEvents Panel2 As Windows.Forms.Panel
    Friend WithEvents PictureBox1 As Windows.Forms.PictureBox
    Friend WithEvents Panel3 As Windows.Forms.Panel
    Friend WithEvents Panel4 As Windows.Forms.Panel
    Friend WithEvents ButtonSave As Windows.Forms.Button
    Friend WithEvents ButtonCancel As Windows.Forms.Button
    Friend WithEvents Panel5 As Windows.Forms.Panel
    Friend WithEvents TabControl1 As Windows.Forms.TabControl
    Friend WithEvents TabPage1 As Windows.Forms.TabPage
    Friend WithEvents TabPage2 As Windows.Forms.TabPage
    Friend WithEvents Panel6 As Windows.Forms.Panel
    Friend WithEvents Label1 As Windows.Forms.Label
    Friend WithEvents Label5 As Windows.Forms.Label
    Friend WithEvents Label4 As Windows.Forms.Label
    Friend WithEvents Label3 As Windows.Forms.Label
    Friend WithEvents Label2 As Windows.Forms.Label
    Friend WithEvents Panel7 As Windows.Forms.Panel
    Friend WithEvents TextBoxОбъект As Windows.Forms.TextBox
    Friend WithEvents TextBoxШифрПроекта As Windows.Forms.TextBox
    Friend WithEvents TextBoxРаздел As Windows.Forms.TextBox
    Friend WithEvents TextBoxЧасть As Windows.Forms.TextBox
    Friend WithEvents TextBoxПодраздел As Windows.Forms.TextBox
    Friend WithEvents ComboBoxПодразделНомер As Windows.Forms.ComboBox
    Friend WithEvents Label6 As Windows.Forms.Label
    Friend WithEvents ComboBoxЧастьНомер As Windows.Forms.ComboBox
    Friend WithEvents ComboBoxСтадия As Windows.Forms.ComboBox
    Friend WithEvents ComboBoxРазделНомер As Windows.Forms.ComboBox
    Friend WithEvents TabPage3 As Windows.Forms.TabPage
    Friend WithEvents LinkLabel1 As Windows.Forms.LinkLabel
    Friend WithEvents Panel8 As Windows.Forms.Panel
    Friend WithEvents Label11 As Windows.Forms.Label
    Friend WithEvents Label12 As Windows.Forms.Label
    Friend WithEvents Panel9 As Windows.Forms.Panel
    Friend WithEvents ComboBoxСпецификацияЛистов As Windows.Forms.ComboBox
    Friend WithEvents ComboBoxРасчетыЛистов As Windows.Forms.ComboBox
    Friend WithEvents Panel11 As Windows.Forms.Panel
    Friend WithEvents TextBoxПроектнаяОрганизация As Windows.Forms.TextBox
    Friend WithEvents Panel10 As Windows.Forms.Panel
    Friend WithEvents Label7 As Windows.Forms.Label
    Friend WithEvents Label8 As Windows.Forms.Label
    Friend WithEvents TextBoxРазработал As Windows.Forms.TextBox
    Friend WithEvents DateTimePickerРазработал As Windows.Forms.DateTimePicker
    Friend WithEvents DateTimePickerНормоконтроль As Windows.Forms.DateTimePicker
    Friend WithEvents TextBoxНормоконтроль As Windows.Forms.TextBox
    Friend WithEvents DateTimePickerГАП As Windows.Forms.DateTimePicker
    Friend WithEvents TextBoxГАП As Windows.Forms.TextBox
    Friend WithEvents DateTimePickerГИП As Windows.Forms.DateTimePicker
    Friend WithEvents TextBoxГИП As Windows.Forms.TextBox
    Friend WithEvents DateTimePickerПроверил As Windows.Forms.DateTimePicker
    Friend WithEvents TextBoxПроверил As Windows.Forms.TextBox
    Friend WithEvents Label10 As Windows.Forms.Label
    Friend WithEvents Label9 As Windows.Forms.Label
    Friend WithEvents Label14 As Windows.Forms.Label
    Friend WithEvents Label13 As Windows.Forms.Label
    Friend WithEvents PictureBox2 As Windows.Forms.PictureBox
    Friend WithEvents Label16 As Windows.Forms.Label
    Friend WithEvents ButtonCreateLogo As Windows.Forms.Button
    Friend WithEvents PictureBox4 As Windows.Forms.PictureBox
    Friend WithEvents PictureBox3 As Windows.Forms.PictureBox
    Friend WithEvents ButtonCreateTop As Windows.Forms.Button
    Friend WithEvents ButtonCreateBottom As Windows.Forms.Button
    Friend WithEvents Label15 As Windows.Forms.Label
End Class
