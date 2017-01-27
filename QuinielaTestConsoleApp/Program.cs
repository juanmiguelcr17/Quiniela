using System;
using System.IO;
using UtilsLibrary.Serialization;

namespace QuinielaTestConsoleApp
{
    class Program
    {
        static Writter wr = new Writter();
        static Test test = new Test();
        static void Main(string[] args)
        {
            test.crearLiga();
            writeToFile("Liga", serialize(test.ligaMX));
            test.CrearTemporada();
            writeToFile("Temporada", serialize(test.temporada));
            test.CrearEquipos();
            test.CrearJornada();
            writeToFile("Jornada 1", serialize(test.semana1));
            test.CrearQuiniela();
            writeToFile("Quiniela J1", serialize(test.Quiniela1));
            test.CrearPrediccion();
            writeToFile("Prediccion J1", serialize(test.Prediccion1));
            test.SetResultsOfWeek();
            test.VerifyResults();
            writeToFile("Resultados Jornada 1", serialize(test.semana1));
        }
        static string serialize(object data)
        {
            return wr.SerializarAJson(data);
        }
        static void writeToFile(string fileName, string data)
        {
            string path =string.Format(@"{0}\{1}.{2}", System.Configuration.ConfigurationManager.AppSettings["Path"], fileName, "json");
            File.WriteAllText(path, data);
        }
    }
}
