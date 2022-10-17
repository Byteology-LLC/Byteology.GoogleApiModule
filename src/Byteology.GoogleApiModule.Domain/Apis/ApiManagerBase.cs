using Byteology.GoogleApiModule.Enums;
using Byteology.GoogleApiModule.Localization;
using Byteology.GoogleApiModule.Options;
using Byteology.GoogleApiModule.Settings;
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
using Volo.Abp.Settings;
using Volo.Abp.Users;

namespace Byteology.GoogleApiModule.Apis
{
    public class ApiManagerBase : DomainService, ITransientDependency
    {
        public readonly IStringLocalizer<GoogleApiModuleResource> Localizer;
        private readonly IServiceProvider _serviceProvider;
        //public readonly string APIKey;
        public IObjectMapper ObjectMapper;
        public ICurrentUser CurrentUser;
        private EndPointType maps;

        protected GoogleApiModuleSettingsManager SettingsManager { get; }
        protected GoogleApiModuleSettingsDto Settings { get; }


        public ApiManagerBase(IStringLocalizer<GoogleApiModuleResource> localizer, IServiceProvider serviceProvider, ICurrentUser currentUser,
            IObjectMapper objectMapper, GoogleApiModuleSettingsManager settingsManager, EndPointType? type = null)
        {
            Localizer = localizer;
            CurrentUser = currentUser;

            Settings = Task.Run(async () => await settingsManager.GetAsync()).Result;

            _serviceProvider = serviceProvider;
            ObjectMapper = objectMapper;
            SettingsManager = settingsManager;
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
                    apiKey = string.IsNullOrWhiteSpace(Settings.MapsApiKey) ? Settings.ApiKey : Settings.MapsApiKey;
                    break;
                case EndPointType.Places:
                    apiKey = string.IsNullOrWhiteSpace(Settings.PlacesApiKey) ? Settings.ApiKey : Settings.PlacesApiKey;
                    break;
                case EndPointType.Search:
                    apiKey = string.IsNullOrWhiteSpace(Settings.SearchApiKey) ? Settings.ApiKey : Settings.SearchApiKey;
                    break;
                case EndPointType.Translate:
                    apiKey = string.IsNullOrWhiteSpace(Settings.TranslateApiKey) ? Settings.ApiKey : Settings.TranslateApiKey;
                    break;
                default:
                    apiKey = Settings.ApiKey;
                    break;
            }

            if (string.IsNullOrEmpty(apiKey))
                throw new UserFriendlyException(Localizer["Error:MissingApiKey"]);
            else
                return apiKey;
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
