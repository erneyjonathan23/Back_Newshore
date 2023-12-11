// ***********************************************************************
// Assembly         : OP.Prueba.WebAPI
// Author           : Jonathan Puerta
// Created          : 10-12-2023
//
// Last Modified By : Jonathan Puerta
// Last Modified On : Jonathan Puerta
// ***********************************************************************
// <copyright file="IGenericClientHttp.cs" company="OP.Prueba.Application">
//     Copyright (c) . All rights reserved.
// </copyright>
// <summary></summary>
// ***********************************************************************

namespace OP.Prueba.Application.Interfaces
{
    /// <summary>
    /// Interface IGenericClientHttp
    /// </summary>
    public interface IGenericClientHttpService
    {
        /// <summary>
        /// Gets the request asynchronous.
        /// </summary>
        /// <typeparam name="TOut">The type of the t out.</typeparam>
        /// <param name="uri">The URI.</param>
        /// <param name="cancellationToken">The cancellation token.</param>
        /// <param name="jwtToken">The JWT token.</param>
        /// <returns>Task&lt;TOut&gt;.</returns>
        Task<TOut> GetRequestAsync<TOut>(string url, CancellationToken cancellationToken,
            string jwtToken, string? keyValue = null, string? keyName = null);
    }
}