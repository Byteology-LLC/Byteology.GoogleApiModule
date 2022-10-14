﻿using Byteology.GoogleApiModule.Enums;
using Byteology.GoogleApiModule.Localization;
using Byteology.GoogleApiModule.Options;
using GoogleApi.Entities.Common.Enums;
using GoogleApi.Entities.Interfaces;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Localization;
using Microsoft.Extensions.Options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Volo.Abp;
using Volo.Abp.DependencyInjection;
using Volo.Abp.Domain.Services;
using Volo.Abp.ObjectMapping;
using Volo.Abp.Users;

namespace Byteology.GoogleApiModule.Apis
{
    public class ApiManagerBase : DomainService, ITransientDependency
    {
        public readonly GoogleApiModuleOptions Options;
        public readonly IStringLocalizer<GoogleApiModuleResource> Localizer;
        private readonly IServiceProvider _serviceProvider;
        public readonly string APIKey;
        public IObjectMapper ObjectMapper;
        public ICurrentUser CurrentUser;

        public ApiManagerBase(IOptions<GoogleApiModuleOptions> options, IStringLocalizer<GoogleApiModuleResource> localizer, IServiceProvider serviceProvider, ICurrentUser currentUser, IObjectMapper objectMapper, EndPointType? type = null)
        {
            Options = options.Value;
            Localizer = localizer;
            CurrentUser = currentUser;
            APIKey = GetApiKey(type);

            _serviceProvider = serviceProvider;
            ObjectMapper = objectMapper;
        }

        /// <summary>
        /// Pulls the API key associated with the given endpoints, otherwise pulls the generic api key. If neither are set, throws an exception.
        /// </summary>
        /// <param name="type"></param>
        /// <returns></returns>
        /// <exception cref="UserFriendlyException"></exception>
        private string GetApiKey(EndPointType? type = null)
        {
            string apiKey = null;

            switch (type)
            {
                case EndPointType.Maps:
                    apiKey = string.IsNullOrWhiteSpace(Options.MapsApiKey) ? Options.APIKey : Options.MapsApiKey;
                    break;
                case EndPointType.Places:
                    apiKey = string.IsNullOrWhiteSpace(Options.PlacesApiKey) ? Options.APIKey : Options.PlacesApiKey;
                    break;
                case EndPointType.Search:
                    apiKey = string.IsNullOrWhiteSpace(Options.SearchApiKey) ? Options.APIKey : Options.SearchApiKey;
                    break;
                case EndPointType.Translate:
                    apiKey = string.IsNullOrWhiteSpace(Options.TranslateApiKey) ? Options.APIKey : Options.TranslateApiKey;
                    break;
                default:
                    apiKey = Options.APIKey;
                    break;
            }

            if (string.IsNullOrEmpty(apiKey))
                throw new UserFriendlyException(Localizer["Error:MissingApiKey"]);
            else
                return apiKey;
        }


        /// <summary>
        /// This method will throw an exception if the RequireGranularPermissions option is set to true and the user has not been granted the correct permission.
        /// </summary>
        /// <param name="permissionName"></param>
        /// <returns></returns>
        protected async Task<bool> CheckAuthorizationAsync(string permissionName)
        {
            if (Options.RequireGranularPermissions)
            {
                //
            }

            if (Options.RequireAuthentication)
            {

                try
                {
                    return CurrentUser.IsAuthenticated;
                }
                catch (Exception)
                {
                    throw new UserFriendlyException(Localizer["Error:UnableToValidateAuthentication"]);
                }
            }

            return true;
        }


        /// <summary>
        /// Will throw an UserFriendlyException if the response status isn't Ok.
        /// </summary>
        /// <param name="response"></param>
        /// <exception cref="UserFriendlyException"></exception>
        protected void CheckResponse(IResponse response)
        {
            if (response.Status != Status.Ok)
            {
                var msgTemplate = $"GoogleApi:Status:{response.Status.GetValueOrDefault(Status.Undefined)}";
                throw new UserFriendlyException(Localizer[msgTemplate].Value, details: response.RawJson);
            }
        }

        ///// <summary>
        ///// Gets a CancellationToken from the HttpContext if one is available. Otherwise it defaults to CancellationToken.None.
        ///// </summary>
        ///// <returns></returns>
        //protected CancellationToken GetCancellationToken()
        //{
        //    var cancellationToken = CancellationToken.None;

        //    if (HttpContextAccessor != null && HttpContextAccessor?.HttpContext != null)
        //    {
        //        cancellationToken = HttpContextAccessor.HttpContext.RequestAborted;
        //    }

        //    return cancellationToken;
        //}

        /// <summary>
        /// Gets the session token from HttpContext if available, otherwise returns the Id of the current user.
        /// </summary>
        /// <returns></returns>
        protected string GetSessionToken()
        {
            var sessionToken = CurrentUser?.Id?.ToString();

            return sessionToken;
        }
    }
}