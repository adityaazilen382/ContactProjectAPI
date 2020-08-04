namespace ContactAPI.DAL
{
    using System.Collections.Generic;

    /// <summary>
    /// Defines the <see cref="IGenericRepository{T}" />
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IGenericRepository<T> where T : class
    {
        /// <summary>
        /// The Get
        /// </summary>
        /// <param name="id">The id<see cref="long"/></param>
        /// <param name="storedProcedure">The storedProcedure<see cref="string"/></param>
        /// <returns>The <see cref="T"/></returns>
        T Get(long id, string storedProcedure);

        /// <summary>
        /// The GetParam
        /// </summary>
        /// <param name="parameters">The parameters<see cref="object"/></param>
        /// <param name="storedProcedure">The storedProcedure<see cref="string"/></param>
        /// <returns>The <see cref="T"/></returns>
        T GetByParam(object parameters, string storedProcedure);

        /// <summary>
        /// The GetAll
        /// </summary>
        /// <param name="parameters">The parameters<see cref="object"/></param>
        /// <param name="storedProcedure">The storedProcedure<see cref="string"/></param>
        /// <returns>The <see cref="IEnumerable{T}"/></returns>
        IEnumerable<T> GetAll(object parameters, string storedProcedure);


        IEnumerable<T> GetAll(object parameters, string storedProcedure, out bool isError, out string errorMessage, out string errorCode);

        T GetByParam(object parameters, string storedProcedure, out bool isError, out string errorMessage, out string errorCode);
    }
}
