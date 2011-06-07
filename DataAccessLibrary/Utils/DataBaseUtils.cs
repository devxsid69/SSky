using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data.Linq;
using System.Linq;
using System.Text;
using System.Threading;
using System.Web;

using DataAccessLibrary.Repository;

namespace DataAccessLibrary.Utils
{
    public class RepositoryKeys
    {
        private Type _repositoryType;

        public Type RepositoryType
        {
            get { return _repositoryType; }
            set { _repositoryType = value; }
        }
        private string _key;

        public string Key
        {
            get { return _key; }
            set { _key = value; }
        }
    }

    internal static class DataBaseUtils
    {
        public static TCRepositoryDataContext GetContext()
        {

            return DataContextFactory.GetWebRequestScopedDataContext<TCRepositoryDataContext>(ConnnectionStringFactory());
        }

        private static string ConnnectionStringFactory()
        {
            return ConfigurationManager.ConnectionStrings[ConfigurationManager.AppSettings["DataAccessMode"]].ConnectionString;
        }

        private class DataContextFactory
        {
            /// <summary>
            /// Creates a new Data Context for a specific DataContext type
            /// 
            /// Provided merely for compleness sake here - same as new YourDataContext()
            /// </summary>
            /// <typeparam name="TDataContext"></typeparam>
            /// <returns></returns>
            public static TDataContext GetDataContext<TDataContext>()
                    where TDataContext : DataContext, new()
            {
                return (TDataContext)Activator.CreateInstance<TDataContext>();
            }

            /// <summary>
            /// Creates a new Data Context for a specific DataContext type with a connection string
            /// 
            /// Provided merely for compleness sake here - same as new YourDataContext()
            /// </summary>
            /// <typeparam name="TDataContext"></typeparam>
            /// <param name="connectionString"></param>
            /// <returns></returns>
            public static TDataContext GetDataContext<TDataContext>(string connectionString)
                    where TDataContext : DataContext, new()
            {
                Type t = typeof(TDataContext);
                return (TDataContext)Activator.CreateInstance(t, connectionString);
            }


            /// <summary>
            /// Creates a ASP.NET Context scoped instance of a DataContext. This static
            /// method creates a single instance and reuses it whenever this method is
            /// called.
            /// 
            /// This version creates an internal request specific key shared key that is
            /// shared by each caller of this method from the current Web request.
            /// </summary>
            public static TDataContext GetWebRequestScopedDataContext<TDataContext>()
                    where TDataContext : DataContext, new()
            {
                // *** Create a request specific unique key 
                return (TDataContext)GetWebRequestScopedDataContextInternal(typeof(TDataContext), null, null);
            }

            /// <summary>
            /// Creates a ASP.NET Context scoped instance of a DataContext. This static
            /// method creates a single instance and reuses it whenever this method is
            /// called.
            /// 
            /// This version lets you specify a specific key so you can create multiple 'shared'
            /// DataContexts explicitly.
            /// </summary>
            /// <typeparam name="TDataContext"></typeparam>

            /// <returns></returns>
            public static TDataContext GetWebRequestScopedDataContext<TDataContext>(string connectionString)
                                       where TDataContext : DataContext, new()
            {
                return (TDataContext)GetWebRequestScopedDataContextInternal(typeof(TDataContext), null, connectionString);
            }



            /// <summary>
            /// 
            /// </summary>
            /// <typeparam name="TDataContext"></typeparam>
            /// <param name="key"></param>
            /// <param name="connectionString"></param>
            /// <returns></returns>
            public static TDataContext GetWebRequestScopedDataContext<TDataContext>(RepositoryKeys key, string connectionString)
                                       where TDataContext : DataContext, new()
            {
                return (TDataContext)GetWebRequestScopedDataContextInternal(typeof(TDataContext), key, connectionString);
            }

            /// <summary>
            /// Internal method that handles creating a context that is scoped to the HttpContext Items collection
            /// by creating and holding the DataContext there.
            /// </summary>
            /// <param name="type"></param>
            /// <param name="key"></param>
            /// <param name="connectionString"></param>
            /// <returns></returns>
            static object GetWebRequestScopedDataContextInternal(Type type, RepositoryKeys key, string connectionString)
            {
                object context;

                if (HttpContext.Current == null)
                {
                    if (connectionString == null)
                        context = Activator.CreateInstance(type);
                    else
                        context = Activator.CreateInstance(type, connectionString);

                    return context;
                }

                // *** Create a unique Key for the Web Request/Context 

                if (key == null)
                {

                    key = new RepositoryKeys
                    {
                        RepositoryType = type,
                        Key = "__WRSCDC_" + HttpContext.Current.GetHashCode().ToString("x") + Thread.CurrentContext.ContextID.ToString()
                    };

                }

                context = HttpContext.Current.Items[String.Format("{0}{1}", key.Key, key.RepositoryType.ToString())];
                if (context == null)
                {
                    if (connectionString == null)
                        context = Activator.CreateInstance(type);
                    else
                        context = Activator.CreateInstance(type, connectionString);

                    if (context != null)
                        HttpContext.Current.Items[String.Format("{0}{1}", key.Key, key.RepositoryType.ToString())] = context;
                }

                return context;
            }


            /// <summary>
            /// Creates a Thread Scoped DataContext object that can be reused.
            /// The DataContext is stored in Thread local storage.
            /// </summary>
            /// <typeparam name="TDataContext"></typeparam>
            /// <param name="key"></param>
            /// <returns></returns>
            public static TDataContext GetThreadScopedDataContext<TDataContext>()
                                       where TDataContext : DataContext, new()
            {
                return (TDataContext)GetThreadScopedDataContextInternal(typeof(TDataContext), null, null);
            }


            /// <summary>
            /// Creates a Thread Scoped DataContext object that can be reused.
            /// The DataContext is stored in Thread local storage.
            /// </summary>
            /// <typeparam name="TDataContext"></typeparam>
            /// <param name="key"></param>
            /// <returns></returns>
            public static TDataContext GetThreadScopedDataContext<TDataContext>(RepositoryKeys key)
                                       where TDataContext : DataContext, new()
            {
                return (TDataContext)GetThreadScopedDataContextInternal(typeof(TDataContext), key, null);
            }


            /// <summary>
            /// Creates a Thread Scoped DataContext object that can be reused.
            /// The DataContext is stored in Thread local storage.
            /// </summary>
            /// <typeparam name="TDataContext"></typeparam>
            /// <param name="key"></param>
            /// <returns></returns>
            static object GetThreadScopedDataContextInternal(Type type, RepositoryKeys key, string ConnectionString)
            {
                if (key == null)
                {
                    key = new RepositoryKeys
                    {
                        RepositoryType = type,
                        Key = "__WRSCDC_" + Thread.CurrentContext.ContextID.ToString()
                    };

                }


                LocalDataStoreSlot threadData = Thread.GetNamedDataSlot(String.Format("{0}{1}", key.Key, key.RepositoryType.ToString()));
                object context = null;
                if (threadData != null)
                    context = Thread.GetData(threadData);

                if (context == null)
                {
                    if (ConnectionString == null)
                        context = Activator.CreateInstance(type);
                    else
                        context = Activator.CreateInstance(type, ConnectionString);

                    if (context != null)
                    {
                        if (threadData == null)
                            threadData = Thread.AllocateNamedDataSlot(key.Key);

                        Thread.SetData(threadData, context);
                    }
                }

                return context;
            }


            /// <summary>
            /// Returns either Web Request scoped DataContext or a Thread scoped
            /// request object if not running a Web request (ie. HttpContext.Current)
            /// is not available.
            /// </summary>
            /// <typeparam name="TDataContext"></typeparam>
            /// <param name="key"></param>
            /// <param name="ConnectionString"></param>
            /// <returns></returns>
            public static TDataContext GetScopedDataContext<TDataContext>(RepositoryKeys key, string connectionString)
            {
                if (HttpContext.Current != null)
                    return (TDataContext)GetWebRequestScopedDataContextInternal(typeof(TDataContext), key, connectionString);

                return (TDataContext)GetThreadScopedDataContextInternal(typeof(TDataContext), key, connectionString);
            }

            /// <summary>
            /// Returns either Web Request scoped DataContext or a Thread scoped
            /// request object if not running a Web request (ie. HttpContext.Current)
            /// is not available.
            /// </summary>
            /// <typeparam name="TDataContext"></typeparam>
            /// <param name="key"></param>
            /// <returns></returns>
            public static TDataContext GetScopedDataContext<TDataContext>(RepositoryKeys key)
            {
                if (HttpContext.Current != null)
                    return (TDataContext)GetWebRequestScopedDataContextInternal(typeof(TDataContext), key, null);

                return (TDataContext)GetThreadScopedDataContextInternal(typeof(TDataContext), key, null);
            }

            /// <summary>
            /// Returns either Web Request scoped DataContext or a Thread scoped
            /// request object if not running a Web request (ie. HttpContext.Current)
            /// is not available.
            /// </summary>
            /// <typeparam name="TDataContext"></typeparam>
            /// <param name="key"></param>
            /// <returns></returns>
            public static TDataContext GetScopedDataContext<TDataContext>()
            {
                if (HttpContext.Current != null)
                    return (TDataContext)GetWebRequestScopedDataContextInternal(typeof(TDataContext), null, null);

                return (TDataContext)GetThreadScopedDataContextInternal(typeof(TDataContext), null, null);
            }

        }
    }
}
