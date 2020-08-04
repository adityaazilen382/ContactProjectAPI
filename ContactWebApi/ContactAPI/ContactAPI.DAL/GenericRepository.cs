namespace ContactAPI.DAL
{
    using Common;
    using Dapper;
    using System;
    using System.Collections.Generic;
    using System.Data;
    using System.Linq;
    using System.Reflection;

    /// <summary>
    /// Defines the <see cref="GenericRepository{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public class GenericRepository<T> : DBConnection, IGenericRepository<T> where T : class
    {
        /// <summary>
        /// The Get
        /// </summary>
        /// <param name="id">The id<see cref="long"/></param>
        /// <param name="storedProcedure">The storedProcedure<see cref="string"/></param>
        /// <returns>The <see cref="T"/></returns>
        public virtual T Get(long id, string storedProcedure)
        {
            T model = default(T);
            try
            {
                using (var connection = SQLConnection)
                {
                    model = connection.Query<T>(storedProcedure, new
                    {
                        ID = id
                    }, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteError("GenericRepository:Get" + ex.Message);
            }

            return model;
        }

        /// <summary>
        /// The GetByParam
        /// </summary>
        /// <param name="parameters">The parameters<see cref="object"/></param>
        /// <param name="storedProcedure">The storedProcedure<see cref="string"/></param>
        /// <returns>The <see cref="T"/></returns>
        public T GetByParam(object parameters, string storedProcedure)
        {
            T model = default(T);
            try
            {
                using (var connection = SQLConnection)
                {
                    model = connection.Query<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteError("GenericRepository:GetByParam" + ex.Message);
            }

            return model;
        }

        /// <summary>
        /// The GetAll
        /// </summary>
        /// <param name="parameters">The parameters<see cref="object"/></param>
        /// <param name="storedProcedure">The storedProcedure<see cref="string"/></param>
        /// <returns>The <see cref="IEnumerable{T}"/></returns>
        public IEnumerable<T> GetAll(object parameters, string storedProcedure)
        {
            List<T> listT = new List<T>();

            try
            {
                using (var connection = SQLConnection)
                {
                    listT = connection.Query<T>(storedProcedure, parameters, commandType: CommandType.StoredProcedure).ToList();
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteError("GenericRepository:GetAll" + ex.Message);
            }

            return listT;
        }



        public IEnumerable<T> GetAll(object parameters, string storedProcedure, out bool result, out string errorMessage, out string errorCode)
        {
            List<T> listT = new List<T>();

            errorMessage = string.Empty;
            errorCode = string.Empty;
            result = false;
            try
            {
                var param = new DynamicParameters();
                foreach (PropertyInfo obj in parameters.GetType().GetProperties())
                {
                    param.Add(obj.Name, obj.GetValue(parameters));
                }

                using (var connection = SQLConnection)
                {
                    param.Add("ErrorCode", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                    param.Add("ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 250);
                    param.Add("Result", dbType: DbType.Boolean, direction: ParameterDirection.Output, size: 250);

                    listT = connection.Query<T>(storedProcedure, param, commandType: CommandType.StoredProcedure).ToList();
                    errorMessage = param.Get<string>("ErrorMessage");
                    errorCode = param.Get<string>("ErrorCode");
                    result = param.Get<bool>("Result");
                }

            }
            catch (Exception ex)
            {
                LogManager.WriteError("GenericRepository:GetAll" + ex.Message);
            }
            return listT;
        }


        public T GetByParam(object parameters, string storedProcedure, out bool result, out string errorMessage, out string errorCode)
        {
            T model = default(T);

            errorMessage = string.Empty;
            errorCode = string.Empty;
            result = false;
            try
            {
                var param = new DynamicParameters();
                foreach (PropertyInfo obj in parameters.GetType().GetProperties())
                {
                    param.Add(obj.Name, obj.GetValue(parameters));
                }

                using (var connection = SQLConnection)
                {
                    param.Add("ErrorCode", dbType: DbType.String, direction: ParameterDirection.Output, size: 100);
                    param.Add("ErrorMessage", dbType: DbType.String, direction: ParameterDirection.Output, size: 250);
                    param.Add("Result", dbType: DbType.Boolean, direction: ParameterDirection.Output, size: 250);
                    model = connection.Query<T>(storedProcedure, param, commandType: CommandType.StoredProcedure).FirstOrDefault();
                    errorMessage = param.Get<string>("ErrorMessage");
                    errorCode = param.Get<string>("ErrorCode");
                    result = param.Get<bool>("Result");
                }
            }
            catch (Exception ex)
            {
                LogManager.WriteError("GenericRepository:GetByParam" + ex.Message);
            }

            return model;
        }
    }
}
