namespace MyDoctorAppointment.Data.Configuration
{
    public static class Constants
    {
        // Определяем корневую папку решения относительно текущей директории выполнения
        public static readonly string rootPath = Directory.GetParent(AppDomain.CurrentDomain.BaseDirectory)?.Parent?.Parent?.Parent?.Parent?.FullName
                                                  ?? throw new InvalidOperationException("Не удалось определить корневую папку решения.");

        // Относительные пути к файлам настроек
        public static readonly string JsonAppSettingsPath = Path.Combine(rootPath, "DoctorAppointmentDemo.Data", "Configuration", "appsettings.json");
        public static readonly string XmlAppSettingsPath = Path.Combine(rootPath, "DoctorAppointmentDemo.Data", "Configuration", "appsettings.xml");
    }
}

