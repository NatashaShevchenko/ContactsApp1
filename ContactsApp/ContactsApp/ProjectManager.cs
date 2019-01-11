﻿using System.IO;
using Newtonsoft.Json;

namespace ContactsApp
{
    public class ProjectManager
    {
        /// <summary>
        ///     Сериалайзер.
        /// </summary>
        private static readonly JsonSerializer JsonSerializer;

        /// <summary>
        ///     Путь к файлу.
        /// </summary>
        private readonly string _pathToFile;

        /// <summary>
        ///     Статический конструктор.
        /// </summary>
        static ProjectManager()
        {
            JsonSerializer = JsonSerializer.Create();
            JsonSerializer.Formatting = Formatting.Indented;
        }

        /// <summary>
        ///     Конструктор, устанавливающий путь к файлу.
        /// </summary>
        /// <param name="pathToFile">Путь к файлу.</param>
        public ProjectManager(string pathToFile)
        {
            _pathToFile = pathToFile;
        }

        /// <summary>
        ///     Cохраняет проект в файл.
        /// </summary>
        /// <param name="project">Проект.</param>
        public void SaveToFile(Project project)
        {
            using (var streamWriter = new StreamWriter(_pathToFile))
            using (var jsonWriter = new JsonTextWriter(streamWriter))
            {
                JsonSerializer.Serialize(jsonWriter, project);
            }
        }

        /// <summary>
        ///     Загружает проект из файла.
        /// </summary>
        /// <returns>Проект.</returns>
        public Project LoadFromFile()
        {
            //if (!File.Exists(_pathToFile))
            //{
            //    File.Create(_pathToFile);
            //}
            using (var streamReader = new StreamReader(_pathToFile))
            using (var jsonReader = new JsonTextReader(streamReader))
            {
                var project = JsonSerializer.Deserialize<Project>(jsonReader);
                return project;
            }
        }

        public bool IsExistProjectFile()
        {
            return File.Exists(_pathToFile);
        }
    }
}