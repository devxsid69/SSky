using System;
using System.Collections;
using System.Web;
using System.Data.SqlClient;
using System.Collections.Specialized;
using System.Configuration;
using System.Web.Configuration;
using System.Collections.Generic;
using System.Configuration.Provider;
using System.Security.Permissions;
using System.Data.Common;
using System.Data;
using System.Web.Caching;
using System.Web.SessionState;
using System.Web.Services;

using System.Threading;


namespace SecurityProvider
{
    [SqlClientPermission(SecurityAction.Demand, Unrestricted = true)]
    public class WTCSiteMapProvider : StaticSiteMapProvider
    {
        #region Vars
        private const string _errmsg1 = "Missing node ID";
        private const string _errmsg2 = "Duplicate node ID";
        private const string _errmsg3 = "Missing parent ID";
        private const string _errmsg4 = "Invalid parent ID";
        private const string _errmsg5 = "Empty or missing connectionStringName";
        private const string _errmsg6 = "Missing connection string";
        private const string _errmsg7 = "Empty connection string";
        private const string _errmsg8 = "Invalid sqlCacheDependency";
        private const string _cacheDependencyName = "__SiteMapCacheDependency";

        private string _connect;              // Database connection string
        private string _database, _table;     // Database info for SQL Server 7/2000 cache dependency
        private bool _2005dependency = true; // Database info for SQL Server 2005 cache dependency
        private int _indexID, _indexTitle, _indexTitulo, _indexUrl, _indexDesc, _indexDescripcion, _indexRoles, _indexParent, _indexOrder;

        private Dictionary<int, SiteMapNode> _nodes = new Dictionary<int, SiteMapNode>(16);
        private Dictionary<int, string> _nodesEsp = new Dictionary<int, string>(16);
        private Dictionary<int, string> _nodesEn = new Dictionary<int, string>(16);

        private readonly object _lock = new object();
        private SiteMapNode _root;
        #endregion

        public override void Initialize(string name, NameValueCollection config)
        {
            // Verify that config isn't null
            if (config == null)
                throw new ArgumentNullException("config");

            // Assign the provider a default name if it doesn't have one
            if (String.IsNullOrEmpty(name))
                name = "SqlSiteMapProvider";

            // Add a default "description" attribute to config if the
            // attribute doesn�t exist or is empty
            if (string.IsNullOrEmpty(config["description"]))
            {
                config.Remove("description");
                config.Add("description", "SQL site map provider");
            }
            this.EnableLocalization = true;
            this.ResourceKey = "ResourceProvider";

            // Call the base class's Initialize method
            base.Initialize(name, config);

            // Initialize _connect
            string connect = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["DataAccessMode"]].ConnectionString;
            //config["connectionStringName"];

            if (String.IsNullOrEmpty(connect))
                throw new ProviderException(_errmsg5);

            // Connnection string is from another resource
            config.Remove("connectionStringName");

            //if (WebConfigurationManager.ConnectionStrings[connect] == null)
            //    throw new ProviderException(_errmsg6);

            _connect = ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["DataAccessMode"]].ConnectionString;
            //    WebConfigurationManager.ConnectionStrings[connect].ConnectionString;

            if (String.IsNullOrEmpty(_connect))
                throw new ProviderException(_errmsg7);

            // Initialize SQL cache dependency info
            string dependency = config["sqlCacheDependency"];

            if (!String.IsNullOrEmpty(dependency))
            {
                if (String.Equals(dependency, "CommandNotification", StringComparison.InvariantCultureIgnoreCase))
                {
                    SqlDependency.Start(_connect);
                    _2005dependency = true;
                }
                else
                {
                    // If not "CommandNotification", then extract database and table names
                    string[] info = dependency.Split(new char[] { ':' });
                    if (info.Length != 2)
                        throw new ProviderException(_errmsg8);

                    _database = info[0];
                    _table = info[1];
                }

                config.Remove("sqlCacheDependency");
            }

            // SiteMapProvider processes the securityTrimmingEnabled
            // attribute but fails to remove it. Remove it now so we can
            // check for unrecognized configuration attributes.

            if (config["securityTrimmingEnabled"] != null)
                config.Remove("securityTrimmingEnabled");

            // Throw an exception if unrecognized attributes remain
            if (config.Count > 0)
            {
                string attr = config.GetKey(0);
                if (!String.IsNullOrEmpty(attr))
                    throw new ProviderException("Unrecognized attribute: " + attr);
            }
        }

        private SiteMapNode ChangeCultureSiteMap(SiteMapNode rootToChange, string uiCulture)
        {

            if (!rootToChange.HasChildNodes)
                return rootToChange;

            foreach (SiteMapNode node in rootToChange.GetAllNodes())
            {
                if (Thread.CurrentThread.CurrentUICulture.Name.Contains("es"))
                {
                    if (_nodesEsp.ContainsKey(int.Parse(node.Key)))
                    {
                        node.Title = _nodesEsp[int.Parse(node.Key)];
                        node.Description = _nodesEsp[int.Parse(node.Key)];
                    }
                }
                else if (Thread.CurrentThread.CurrentUICulture.Name.Contains("en"))
                {
                    if (_nodes.ContainsKey(int.Parse(node.Key)))
                    {
                        node.Title = _nodesEn[int.Parse(node.Key)];
                        node.Description = _nodesEn[int.Parse(node.Key)];
                    }
                }


            }
            return rootToChange;
        }

        public override SiteMapNode BuildSiteMap()
        {

            //Aqui va el Application 

            lock (_lock)
            {

                // Return immediately if this method has been called before
                if (HttpContext.Current.Application["IdWebApplication"] == null && _root != null)
                {
                    //Checar cultura y regresal el root corecto
                    //return Thread.CurrentThread.CurrentUICulture.Name.Contains("es") ? ChangeCultureSiteMap(_root) : _root;
                    return _root;
                }

                //    return (SiteMapNode)HttpContext.Current.Application["SiteMap"];
                //else
                //    SiteMapChanged();
                if (_root != null)
                {
                    //Checar cultura y regresal el root corecto

                    return _root;
                }


                // Query the database for site map nodes
                SqlConnection connection = new SqlConnection(_connect);

                try
                {
                    SqlCommand command = new SqlCommand("st_GetSiteMapByIdWebApplication", connection);
                    command.CommandType = CommandType.StoredProcedure;
                    SqlParameter sqlpaar = new SqlParameter("@IdWebApplication", SqlDbType.Int);
                    sqlpaar.Value = HttpContext.Current.Application["IdWebApplication"];
                    sqlpaar.Direction = ParameterDirection.Input;
                    command.Parameters.Add(sqlpaar);


                    // Create a SQL cache dependency if requested
                    SqlCacheDependency dependency = null;

                    SqlCommand select = new SqlCommand("SELECT [dbo].[tbl_Roles_SiteMap].[IdRole] ,[dbo].[tbl_Roles_SiteMap].[IdSiteMap]  FROM [dbo].[tbl_Roles_SiteMap]", connection);


                    if (_2005dependency)
                    {
                        //dependency = new SqlCacheDependency(command);
                        dependency = new SqlCacheDependency(select);
                        // need to call Static Start method if no options specified,
                        // prior to getting any data from command.
                        SqlDependency.Start(connection.ConnectionString);

                    }
                    else if (!String.IsNullOrEmpty(_database) && !string.IsNullOrEmpty(_table))
                    {
                        dependency = new SqlCacheDependency(_database, _table);
                    }

                    //if (_2005dependency)
                    //    dependency = new SqlCacheDependency(selectcmd);
                    //else if (!String.IsNullOrEmpty(_database) && !string.IsNullOrEmpty(_table))
                    //    dependency = new SqlCacheDependency(_database, _table);

                    connection.Open();
                    SqlDataReader parse = select.ExecuteReader();

                    connection.Close();

                    //connection.Open();
                    //select.ExecuteReader();
                    //connection.Close();
                    connection.Open();

                    SqlDataReader reader = command.ExecuteReader();
                    _indexID = reader.GetOrdinal("IdSiteMap");
                    _indexTitle = reader.GetOrdinal("Title");
                    _indexDesc = reader.GetOrdinal("Description");
                    _indexUrl = reader.GetOrdinal("URL");
                    _indexOrder = reader.GetOrdinal("SiteMapOrder");
                    _indexParent = reader.GetOrdinal("IdSiteMapParent");
                    _indexRoles = reader.GetOrdinal("Roles");
                    _indexTitulo = reader.GetOrdinal("Title");
                    _indexDescripcion = reader.GetOrdinal("Description");

                    if (reader.HasRows)
                    {
                        // Create the root SiteMapNode and add it to the site map
                        //_root = CreateSiteMapNodeFromDataReader(reader);
                        //AddNode(_root, null);


                        _root = CreateRoot();
                        AddNode(_root, null);

                        // Build a tree of SiteMapNodes underneath the root node
                        while (reader.Read())
                        {
                            // Create another site map node and add it to the site map
                            SiteMapNode node = CreateSiteMapNodeFromDataReader(reader);
                            AddNode(node, GetParentNodeFromDataReader(reader));


                        }

                        // Use the SQL cache dependency
                        if (dependency != null)
                        {
                            HttpRuntime.Cache.Insert(_cacheDependencyName, new object(), dependency,
                                                     Cache.NoAbsoluteExpiration, Cache.NoSlidingExpiration, CacheItemPriority.NotRemovable,
                                                     new CacheItemRemovedCallback(OnSiteMapChanged));
                        }

                    }
                }
                finally
                {
                    connection.Close();
                }
                // Return the root SiteMapNode
                ////if (Thread.CurrentThread.CurrentUICulture.Name.Contains("es"))
                ////    return _rootEsp;
                return _root;
            }
        }

        public override bool IsAccessibleToUser(HttpContext context, SiteMapNode node)
        {

            //If Security Trimming is not enabled return true
            if (!SecurityTrimmingEnabled)
                return true;

            //If there are no roles defined for the page
            //return true or false depending on your authorization scheme (when true pages with
            //no roles are visible to all users, when false no user can access these pages)
            if (node.Roles == null || node.Roles.Count == 0)
                return false;


            if (node == _root) //everyone has acces to level 0
                return true;

            //check each role, if the user is in any of the roles return true
            foreach (string role in node.Roles)
            {
                if (context.User.IsInRole(role) || String.Equals(role, "*", StringComparison.InvariantCultureIgnoreCase))
                    return true;
            }

            return false;
        }

        protected override SiteMapNode GetRootNodeCore()
        {
            lock (_lock)
            {

                BuildSiteMap();
                return ChangeCultureSiteMap(_root, Thread.CurrentThread.CurrentUICulture.Name);
            }
        }

        private SiteMapNode CreateRoot()
        {
            // If roles were specified, turn the list into a string array
            WTCRoleProvider _operation = new WTCRoleProvider();
            //string roles = ""
            string[] rolelist = _operation.GetAllRoles(); ;
            //if (!String.IsNullOrEmpty(roles))
            //    rolelist = roles.Split(new char[] { ',', ';' }, 512);

            // Create a SiteMapNode
            SiteMapNode node = new SiteMapNode(this, "0", "", "Root", "0", rolelist, null, null, null);

            // Record the node in the _nodes dictionary
            _nodes.Add(0, node);



            // Return the node        
            return node;
        }

        // Helper methods
        private SiteMapNode CreateSiteMapNodeFromDataReader(DbDataReader reader)
        {

            // Make sure the node ID is present
            if (reader.IsDBNull(_indexID))
                throw new ProviderException(_errmsg1);

            // Get the node ID from the DataReader
            int id = reader.GetInt32(_indexID);

            // Make sure the node ID is unique
            if (_nodes.ContainsKey(id))
                throw new ProviderException(_errmsg2);

            // Get title, URL, description, and roles from the DataReader
            string title = reader.IsDBNull(_indexTitle) ? null : reader.GetString(_indexTitle).Trim();
            string titleEs = reader.IsDBNull(_indexTitulo) ? null : reader.GetString(_indexTitulo).Trim();
            string url = reader.IsDBNull(_indexUrl) ? null : reader.GetString(_indexUrl).Trim();
            string description = reader.IsDBNull(_indexDesc) ? null : reader.GetString(_indexDesc).Trim();
            string descriptionEs = reader.IsDBNull(_indexDescripcion) ? null : reader.GetString(_indexDescripcion).Trim();
            string roles = reader.IsDBNull(_indexRoles) ? null : reader.GetString(_indexRoles).Trim();
            //}
            // If roles were specified, turn the list into a string array
            string[] rolelist = null;
            if (!String.IsNullOrEmpty(roles))
                rolelist = roles.Split(new char[] { ',', ';' }, 512);

            // Create a SiteMapNode
            SiteMapNode node = new SiteMapNode(this, id.ToString(), url, title, description, rolelist, null, null, null);

            _nodesEsp.Add(id, titleEs);
            _nodesEn.Add(id, title);
            // Record the node in the _nodes dictionary
            _nodes.Add(id, node);

            // Return the node        
            return node;
        }

        private SiteMapNode GetParentNodeFromDataReader(DbDataReader reader)
        {
            // Make sure the parent ID is present
            if (reader.IsDBNull(_indexParent))
                //throw new ProviderException(_errmsg3);
                return null;

            // Get the parent ID from the DataReader
            int pid = reader.GetInt32(_indexParent);

            // Make sure the parent ID is valid
            if (!_nodes.ContainsKey(pid))
                return null;

            // Return the parent SiteMapNode
            return _nodes[pid];
        }

        void OnSiteMapChanged(string key, object item, CacheItemRemovedReason reason)
        {
            lock (_lock)
            {
                if (key == _cacheDependencyName)
                {
                    // Refresh the site map
                    Clear();
                    _nodes.Clear();
                    _nodesEsp.Clear();
                    _nodesEn.Clear();
                    _root = null;
                }
            }
        }

    }
}
