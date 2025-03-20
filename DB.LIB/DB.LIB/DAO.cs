using System;
using System.Collections.Generic;
using System.Data;
using System.Reflection;
using System.Linq;
using System.Text;

namespace DB.LIB
{
    public class DAO : Connexion, IDAO<object>
    {
        public int id = 0;
        public string sql = "";
        
        public DAO()
        {
            using (Connexion connexion = new Connexion())
            {
                connexion.Connect();
            }
        }
        
        public Dictionary<string, object> ObjectToDictionary()
        {
            Dictionary<string, object> dict = new Dictionary<string, object>();
            
            Type type = this.GetType();
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Instance);
            
            foreach (PropertyInfo property in properties)
            {
                dict.Add(property.Name, property.GetValue(this));
            }
            
            return dict;
        }
        
        public object DictionaryToObject(Dictionary<string, object> dico)
        {
            Type type = this.GetType();
            
            foreach (var item in dico)
            {
                PropertyInfo property = type.GetProperty(item.Key);
                if (property != null && property.CanWrite)
                {
                    if (item.Value == DBNull.Value)
                        property.SetValue(this, null);
                    else
                        property.SetValue(this, item.Value);
                }
            }
            
            return this;
        }
        

        private string GetTableName()
        {
            return this.GetType().Name;
        }
        
        
        private string PropertyToColumnName(string propertyName)
        {
            if (propertyName == "Id") return "id";
            
            StringBuilder result = new StringBuilder();
            
            for (int i = 0; i < propertyName.Length; i++)
            {
                if (i > 0 && char.IsUpper(propertyName[i]))
                    result.Append('_');
                result.Append(char.ToLower(propertyName[i]));
            }
            
            return result.ToString();
        }
        
       
        private string ColumnToPropertyName(string columnName)
        {
            if (columnName == "id") return "Id";
            
            string[] parts = columnName.Split('_');
            StringBuilder result = new StringBuilder();
            
            foreach (string part in parts)
            {
                if (!string.IsNullOrEmpty(part))
                {
                    result.Append(char.ToUpper(part[0]));
                    if (part.Length > 1)
                        result.Append(part.Substring(1));
                }
            }
            
            return result.ToString();
        }

        public virtual int insert()
        {
            Connect();
            
            Dictionary<string, object> properties = ObjectToDictionary();
            string tableName = GetTableName();
            

            if (properties.ContainsKey("Id") && (Convert.ToInt32(properties["Id"]) <= 0))
            {
                properties.Remove("Id");
            }
            

            List<string> columns = new List<string>();
            List<string> parameters = new List<string>();
            Dictionary<string, object> paramDict = new Dictionary<string, object>();
            
            foreach (var prop in properties)
            {
                if (prop.Key != "sql")  
                {
                    columns.Add(PropertyToColumnName(prop.Key));
                    parameters.Add("@" + prop.Key);
                    paramDict.Add("@" + prop.Key, prop.Value);
                }
            }
            
            sql = $"INSERT INTO {tableName} ({string.Join(", ", columns)}) VALUES ({string.Join(", ", parameters)}) RETURNING id";
            
            using (IDataReader reader = select(sql, paramDict))
            {
                if (reader.Read())
                {
                    id = Convert.ToInt32(reader[0]);

                    PropertyInfo idProp = this.GetType().GetProperty("Id");
                    if (idProp != null && idProp.CanWrite)
                    {
                        idProp.SetValue(this, id);
                    }
                }
            }
            
            return id;
        }
        
        public virtual int update()
        {

            PropertyInfo idProp = this.GetType().GetProperty("Id");
            if (idProp == null || Convert.ToInt32(idProp.GetValue(this)) <= 0)
                throw new Exception($"L'objet {GetTableName()} doit avoir un ID valide pour être mis à jour.");
            
            Connect();
            
            Dictionary<string, object> properties = ObjectToDictionary();
            string tableName = GetTableName();
            int objectId = Convert.ToInt32(properties["Id"]);
            

            List<string> setStatements = new List<string>();
            Dictionary<string, object> paramDict = new Dictionary<string, object>();
            
            foreach (var prop in properties)
            {
                if (prop.Key != "Id" && prop.Key != "sql")  // Ignorer les propriétés Id et sql
                {
                    setStatements.Add($"{PropertyToColumnName(prop.Key)} = @{prop.Key}");
                    paramDict.Add("@" + prop.Key, prop.Value);
                }
            }
            
            paramDict.Add("@Id", objectId);
            
            sql = $"UPDATE {tableName} SET {string.Join(", ", setStatements)} WHERE id = @Id";
            
            return iud(sql, paramDict);
        }
        
        public virtual int delete()
        {

            PropertyInfo idProp = this.GetType().GetProperty("Id");
            if (idProp == null || Convert.ToInt32(idProp.GetValue(this)) <= 0)
                throw new Exception($"L'objet {GetTableName()} doit avoir un ID valide pour être supprimé.");
            
            Connect();
            
            int objectId = Convert.ToInt32(idProp.GetValue(this));
            string tableName = GetTableName();
            
            sql = $"DELETE FROM {tableName} WHERE id = @Id";
            
            Dictionary<string, object> paramDict = new Dictionary<string, object>
            {
                { "@Id", objectId }
            };
            
            return iud(sql, paramDict);
        }
        
        public virtual object findById()
        {
            // Vérifier que nous avons un ID valide
            PropertyInfo idProp = this.GetType().GetProperty("Id");
            if (idProp == null || Convert.ToInt32(idProp.GetValue(this)) <= 0)
                throw new Exception($"L'ID de l'objet {GetTableName()} doit être valide pour effectuer la recherche.");
            
            Connect();
            
            int objectId = Convert.ToInt32(idProp.GetValue(this));
            string tableName = GetTableName();
            
            sql = $"SELECT * FROM {tableName} WHERE id = @Id";
            
            Dictionary<string, object> paramDict = new Dictionary<string, object>
            {
                { "@Id", objectId }
            };
            
            using (IDataReader reader = select(sql, paramDict))
            {
                if (reader.Read())
                {
                    Dictionary<string, object> dico = new Dictionary<string, object>();
                    
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string columnName = reader.GetName(i);
                        string propertyName = ColumnToPropertyName(columnName);
                        dico.Add(propertyName, reader[columnName]);
                    }
                    
                    return DictionaryToObject(dico);
                }
            }
            
            return null;
        }
        
        public virtual List<object> findAll()
        {
            Connect();
            
            string tableName = GetTableName();
            List<object> results = new List<object>();
            
            // Par défaut, on trie par le champ "nom" s'il existe, sinon par "id"
            string orderBy = "id";
            PropertyInfo[] properties = this.GetType().GetProperties();
            if (properties.Any(p => p.Name.ToLower() == "nom"))
            {
                orderBy = "nom";
            }
            
            sql = $"SELECT * FROM {tableName} ORDER BY {orderBy}";
            
            using (IDataReader reader = select(sql))
            {
                while (reader.Read())
                {
                    // Créer une nouvelle instance du même type que l'objet courant
                    object instance = Activator.CreateInstance(this.GetType());
                    Dictionary<string, object> dico = new Dictionary<string, object>();
                    
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string columnName = reader.GetName(i);
                        string propertyName = ColumnToPropertyName(columnName);
                        dico.Add(propertyName, reader[columnName]);
                    }
                    
                    // Convertir le dictionnaire en objet et l'ajouter à la liste
                    ((DAO)instance).DictionaryToObject(dico);
                    results.Add(instance);
                }
            }
            
            return results;
        }
        
        public virtual List<object> find()
        {
            Connect();
            
            string tableName = GetTableName();
            Dictionary<string, object> properties = ObjectToDictionary();
            List<object> results = new List<object>();
            
            // Construire la requête de recherche conditionnelle
            List<string> conditions = new List<string>();
            Dictionary<string, object> paramDict = new Dictionary<string, object>();
            
            foreach (var prop in properties)
            {
                if (prop.Key != "Id" && prop.Key != "sql" && prop.Value != null && !string.IsNullOrEmpty(prop.Value.ToString()))
                {
                    // Pour les chaînes, on utilise LIKE
                    if (prop.Value is string)
                    {
                        conditions.Add($"{PropertyToColumnName(prop.Key)} LIKE @{prop.Key}");
                        paramDict.Add("@" + prop.Key, "%" + prop.Value + "%");
                    }
                    else // Pour les autres types, on utilise l'égalité
                    {
                        conditions.Add($"{PropertyToColumnName(prop.Key)} = @{prop.Key}");
                        paramDict.Add("@" + prop.Key, prop.Value);
                    }
                }
            }
            
            // Si aucune condition n'est définie, on retourne tous les résultats
            if (conditions.Count == 0)
            {
                return findAll();
            }
            
            // Par défaut, on trie par le champ "nom" s'il existe, sinon par "id"
            string orderBy = "id";
            PropertyInfo[] allProperties = this.GetType().GetProperties();
            if (allProperties.Any(p => p.Name.ToLower() == "nom"))
            {
                orderBy = "nom";
            }
            
            sql = $"SELECT * FROM {tableName} WHERE {string.Join(" OR ", conditions)} ORDER BY {orderBy}";
            
            using (IDataReader reader = select(sql, paramDict))
            {
                while (reader.Read())
                {
                    // Créer une nouvelle instance du même type que l'objet courant
                    object instance = Activator.CreateInstance(this.GetType());
                    Dictionary<string, object> dico = new Dictionary<string, object>();
                    
                    for (int i = 0; i < reader.FieldCount; i++)
                    {
                        string columnName = reader.GetName(i);
                        string propertyName = ColumnToPropertyName(columnName);
                        dico.Add(propertyName, reader[columnName]);
                    }
                    
                    // Convertir le dictionnaire en objet et l'ajouter à la liste
                    ((DAO)instance).DictionaryToObject(dico);
                    results.Add(instance);
                }
            }
            
            return results;
        }
    }
}