using System;
using System.Collections.Generic;
using System.Text.Json;
using System.IO;

namespace Repository
{
    public static class Repository<T> where T : class, new()
    {
        private static readonly JsonSerializerOptions options = new JsonSerializerOptions { WriteIndented = true };
        // Construye la ruta absoluta hacia Repository/Data/[archivo].json en la raíz del proyecto
        private static string GetProjectRelativePath(string archivo)
        {
            var basePath = AppDomain.CurrentDomain.BaseDirectory;
            var projectRoot = Path.Combine(basePath, @"..\..\..\Repository\Data");
            Directory.CreateDirectory(projectRoot); // crea la carpeta si no existe
            return Path.GetFullPath(Path.Combine(projectRoot, $"{archivo}.json"));
        }

        public static void Agregar(string archivo, T entidad)
        {
            var datos = Cargar(archivo);
            datos.Add(entidad);
            Guardar(archivo, datos);
        }

        public static List<T> ObtenerTodos(string archivo) => Cargar(archivo);

        public static void Eliminar(string archivo, Predicate<T> predicado)
        {
            var datos = Cargar(archivo);
            datos.RemoveAll(predicado);
            Guardar(archivo, datos);
        }

        public static void Actualizar(string archivo, Predicate<T> predicado, T nuevaEntidad)
        {
            var datos = Cargar(archivo);
            int index = datos.FindIndex(predicado);
            if (index != -1)
            {
                datos[index] = nuevaEntidad;
                Guardar(archivo, datos);
            }
        }

        private static void Guardar(string archivo, List<T> datos)
        {
            string path = GetProjectRelativePath(archivo);
            File.WriteAllText(path, JsonSerializer.Serialize(datos,
            options));
        }

        private static List<T> Cargar(string archivo)
        {
            string path = GetProjectRelativePath(archivo);
            if (!File.Exists(path)) return new List<T>();
            return
            JsonSerializer.Deserialize<List<T>>(File.ReadAllText(path), options)
            ?? new List<T>();
        }

        public static void GuardarLista(string archivo, List<T> datos)
        {
            try
            {
                string path = GetProjectRelativePath(archivo);
                string json = JsonSerializer.Serialize(datos, options);
                File.WriteAllText(path, json);
            }
            catch (IOException ex)
            {
                Console.Error.WriteLine($"[ERROR] No se pudo guardar el archivo {archivo}.json: {ex.Message}");
            }
        }


    }
}