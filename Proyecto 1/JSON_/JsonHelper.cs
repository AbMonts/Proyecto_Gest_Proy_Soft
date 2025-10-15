using Newtonsoft.Json;
using System.IO;
using System.Collections.Generic;
using System.ComponentModel;
using System;
using System.Linq;

public class JsonHelper
{
    // Métodos para manejar Notificaciones en formato JSON

    // Carga todas las notificaciones desde un archivo JSON
    // Si el archivo no existe, lo crea con un array vacío
    public static List<NotificacionJson> CargarNotificacionesJson(string archivoJson)
    {
        List<NotificacionJson> notificaciones = new List<NotificacionJson>();

        if (File.Exists(archivoJson))
        {
            // Lee y deserializa el contenido del archivo JSON
            string json = File.ReadAllText(archivoJson);
            notificaciones = JsonConvert.DeserializeObject<List<NotificacionJson>>(json);
        }
        else
        {
            // Crea el archivo con un array vacío si no existe
            File.WriteAllText(archivoJson, "[]");
        }

        return notificaciones;
    }

    // Carga notificaciones aplicando filtros
    // Los filtros se pasan como string separado por comas
    public static List<NotificacionJson> CargarNotificacionesJsonFiltro(string archivoJson, string x)
    {
        List<NotificacionJson> notificaciones = new List<NotificacionJson>();

        if (File.Exists(archivoJson))
        {
            string json = File.ReadAllText(archivoJson);
            notificaciones = JsonConvert.DeserializeObject<List<NotificacionJson>>(json);
        }
        else
        {
            File.WriteAllText(archivoJson, "[]");
        }

        // Divide los filtros y limpia espacios en blanco
        string[] F = x.Split(',').Select(filtro => filtro.Trim()).ToArray();

        // Filtra las notificaciones que coincidan con REMITENTE, TIPO o FECHA
        List<NotificacionJson> notificacionesFiltradas = notificaciones
            .Where(n => F.Contains(n.REMITENTE.ToString()) || F.Contains(n.TIPO.ToString()) || F.Contains(n.FECHA.ToString()))
            .ToList();

        // Crea una nueva lista con solo los campos necesarios
        List<NotificacionJson> notificacionesConCampos = notificacionesFiltradas.Select(n =>
        {
            var notiFiltrada = new NotificacionJson();

            notiFiltrada.TIPO = n.TIPO;
            notiFiltrada.DESCRIPCIÓN = n.DESCRIPCIÓN;
            notiFiltrada.REMITENTE = n.REMITENTE;
            notiFiltrada.FECHA = n.FECHA;

            return notiFiltrada;
        }).ToList();

        // Ordena por fecha descendente (aunque falta asignar el resultado)
        notificacionesConCampos.OrderByDescending(n => n.FECHA).ToList();

        return notificacionesConCampos;
    }

    // Guarda la lista de notificaciones en el archivo JSON
    public static void GuardarNotificacionesJson(List<NotificacionJson> notificaciones, string archivoJson)
    {
        // Serializa la lista con formato indentado
        string nuevoJson = Newtonsoft.Json.JsonConvert.SerializeObject(notificaciones, Newtonsoft.Json.Formatting.Indented);
        File.WriteAllText(archivoJson, nuevoJson);
    }

    // Convierte una List<NotificacionJson> a BindingList<NotificacionJson>
    // Útil para enlazar con controles de UI como DataGridView
    public static BindingList<NotificacionJson> ConvertirAListaDeBindingList(List<NotificacionJson> listaNotificaciones)
    {
        return new BindingList<NotificacionJson>(listaNotificaciones);
    }

    // Métodos para manejar Secciones en formato JSON

    // Guarda una nueva sección en el archivo JSON
    public static bool GuardarSeccionJson(SeccionJson nuevaSeccion, string archivoJson)
    {
        try
        {
            List<SeccionJson> secciones = new List<SeccionJson>();

            if (File.Exists(archivoJson))
            {
                // Carga las secciones existentes
                string jsonExistente = File.ReadAllText(archivoJson);
                secciones = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SeccionJson>>(jsonExistente) ?? new List<SeccionJson>();
            }
            else
            {
                File.WriteAllText(archivoJson, "[]");
            }

            // Agrega la nueva sección
            secciones.Add(nuevaSeccion);

            // Guarda la lista actualizada
            string nuevoJson = Newtonsoft.Json.JsonConvert.SerializeObject(secciones, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(archivoJson, nuevoJson);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    // Actualiza una sección existente
    public static bool actualizarSeccionJson(SeccionJson viejaSeccion, SeccionJson nuevaSeccion, string archivoJson)
    {
        try
        {
            List<SeccionJson> secciones = new List<SeccionJson>();

            if (File.Exists(archivoJson))
            {
                string jsonExistente = File.ReadAllText(archivoJson);
                secciones = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SeccionJson>>(jsonExistente) ?? new List<SeccionJson>();
            }
            else
            {
                File.WriteAllText(archivoJson, "[]");
            }

            // Busca la sección a actualizar
            int indice = secciones.FindIndex(s =>
                s.NOMBRE == viejaSeccion.NOMBRE &&
                s.DESCRIPCIÓN == viejaSeccion.DESCRIPCIÓN &&
                s.FILTRO == viejaSeccion.FILTRO
            );

            if (indice != -1)
            {
                // Reemplaza la sección antigua con la nueva
                secciones[indice] = nuevaSeccion;

                string nuevoJson = Newtonsoft.Json.JsonConvert.SerializeObject(secciones, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(archivoJson, nuevoJson);

                return true;
            }

            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    // Elimina una sección del archivo JSON
    public static bool eliminarSeccionJson(SeccionJson Seccion, string archivoJson)
    {
        try
        {
            List<SeccionJson> secciones = new List<SeccionJson>();

            if (File.Exists(archivoJson))
            {
                string jsonExistente = File.ReadAllText(archivoJson);
                secciones = Newtonsoft.Json.JsonConvert.DeserializeObject<List<SeccionJson>>(jsonExistente) ?? new List<SeccionJson>();
            }
            else
            {
                File.WriteAllText(archivoJson, "[]");
            }

            // Busca la sección a eliminar
            int indice = secciones.FindIndex(s =>
                s.NOMBRE == Seccion.NOMBRE &&
                s.DESCRIPCIÓN == Seccion.DESCRIPCIÓN &&
                s.FILTRO == Seccion.FILTRO
            );

            if (indice != -1)
            {
                // Elimina la sección encontrada
                secciones.RemoveAt(indice);

                string nuevoJson = Newtonsoft.Json.JsonConvert.SerializeObject(secciones, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(archivoJson, nuevoJson);

                return true;
            }

            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    // Carga todas las secciones desde el archivo JSON
    public static List<SeccionJson> cargarSeccionJson(string archivoJson)
    {
        List<SeccionJson> secciones = new List<SeccionJson>();

        if (File.Exists(archivoJson))
        {
            string json = File.ReadAllText(archivoJson);
            secciones = JsonConvert.DeserializeObject<List<SeccionJson>>(json);
        }
        else
        {
            File.WriteAllText(archivoJson, "[]");
        }

        return secciones;
    }

    // Métodos para manejar Grupos en formato JSON
    // (Similar a los métodos de Secciones)

    // Guarda un nuevo grupo en el archivo JSON
    public static bool GuardarGrupoJson(GrupoJson nuevaSeccion, string archivoJson)
    {
        try
        {
            List<GrupoJson> grupos = new List<GrupoJson>();

            if (File.Exists(archivoJson))
            {
                string jsonExistente = File.ReadAllText(archivoJson);
                grupos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<GrupoJson>>(jsonExistente) ?? new List<GrupoJson>();
            }
            else
            {
                File.WriteAllText(archivoJson, "[]");
            }

            grupos.Add(nuevaSeccion);

            string nuevoJson = Newtonsoft.Json.JsonConvert.SerializeObject(grupos, Newtonsoft.Json.Formatting.Indented);
            File.WriteAllText(archivoJson, nuevoJson);
            return true;
        }
        catch (Exception ex)
        {
            return false;
        }
    }

    // Actualiza un grupo existente
    public static bool actualizarGrupoJson(GrupoJson viejoGrupo, GrupoJson nuevoGrupo, string archivoJson)
    {
        try
        {
            List<GrupoJson> grupos = new List<GrupoJson>();

            if (File.Exists(archivoJson))
            {
                string jsonExistente = File.ReadAllText(archivoJson);
                grupos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<GrupoJson>>(jsonExistente) ?? new List<GrupoJson>();
            }
            else
            {
                File.WriteAllText(archivoJson, "[]");
            }

            // Busca el grupo por nombre
            int indice = grupos.FindIndex(g =>
                g.NOMBRE == viejoGrupo.NOMBRE
            );

            if (indice != -1)
            {
                // Reemplaza el grupo antiguo con el nuevo
                grupos[indice] = nuevoGrupo;

                string nuevoJson = Newtonsoft.Json.JsonConvert.SerializeObject(grupos, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(archivoJson, nuevoJson);

                return true;
            }

            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    // Elimina un grupo del archivo JSON
    public static bool eliminarGrupoJson(GrupoJson Grupo, string archivoJson)
    {
        try
        {
            List<GrupoJson> grupos = new List<GrupoJson>();

            if (File.Exists(archivoJson))
            {
                string jsonExistente = File.ReadAllText(archivoJson);
                grupos = Newtonsoft.Json.JsonConvert.DeserializeObject<List<GrupoJson>>(jsonExistente) ?? new List<GrupoJson>();
            }
            else
            {
                File.WriteAllText(archivoJson, "[]");
            }

            // Busca el grupo por nombre
            int indice = grupos.FindIndex(g =>
                g.NOMBRE == Grupo.NOMBRE
            );

            if (indice != -1)
            {
                // Elimina el grupo encontrado
                grupos.RemoveAt(indice);

                string nuevoJson = Newtonsoft.Json.JsonConvert.SerializeObject(grupos, Newtonsoft.Json.Formatting.Indented);
                File.WriteAllText(archivoJson, nuevoJson);

                return true;
            }

            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    // Carga todos los grupos desde el archivo JSON
    public static List<GrupoJson> cargarGrupoJson(string archivoJson)
    {
        List<GrupoJson> grupos = new List<GrupoJson>();

        if (File.Exists(archivoJson))
        {
            string json = File.ReadAllText(archivoJson);
            grupos = JsonConvert.DeserializeObject<List<GrupoJson>>(json);
        }
        else
        {
            File.WriteAllText(archivoJson, "[]");
        }

        return grupos;
    }
}