Imports System.Reflection
Imports System.IO
Imports System.Environment

Namespace KBStudio
    Public NotInheritable Class PluginSettings
        'Путь к папке расположения DLL
        Public Shared ReadOnly Property AssemblyPath As String = Assembly.GetExecutingAssembly().Location
        'Путь к корневому каталогу плагина
        Public Shared ReadOnly Property RootPath As String = Directory.GetParent(AssemblyPath).FullName
        ' Путь к папке расположения шаблонов
        Public Shared ReadOnly Property TemplatePath As String = Path.Combine(RootPath, "Template")
        ' Путь к папке расположения баз данных
        Public Shared ReadOnly Property DatabasePath As String = Path.Combine(RootPath, "Database")
        ' Путь к папке расположения ресурсов
        Public Shared ReadOnly Property ResourcesPath As String = Path.Combine(RootPath, "Resources")
        ' Путь к папке расположения значков
        Public Shared ReadOnly Property IconsPath As String = Path.Combine(RootPath, "Icons")
        ' Путь к папке ДОКУМЕНТЫ
        Public Shared ReadOnly Property DocPath As String = GetFolderPath(SpecialFolder.MyDocuments)
        ' Шаблоны чертежей
        Public Const TemplateCAD As String = "acdKBS.dwt"
        Public Const TemplateCVL As String = "cvlKBS.dwt"

    End Class
End Namespace

